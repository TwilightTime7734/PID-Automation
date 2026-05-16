using System.ComponentModel;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Management;
using DronePidTuningAssistant.WinForms.Models;
using DronePidTuningAssistant.WinForms.Services;

namespace DronePidTuningAssistant.WinForms;

public sealed partial class MainForm : Form
{
    private enum ControlPath
    {
        None = 0,
        FcDirect = 1,
        ArduinoTransmitter = 2,
    }

    private const int DefaultSerialBaud = 115200;
    private int _fcBaudRate = DefaultSerialBaud;
    private int _arduinoBaudRate = DefaultSerialBaud;
    private readonly LayoutSettingsService _settingsService = new();
    private readonly SerialPortService _serialPortService = new();
    private readonly List<TuningRunRecord> _tuningRuns = new();
    private bool _channelTestRunning;
    private bool _arduinoConnected;
    private System.Windows.Forms.Timer? _telemetryTimer;
    private bool _startupScanInProgress;
    private string? _activeAxis;
    private int _rollIteration;
    private int _pitchIteration;
    private PidAdjustmentRecommendation? _pendingRecommendation;

    public MainForm()
    {
        InitializeComponent();

        if (IsInDesignMode())
        {
            return;
        }

        Shown += async (_, _) => await DiscoverPortsOnStartupAsync();
        cboPort.SelectedIndexChanged += (_, _) => UpdateSerialConnectionUi();
        cboArduinoPort.SelectedIndexChanged += (_, _) => UpdateSerialConnectionUi();
        cboBaud.SelectedIndexChanged += (_, _) => OnFcBaudChanged();
        cboArduinoBaud.SelectedIndexChanged += (_, _) => OnArduinoBaudChanged();
        RefreshPortList();
        LoadChannelMapping();
        InitializeTelemetry();
        InitializePidWorkflow();
        UpdateSerialConnectionUi();
    }

    private async Task DiscoverPortsOnStartupAsync()
    {
        _startupScanInProgress = true;
        SetFcStatus("Startup scan in progress...");
        SetArduinoStatus("Arduino not connected.");
        UpdateSerialConnectionUi();

        try
        {
            var result = await Task.Run(() =>
            {
                var available = _serialPortService.GetAvailablePorts().ToList();
                var responsive = available.Where(IsPortResponsive).ToList();
                var source = responsive.Count > 0 ? responsive : available;
                var friendlyByPort = GetPortFriendlyNames();

                string? fcConnectedPort = null;
                var fcCandidates = source
                    .OrderByDescending(p => friendlyByPort.TryGetValue(p, out var n) && IsLikelyFcPort(n))
                    .ThenBy(p => p, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                foreach (var candidate in fcCandidates.Take(Math.Min(2, fcCandidates.Count)))
                {
                    try
                    {
                        _serialPortService.Connect(candidate, _fcBaudRate);
                        fcConnectedPort = candidate;
                        break;
                    }
                    catch
                    {
                        // Try next FC candidate.
                    }
                }

                string? arduinoPort = null;
                var arduinoPreferred = source
                    .Where(p => !string.Equals(p, fcConnectedPort, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(p => friendlyByPort.TryGetValue(p, out var n) && IsLikelyArduinoPort(n))
                    .ThenBy(p => p, StringComparer.OrdinalIgnoreCase)
                    .ToList();

                foreach (var candidate in arduinoPreferred)
                {
                    if (TryOpenPort(candidate))
                    {
                        arduinoPort = candidate;
                        break;
                    }
                }

                return (source, fcConnectedPort, arduinoPort);
            });

            PopulatePortCombos(result.source);

            if (!string.IsNullOrWhiteSpace(result.fcConnectedPort) && cboPort.Items.Contains(result.fcConnectedPort))
            {
                cboPort.SelectedItem = result.fcConnectedPort;
            }
            else if (cboPort.Items.Count > 0 && cboPort.SelectedIndex < 0)
            {
                cboPort.SelectedIndex = 0;
            }

            if (!string.IsNullOrWhiteSpace(result.arduinoPort) && cboArduinoPort.Items.Contains(result.arduinoPort))
            {
                cboArduinoPort.SelectedItem = result.arduinoPort;
                _arduinoConnected = true;
            }
            else
            {
                _arduinoConnected = false;
                if (cboArduinoPort.Items.Count > 0 && cboArduinoPort.SelectedIndex < 0)
                {
                    cboArduinoPort.SelectedIndex = 0;
                }
            }

            if (result.source.Count == 0)
            {
                SetFcStatus("FC not connected.");
                SetArduinoStatus("Arduino not connected.");
            }
            else if (!string.IsNullOrWhiteSpace(result.fcConnectedPort))
            {
                SetFcStatus($"Startup: FC on {result.fcConnectedPort}@{_fcBaudRate}.");
                SetArduinoStatus(string.IsNullOrWhiteSpace(result.arduinoPort)
                    ? "Arduino not connected."
                    : $"Arduino connected: {result.arduinoPort}@{_arduinoBaudRate}");
            }
            else
            {
                SetFcStatus("FC not connected.");
                SetArduinoStatus(string.IsNullOrWhiteSpace(result.arduinoPort)
                    ? "Arduino not connected."
                    : $"Arduino connected: {result.arduinoPort}@{_arduinoBaudRate}");
            }
        }
        finally
        {
            _startupScanInProgress = false;
            UpdateSerialConnectionUi();
        }
    }

    private static bool IsLikelyArduinoPort(string friendlyName)
    {
        if (string.IsNullOrWhiteSpace(friendlyName))
        {
            return false;
        }

        var text = friendlyName.ToLowerInvariant();
        return text.Contains("arduino")
            || text.Contains("ch340")
            || text.Contains("cp210")
            || text.Contains("usb serial")
            || text.Contains("wchusbserial")
            || text.Contains("silicon labs");
    }

    private static bool IsLikelyFcPort(string friendlyName)
    {
        if (string.IsNullOrWhiteSpace(friendlyName))
        {
            return false;
        }

        var text = friendlyName.ToLowerInvariant();
        return text.Contains("stm32")
            || text.Contains("vcp")
            || text.Contains("virtual com")
            || text.Contains("betaflight")
            || text.Contains("inav")
            || text.Contains("flight controller");
    }

    private static Dictionary<string, string> GetPortFriendlyNames()
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'");
            using var objects = searcher.Get();
            foreach (ManagementObject obj in objects)
            {
                var name = obj["Name"]?.ToString();
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                var start = name.LastIndexOf("(COM", StringComparison.OrdinalIgnoreCase);
                if (start < 0)
                {
                    continue;
                }
                var end = name.IndexOf(')', start);
                if (end < 0)
                {
                    continue;
                }

                var port = name.Substring(start + 1, end - start - 1).Trim();
                if (!string.IsNullOrWhiteSpace(port))
                {
                    result[port] = name;
                }
            }
        }
        catch
        {
            // Ignore WMI failures and fall back to generic probing.
        }
        return result;
    }

    private void LoadChannelMapping()
    {
        var mapping = _settingsService.LoadMapping();
        SetComboValue(cboCH1, mapping.Roll);
        SetComboValue(cboCH2, mapping.Pitch);
        SetComboValue(cboCH3, mapping.Throttle);
        SetComboValue(cboCH4, mapping.Yaw);
        lblFCStatus.Text = "Loaded channel mapping.";
    }

    private void SaveChannelMapping()
    {
        var mapping = new ChannelMapping
        {
            Roll = GetComboValue(cboCH1, "A"),
            Pitch = GetComboValue(cboCH2, "E"),
            Throttle = GetComboValue(cboCH3, "T"),
            Yaw = GetComboValue(cboCH4, "R"),
        };
        _settingsService.SaveMapping(mapping);
        lblFCStatus.Text = $"Saved mapping: Roll {mapping.Roll}, Pitch {mapping.Pitch}, Throttle {mapping.Throttle}, Yaw {mapping.Yaw}";
    }

    private static string GetComboValue(ComboBox combo, string fallback)
    {
        return combo.SelectedItem?.ToString() ?? fallback;
    }

    private static void SetComboValue(ComboBox combo, string value)
    {
        if (combo.Items.Contains(value))
        {
            combo.SelectedItem = value;
        }
        else if (combo.Items.Count > 0)
        {
            combo.SelectedIndex = 0;
        }
    }

    private void ApplyMappingPreset(string pattern)
    {
        if (string.IsNullOrWhiteSpace(pattern) || pattern.Length != 4)
        {
            return;
        }

        SetComboValue(cboCH1, pattern[0].ToString());
        SetComboValue(cboCH2, pattern[1].ToString());
        SetComboValue(cboCH3, pattern[2].ToString());
        SetComboValue(cboCH4, pattern[3].ToString());
        lblFCStatus.Text = $"Applied mapping preset: {pattern}";
    }

    private void RefreshPortList()
    {
        var ports = _serialPortService.GetAvailablePorts();
        PopulatePortCombos(ports);
        lblFCStatus.Text = ports.Count == 0
            ? "No serial ports detected."
            : $"Detected {ports.Count} serial port(s).";
        UpdateSerialConnectionUi();
    }

    private void PopulatePortCombos(IReadOnlyList<string> ports)
    {
        var previousSelection = cboPort.SelectedItem as string;
        var previousArduinoSelection = cboArduinoPort.SelectedItem as string;

        cboPort.Items.Clear();
        cboArduinoPort.Items.Clear();
        foreach (var port in ports)
        {
            cboPort.Items.Add(port);
            cboArduinoPort.Items.Add(port);
        }

        if (previousSelection is not null && cboPort.Items.Contains(previousSelection))
        {
            cboPort.SelectedItem = previousSelection;
        }
        else if (cboPort.Items.Count > 0)
        {
            cboPort.SelectedIndex = 0;
        }
        if (previousArduinoSelection is not null && cboArduinoPort.Items.Contains(previousArduinoSelection))
        {
            cboArduinoPort.SelectedItem = previousArduinoSelection;
        }
        else if (cboArduinoPort.Items.Count > 0)
        {
            cboArduinoPort.SelectedIndex = 0;
        }
    }

    private static bool IsPortResponsive(string portName)
    {
        return TryOpenPort(portName);
    }

    private static bool TryOpenPort(string portName)
    {
        try
        {
            using var probe = new SerialPort(portName, DefaultSerialBaud)
            {
                ReadTimeout = 150,
                WriteTimeout = 150,
                DtrEnable = false,
                RtsEnable = false,
            };
            probe.Open();
            return probe.IsOpen;
        }
        catch
        {
            return false;
        }
    }

    private void ConnectUsb()
    {
        if (cboPort.SelectedItem is not string portName || string.IsNullOrWhiteSpace(portName))
        {
            MessageBox.Show(this, "Select an FC USB serial port first.", "Missing port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var baudRate = _fcBaudRate;

        try
        {
            _serialPortService.Connect(portName, baudRate);
            lblFCStatus.Text = $"Connected FC USB: {portName}@{baudRate}";
            UpdateSerialConnectionUi();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblFCStatus.Text = "FC USB connection failed.";
            UpdateSerialConnectionUi();
        }
    }

    private void DisconnectUsb()
    {
        StopTelemetryLoop("FC not connected.");
        _serialPortService.Disconnect();
        UpdateSerialConnectionUi();
    }

    private void ConnectArduinoUsb()
    {
        if (cboArduinoPort.SelectedItem is not string portName || string.IsNullOrWhiteSpace(portName))
        {
            MessageBox.Show(this, "Select an Arduino serial port first.", "Missing port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var baudRate = _arduinoBaudRate;

        _arduinoConnected = true;
        SetArduinoStatus($"Arduino connected: {portName}@{baudRate}");
        UpdateSerialConnectionUi();
    }

    private void DisconnectArduinoUsb()
    {
        _arduinoConnected = false;
        SetArduinoStatus("Arduino not connected.");
        UpdateSerialConnectionUi();
    }

    private void UpdateSerialConnectionUi()
    {
        var fcConnected = _serialPortService.IsConnected;
        var fcPortSelected = cboPort.SelectedItem is string fcPort && !string.IsNullOrWhiteSpace(fcPort);
        btnFcConnect.Enabled = !_startupScanInProgress && !fcConnected && fcPortSelected;
        btnFcDisconnect.Enabled = fcConnected;

        var arduinoPortSelected = cboArduinoPort.SelectedItem is string arduinoPort && !string.IsNullOrWhiteSpace(arduinoPort);
        btnArduinoConnect.Enabled = !_startupScanInProgress && !_arduinoConnected && arduinoPortSelected;
        btnArduinoDisconnect.Enabled = _arduinoConnected;
        UpdateWorkflowUiState();
    }

    private static int GetSelectedBaud(ComboBox combo, int fallback)
    {
        var raw = combo.SelectedItem?.ToString();
        return int.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : fallback;
    }

    private void OnFcBaudChanged()
    {
        var selected = GetSelectedBaud(cboBaud, DefaultSerialBaud);
        if (selected == _fcBaudRate)
        {
            return;
        }

        _fcBaudRate = selected;
        if (_serialPortService.IsConnected && cboPort.SelectedItem is string port && !string.IsNullOrWhiteSpace(port))
        {
            try
            {
                StopTelemetryLoop("Live telemetry stopped for FC baud change.");
                _serialPortService.Disconnect();
                _serialPortService.Connect(port, _fcBaudRate);
                lblFCStatus.Text = $"FC baud changed: {port}@{_fcBaudRate}";
            }
            catch (Exception ex)
            {
                lblFCStatus.Text = $"FC baud change failed: {ex.Message}";
            }
        }
        else
        {
            lblFCStatus.Text = $"FC baud set to {_fcBaudRate}.";
        }
    }

    private void OnArduinoBaudChanged()
    {
        var selected = GetSelectedBaud(cboArduinoBaud, DefaultSerialBaud);
        if (selected == _arduinoBaudRate)
        {
            return;
        }

        _arduinoBaudRate = selected;
        if (_arduinoConnected && cboArduinoPort.SelectedItem is string port && !string.IsNullOrWhiteSpace(port))
        {
            SetArduinoStatus($"Arduino connected: {port}@{_arduinoBaudRate}");
        }
        else
        {
            SetArduinoStatus($"Arduino not connected. Baud set to {_arduinoBaudRate}.");
        }
    }

    private void SetFcStatus(string text)
    {
        lblFCStatus.Text = string.Empty;
        lblFCStatus.Text = text;
    }

    private void SetArduinoStatus(string text)
    {
        lblArduinoStatus.Text = string.Empty;
        lblArduinoStatus.Text = text;
    }

    private ControlPath GetActiveControlPath()
    {
        if (_arduinoConnected)
        {
            return ControlPath.ArduinoTransmitter;
        }
        if (_serialPortService.IsConnected)
        {
            return ControlPath.FcDirect;
        }
        return ControlPath.None;
    }

    private static string DescribeControlPath(ControlPath path)
    {
        return path switch
        {
            ControlPath.ArduinoTransmitter => "Arduino TX",
            ControlPath.FcDirect => "FC Direct",
            _ => "Not connected",
        };
    }

    private void UpdateWorkflowUiState()
    {
        var fcConnected = _serialPortService.IsConnected;
        var telemetryRunning = _telemetryTimer?.Enabled == true;
        var activePath = GetActiveControlPath();
        var canRunChannelTests = activePath != ControlPath.None;

        if (!_channelTestRunning)
        {
            btnTestRoll.Enabled = canRunChannelTests;
            btnTestPitch.Enabled = canRunChannelTests;
            btnTestThrottle.Enabled = canRunChannelTests;
            lblChannelVisual.Text = $"Path: {DescribeControlPath(activePath)}";
        }

        btnTelemetryStart.Enabled = fcConnected && !telemetryRunning;
        btnTelemetryStop.Enabled = fcConnected && telemetryRunning;

        var pidEnabled = fcConnected && !_channelTestRunning;
        SetPidButtonsEnabled(pidEnabled);
    }

    private async Task RunChannelTestAsync(string control)
    {
        if (_channelTestRunning)
        {
            return;
        }
        var activePath = GetActiveControlPath();
        if (activePath == ControlPath.None)
        {
            MessageBox.Show(this, "Connect FC USB or Arduino before running channel tests.", "Channel test unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        control = control.ToLowerInvariant();
        if (control == "throttle")
        {
            var proceed = MessageBox.Show(
                this,
                "This will briefly raise the mapped throttle channel.\nOnly run this while the drone is disarmed.\n\nContinue?",
                "Throttle channel test",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (proceed != DialogResult.Yes)
            {
                return;
            }
        }

        _channelTestRunning = true;
        SetChannelTestButtonsEnabled(false);

        var settleMs = (int)(nudSettleSec.Value * 1000m);
        var baselineMs = (int)(nudBaselineSec.Value * 1000m);
        var targetDeg = (double)nudTargetDeg.Value;
        var throttleUs = (int)nudThrottleUs.Value;
        var mapping = new ChannelMapping
        {
            Roll = GetComboValue(cboCH1, "A"),
            Pitch = GetComboValue(cboCH2, "E"),
            Throttle = GetComboValue(cboCH3, "T"),
        };
        var channelCode = control switch
        {
            "roll" => mapping.Roll,
            "pitch" => mapping.Pitch,
            "throttle" => mapping.Throttle,
            _ => "-",
        };

        try
        {
            lblFCStatus.Text = $"Testing {control} on {channelCode} via {DescribeControlPath(activePath)}...";

            if (settleMs > 0)
            {
                SetChannelTestVisual("Settle", control == "throttle" ? 1000 : 1500, 0.0, 0.0);
                await Task.Delay(settleMs);
            }

            if (control == "throttle")
            {
                SetChannelTestVisual("Throttle up", throttleUs, 0.0, 0.0);
                await Task.Delay(800);
                SetChannelTestVisual("Throttle low", 1000, 0.0, 0.0);
            }
            else if (control == "roll")
            {
                SetChannelTestVisual("Roll right", 1700, targetDeg, 0.0);
                await Task.Delay(650);
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
                if (baselineMs > 0)
                {
                    await Task.Delay(baselineMs);
                }
                SetChannelTestVisual("Roll left", 1300, -targetDeg, 0.0);
                await Task.Delay(650);
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
            }
            else if (control == "pitch")
            {
                SetChannelTestVisual("Pitch forward", 1700, 0.0, targetDeg);
                await Task.Delay(650);
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
                if (baselineMs > 0)
                {
                    await Task.Delay(baselineMs);
                }
                SetChannelTestVisual("Pitch back", 1300, 0.0, -targetDeg);
                await Task.Delay(650);
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
            }

            if (baselineMs > 0)
            {
                await Task.Delay(baselineMs);
            }

            SetChannelTestVisual("Idle", control == "throttle" ? 1000 : 1500, 0.0, 0.0);
            lblFCStatus.Text = $"Completed {control} channel test on {channelCode} via {DescribeControlPath(activePath)}.";
        }
        finally
        {
            _channelTestRunning = false;
            UpdateWorkflowUiState();
        }
    }

    private void SetChannelTestVisual(string status, int pulseUs, double rollDeg, double pitchDeg)
    {
        lblChannelVisual.Text = status;
        lblChannelValue.Text = $"{pulseUs} us";
        lblRollAngle.Text = $"{rollDeg:F1} deg";
        lblPitchAngle.Text = $"{pitchDeg:F1} deg";
    }

    private void SetChannelTestButtonsEnabled(bool enabled)
    {
        btnTestRoll.Enabled = enabled;
        btnTestPitch.Enabled = enabled;
        btnTestThrottle.Enabled = enabled;
    }

    private void InitializeTelemetry()
    {
        _telemetryTimer = new System.Windows.Forms.Timer
        {
            Interval = 250,
        };
        _telemetryTimer.Tick += (_, _) => PollTelemetrySample();
        UpdateWorkflowUiState();
    }

    private void PollTelemetrySample()
    {
        if (!_serialPortService.IsConnected)
        {
            StopTelemetryLoop("Telemetry stopped: FC USB not connected.");
            return;
        }
        try
        {
            var attitude = _serialPortService.ReadAttitude(1.0);
            ApplyTelemetryVisual(attitude.RollDeg, attitude.PitchDeg, attitude.YawDeg);
            lblRollAngle.Text = $"{attitude.RollDeg.ToString("F1", CultureInfo.InvariantCulture)} deg";
            lblPitchAngle.Text = $"{attitude.PitchDeg.ToString("F1", CultureInfo.InvariantCulture)} deg";
        }
        catch (Exception ex)
        {
            StopTelemetryLoop($"Telemetry read failed: {ex.Message}");
        }
    }

    private void ApplyTelemetryVisual(double roll, double pitch, double yaw)
    {
        lblTelemetryRoll.Text = $"{roll:F1} deg";
        lblTelemetryPitch.Text = $"{pitch:F1} deg";
        lblTelemetryYaw.Text = $"{yaw:F1} deg";
    }

    private void StartTelemetryLoop()
    {
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB before starting live telemetry.", "Telemetry unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _telemetryTimer?.Start();
        UpdateWorkflowUiState();
        lblFCStatus.Text = "Live telemetry started.";
    }

    private void StopTelemetryLoop(string statusText = "Live telemetry stopped.")
    {
        _telemetryTimer?.Stop();
        UpdateWorkflowUiState();
        lblFCStatus.Text = statusText;
    }

    private void TelemetrySnapshot()
    {
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB before requesting telemetry snapshot.", "Telemetry unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        PollTelemetrySample();
        lblFCStatus.Text = "Telemetry snapshot updated.";
    }

    private void InitializePidWorkflow()
    {
        lblActiveAxis.Text = "N/A";
        txtPidRecommendation.Text = "Run Roll or Pitch to generate a recommendation.";
        UpdatePidSnapshotPanel(null, null, null, null, null, null);
        cmbManualAxis.Items.Clear();
        cmbManualAxis.Items.AddRange(new object[] { "Roll", "Pitch" });
        cmbManualAxis.SelectedIndex = 0;
        cmbManualGain.Items.Clear();
        cmbManualGain.Items.AddRange(new object[] { "P", "I", "D" });
        cmbManualGain.SelectedIndex = 0;
        cmbManualPoints.Items.Clear();
        cmbManualPoints.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
        cmbManualPoints.SelectedIndex = 0;
        UpdateWorkflowUiState();
    }

    private async Task RunPidTuningRoundAsync(string axis, bool resetAxis)
    {
        if (_channelTestRunning)
        {
            return;
        }
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB first.", "PID workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        axis = axis.ToLowerInvariant();
        if (resetAxis || _activeAxis != axis)
        {
            _activeAxis = axis;
        }

        var iteration = axis == "roll" ? ++_rollIteration : ++_pitchIteration;
        lblActiveAxis.Text = $"{axis.ToUpperInvariant()} round {iteration}";
        lblFCStatus.Text = $"Running {axis} tuning round {iteration}...";
        SetPidButtonsEnabled(false);
        SetChannelTestButtonsEnabled(false);

        try
        {
            var before = await SampleAxisNoiseAsync(axis, sampleCount: 14, sampleDelayMs: 70);
            await RunChannelTestAsync(axis);
            var after = await SampleAxisNoiseAsync(axis, sampleCount: 14, sampleDelayMs: 70);

            var score = (before + after) / 2.0;
            var recommendation = BuildRecommendation(axis, score);
            _pendingRecommendation = recommendation;

            txtPidRecommendation.Text = recommendation.Message;
            AppendTuningRun(axis, iteration, score, recommendation);
            lblFCStatus.Text = $"Completed {axis} round {iteration}. Score {score:F2}.";
        }
        catch (Exception ex)
        {
            lblFCStatus.Text = $"PID workflow failed: {ex.Message}";
        }
        finally
        {
            SetPidButtonsEnabled(true);
            SetChannelTestButtonsEnabled(true);
        }
    }

    private async Task<double> SampleAxisNoiseAsync(string axis, int sampleCount, int sampleDelayMs)
    {
        var values = new List<double>(sampleCount);
        for (var i = 0; i < sampleCount; i++)
        {
            var attitude = _serialPortService.ReadAttitude(1.0);
            values.Add(axis == "roll" ? attitude.RollDeg : attitude.PitchDeg);
            await Task.Delay(sampleDelayMs);
        }

        if (values.Count == 0)
        {
            return 999;
        }

        var mean = values.Average();
        var variance = values.Sum(v => Math.Pow(v - mean, 2)) / values.Count;
        return Math.Sqrt(variance);
    }

    private static PidAdjustmentRecommendation BuildRecommendation(string axis, double score)
    {
        if (score >= 6.0)
        {
            return new PidAdjustmentRecommendation(axis, "P", "decrease", 2,
                $"Recommendation: decrease {axis} P by 2 points. High noise score ({score:F2}) suggests oscillation risk.");
        }
        if (score >= 3.0)
        {
            return new PidAdjustmentRecommendation(axis, "D", "increase", 1,
                $"Recommendation: increase {axis} D by 1 point. Moderate noise score ({score:F2}) suggests damping can improve response.");
        }
        return new PidAdjustmentRecommendation(axis, "none", "none", 0,
            $"Recommendation: axis looks stable (score {score:F2}). No PID change required.");
    }

    private void AppendTuningRun(string axis, int iteration, double score, PidAdjustmentRecommendation recommendation)
    {
        var runNumber = _tuningRuns.Count + 1;
        var record = new TuningRunRecord(runNumber, axis, iteration, score, recommendation.Message);
        _tuningRuns.Add(record);

        var item = new ListViewItem(runNumber.ToString(CultureInfo.InvariantCulture));
        item.SubItems.Add(axis.ToUpperInvariant());
        item.SubItems.Add(score.ToString("F2", CultureInfo.InvariantCulture));
        item.SubItems.Add(recommendation.Message);
        lvTuningRuns.Items.Add(item);
        lvTuningRuns.EnsureVisible(lvTuningRuns.Items.Count - 1);

        pnlScoreChart.Invalidate();
    }

    private void SetPidButtonsEnabled(bool enabled)
    {
        btnTuneRoll.Enabled = enabled;
        btnTunePitch.Enabled = enabled;
        btnRetestAxis.Enabled = enabled;
        btnFinishAxis.Enabled = enabled;
        btnApplyRecommendedPid.Enabled = enabled;
        btnManualPidMinus.Enabled = enabled;
        btnManualPidPlus.Enabled = enabled;
        btnReadFcPid.Enabled = enabled;
        btnSaveFcPid.Enabled = enabled;
        cmbManualAxis.Enabled = enabled;
        cmbManualGain.Enabled = enabled;
        cmbManualPoints.Enabled = enabled;
    }

    private void ApplyRecommendedPid()
    {
        if (_pendingRecommendation is null || _pendingRecommendation.Points <= 0)
        {
            MessageBox.Show(this, "No pending PID adjustment to apply.", "PID workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB first.", "PID workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            var settingName = ResolvePidSettingName(_pendingRecommendation.Axis, _pendingRecommendation.Gain);
            var current = _serialPortService.GetSettingInt(settingName);
            var delta = _pendingRecommendation.Direction.Equals("increase", StringComparison.OrdinalIgnoreCase)
                ? _pendingRecommendation.Points
                : -_pendingRecommendation.Points;
            var target = Math.Max(0, Math.Min(255, current + delta));
            var applied = _serialPortService.SetSettingInt(settingName, target);
            _serialPortService.SaveSettings();

            lblFCStatus.Text = $"Applied PID: {settingName} {current} -> {applied} and saved.";
            txtPidRecommendation.Text += $"{Environment.NewLine}{Environment.NewLine}Applied to FC: {settingName} {current} -> {applied}.";
            RefreshPidSnapshotFromFc();
        }
        catch (Exception ex)
        {
            lblFCStatus.Text = $"PID write failed: {ex.Message}";
            MessageBox.Show(this, ex.Message, "PID write failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SendManualPidAdjustment(string direction)
    {
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB first.", "Manual PID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var axis = (cmbManualAxis.SelectedItem?.ToString() ?? "Roll").Trim().ToLowerInvariant();
        var gain = (cmbManualGain.SelectedItem?.ToString() ?? "P").Trim().ToLowerInvariant();
        var pointsRaw = cmbManualPoints.SelectedItem?.ToString() ?? "1";
        if (!int.TryParse(pointsRaw, out var points))
        {
            points = 1;
        }
        points = Math.Max(1, Math.Min(5, points));

        try
        {
            var settingName = ResolvePidSettingName(axis, gain);
            var current = _serialPortService.GetSettingInt(settingName);
            var delta = direction.Equals("increase", StringComparison.OrdinalIgnoreCase) ? points : -points;
            var target = Math.Max(0, Math.Min(255, current + delta));
            var applied = _serialPortService.SetSettingInt(settingName, target);
            lblFCStatus.Text = $"Manual PID: {settingName} {current} -> {applied}";
            RefreshPidSnapshotFromFc();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Manual PID write failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblFCStatus.Text = "Manual PID write failed.";
        }
    }

    private void ReadFcPidValues()
    {
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB first.", "Read FC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            var rp = _serialPortService.GetSettingInt("mc_p_roll");
            var ri = _serialPortService.GetSettingInt("mc_i_roll");
            var rd = _serialPortService.GetSettingInt("mc_d_roll");
            var pp = _serialPortService.GetSettingInt("mc_p_pitch");
            var pi = _serialPortService.GetSettingInt("mc_i_pitch");
            var pd = _serialPortService.GetSettingInt("mc_d_pitch");
            UpdatePidSnapshotPanel(rp, ri, rd, pp, pi, pd);
            txtPidRecommendation.Text =
                $"FC PID values:{Environment.NewLine}" +
                $"Roll P/I/D: {rp}/{ri}/{rd}{Environment.NewLine}" +
                $"Pitch P/I/D: {pp}/{pi}/{pd}";
            lblFCStatus.Text = "Read PID values from FC.";
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Read FC failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblFCStatus.Text = "Read FC failed.";
        }
    }

    private void SaveFcPidValues()
    {
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB first.", "Save FC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            _serialPortService.SaveSettings();
            lblFCStatus.Text = "Saved current PID values to FC.";
            RefreshPidSnapshotFromFc();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Save FC failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblFCStatus.Text = "Save FC failed.";
        }
    }

    private static string ResolvePidSettingName(string axis, string gain)
    {
        var axisKey = axis.Trim().ToLowerInvariant();
        var gainKey = gain.Trim().ToLowerInvariant();
        return (axisKey, gainKey) switch
        {
            ("roll", "p") => "mc_p_roll",
            ("roll", "i") => "mc_i_roll",
            ("roll", "d") => "mc_d_roll",
            ("pitch", "p") => "mc_p_pitch",
            ("pitch", "i") => "mc_i_pitch",
            ("pitch", "d") => "mc_d_pitch",
            _ => throw new InvalidOperationException($"Unsupported PID selector axis='{axis}' gain='{gain}'."),
        };
    }

    private void RefreshPidSnapshotFromFc()
    {
        if (!_serialPortService.IsConnected)
        {
            UpdatePidSnapshotPanel(null, null, null, null, null, null);
            return;
        }
        try
        {
            var rp = _serialPortService.GetSettingInt("mc_p_roll");
            var ri = _serialPortService.GetSettingInt("mc_i_roll");
            var rd = _serialPortService.GetSettingInt("mc_d_roll");
            var pp = _serialPortService.GetSettingInt("mc_p_pitch");
            var pi = _serialPortService.GetSettingInt("mc_i_pitch");
            var pd = _serialPortService.GetSettingInt("mc_d_pitch");
            UpdatePidSnapshotPanel(rp, ri, rd, pp, pi, pd);
        }
        catch
        {
            UpdatePidSnapshotPanel(null, null, null, null, null, null);
        }
    }

    private void UpdatePidSnapshotPanel(int? rollP, int? rollI, int? rollD, int? pitchP, int? pitchI, int? pitchD)
    {
        var rp = rollP?.ToString(CultureInfo.InvariantCulture) ?? "--";
        var ri = rollI?.ToString(CultureInfo.InvariantCulture) ?? "--";
        var rd = rollD?.ToString(CultureInfo.InvariantCulture) ?? "--";
        var pp = pitchP?.ToString(CultureInfo.InvariantCulture) ?? "--";
        var pi = pitchI?.ToString(CultureInfo.InvariantCulture) ?? "--";
        var pd = pitchD?.ToString(CultureInfo.InvariantCulture) ?? "--";
        txtPidValues.Text = $"Roll P/I/D: {rp}/{ri}/{rd}{Environment.NewLine}Pitch P/I/D: {pp}/{pi}/{pd}";
    }

    private void RetestActiveAxis()
    {
        if (string.IsNullOrWhiteSpace(_activeAxis))
        {
            MessageBox.Show(this, "Run Roll or Pitch first.", "PID workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        _ = RunPidTuningRoundAsync(_activeAxis, resetAxis: false);
    }

    private void FinishActiveAxis()
    {
        _activeAxis = null;
        lblActiveAxis.Text = "N/A";
        txtPidRecommendation.Text = "Axis tuning stopped. Run Roll or Pitch to continue.";
        lblFCStatus.Text = "Axis tuning finished.";
    }

    private void DrawScoreChart(Graphics g, Rectangle bounds)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);

        if (_tuningRuns.Count < 2)
        {
            using var textBrush = new SolidBrush(Color.DimGray);
            g.DrawString("Run at least 2 rounds to chart score trend.", Font, textBrush, bounds.X + 8, bounds.Y + 8);
            return;
        }

        var left = bounds.Left + 30;
        var top = bounds.Top + 8;
        var width = bounds.Width - 40;
        var height = bounds.Height - 24;

        var minScore = _tuningRuns.Min(r => r.Score);
        var maxScore = _tuningRuns.Max(r => r.Score);
        if (Math.Abs(maxScore - minScore) < 0.001)
        {
            maxScore = minScore + 1.0;
        }

        using var axisPen = new Pen(Color.Silver, 1);
        g.DrawRectangle(axisPen, left, top, width, height);

        var points = new PointF[_tuningRuns.Count];
        for (var i = 0; i < _tuningRuns.Count; i++)
        {
            var x = left + (width * i / (float)(_tuningRuns.Count - 1));
            var normalized = (_tuningRuns[i].Score - minScore) / (maxScore - minScore);
            var y = top + height - (float)(normalized * height);
            points[i] = new PointF(x, y);
        }

        using var linePen = new Pen(Color.FromArgb(30, 120, 200), 2);
        g.DrawLines(linePen, points);
        using var pointBrush = new SolidBrush(Color.FromArgb(15, 90, 170));
        foreach (var point in points)
        {
            g.FillEllipse(pointBrush, point.X - 3, point.Y - 3, 6, 6);
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _telemetryTimer?.Stop();
        _telemetryTimer?.Dispose();
        _arduinoConnected = false;
        _serialPortService.Dispose();

        // Do not persist layout on exit; always use designer layout on next startup.
        base.OnFormClosed(e);
    }

    private static bool IsInDesignMode()
    {
        return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
    }

    private void btnRefreshPorts_Click(object sender, EventArgs e) => RefreshPortList();
    private void btnConnect_Click(object sender, EventArgs e) => ConnectUsb();
    private void btnDisconnect_Click(object sender, EventArgs e) => DisconnectUsb();
    private void btnApplyMapping_Click(object sender, EventArgs e) => SaveChannelMapping();
    private void btnPresetAetr_Click(object sender, EventArgs e) => ApplyMappingPreset("AETR");
    private void btnPresetRtae_Click(object sender, EventArgs e) => ApplyMappingPreset("RTAE");
    private void btnPresetReat_Click(object sender, EventArgs e) => ApplyMappingPreset("REAT");
    private void btnArduinoConnect_Click(object sender, EventArgs e) => ConnectArduinoUsb();
    private void btnArduinoDisconnect_Click(object sender, EventArgs e) => DisconnectArduinoUsb();
    private async void btnTestRoll_Click(object sender, EventArgs e) => await RunChannelTestAsync("roll");
    private async void btnTestPitch_Click(object sender, EventArgs e) => await RunChannelTestAsync("pitch");
    private async void btnTestThrottle_Click(object sender, EventArgs e) => await RunChannelTestAsync("throttle");
    private void btnTelemetryStart_Click(object sender, EventArgs e) => StartTelemetryLoop();
    private void btnTelemetryStop_Click(object sender, EventArgs e) => StopTelemetryLoop();
    private void btnTelemetrySnapshot_Click(object sender, EventArgs e) => TelemetrySnapshot();
    private void btnTuneRoll_Click(object sender, EventArgs e) => _ = RunPidTuningRoundAsync("roll", resetAxis: true);
    private void btnTunePitch_Click(object sender, EventArgs e) => _ = RunPidTuningRoundAsync("pitch", resetAxis: true);
    private void btnRetestAxis_Click(object sender, EventArgs e) => RetestActiveAxis();
    private void btnFinishAxis_Click(object sender, EventArgs e) => FinishActiveAxis();
    private void btnApplyRecommendedPid_Click(object sender, EventArgs e) => ApplyRecommendedPid();
    private void btnManualPidMinus_Click(object sender, EventArgs e) => SendManualPidAdjustment("decrease");
    private void btnManualPidPlus_Click(object sender, EventArgs e) => SendManualPidAdjustment("increase");
    private void btnReadFcPid_Click(object sender, EventArgs e) => ReadFcPidValues();
    private void btnSaveFcPid_Click(object sender, EventArgs e) => SaveFcPidValues();
    private void pnlScoreChart_Paint(object sender, PaintEventArgs e) => DrawScoreChart(e.Graphics, pnlScoreChart.ClientRectangle);

    private sealed record TuningRunRecord(int RunNumber, string Axis, int Iteration, double Score, string Recommendation);
    private sealed record PidAdjustmentRecommendation(string Axis, string Gain, string Direction, int Points, string Message);
}
