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

    private SerialPort? _serialPort;
    private readonly object _sync = new();
    private readonly Dictionary<string, int> _settingIndexCache = new(StringComparer.OrdinalIgnoreCase);

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

        var serial = new SerialPort(portName, baudRate)
        {
            ReadTimeout = 2000,
            WriteTimeout = 2000,
            DtrEnable = false,
            RtsEnable = false,
        };

        serial.Open();
        try
        {
            lock (_sync)
            {
                _serialPort = serial;
                ProbeInav();
            }
        }
        catch
        {
            try
            {
                serial.Dispose();
            }
            catch
            {
                // Ignore cleanup exceptions.
            }
            lock (_sync)
            {
                _serialPort = null;
            }
            throw;
        }
    }

    public void Disconnect()
    {
        lock (_sync)
        {
            if (_serialPort is null)
            {
                return;
            }

            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
            }
            finally
            {
                _serialPort.Dispose();
                _serialPort = null;
            }
        }
    }

    public AttitudeSample ReadAttitude(double timeoutSeconds = 1.0)
    {
        lock (_sync)
        {
            var payload = Request(MspAttitude, timeoutSeconds);
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
    }

    public int GetSettingInt(string settingName, double timeoutSeconds = 0.8)
    {
        lock (_sync)
        {
            var index = SettingIndex(settingName, timeoutSeconds);
            var payload = RequestWithPayload(Msp2CommonSetting, SettingKeyPayload(index), timeoutSeconds);
            if (payload.Length == 0)
            {
                throw new InvalidOperationException($"INAV setting '{settingName}' returned an empty payload.");
            }
            return PayloadToUnsignedInt(payload);
        }
    }

    public int SetSettingInt(string settingName, int value, double timeoutSeconds = 0.8)
    {
        lock (_sync)
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
    }

    public void SaveSettings(double timeoutSeconds = 1.2)
    {
        lock (_sync)
        {
            _ = Request(MspEepromWrite, timeoutSeconds);
        }
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

    private byte[] Request(int commandId, double timeoutSeconds)
    {
        return RequestWithPayload(commandId, Array.Empty<byte>(), timeoutSeconds);
    }

    private byte[] RequestWithPayload(int commandId, byte[] payload, double timeoutSeconds)
    {
        var serial = RequireOpenPort();
        var request = MspV2Request(commandId, payload);
        serial.Write(request, 0, request.Length);
        serial.BaseStream.Flush();
        return ReadResponse(commandId, timeoutSeconds);
    }

    private int SettingIndex(string settingName, double timeoutSeconds)
    {
        var key = settingName.Trim().ToLowerInvariant();
        if (_settingIndexCache.TryGetValue(key, out var cached))
        {
            return cached;
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

    private byte[] ReadResponse(int expectedCommand, double timeoutSeconds)
    {
        var serial = RequireOpenPort();
        var deadline = DateTime.UtcNow.AddSeconds(Math.Max(0.1, timeoutSeconds));

        while (DateTime.UtcNow < deadline)
        {
            if (ReadExact(1, 0.25)[0] != (byte)'$')
            {
                continue;
            }

            var header = ReadExact(2, 0.25);

            if (header[0] == (byte)'M' && (header[1] == (byte)'>' || header[1] == (byte)'!'))
            {
                var sizeAndCmd = ReadExact(2, 0.25);
                var payloadSize = sizeAndCmd[0];
                var cmd = sizeAndCmd[1];
                var payload = ReadExact(payloadSize, 0.4);
                var checksum = ReadExact(1, 0.15)[0];

                var calculated = payloadSize ^ cmd;
                foreach (var b in payload)
                {
                    calculated ^= b;
                }

                if ((byte)calculated == checksum && cmd == expectedCommand)
                {
                    return payload;
                }

                continue;
            }

            if (header[0] == (byte)'X' && (header[1] == (byte)'>' || header[1] == (byte)'!'))
            {
                var frameHeader = ReadExact(5, 0.25);
                var cmd = frameHeader[1] | (frameHeader[2] << 8);
                var payloadSize = frameHeader[3] | (frameHeader[4] << 8);
                var payload = ReadExact(payloadSize, 0.5);
                var checksum = ReadExact(1, 0.15)[0];
                var calculated = Crc8DvbS2(frameHeader.Concat(payload).ToArray());

                if (calculated == checksum && cmd == expectedCommand)
                {
                    return payload;
                }

                continue;
            }
        }

        throw new TimeoutException($"Timed out waiting for MSP command {expectedCommand} on {serial.PortName}");
    }

    private byte[] ReadExact(int count, double timeoutSeconds)
    {
        var serial = RequireOpenPort();
        var deadline = DateTime.UtcNow.AddSeconds(Math.Max(0.05, timeoutSeconds));
        var outBuffer = new byte[count];
        var offset = 0;

        while (offset < count && DateTime.UtcNow < deadline)
        {
            var read = serial.Read(outBuffer, offset, count - offset);
            if (read > 0)
            {
                offset += read;
            }
        }

        if (offset != count)
        {
            throw new TimeoutException($"Timed out reading {count} serial byte(s).");
        }

        return outBuffer;
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

    private SerialPort RequireOpenPort()
    {
        if (_serialPort is null || !_serialPort.IsOpen)
        {
            throw new InvalidOperationException("FC USB serial port is not connected.");
        }
        return _serialPort;
    }

    public void Dispose()
    {
        Disconnect();
    }
}
