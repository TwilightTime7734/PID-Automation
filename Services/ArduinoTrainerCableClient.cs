using System.IO.Ports;
using System.Diagnostics;

namespace DronePidTuningAssistant.WinForms.Services;

public sealed class ArduinoTrainerCableClient : IDisposable
{
    private const byte TrainerCableBeginCommand = 62;
    private const byte TrainerCableEndCommand = 63;
    private const byte TrainerCableSetChannelCommand = 64;
    private const byte TrainerCableSetChannelsCommand = 65;
    private const byte TrainerCableCenterCommand = 66;
    private const byte TrainerCableStatusCommand = 67;
    private const byte TrainerCableSetPinCommand = 68;
    private const byte StopAllReportsCommand = 15;

    private const byte TrainerCableStatusReport = 23;
    private static readonly HashSet<int> AllowedPins = new() { 3, 5, 6, 9, 10, 11 };
    private readonly object _sync = new();
    private SerialPort? _serial;

    public bool IsConnected => _serial?.IsOpen == true;
    public string? PortName => _serial?.PortName;
    public int BaudRate => _serial?.BaudRate ?? 0;

    public void Connect(string portName, int baudRate)
    {
        Disconnect();

        var serial = new SerialPort(portName, baudRate)
        {
            ReadTimeout = 1200,
            WriteTimeout = 1200,
            DtrEnable = true,
            RtsEnable = true,
        };

        serial.Open();
        Thread.Sleep(2400);
        try
        {
            serial.DiscardInBuffer();
            serial.DiscardOutBuffer();
        }
        catch
        {
            // Ignore non-fatal flush issues.
        }
        // Mirror Python client startup behavior:
        // give the sketch a moment, then stop background reports before request/response traffic.
        Thread.Sleep(200);
        try
        {
            var packet = new byte[] { 1, StopAllReportsCommand };
            serial.Write(packet, 0, packet.Length);
            serial.BaseStream.Flush();
        }
        catch
        {
            // Non-fatal; continue and let command/response path decide.
        }

        lock (_sync)
        {
            _serial = serial;
        }
    }

    public void Disconnect()
    {
        lock (_sync)
        {
            if (_serial is null)
            {
                return;
            }

            try
            {
                if (_serial.IsOpen)
                {
                    _serial.Close();
                }
            }
            finally
            {
                _serial.Dispose();
                _serial = null;
            }
        }
    }

    public TrainerCableStatus Begin()
    {
        lock (_sync)
        {
            SendCommand(TrainerCableBeginCommand);
            return GetStatusCore(2.0);
        }
    }

    public TrainerCableStatus End()
    {
        lock (_sync)
        {
            SendCommand(TrainerCableEndCommand);
            return GetStatusCore(2.0);
        }
    }

    public void SetChannelPulseUs(int channel, int valueUs)
    {
        if (channel < 1 || channel > 8)
        {
            throw new ArgumentOutOfRangeException(nameof(channel), "Trainer channel must be 1..8.");
        }

        var clamped = Math.Max(0, Math.Min(65535, valueUs));
        lock (_sync)
        {
            SendCommand(TrainerCableSetChannelCommand, new byte[]
            {
                (byte)channel,
                (byte)(clamped >> 8),
                (byte)(clamped & 0xFF),
            });
        }
    }

    public void SetChannelsPulseUs(IReadOnlyList<int> valuesUs)
    {
        if (valuesUs.Count != 8)
        {
            throw new ArgumentException("Trainer cable requires exactly 8 channel values.", nameof(valuesUs));
        }

        var payload = new byte[16];
        for (var i = 0; i < 8; i++)
        {
            var clamped = Math.Max(0, Math.Min(65535, valuesUs[i]));
            payload[i * 2] = (byte)(clamped >> 8);
            payload[(i * 2) + 1] = (byte)(clamped & 0xFF);
        }

        lock (_sync)
        {
            SendCommand(TrainerCableSetChannelsCommand, payload);
        }
    }

    public void Center()
    {
        lock (_sync)
        {
            SendCommand(TrainerCableCenterCommand);
        }
    }

    public TrainerCableStatus SetPin(int pin)
    {
        if (!AllowedPins.Contains(pin))
        {
            throw new ArgumentOutOfRangeException(nameof(pin), "Supported trainer pins: 3, 5, 6, 9, 10, 11.");
        }

        lock (_sync)
        {
            SendCommand(TrainerCableSetPinCommand, new[] { (byte)pin });
            return GetStatusCore(2.0);
        }
    }

    public TrainerCableStatus GetStatus(double timeoutSeconds = 2.0)
    {
        lock (_sync)
        {
            return GetStatusCore(timeoutSeconds);
        }
    }

    private TrainerCableStatus GetStatusCore(double timeoutSeconds)
    {
        byte[] payload;
        TimeoutException? lastTimeout = null;
        for (var attempt = 0; attempt < 2; attempt++)
        {
            try
            {
                // Drop stale packets before a fresh status request.
                try
                {
                    var serial = RequireOpenPort();
                    serial.DiscardInBuffer();
                }
                catch
                {
                    // Ignore discard failures and continue.
                }

                SendCommand(TrainerCableStatusCommand);
                payload = ReadReportPayload(TrainerCableStatusReport, timeoutSeconds);
                goto ParsePayload;
            }
            catch (TimeoutException ex)
            {
                lastTimeout = ex;
                Thread.Sleep(250);
            }
        }

        throw lastTimeout ?? new TimeoutException($"Timed out waiting for trainer report {TrainerCableStatusReport}.");

    ParsePayload:
        if (payload.Length != 7)
        {
            var hint = payload.Length == 76
                ? "Detected legacy 76-byte payload. Upload wired trainer-cable firmware (Telemetrix4UnoR4SerialUSB)."
                : "Unexpected payload shape from Arduino trainer firmware.";
            throw new InvalidOperationException($"Invalid trainer status payload length: {payload.Length}. {hint}");
        }

        var frameUs = (payload[3] << 8) + payload[4];
        var pulseUs = (payload[5] << 8) + payload[6];
        return new TrainerCableStatus(
            payload[0] != 0,
            payload[1],
            payload[2],
            frameUs,
            pulseUs);
    }

    private void SendCommand(byte commandId, byte[]? payload = null)
    {
        var serial = RequireOpenPort();
        payload ??= Array.Empty<byte>();
        var packet = new byte[2 + payload.Length];
        packet[0] = (byte)(1 + payload.Length);
        packet[1] = commandId;
        if (payload.Length > 0)
        {
            Buffer.BlockCopy(payload, 0, packet, 2, payload.Length);
        }
        // Send packet to Arduino trainer cable
        serial.Write(packet, 0, packet.Length);
        serial.BaseStream.Flush();
    }

    private byte[] ReadReportPayload(byte reportId, double timeoutSeconds)
    {
        var serial = RequireOpenPort();
        var timeoutAt = DateTime.UtcNow.AddSeconds(Math.Max(0.1, timeoutSeconds));
        while (DateTime.UtcNow < timeoutAt)
        {
            var remainingMs = (int)Math.Max(50, (timeoutAt - DateTime.UtcNow).TotalMilliseconds);
            serial.ReadTimeout = remainingMs;

            int lengthByte;
            try
            {
                lengthByte = serial.ReadByte();
            }
            catch (TimeoutException)
            {
                break;
            }

            if (lengthByte <= 0)
            {
                continue;
            }

            var packetLength = lengthByte;
            var packet = new byte[packetLength];
            var offset = 0;
            while (offset < packetLength)
            {
                var read = serial.Read(packet, offset, packetLength - offset);
                if (read <= 0)
                {
                    break;
                }
                offset += read;
            }
            if (offset != packetLength)
            {
                continue;
            }
            if (packet[0] != reportId)
            {
                continue;
            }
            return packet[1..];
        }

        throw new TimeoutException($"Timed out waiting for trainer report {reportId}.");
    }

    private SerialPort RequireOpenPort()
    {
        if (_serial is null || !_serial.IsOpen)
        {
            throw new InvalidOperationException("Arduino trainer-cable serial port is not connected.");
        }
        return _serial;
    }

    public void Dispose()
    {
        Disconnect();
    }
}

public readonly record struct TrainerCableStatus(
    bool Enabled,
    int OutputPin,
    int ChannelCount,
    int FrameUs,
    int PulseUs);
