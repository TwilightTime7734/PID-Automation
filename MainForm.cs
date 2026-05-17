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
    private const int DefaultTrainerPin = 3;
    private const double MaxCommandDeg = 45.0;
    private int _fcBaudRate = DefaultSerialBaud;
    private int _arduinoBaudRate = DefaultSerialBaud;
    private readonly LayoutSettingsService _settingsService = new();
    private readonly SerialPortService _serialPortService = new();
    private readonly ArduinoTrainerCableClient _arduinoTrainerClient = new();
    private readonly List<TuningRunRecord> _tuningRuns = new();
    private bool _channelTestRunning;
    private bool _arduinoConnected;
    private bool _startupScanInProgress;
    private string? _activeAxis;
    private int _rollIteration;
    private int _pitchIteration;
    private PidAdjustmentRecommendation? _pendingRecommendation;
    private int _ch1PulseUs = 1500;
    private int _ch2PulseUs = 1500;
    private int _ch3PulseUs = 1000;
    private int _ch4PulseUs = 1500;
    private double _ch1DisplayedPulseUs = 1500;
    private double _ch2DisplayedPulseUs = 1500;
    private double _ch3DisplayedPulseUs = 1000;
    private double _ch4DisplayedPulseUs = 1500;
    private System.Windows.Forms.Timer? _stickAnimationTimer;

    // Stick UI controls for channel test visualizers
    private Panel _pnlLeftStick => pnlLeftStick;
    private Panel _pnlLeftStickIndicator => pnlLeftStickIndicator;
    private Panel _pnlRightStick => pnlRightStick;
    private Panel _pnlRightStickIndicator => pnlRightStickIndicator;

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
        cboTrainerPin.SelectedIndexChanged += (_, _) => OnTrainerPinChanged();
        chkSimulation.CheckedChanged += (_, _) => OnSimulationModeChanged();
        if (cboTrainerPin.Items.Count > 0)
        {
            cboTrainerPin.SelectedItem = DefaultTrainerPin.ToString(CultureInfo.InvariantCulture);
        }
        RefreshPortList();
        LoadChannelMapping();
        cboCH1.SelectedIndexChanged += (_, _) => RefreshStickVisualsFromChannelState();
        cboCH2.SelectedIndexChanged += (_, _) => RefreshStickVisualsFromChannelState();
        cboCH3.SelectedIndexChanged += (_, _) => RefreshStickVisualsFromChannelState();
        cboCH4.SelectedIndexChanged += (_, _) => RefreshStickVisualsFromChannelState();
        InitializePidWorkflow();
        InitializeStickVisuals();
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
                _arduinoConnected = false;
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
                    : $"Arduino port detected: {result.arduinoPort} (not connected)");
            }
            else
            {
                SetFcStatus("FC not connected.");
                SetArduinoStatus(string.IsNullOrWhiteSpace(result.arduinoPort)
                    ? "Arduino not connected."
                    : $"Arduino port detected: {result.arduinoPort} (not connected)");
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

    private void InitializeStickVisuals()
    {
        _stickAnimationTimer = new System.Windows.Forms.Timer
        {
            Interval = 16,
        };
        _stickAnimationTimer.Tick += (_, _) => TickStickAnimation();
        RefreshStickVisualsFromChannelState();
    }

    // pulse expected in microseconds 1000..2000 -> normalize to -1..1
    private static double NormalizePulse(int pulse)
    {
        const double min = 1000.0;
        const double max = 2000.0;
        return Math.Max(-1.0, Math.Min(1.0, (pulse - ((min + max) / 2.0)) / ((max - min) / 2.0)));
    }

    private void UpdateLeftStick(int ch1Pulse, int ch2Pulse)
    {
        if (pnlLeftStick == null || pnlLeftStickIndicator == null) return;
        var nx = NormalizePulse(ch1Pulse);
        var ny = NormalizePulse(ch2Pulse);
        UpdateStickIndicator(pnlLeftStick, pnlLeftStickIndicator, nx, ny);
    }

    private void UpdateRightStick(int ch3Pulse, int ch4Pulse)
    {
        if (pnlRightStick == null || pnlRightStickIndicator == null) return;
        var nx = NormalizePulse(ch3Pulse);
        var ny = NormalizePulse(ch4Pulse);
        UpdateStickIndicator(pnlRightStick, pnlRightStickIndicator, nx, ny);
    }

    private void SetChannelPulseState(int channel, int pulseUs)
    {
        var clamped = Math.Max(1000, Math.Min(2000, pulseUs));
        switch (channel)
        {
            case 1:
                _ch1PulseUs = clamped;
                break;
            case 2:
                _ch2PulseUs = clamped;
                break;
            case 3:
                _ch3PulseUs = clamped;
                break;
            case 4:
                _ch4PulseUs = clamped;
                break;
            default:
                return;
        }

        if (_stickAnimationTimer?.Enabled != true)
        {
            _stickAnimationTimer?.Start();
        }
    }

    private void RefreshStickVisualsFromChannelState()
    {
        // Axis-based visualization so Ch1..Ch4 mapping changes are reflected live.
        // Right stick: Roll (A) X, Pitch (E) Y
        // Left stick:  Yaw (R)  X, Throttle (T) Y
        UpdateRightStick(GetDisplayedPulseForAxisCode("A"), GetDisplayedPulseForAxisCode("E"));
        UpdateLeftStick(GetDisplayedPulseForAxisCode("R"), GetDisplayedPulseForAxisCode("T"));
    }

    private int GetDisplayedPulseForAxisCode(string axisCode)
    {
        if (string.Equals(GetComboValue(cboCH1, "A"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return (int)Math.Round(_ch1DisplayedPulseUs);
        }

        if (string.Equals(GetComboValue(cboCH2, "E"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return (int)Math.Round(_ch2DisplayedPulseUs);
        }

        if (string.Equals(GetComboValue(cboCH3, "T"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return (int)Math.Round(_ch3DisplayedPulseUs);
        }

        if (string.Equals(GetComboValue(cboCH4, "R"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return (int)Math.Round(_ch4DisplayedPulseUs);
        }

        return 1500;
    }

    private void TickStickAnimation()
    {
        const double smoothing = 0.33;
        const double snapThresholdUs = 1.0;

        _ch1DisplayedPulseUs += (_ch1PulseUs - _ch1DisplayedPulseUs) * smoothing;
        _ch2DisplayedPulseUs += (_ch2PulseUs - _ch2DisplayedPulseUs) * smoothing;
        _ch3DisplayedPulseUs += (_ch3PulseUs - _ch3DisplayedPulseUs) * smoothing;
        _ch4DisplayedPulseUs += (_ch4PulseUs - _ch4DisplayedPulseUs) * smoothing;

        var done =
            Math.Abs(_ch1PulseUs - _ch1DisplayedPulseUs) < snapThresholdUs &&
            Math.Abs(_ch2PulseUs - _ch2DisplayedPulseUs) < snapThresholdUs &&
            Math.Abs(_ch3PulseUs - _ch3DisplayedPulseUs) < snapThresholdUs &&
            Math.Abs(_ch4PulseUs - _ch4DisplayedPulseUs) < snapThresholdUs;

        if (done)
        {
            _ch1DisplayedPulseUs = _ch1PulseUs;
            _ch2DisplayedPulseUs = _ch2PulseUs;
            _ch3DisplayedPulseUs = _ch3PulseUs;
            _ch4DisplayedPulseUs = _ch4PulseUs;
            _stickAnimationTimer?.Stop();
        }

        RefreshStickVisualsFromChannelState();
    }

    private static void UpdateStickIndicator(Panel container, Panel indicator, double nx, double ny)
    {
        // nx, ny in [-1,1], map to container interior with padding
        var padding = 6;
        var availableW = Math.Max(0, container.ClientSize.Width - indicator.Width - padding * 2);
        var availableH = Math.Max(0, container.ClientSize.Height - indicator.Height - padding * 2);
        var centerX = padding + (availableW / 2.0);
        var centerY = padding + (availableH / 2.0);
        var x = centerX + (nx * (availableW / 2.0));
        var y = centerY - (ny * (availableH / 2.0)); // invert Y so up is negative
        // ensure within bounds
        x = Math.Max(padding, Math.Min(container.ClientSize.Width - indicator.Width - padding, x));
        y = Math.Max(padding, Math.Min(container.ClientSize.Height - indicator.Height - padding, y));
        indicator.Left = (int)Math.Round(x);
        indicator.Top = (int)Math.Round(y);
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
        RefreshStickVisualsFromChannelState();
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
        RefreshStickVisualsFromChannelState();
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
        RefreshStickVisualsFromChannelState();
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
        _serialPortService.Disconnect();
        UpdateSerialConnectionUi();
    }

    private void ConnectArduinoUsb()
    {
        if (chkSimulation.Checked)
        {
            _arduinoConnected = true;
            SetArduinoStatus("Simulation mode active - no Arduino hardware is being used.");
            CenterArduinoFlightControls();
            UpdateSerialConnectionUi();
            return;
        }

        if (cboArduinoPort.SelectedItem is not string portName || string.IsNullOrWhiteSpace(portName))
        {
            MessageBox.Show(this, "Select an Arduino serial port first.", "Missing port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var baudRate = _arduinoBaudRate;

        try
        {
            _arduinoTrainerClient.Connect(portName, baudRate);
            _ = _arduinoTrainerClient.SetPin(GetSelectedTrainerPin());
            var status = _arduinoTrainerClient.Begin();
            _arduinoConnected = true;
            SetArduinoStatus($"Arduino connected: {portName}@{baudRate} (pin {status.OutputPin})");
            CenterArduinoFlightControls();
            UpdateSerialConnectionUi();
        }
        catch (Exception ex)
        {
            _arduinoConnected = false;
            SetArduinoStatus("Arduino not connected.");
            MessageBox.Show(this, ex.Message, "Arduino connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            UpdateSerialConnectionUi();
        }
    }

    private void DisconnectArduinoUsb()
    {
        if (chkSimulation.Checked)
        {
            _arduinoConnected = false;
            SetArduinoStatus("Simulation mode disconnected.");
            UpdateSerialConnectionUi();
            return;
        }

        try
        {
            if (_arduinoTrainerClient.IsConnected)
            {
                _ = _arduinoTrainerClient.End();
            }
        }
        catch
        {
            // Ignore shutdown packet failures.
        }
        finally
        {
            _arduinoTrainerClient.Disconnect();
            _arduinoConnected = false;
        }
        SetArduinoStatus("Arduino not connected.");
        UpdateSerialConnectionUi();
    }

    private void UpdateSerialConnectionUi()
    {
        var fcConnected = _serialPortService.IsConnected;
        var selectedFcPort = cboPort.SelectedItem as string;
        var fcPortSelected = !string.IsNullOrWhiteSpace(selectedFcPort);
        var fcSelectedIsConnected = fcConnected
            && fcPortSelected
            && string.Equals(_serialPortService.ConnectedPortName, selectedFcPort, StringComparison.OrdinalIgnoreCase);
        btnFcConnect.Enabled = !_startupScanInProgress && fcPortSelected && !fcSelectedIsConnected;
        btnFcDisconnect.Enabled = fcSelectedIsConnected;

        var simulationEnabled = chkSimulation.Checked;
        var arduinoPortSelected = cboArduinoPort.SelectedItem is string arduinoPort && !string.IsNullOrWhiteSpace(arduinoPort);
        var arduinoConnectedNow = _arduinoConnected || _arduinoTrainerClient.IsConnected;
        btnArduinoConnect.Enabled = !_startupScanInProgress && (simulationEnabled || arduinoPortSelected) && !arduinoConnectedNow;
        btnArduinoDisconnect.Enabled = arduinoConnectedNow;
        cboArduinoPort.Enabled = !simulationEnabled;
        cboArduinoBaud.Enabled = !simulationEnabled;
        cboTrainerPin.Enabled = !simulationEnabled;
        UpdateWorkflowUiState();
    }

    private static int GetSelectedBaud(ComboBox combo, int fallback)
    {
        var raw = combo.SelectedItem?.ToString();
        return int.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsed)
            ? parsed
            : fallback;
    }

    private int GetSelectedTrainerPin()
    {
        var raw = cboTrainerPin.SelectedItem?.ToString();
        return int.TryParse(raw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var pin)
            ? pin
            : DefaultTrainerPin;
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
        if (chkSimulation.Checked)
        {
            SetArduinoStatus("Simulation mode active.");
            return;
        }

        var selected = GetSelectedBaud(cboArduinoBaud, DefaultSerialBaud);
        if (selected == _arduinoBaudRate)
        {
            return;
        }

        _arduinoBaudRate = selected;
        if (_arduinoConnected && cboArduinoPort.SelectedItem is string port && !string.IsNullOrWhiteSpace(port))
        {
            try
            {
                _arduinoTrainerClient.Disconnect();
                _arduinoTrainerClient.Connect(port, _arduinoBaudRate);
                _ = _arduinoTrainerClient.SetPin(GetSelectedTrainerPin());
                var status = _arduinoTrainerClient.Begin();
                SetArduinoStatus($"Arduino connected: {port}@{_arduinoBaudRate} (pin {status.OutputPin})");
                CenterArduinoFlightControls();
            }
            catch (Exception ex)
            {
                _arduinoConnected = false;
                SetArduinoStatus($"Arduino not connected. Baud set to {_arduinoBaudRate}.");
                MessageBox.Show(this, ex.Message, "Arduino reconnect failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        else
        {
            SetArduinoStatus($"Arduino not connected. Baud set to {_arduinoBaudRate}.");
        }
        UpdateSerialConnectionUi();
    }

    private void OnTrainerPinChanged()
    {
        if (chkSimulation.Checked)
        {
            return;
        }

        if (!_arduinoConnected || !_arduinoTrainerClient.IsConnected)
        {
            return;
        }

        try
        {
            var status = _arduinoTrainerClient.SetPin(GetSelectedTrainerPin());
            SetArduinoStatus($"Arduino connected: {_arduinoTrainerClient.PortName}@{_arduinoBaudRate} (pin {status.OutputPin})");
            CenterArduinoFlightControls();
        }
        catch (Exception ex)
        {
            SetArduinoStatus($"Trainer pin change failed: {ex.Message}");
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
        var activePath = GetActiveControlPath();
        var canRunChannelTests = _arduinoConnected;

        if (!_channelTestRunning)
        {
            btnTestRoll.Enabled = canRunChannelTests;
            btnTestPitch.Enabled = canRunChannelTests;
            btnTestThrottle.Enabled = canRunChannelTests;
            lblChannelVisual.Text = $"Path: {DescribeControlPath(activePath)}";
        }

        var pidEnabled = fcConnected && !_channelTestRunning;
        SetPidButtonsEnabled(pidEnabled);
    }

    private async Task RunChannelTestAsync(string control)
    {
        if (_channelTestRunning)
        {
            return;
        }

        if (!_arduinoConnected || !_arduinoTrainerClient.IsConnected)
        {
            MessageBox.Show(this, "Connect Arduino before running channel tests.", "Channel test unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse(control, control == "throttle" ? 1000 : 1500);
                }
                SetChannelTestVisual("Settle", control == "throttle" ? 1000 : 1500, 0.0, 0.0);
                await Task.Delay(settleMs);
            }

            if (control == "throttle")
            {
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("throttle", throttleUs);
                }
                SetChannelTestVisual("Throttle up", throttleUs, 0.0, 0.0);
                await Task.Delay(800);
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("throttle", 1000);
                }
                SetChannelTestVisual("Throttle low", 1000, 0.0, 0.0);
            }
            else if (control == "roll")
            {
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("roll", 1700);
                }
                SetChannelTestVisual("Roll right", 1700, targetDeg, 0.0);
                await Task.Delay(650);
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("roll", 1500);
                }
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
                if (baselineMs > 0)
                {
                    await Task.Delay(baselineMs);
                }
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("roll", 1300);
                }
                SetChannelTestVisual("Roll left", 1300, -targetDeg, 0.0);
                await Task.Delay(650);
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("roll", 1500);
                }
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
            }
            else if (control == "pitch")
            {
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("pitch", 1700);
                }
                SetChannelTestVisual("Pitch forward", 1700, 0.0, targetDeg);
                await Task.Delay(650);
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("pitch", 1500);
                }
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
                if (baselineMs > 0)
                {
                    await Task.Delay(baselineMs);
                }
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("pitch", 1300);
                }
                SetChannelTestVisual("Pitch back", 1300, 0.0, -targetDeg);
                await Task.Delay(650);
                if (activePath == ControlPath.ArduinoTransmitter)
                {
                    SetArduinoAxisPulse("pitch", 1500);
                }
                SetChannelTestVisual("Center baseline", 1500, 0.0, 0.0);
            }

            if (baselineMs > 0)
            {
                await Task.Delay(baselineMs);
            }

            if (activePath == ControlPath.ArduinoTransmitter)
            {
                CenterArduinoFlightControls();
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

    private static string AxisCodeForControl(string control)
    {
        return control switch
        {
            "roll" => "A",
            "pitch" => "E",
            "throttle" => "T",
            "yaw" => "R",
            _ => throw new ArgumentOutOfRangeException(nameof(control), $"Unsupported control '{control}'."),
        };
    }

    private int ChannelFromAxisCode(string axisCode)
    {
        if (string.Equals(GetComboValue(cboCH1, "A"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return 1;
        }
        if (string.Equals(GetComboValue(cboCH2, "E"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return 2;
        }
        if (string.Equals(GetComboValue(cboCH3, "T"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return 3;
        }
        if (string.Equals(GetComboValue(cboCH4, "R"), axisCode, StringComparison.OrdinalIgnoreCase))
        {
            return 4;
        }
        throw new InvalidOperationException($"No channel mapped to axis '{axisCode}'.");
    }

    private void SetArduinoAxisPulse(string control, int pulseUs)
    {
        if (chkSimulation.Checked)
        {
            var simAxisCode = AxisCodeForControl(control);
            var simChannel = ChannelFromAxisCode(simAxisCode);
            SetChannelPulseState(simChannel, pulseUs);
            return;
        }

        if (!_arduinoTrainerClient.IsConnected)
        {
            throw new InvalidOperationException("Arduino trainer cable is not connected.");
        }

        var axisCode = AxisCodeForControl(control);
        var channel = ChannelFromAxisCode(axisCode);
        _arduinoTrainerClient.SetChannelPulseUs(channel, pulseUs);
        SetChannelPulseState(channel, pulseUs);
    }

    private void CenterArduinoFlightControls()
    {
        if (chkSimulation.Checked)
        {
            SetChannelPulseState(ChannelFromAxisCode("A"), 1500);
            SetChannelPulseState(ChannelFromAxisCode("E"), 1500);
            SetChannelPulseState(ChannelFromAxisCode("T"), 1000);
            SetChannelPulseState(ChannelFromAxisCode("R"), 1500);
            return;
        }

        if (!_arduinoTrainerClient.IsConnected)
        {
            return;
        }

        _arduinoTrainerClient.SetChannelPulseUs(ChannelFromAxisCode("A"), 1500);
        SetChannelPulseState(ChannelFromAxisCode("A"), 1500);
        _arduinoTrainerClient.SetChannelPulseUs(ChannelFromAxisCode("E"), 1500);
        SetChannelPulseState(ChannelFromAxisCode("E"), 1500);
        _arduinoTrainerClient.SetChannelPulseUs(ChannelFromAxisCode("T"), 1000);
        SetChannelPulseState(ChannelFromAxisCode("T"), 1000);
        _arduinoTrainerClient.SetChannelPulseUs(ChannelFromAxisCode("R"), 1500);
        SetChannelPulseState(ChannelFromAxisCode("R"), 1500);
    }


    private void InitializePidWorkflow()
    {
        lblActiveAxis.Text = "N/A";
        UpdatePidSnapshotPanel(null, null, null, null, null, null);
        if (cmbManualAxis.Items.Count > 0 && cmbManualAxis.SelectedIndex < 0)
        {
            cmbManualAxis.SelectedIndex = 0;
        }

        if (cmbManualGain.Items.Count > 0 && cmbManualGain.SelectedIndex < 0)
        {
            cmbManualGain.SelectedIndex = 0;
        }

        if (cmbManualPoints.Items.Count > 0 && cmbManualPoints.SelectedIndex < 0)
        {
            cmbManualPoints.SelectedIndex = 0;
        }
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
            MessageBox.Show(this, "Connect FC USB first.", "PID Tuning Workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            double score;
            if (_arduinoConnected)
            {
                score = await RunAxisDynamicScoreAsync(
                    axis,
                    targetDeg: Math.Max(5.0, (double)nudTargetDeg.Value),
                    durationSec: 5.0,
                    throttleUs: (int)nudThrottleUs.Value);
            }
            else
            {
                var before = await SampleAxisNoiseAsync(axis, sampleCount: 14, sampleDelayMs: 70);
                await RunChannelTestAsync(axis);
                var after = await SampleAxisNoiseAsync(axis, sampleCount: 14, sampleDelayMs: 70);
                score = (before + after) / 2.0;
            }

            var recommendation = BuildRecommendation(axis, score);
            _pendingRecommendation = recommendation;

            AppendTuningRun(axis, iteration, score, recommendation);
            lblFCStatus.Text = $"Completed {axis} round {iteration}. Score {score:F2}.";
        }
        catch (Exception ex)
        {
            lblFCStatus.Text = $"PID tuning workflow failed: {ex.Message}";
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

    private async Task<double> RunAxisDynamicScoreAsync(string axis, double targetDeg, double durationSec, int throttleUs)
    {
        var baseline = await RecordAxisBaselineRateAsync(axis, Math.Max(0.3, (double)nudBaselineSec.Value));
        var positive = await CaptureDirectionMetricsAsync(axis, Math.Abs(targetDeg), durationSec, baseline, throttleUs);
        await Task.Delay(250);
        var negative = await CaptureDirectionMetricsAsync(axis, -Math.Abs(targetDeg), durationSec, baseline, throttleUs);
        return (positive.Score + negative.Score) / 2.0;
    }

    private async Task<double> RecordAxisBaselineRateAsync(string axis, double durationSec)
    {
        var previous = _serialPortService.ReadAttitude(2.0);
        var previousAt = DateTime.UtcNow;
        var rates = new List<double>();
        var endAt = DateTime.UtcNow.AddSeconds(durationSec);

        CenterArduinoFlightControls();
        while (DateTime.UtcNow < endAt)
        {
            await Task.Delay(50);
            var now = DateTime.UtcNow;
            var attitude = _serialPortService.ReadAttitude(2.0);
            var dt = Math.Max(0.001, (now - previousAt).TotalSeconds);
            var rate = axis == "roll"
                ? (attitude.RollDeg - previous.RollDeg) / dt
                : (attitude.PitchDeg - previous.PitchDeg) / dt;
            rates.Add(rate);
            previous = attitude;
            previousAt = now;
        }

        return rates.Count == 0 ? 0.0 : rates.Average();
    }

    private async Task<DirectionMetrics> CaptureDirectionMetricsAsync(string axis, double commandDeg, double durationSec, double baselineRate, int throttleUs)
    {
        var target = Math.Max(1.0, Math.Abs(commandDeg));
        var start = DateTime.UtcNow;
        var stopAt = start.AddSeconds(durationSec);
        var previous = _serialPortService.ReadAttitude(2.0);
        var previousAt = DateTime.UtcNow;
        var referenceAngle = axis == "roll" ? previous.RollDeg : previous.PitchDeg;
        var movementRates = new List<double>();
        var angleDeltas = new List<double>();
        var timeData = new List<double>();
        var commandPulse = ToPulseFromCommandDeg(commandDeg);
        var commandActive = false;
        var reachedTarget = false;

        if (_arduinoConnected)
        {
            SetArduinoAxisPulse("throttle", throttleUs);
            SetArduinoAxisPulse(axis, commandPulse);
            commandActive = true;
        }

        try
        {
            while (DateTime.UtcNow < stopAt)
            {
                await Task.Delay(50);
                var now = DateTime.UtcNow;
                var attitude = _serialPortService.ReadAttitude(2.0);
                var dt = Math.Max(0.001, (now - previousAt).TotalSeconds);
                var currentAngle = axis == "roll" ? attitude.RollDeg : attitude.PitchDeg;
                var previousAngle = axis == "roll" ? previous.RollDeg : previous.PitchDeg;
                var rawRate = (currentAngle - previousAngle) / dt;
                var movement = rawRate - baselineRate;
                var angleDelta = currentAngle - referenceAngle;
                var elapsed = (now - start).TotalSeconds;

                movementRates.Add(movement);
                angleDeltas.Add(angleDelta);
                timeData.Add(elapsed);

                if (commandActive && Math.Abs(angleDelta) >= target)
                {
                    CenterArduinoFlightControls();
                    commandActive = false;
                    reachedTarget = true;
                }

                previous = attitude;
                previousAt = now;
            }
        }
        finally
        {
            if (_arduinoConnected)
            {
                CenterArduinoFlightControls();
            }
        }

        if (!reachedTarget)
        {
            lblFCStatus.Text = $"{axis} target not reached within {durationSec:F1}s; forced neutral.";
        }

        var score = ComputeDirectionScore(movementRates, angleDeltas, target, durationSec);
        return new DirectionMetrics(score);
    }

    private static int ToPulseFromCommandDeg(double commandDeg)
    {
        var clamped = Math.Max(-MaxCommandDeg, Math.Min(MaxCommandDeg, commandDeg));
        var pulse = 1500.0 + (clamped / MaxCommandDeg) * 500.0;
        return (int)Math.Round(pulse, MidpointRounding.AwayFromZero);
    }

    private static double ComputeDirectionScore(IReadOnlyList<double> movementRates, IReadOnlyList<double> angleDeltas, double targetDeg, double durationSec)
    {
        if (movementRates.Count == 0 || angleDeltas.Count == 0)
        {
            return 999.0;
        }

        var oscillations = 0;
        var prevSign = 0;
        foreach (var value in movementRates)
        {
            var sign = value > 1.0 ? 1 : value < -1.0 ? -1 : 0;
            if (sign != 0 && prevSign != 0 && sign != prevSign)
            {
                oscillations++;
            }
            if (sign != 0)
            {
                prevSign = sign;
            }
        }

        var maxAbsDelta = angleDeltas.Select(Math.Abs).DefaultIfEmpty(0.0).Max();
        var overshootRatio = targetDeg <= 0.001 ? 1.0 : maxAbsDelta / targetDeg;
        var tailStart = Math.Max(0, movementRates.Count - Math.Max(3, movementRates.Count / 4));
        var steadyStateError = movementRates.Skip(tailStart).Select(Math.Abs).DefaultIfEmpty(0.0).Average();
        var settleTolerance = Math.Max(targetDeg * 0.05, 1.0);
        var settlingTime = durationSec;
        for (var i = 0; i < movementRates.Count; i++)
        {
            if (Math.Abs(movementRates[i]) > settleTolerance)
            {
                continue;
            }

            var remainingStable = true;
            for (var j = i; j < movementRates.Count; j++)
            {
                if (Math.Abs(movementRates[j]) > settleTolerance)
                {
                    remainingStable = false;
                    break;
                }
            }
            if (remainingStable)
            {
                settlingTime = durationSec * i / movementRates.Count;
                break;
            }
        }

        return
            oscillations * 2.0
            + Math.Max(0.0, overshootRatio - 1.0) * 2.0
            + steadyStateError / settleTolerance
            + (settlingTime / Math.Max(durationSec, 0.001));
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
            MessageBox.Show(this, "No pending PID adjustment to apply.", "PID Tuning Workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB first.", "PID Tuning Workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }

    private void RetestActiveAxis()
    {
        if (string.IsNullOrWhiteSpace(_activeAxis))
        {
            MessageBox.Show(this, "Tune Roll or Pitch first.", "PID Tuning Workflow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        _ = RunPidTuningRoundAsync(_activeAxis, resetAxis: false);
    }

    private void FinishActiveAxis()
    {
        _activeAxis = null;
        lblActiveAxis.Text = "N/A";
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
        DisconnectArduinoUsb();
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

    private void OnSimulationModeChanged()
    {
        if (chkSimulation.Checked && _arduinoTrainerClient.IsConnected)
        {
            _arduinoTrainerClient.Disconnect();
        }

        _arduinoConnected = false;
        SetArduinoStatus(chkSimulation.Checked
            ? "Simulation mode selected."
            : "Arduino not connected.");
        UpdateSerialConnectionUi();
    }
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

    private void lblActiveAxisTitle_Click(object sender, EventArgs e)
    {

    }

    private sealed record TuningRunRecord(int RunNumber, string Axis, int Iteration, double Score, string Recommendation);
    private sealed record PidAdjustmentRecommendation(string Axis, string Gain, string Direction, int Points, string Message);
    private sealed record DirectionMetrics(double Score);
}
