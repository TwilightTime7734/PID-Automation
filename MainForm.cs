using System.ComponentModel;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Management;
using DronePidTuningAssistant.WinForms.Models;
using DronePidTuningAssistant.WinForms.Services;
using WeifenLuo.WinFormsUI.Docking;
using WeifenLuo.WinFormsUI.ThemeVS2015;

namespace DronePidTuningAssistant.WinForms;

public sealed partial class MainForm : Form
{
    private enum ControlPath
    {
        None = 0,
        FcDirect = 1,
        ArduinoTransmitter = 2,
    }

    private const int FixedSerialBaud = 115200;
    private const string PersistKeyTelemetry = "panel.telemetry";
    private const string PersistKeyChannelTest = "panel.channel_test";
    private const string PersistKeyPidWorkflow = "panel.pid_workflow";
    private const string PersistKeyTuningProgress = "panel.tuning_progress";
    private const string PersistKeySerialPorts = "panel.serial_ports";
    private const string PersistKeyPpmMapping = "panel.ppm_mapping";

    private readonly LayoutSettingsService _settingsService = new();
    private readonly SerialPortService _serialPortService = new();
    private readonly List<TuningRunRecord> _tuningRuns = new();
    private readonly Dictionary<string, DockSectionContent> _dockSections = new(StringComparer.Ordinal);
    private bool _channelTestRunning;
    private bool _arduinoConnected;
    private System.Windows.Forms.Timer? _telemetryTimer;
    private DockPanel? _dockWorkspace;
    private bool _dockWorkspaceInitialized;
    private bool _dockRecoveryAttempted;
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

        ConfigureChannelCombo(cboRoll);
        ConfigureChannelCombo(cboPitch);
        ConfigureChannelCombo(cboThrottle);
        ApplyResponsiveLayoutRules(this);
        ConfigureSerialPortsResponsiveLayout();
        Shown += async (_, _) => await DiscoverPortsOnStartupAsync();
        cboPort.SelectedIndexChanged += (_, _) => UpdateSerialConnectionUi();
        cboArduinoPort.SelectedIndexChanged += (_, _) => UpdateSerialConnectionUi();
        LoadSerialDefaults();
        RefreshPortList();
        LoadChannelMapping();
        InitializeTelemetry();
        InitializePidWorkflow();
        UpdateSerialConnectionUi();
        // InitializeDockWorkspace disabled to keep the runtime UI identical to the Designer layout.
        // InitializeDockWorkspace();
    }

    private static void ApplyResponsiveLayoutRules(Control root)
    {
        if (root is TableLayoutPanel table)
        {
            table.AutoSize = false;

            var allColumnsAuto = table.ColumnStyles.Count > 0 && table.ColumnStyles.Cast<ColumnStyle>().All(c => c.SizeType == SizeType.AutoSize);
            if (allColumnsAuto)
            {
                var last = table.ColumnStyles.Count - 1;
                table.ColumnStyles[last].SizeType = SizeType.Percent;
                table.ColumnStyles[last].Width = 100f;
            }

            var allRowsAuto = table.RowStyles.Count > 0 && table.RowStyles.Cast<RowStyle>().All(r => r.SizeType == SizeType.AutoSize);
            if (allRowsAuto)
            {
                var last = table.RowStyles.Count - 1;
                table.RowStyles[last].SizeType = SizeType.Percent;
                table.RowStyles[last].Height = 100f;
            }
        }

        switch (root)
        {
            case ComboBox:
            case TextBox:
            case NumericUpDown:
                root.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                break;
            case ListView:
            case Panel:
                root.Dock = DockStyle.Fill;
                break;
        }

        foreach (Control child in root.Controls)
        {
            ApplyResponsiveLayoutRules(child);
        }
    }

    private void ConfigureSerialPortsResponsiveLayout()
    {
        usbLayout.SuspendLayout();
        try
        {
            usbLayout.AutoSize = false;
            usbLayout.Dock = DockStyle.Fill;
            usbLayout.ColumnStyles.Clear();
            usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f)); // FC/Arduino label
            usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24f)); // Port combo
            usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8f));  // Baud label
            usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f)); // Baud value
            usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16f)); // Refresh
            usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16f)); // Connect
            usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16f)); // Disconnect

            cboPort.Dock = DockStyle.Fill;
            cboArduinoPort.Dock = DockStyle.Fill;
            btnRefreshPorts.Dock = DockStyle.Fill;
            btnConnect.Dock = DockStyle.Fill;
            btnDisconnect.Dock = DockStyle.Fill;
            btnArduinoConnect.Dock = DockStyle.Fill;
            btnArduinoDisconnect.Dock = DockStyle.Fill;
            lblStatus.Dock = DockStyle.Fill;
        }
        finally
        {
            usbLayout.ResumeLayout();
        }
    }

    private async Task DiscoverPortsOnStartupAsync()
    {
        _startupScanInProgress = true;
        lblStatus.Text = "Startup scan in progress...";
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
                        _serialPortService.Connect(candidate, FixedSerialBaud);
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
                lblStatus.Text = "Startup scan: no serial ports detected.";
            }
            else if (!string.IsNullOrWhiteSpace(result.fcConnectedPort))
            {
                var arduinoText = string.IsNullOrWhiteSpace(result.arduinoPort)
                    ? "Arduino not connected."
                    : $"Arduino on {result.arduinoPort}.";
                lblStatus.Text = $"Startup auto-connect: FC on {result.fcConnectedPort}@{FixedSerialBaud}. {arduinoText}";
            }
            else
            {
                lblStatus.Text = "Startup auto-connect: FC not connected (tried top 2 candidates).";
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

    private static void ConfigureChannelCombo(ComboBox combo)
    {
        combo.DropDownStyle = ComboBoxStyle.DropDownList;
        combo.Items.Clear();
        for (var i = 1; i <= 8; i++)
        {
            combo.Items.Add(i);
        }
    }

    private void LoadChannelMapping()
    {
        var mapping = _settingsService.LoadMapping();
        SetComboValue(cboRoll, mapping.Roll);
        SetComboValue(cboPitch, mapping.Pitch);
        SetComboValue(cboThrottle, mapping.Throttle);
        lblStatus.Text = "Loaded channel mapping.";
    }

    private void SaveChannelMapping()
    {
        var mapping = new ChannelMapping
        {
            Roll = GetComboValue(cboRoll, 1),
            Pitch = GetComboValue(cboPitch, 2),
            Throttle = GetComboValue(cboThrottle, 3),
        };
        _settingsService.SaveMapping(mapping);
        lblStatus.Text = $"Saved mapping: Roll CH{mapping.Roll}, Pitch CH{mapping.Pitch}, Throttle CH{mapping.Throttle}";
    }

    private static int GetComboValue(ComboBox combo, int fallback)
    {
        return combo.SelectedItem is int value ? value : fallback;
    }

    private static void SetComboValue(ComboBox combo, int value)
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

    private void LoadSerialDefaults()
    {
        lblBaudValue.Text = FixedSerialBaud.ToString(CultureInfo.InvariantCulture);
        lblArduinoBaudValue.Text = FixedSerialBaud.ToString(CultureInfo.InvariantCulture);
    }

    private void RefreshPortList()
    {
        var ports = _serialPortService.GetAvailablePorts();
        PopulatePortCombos(ports);
        lblStatus.Text = ports.Count == 0
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
            using var probe = new SerialPort(portName, FixedSerialBaud)
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
        var baudRate = FixedSerialBaud;

        try
        {
            _serialPortService.Connect(portName, baudRate);
            lblStatus.Text = $"Connected FC USB: {portName}@{baudRate}";
            UpdateSerialConnectionUi();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Connection failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "FC USB connection failed.";
            UpdateSerialConnectionUi();
        }
    }

    private void DisconnectUsb()
    {
        StopTelemetryLoop("FC USB disconnected.");
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
        var baudRate = FixedSerialBaud;

        _arduinoConnected = true;
        lblStatus.Text = $"Arduino controls queued: {portName}@{baudRate}.";
        UpdateSerialConnectionUi();
    }

    private void DisconnectArduinoUsb()
    {
        _arduinoConnected = false;
        lblStatus.Text = "Arduino serial disconnected.";
        UpdateSerialConnectionUi();
    }

    private void UpdateSerialConnectionUi()
    {
        var fcConnected = _serialPortService.IsConnected;
        var fcPortSelected = cboPort.SelectedItem is string fcPort && !string.IsNullOrWhiteSpace(fcPort);
        btnConnect.Enabled = !_startupScanInProgress && !fcConnected && fcPortSelected;
        btnDisconnect.Enabled = fcConnected;

        var arduinoPortSelected = cboArduinoPort.SelectedItem is string arduinoPort && !string.IsNullOrWhiteSpace(arduinoPort);
        btnArduinoConnect.Enabled = !_startupScanInProgress && !_arduinoConnected && arduinoPortSelected;
        btnArduinoDisconnect.Enabled = _arduinoConnected;
        UpdateWorkflowUiState();
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
            Roll = GetComboValue(cboRoll, 1),
            Pitch = GetComboValue(cboPitch, 2),
            Throttle = GetComboValue(cboThrottle, 3),
        };
        var channelNumber = control switch
        {
            "roll" => mapping.Roll,
            "pitch" => mapping.Pitch,
            "throttle" => mapping.Throttle,
            _ => 0,
        };

        try
        {
            lblStatus.Text = $"Testing {control} on CH{channelNumber} via {DescribeControlPath(activePath)}...";

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
            lblStatus.Text = $"Completed {control} channel test on CH{channelNumber} via {DescribeControlPath(activePath)}.";
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
        lblStatus.Text = "Live telemetry started.";
    }

    private void StopTelemetryLoop(string statusText = "Live telemetry stopped.")
    {
        _telemetryTimer?.Stop();
        UpdateWorkflowUiState();
        lblStatus.Text = statusText;
    }

    private void TelemetrySnapshot()
    {
        if (!_serialPortService.IsConnected)
        {
            MessageBox.Show(this, "Connect FC USB before requesting telemetry snapshot.", "Telemetry unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        PollTelemetrySample();
        lblStatus.Text = "Telemetry snapshot updated.";
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

    private void InitializeDockWorkspace()
    {
        if (_dockWorkspaceInitialized)
        {
            return;
        }

        _dockWorkspaceInitialized = true;
        _dockWorkspace = CreateDockWorkspace();

        topLayout.Controls.Remove(grpUsb);
        topLayout.Controls.Remove(grpMapping);
        topLayout.Visible = false;
        rootLayout.RowStyles[0].SizeType = SizeType.Absolute;
        rootLayout.RowStyles[0].Height = 0;

        grpPortingArea.Controls.Clear();
        grpPortingArea.Controls.Add(_dockWorkspace);

        PrepareSectionForDocking(grpUsb);
        PrepareSectionForDocking(grpMapping);
        PrepareSectionForDocking(grpTelemetry);
        PrepareSectionForDocking(grpChannelTest);
        PrepareSectionForDocking(grpPidWorkflow);
        PrepareSectionForDocking(grpTuningProgress);

        var serialContent = new DockSectionContent(grpUsb.Text, PersistKeySerialPorts, grpUsb);
        var mappingContent = new DockSectionContent(grpMapping.Text, PersistKeyPpmMapping, grpMapping);
        var telemetryContent = new DockSectionContent(grpTelemetry.Text, PersistKeyTelemetry, grpTelemetry);
        var channelContent = new DockSectionContent(grpChannelTest.Text, PersistKeyChannelTest, grpChannelTest);
        var pidContent = new DockSectionContent(grpPidWorkflow.Text, PersistKeyPidWorkflow, grpPidWorkflow);
        var progressContent = new DockSectionContent(grpTuningProgress.Text, PersistKeyTuningProgress, grpTuningProgress);

        _dockSections.Clear();
        _dockSections[PersistKeySerialPorts] = serialContent;
        _dockSections[PersistKeyPpmMapping] = mappingContent;
        _dockSections[PersistKeyTelemetry] = telemetryContent;
        _dockSections[PersistKeyChannelTest] = channelContent;
        _dockSections[PersistKeyPidWorkflow] = pidContent;
        _dockSections[PersistKeyTuningProgress] = progressContent;

        // Ensure any previously saved dock layout is removed so designer layout is used.
        TryDeleteDockLayoutFile();
        ApplyDefaultDockLayout();
        EnsureDockSectionsVisible();
    }

    private static void PrepareSectionForDocking(Control root)
    {
        if (root is GroupBox groupBox)
        {
            groupBox.AutoSize = false;
            groupBox.AutoSizeMode = AutoSizeMode.GrowOnly;
            groupBox.Dock = DockStyle.Fill;
        }

        if (root is ScrollableControl scrollable)
        {
            scrollable.AutoScroll = true;
        }

        foreach (Control child in root.Controls)
        {
            if (child is TableLayoutPanel table)
            {
                table.AutoSize = false;
                table.Dock = DockStyle.Fill;
            }

            PrepareSectionForDocking(child);
        }
    }

    private void EnsureDockTheme()
    {
        if (_dockWorkspace is null)
        {
            return;
        }

        if (_dockWorkspace.Theme is null)
        {
            _dockWorkspace.Theme = new VS2015LightTheme();
        }
    }

    private static DockPanel CreateDockWorkspace()
    {
        var dockWorkspace = new DockPanel
        {
            Dock = DockStyle.Fill,
            DocumentStyle = DocumentStyle.DockingWindow,
            AllowEndUserDocking = true,
            AllowEndUserNestedDocking = true,
            Theme = new VS2015LightTheme(),
        };
        return dockWorkspace;
    }

    private void ApplyDefaultDockLayout()
    {
        if (_dockWorkspace is null)
        {
            return;
        }
        EnsureDockTheme();

        var telemetryContent = _dockSections[PersistKeyTelemetry];
        var channelContent = _dockSections[PersistKeyChannelTest];
        var pidContent = _dockSections[PersistKeyPidWorkflow];
        var progressContent = _dockSections[PersistKeyTuningProgress];
        var serialContent = _dockSections[PersistKeySerialPorts];
        var mappingContent = _dockSections[PersistKeyPpmMapping];

        try
        {
            serialContent.Show(_dockWorkspace, DockState.DockTop);
            mappingContent.Show(_dockWorkspace, DockState.DockTop);
            telemetryContent.Show(_dockWorkspace, DockState.DockTop);
            channelContent.Show(_dockWorkspace, DockState.Document);
            pidContent.Show(_dockWorkspace, DockState.DockRight);
            progressContent.Show(_dockWorkspace, DockState.DockBottom);
            _dockRecoveryAttempted = false;
        }
        catch (ArgumentException)
        {
            RecoverDockWorkspace();
        }
    }

    private bool TryRestoreDockLayout()
    {
        // Restoring persisted dock layouts disabled to keep runtime UI consistent with the Designer.
        return false;
    }

    private void RecoverDockWorkspace()
    {
        if (_dockRecoveryAttempted)
        {
            lblStatus.Text = "Dock layout recovery failed. Delete saved layout and restart app.";
            return;
        }

        _dockRecoveryAttempted = true;
        TryDeleteDockLayoutFile();

        if (_dockWorkspace is not null)
        {
            grpPortingArea.Controls.Remove(_dockWorkspace);
            _dockWorkspace.Dispose();
        }

        _dockWorkspace = CreateDockWorkspace();
        grpPortingArea.Controls.Clear();
        grpPortingArea.Controls.Add(_dockWorkspace);
        EnsureDockTheme();

        try
        {
            var telemetryContent = _dockSections[PersistKeyTelemetry];
            var channelContent = _dockSections[PersistKeyChannelTest];
            var pidContent = _dockSections[PersistKeyPidWorkflow];
            var progressContent = _dockSections[PersistKeyTuningProgress];
            var serialContent = _dockSections[PersistKeySerialPorts];
            var mappingContent = _dockSections[PersistKeyPpmMapping];

            serialContent.Show(_dockWorkspace, DockState.DockTop);
            mappingContent.Show(_dockWorkspace, DockState.DockTop);
            telemetryContent.Show(_dockWorkspace, DockState.DockTop);
            channelContent.Show(_dockWorkspace, DockState.Document);
            pidContent.Show(_dockWorkspace, DockState.DockRight);
            progressContent.Show(_dockWorkspace, DockState.DockBottom);
            lblStatus.Text = "Dock layout reset to default.";
        }
        catch
        {
            lblStatus.Text = "Dock layout recovery failed. Delete saved layout and restart app.";
        }
    }

    private void TryDeleteDockLayoutFile()
    {
        try
        {
            var path = GetDockLayoutPath();
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        catch
        {
            // Ignore cleanup failures.
        }
    }

    private bool HasVisibleDockContent()
    {
        if (_dockWorkspace is null)
        {
            return false;
        }

        foreach (var section in _dockSections.Values)
        {
            if (section.DockPanel != _dockWorkspace)
            {
                continue;
            }

            if (section.DockState != DockState.Hidden && section.DockState != DockState.Unknown)
            {
                return true;
            }
        }

        return false;
    }

    private void EnsureDockSectionsVisible()
    {
        if (_dockWorkspace is null)
        {
            return;
        }

        ShowIfMissingOrHidden(PersistKeySerialPorts, DockState.DockTop);
        ShowIfMissingOrHidden(PersistKeyPpmMapping, DockState.DockTop);
        ShowIfMissingOrHidden(PersistKeyTelemetry, DockState.DockLeft);
        ShowIfMissingOrHidden(PersistKeyChannelTest, DockState.Document);
        ShowIfMissingOrHidden(PersistKeyPidWorkflow, DockState.DockRight);
        ShowIfMissingOrHidden(PersistKeyTuningProgress, DockState.DockBottom);
    }

    private void ShowIfMissingOrHidden(string key, DockState defaultState)
    {
        if (_dockWorkspace is null || !_dockSections.TryGetValue(key, out var section))
        {
            return;
        }

        if (section.DockPanel != _dockWorkspace || section.DockState == DockState.Hidden || section.DockState == DockState.Unknown)
        {
            section.Show(_dockWorkspace, defaultState);
        }
    }

    private IDockContent? DeserializeDockContent(string persistString)
    {
        return _dockSections.TryGetValue(persistString, out var content) ? content : null;
    }

    private void SaveDockLayout()
    {
        // Persisting layout disabled to avoid runtime layout drift.
    }

    private static string GetDockLayoutPath()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var folder = Path.Combine(appData, "DronePidTuningAssistantWinForms", "layouts");
        var machine = Environment.MachineName;
        return Path.Combine(folder, $"docklayout_{machine}.xml");
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
        lblStatus.Text = $"Running {axis} tuning round {iteration}...";
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
            lblStatus.Text = $"Completed {axis} round {iteration}. Score {score:F2}.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"PID workflow failed: {ex.Message}";
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

            lblStatus.Text = $"Applied PID: {settingName} {current} -> {applied} and saved.";
            txtPidRecommendation.Text += $"{Environment.NewLine}{Environment.NewLine}Applied to FC: {settingName} {current} -> {applied}.";
            RefreshPidSnapshotFromFc();
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"PID write failed: {ex.Message}";
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
            lblStatus.Text = $"Manual PID: {settingName} {current} -> {applied}";
            RefreshPidSnapshotFromFc();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Manual PID write failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "Manual PID write failed.";
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
            lblStatus.Text = "Read PID values from FC.";
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Read FC failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "Read FC failed.";
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
            lblStatus.Text = "Saved current PID values to FC.";
            RefreshPidSnapshotFromFc();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Save FC failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "Save FC failed.";
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
        lblStatus.Text = "Axis tuning finished.";
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
