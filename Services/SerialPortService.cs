using System.Collections.Concurrent;
using System.IO.Ports;
using DronePidTuningAssistant.WinForms.Models;

namespace DronePidTuningAssistant.WinForms.Services;

public sealed class SerialPortService : IDisposable
{
    private const int MspApiVersion = 1;
    private const int MspFcVariant = 2;
    private const int MspFcVersion = 3;
    private const int MspAttitude = 108;
    private const int Msp2CommonSetting = 0x1003;
    private const int Msp2CommonSetSetting = 0x1004;
    private const int Msp2CommonSettingInfo = 0x1007;
    private const int MspEepromWrite = 250;

    private readonly object _sync = new();
    private readonly Dictionary<string, int> _settingIndexCache = new(StringComparer.OrdinalIgnoreCase);
    private readonly HashSet<string> _missingSettingCache = new(StringComparer.OrdinalIgnoreCase);

    private SerialPort? _serialPort;
    private CancellationTokenSource? _ioCts;
    private Thread? _readerThread;
    private Thread? _writerThread;
    private Thread? _attitudePollThread;
    private BlockingCollection<MspRequest>? _requestQueue;

    private readonly object _inFlightSync = new();
    private MspRequest? _inFlight;

    private readonly object _attitudeSync = new();
    private AttitudeSample? _latestAttitude;

    private string? _lastPortName;
    private int _lastBaudRate;

    public bool IsConnected => _serialPort?.IsOpen == true;
    public string? ConnectedPortName => _serialPort?.PortName;
    public int ConnectedBaudRate => _serialPort?.BaudRate ?? 0;

    public IReadOnlyList<string> GetAvailablePorts()
    {
        return SerialPort.GetPortNames()
            .OrderBy(name => name, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    public void Connect(string portName, int baudRate)
    {
        Disconnect();

        _lastPortName = portName;
        _lastBaudRate = baudRate;

        var serial = new SerialPort(portName, baudRate)
        {
            ReadTimeout = 100,
            WriteTimeout = 1500,
            DtrEnable = true,
            RtsEnable = true,
        };

        serial.Open();
        Thread.Sleep(250);
        serial.DiscardInBuffer();
        serial.DiscardOutBuffer();
        Thread.Sleep(100);

        _settingIndexCache.Clear();
        _missingSettingCache.Clear();

        var cts = new CancellationTokenSource();
        var queue = new BlockingCollection<MspRequest>(new ConcurrentQueue<MspRequest>());

        lock (_sync)
        {
            _serialPort = serial;
            _ioCts = cts;
            _requestQueue = queue;

            _readerThread = new Thread(ReadLoop) { IsBackground = true, Name = "FC-MSP-Reader" };
            _writerThread = new Thread(WriteLoop) { IsBackground = true, Name = "FC-MSP-Writer" };

            _readerThread.Start();
            _writerThread.Start();
        }

        try
        {
            ProbeInav();
            StartAttitudePolling();
        }
        catch
        {
            Disconnect();
            throw;
        }
    }

    public void Disconnect()
    {
        CancellationTokenSource? cts;
        BlockingCollection<MspRequest>? queue;
        Thread? reader;
        Thread? writer;
        Thread? poller;
        SerialPort? serial;

        lock (_sync)
        {
            cts = _ioCts;
            queue = _requestQueue;
            reader = _readerThread;
            writer = _writerThread;
            poller = _attitudePollThread;
            serial = _serialPort;

            _ioCts = null;
            _requestQueue = null;
            _readerThread = null;
            _writerThread = null;
            _attitudePollThread = null;
            _serialPort = null;

            lock (_inFlightSync)
            {
                _inFlight?.Fail(new TimeoutException("MSP transport disconnected."));
                _inFlight = null;
            }
        }

        try { cts?.Cancel(); } catch { }
        try { queue?.CompleteAdding(); } catch { }

        JoinThread(poller, 300);
        JoinThread(writer, 500);
        JoinThread(reader, 500);

        if (queue is not null)
        {
            while (queue.TryTake(out var pending))
            {
                pending.Fail(new TimeoutException("MSP transport disconnected."));
            }
            queue.Dispose();
        }

        if (serial is not null)
        {
            try
            {
                if (serial.IsOpen)
                {
                    serial.Close();
                }
            }
            finally
            {
                serial.Dispose();
            }
        }

        cts?.Dispose();

        lock (_attitudeSync)
        {
            _latestAttitude = null;
        }
    }

    public AttitudeSample ReadAttitude(double timeoutSeconds = 1.0)
    {
        lock (_attitudeSync)
        {
            if (_latestAttitude is { } cached && (DateTime.Now - cached.TimestampLocal).TotalSeconds <= 0.8)
            {
                return cached;
            }
        }

        var payload = Request(MspAttitude, timeoutSeconds);
        return ParseAttitudePayload(payload);
    }

    public int GetSettingInt(string settingName, double timeoutSeconds = 0.8)
    {
        var index = SettingIndex(settingName, timeoutSeconds);
        var payload = RequestWithPayload(Msp2CommonSetting, SettingKeyPayload(index), timeoutSeconds);
        if (payload.Length == 0)
        {
            throw new InvalidOperationException($"INAV setting '{settingName}' returned an empty payload.");
        }
        return PayloadToUnsignedInt(payload);
    }

    public int SetSettingInt(string settingName, int value, double timeoutSeconds = 0.8)
    {
        var key = settingName.Trim().ToLowerInvariant();
        var index = SettingIndex(key, timeoutSeconds);

        var info = RequestWithPayload(Msp2CommonSettingInfo, SettingKeyPayload(index), timeoutSeconds).ToArray();
        var nameEnd = Array.IndexOf(info, (byte)0);
        if (nameEnd < 0)
        {
            throw new InvalidOperationException($"Invalid setting info payload for '{key}'.");
        }

        var currentPayload = RequestWithPayload(Msp2CommonSetting, SettingKeyPayload(index), timeoutSeconds);
        var valueSize = currentPayload.Length;
        if (valueSize is not (1 or 2 or 4))
        {
            throw new InvalidOperationException($"Unsupported setting width for '{key}': {valueSize} byte(s).");
        }

        var clamped = Math.Max(0, Math.Min(255, value));
        var encoded = UnsignedIntToPayload(clamped, valueSize);
        Array.Copy(encoded, 0, info, nameEnd + 1, valueSize);

        _ = RequestWithPayload(Msp2CommonSetSetting, info, timeoutSeconds);
        return GetSettingInt(key, timeoutSeconds);
    }

    public void SaveSettings(double timeoutSeconds = 1.2)
    {
        _ = Request(MspEepromWrite, timeoutSeconds);
    }

    private void ProbeInav()
    {
        var variant = Request(MspFcVariant, 1.2);
        if (variant.Length < 4)
        {
            throw new InvalidOperationException("MSP did not return FC variant.");
        }

        var variantText = System.Text.Encoding.ASCII.GetString(variant, 0, 4).ToUpperInvariant();
        if (variantText != "INAV")
        {
            throw new InvalidOperationException($"MSP variant '{variantText}' is not INAV.");
        }

        _ = Request(MspApiVersion, 1.0);
        _ = Request(MspFcVersion, 1.0);
    }

    private void StartAttitudePolling()
    {
        lock (_sync)
        {
            if (_ioCts is null || _attitudePollThread is not null)
            {
                return;
            }

            _attitudePollThread = new Thread(AttitudePollLoop)
            {
                IsBackground = true,
                Name = "FC-MSP-Attitude-Poll"
            };
            _attitudePollThread.Start();
        }
    }

    private void AttitudePollLoop()
    {
        while (true)
        {
            CancellationToken token;
            lock (_sync)
            {
                if (_ioCts is null)
                {
                    return;
                }
                token = _ioCts.Token;
            }

            if (token.IsCancellationRequested)
            {
                return;
            }

            try
            {
                _ = Request(MspAttitude, 0.25);
            }
            catch
            {
                // Non-fatal: foreground requests will surface real failures.
            }

            if (token.WaitHandle.WaitOne(45))
            {
                return;
            }
        }
    }

    private byte[] Request(int commandId, double timeoutSeconds)
    {
        return RequestWithPayload(commandId, Array.Empty<byte>(), timeoutSeconds);
    }

    private byte[] RequestWithPayload(int commandId, byte[] payload, double timeoutSeconds)
    {
        var queue = _requestQueue ?? throw new InvalidOperationException("FC USB serial transport is not connected.");
        var request = new MspRequest(commandId, payload, TimeSpan.FromSeconds(Math.Max(0.1, timeoutSeconds)));

        if (!queue.TryAdd(request, 250))
        {
            throw new TimeoutException($"Timed out queueing MSP command {commandId}.");
        }

        if (!request.Done.Wait(request.Timeout + TimeSpan.FromMilliseconds(100)))
        {
            throw new TimeoutException($"Timed out waiting for MSP command {commandId}.");
        }

        if (request.Error is not null)
        {
            throw request.Error;
        }

        return request.Response ?? throw new TimeoutException($"MSP command {commandId} returned no payload.");
    }

    private void WriteLoop()
    {
        while (true)
        {
            BlockingCollection<MspRequest>? queue;
            SerialPort? serial;
            CancellationToken token;
            lock (_sync)
            {
                queue = _requestQueue;
                serial = _serialPort;
                token = _ioCts?.Token ?? CancellationToken.None;
            }

            if (queue is null || serial is null || token.IsCancellationRequested)
            {
                return;
            }

            MspRequest request;
            try
            {
                request = queue.Take(token);
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (InvalidOperationException)
            {
                return;
            }

            try
            {
                var packet = MspV2Request(request.CommandId, request.Payload);
                lock (_inFlightSync)
                {
                    _inFlight = request;
                }

                serial.Write(packet, 0, packet.Length);
                serial.BaseStream.Flush();

                if (!request.Done.Wait(request.Timeout))
                {
                    request.Fail(new TimeoutException($"Timed out waiting for MSP command {request.CommandId} response."));
                }
            }
            catch (Exception ex)
            {
                request.Fail(ex);
            }
            finally
            {
                lock (_inFlightSync)
                {
                    if (ReferenceEquals(_inFlight, request))
                    {
                        _inFlight = null;
                    }
                }
            }
        }
    }

    private void ReadLoop()
    {
        var parser = new MspStreamParser();

        while (true)
        {
            SerialPort? serial;
            CancellationToken token;
            lock (_sync)
            {
                serial = _serialPort;
                token = _ioCts?.Token ?? CancellationToken.None;
            }

            if (serial is null || token.IsCancellationRequested)
            {
                return;
            }

            try
            {
                var b = serial.ReadByte();
                if (b < 0)
                {
                    continue;
                }

                if (parser.Push((byte)b, out var frame))
                {
                    OnFrame(frame);
                }
            }
            catch (TimeoutException)
            {
                continue;
            }
            catch
            {
                return;
            }
        }
    }

    private void OnFrame(MspFrame frame)
    {
        if (!frame.IsValid)
        {
            return;
        }

        if (frame.CommandId == MspAttitude && frame.Payload.Length >= 6)
        {
            lock (_attitudeSync)
            {
                _latestAttitude = ParseAttitudePayload(frame.Payload);
            }
        }

        MspRequest? current;
        lock (_inFlightSync)
        {
            current = _inFlight;
        }

        if (current is not null && current.CommandId == frame.CommandId && !current.Done.IsSet)
        {
            current.Succeed(frame.Payload);
        }
    }

    private static AttitudeSample ParseAttitudePayload(byte[] payload)
    {
        if (payload.Length < 6)
        {
            throw new InvalidOperationException($"Invalid MSP_ATTITUDE payload length: {payload.Length}");
        }

        var rollRaw = BitConverter.ToInt16(payload, 0);
        var pitchRaw = BitConverter.ToInt16(payload, 2);
        var yawRaw = BitConverter.ToInt16(payload, 4);

        return new AttitudeSample
        {
            RollDeg = rollRaw / 10.0,
            PitchDeg = pitchRaw / 10.0,
            YawDeg = yawRaw,
            TimestampLocal = DateTime.Now,
        };
    }

    private int SettingIndex(string settingName, double timeoutSeconds)
    {
        var key = settingName.Trim().ToLowerInvariant();
        if (_settingIndexCache.TryGetValue(key, out var cached))
        {
            return cached;
        }
        if (_missingSettingCache.Contains(key))
        {
            throw new KeyNotFoundException($"INAV setting '{settingName}' was not found via MSP2_COMMON_SETTING_INFO.");
        }

        for (var index = 0; index < 4096; index++)
        {
            var payload = RequestWithPayload(Msp2CommonSettingInfo, SettingKeyPayload(index), timeoutSeconds);
            var zero = Array.IndexOf(payload, (byte)0);
            if (zero < 0)
            {
                continue;
            }

            var found = System.Text.Encoding.ASCII.GetString(payload, 0, zero).Trim().ToLowerInvariant();
            if (found == key)
            {
                _settingIndexCache[key] = index;
                return index;
            }
        }

        _missingSettingCache.Add(key);
        throw new KeyNotFoundException($"INAV setting '{settingName}' was not found via MSP2_COMMON_SETTING_INFO.");
    }

    private static byte[] SettingKeyPayload(int index)
    {
        var key = (uint)index << 8;
        return BitConverter.GetBytes(key);
    }

    private static int PayloadToUnsignedInt(byte[] payload)
    {
        return payload.Length switch
        {
            1 => payload[0],
            2 => BitConverter.ToUInt16(payload, 0),
            4 => (int)BitConverter.ToUInt32(payload, 0),
            _ => throw new InvalidOperationException($"Unsupported setting payload width: {payload.Length}."),
        };
    }

    private static byte[] UnsignedIntToPayload(int value, int size)
    {
        return size switch
        {
            1 => new[] { (byte)value },
            2 => BitConverter.GetBytes((ushort)value),
            4 => BitConverter.GetBytes((uint)value),
            _ => throw new InvalidOperationException($"Unsupported setting payload width: {size}."),
        };
    }

    private static byte[] MspV2Request(int commandId, byte[] payload)
    {
        var flags = 0;
        var command = commandId & 0xFFFF;
        var size = payload.Length & 0xFFFF;
        var header = new byte[]
        {
            (byte)flags,
            (byte)(command & 0xFF),
            (byte)((command >> 8) & 0xFF),
            (byte)(size & 0xFF),
            (byte)((size >> 8) & 0xFF),
        };

        var crcData = header.Concat(payload).ToArray();
        var checksum = Crc8DvbS2(crcData);
        return new[] { (byte)'$', (byte)'X', (byte)'<' }
            .Concat(header)
            .Concat(payload)
            .Concat(new[] { checksum })
            .ToArray();
    }

    private static byte Crc8DvbS2(byte[] data)
    {
        byte crc = 0;
        foreach (var value in data)
        {
            crc ^= value;
            for (var i = 0; i < 8; i++)
            {
                if ((crc & 0x80) != 0)
                {
                    crc = (byte)(((crc << 1) ^ 0xD5) & 0xFF);
                }
                else
                {
                    crc = (byte)((crc << 1) & 0xFF);
                }
            }
        }
        return crc;
    }

    private static void JoinThread(Thread? thread, int milliseconds)
    {
        if (thread is null)
        {
            return;
        }
        try
        {
            thread.Join(milliseconds);
        }
        catch
        {
            // Best-effort shutdown only.
        }
    }

    private sealed class MspRequest
    {
        public MspRequest(int commandId, byte[] payload, TimeSpan timeout)
        {
            CommandId = commandId;
            Payload = payload;
            Timeout = timeout;
        }

        public int CommandId { get; }
        public byte[] Payload { get; }
        public TimeSpan Timeout { get; }
        public ManualResetEventSlim Done { get; } = new(false);
        public byte[]? Response { get; private set; }
        public Exception? Error { get; private set; }

        public void Succeed(byte[] payload)
        {
            Response = payload;
            Done.Set();
        }

        public void Fail(Exception ex)
        {
            Error = ex;
            Done.Set();
        }
    }

    private readonly record struct MspFrame(int CommandId, byte[] Payload, bool IsValid);

    private sealed class MspStreamParser
    {
        private enum State
        {
            Idle,
            Proto,
            Dir,
            V1Size,
            V1Cmd,
            V1Payload,
            V1Checksum,
            V2Flag,
            V2CmdLo,
            V2CmdHi,
            V2SizeLo,
            V2SizeHi,
            V2Payload,
            V2Checksum,
        }

        private State _state = State.Idle;
        private bool _isV2;
        private byte _v2Flag;
        private int _cmd;
        private int _size;
        private int _offset;
        private byte[] _payload = Array.Empty<byte>();

        public bool Push(byte value, out MspFrame frame)
        {
            frame = default;

            switch (_state)
            {
                case State.Idle:
                    if (value == (byte)'$')
                    {
                        _state = State.Proto;
                    }
                    return false;

                case State.Proto:
                    if (value == (byte)'M')
                    {
                        _isV2 = false;
                        _state = State.Dir;
                        _cmd = 0;
                        _size = 0;
                        _offset = 0;
                    }
                    else if (value == (byte)'X')
                    {
                        _isV2 = true;
                        _state = State.Dir;
                        _cmd = 0;
                        _size = 0;
                        _offset = 0;
                    }
                    else
                    {
                        _state = State.Idle;
                    }
                    return false;

                case State.Dir:
                    if (value != (byte)'>' && value != (byte)'!' && value != (byte)'<')
                    {
                        _state = State.Idle;
                        return false;
                    }

                    _state = _isV2 ? State.V2Flag : State.V1Size;
                    return false;
            }

            return Advance(value, out frame);
        }

        private bool Advance(byte value, out MspFrame frame)
        {
            frame = default;

            switch (_state)
            {
                case State.V1Size:
                    _size = value;
                    _payload = _size > 0 ? new byte[_size] : Array.Empty<byte>();
                    _offset = 0;
                    _state = State.V1Cmd;
                    return false;

                case State.V1Cmd:
                    _cmd = value;
                    _state = _size > 0 ? State.V1Payload : State.V1Checksum;
                    return false;

                case State.V1Payload:
                    _payload[_offset++] = value;
                    if (_offset >= _size)
                    {
                        _state = State.V1Checksum;
                    }
                    return false;

                case State.V1Checksum:
                {
                    var crc = _size ^ _cmd;
                    for (var i = 0; i < _size; i++)
                    {
                        crc ^= _payload[i];
                    }
                    frame = new MspFrame(_cmd, _payload, (byte)crc == value);
                    _state = State.Idle;
                    return true;
                }

                case State.V2Flag:
                    _v2Flag = value;
                    _state = State.V2CmdLo;
                    return false;

                case State.V2CmdLo:
                    _cmd = value;
                    _state = State.V2CmdHi;
                    return false;

                case State.V2CmdHi:
                    _cmd |= value << 8;
                    _state = State.V2SizeLo;
                    return false;

                case State.V2SizeLo:
                    _size = value;
                    _state = State.V2SizeHi;
                    return false;

                case State.V2SizeHi:
                    _size |= value << 8;
                    _payload = _size > 0 ? new byte[_size] : Array.Empty<byte>();
                    _offset = 0;
                    _state = _size > 0 ? State.V2Payload : State.V2Checksum;
                    return false;

                case State.V2Payload:
                    _payload[_offset++] = value;
                    if (_offset >= _size)
                    {
                        _state = State.V2Checksum;
                    }
                    return false;

                case State.V2Checksum:
                {
                    var crc = Crc8(_v2Flag);
                    crc = Crc8((byte)(_cmd & 0xFF), crc);
                    crc = Crc8((byte)((_cmd >> 8) & 0xFF), crc);
                    crc = Crc8((byte)(_size & 0xFF), crc);
                    crc = Crc8((byte)((_size >> 8) & 0xFF), crc);
                    for (var i = 0; i < _size; i++)
                    {
                        crc = Crc8(_payload[i], crc);
                    }

                    frame = new MspFrame(_cmd, _payload, crc == value);
                    _state = State.Idle;
                    return true;
                }
            }

            _state = State.Idle;
            return false;
        }

        private static byte Crc8(byte value, byte crc = 0)
        {
            crc ^= value;
            for (var i = 0; i < 8; i++)
            {
                if ((crc & 0x80) != 0)
                {
                    crc = (byte)(((crc << 1) ^ 0xD5) & 0xFF);
                }
                else
                {
                    crc = (byte)((crc << 1) & 0xFF);
                }
            }

            return crc;
        }

    }

    public void Dispose()
    {
        Disconnect();
    }
}
