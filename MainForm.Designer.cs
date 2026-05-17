#nullable disable
namespace DronePidTuningAssistant.WinForms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components is not null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    ///  Required method for Designer support.
    /// </summary>
    private void InitializeComponent()
    {
        rootLayout = new TableLayoutPanel();
        grpUsb = new GroupBox();
        lblPort = new Label();
        lblArduinoStatus = new Label();
        cboPort = new ComboBox();
        cboBaud = new ComboBox();
        btnFcConnect = new Button();
        btnFcDisconnect = new Button();
        btnRefreshPorts = new Button();
        lblArduinoPort = new Label();
        cboArduinoPort = new ComboBox();
        cboArduinoBaud = new ComboBox();
        lblTrainerPin = new Label();
        cboTrainerPin = new ComboBox();
        chkSimulation = new CheckBox();
        btnArduinoConnect = new Button();
        btnArduinoDisconnect = new Button();
        lblFCStatus = new Label();
        grpMapping = new GroupBox();
        lblRoll = new Label();
        cboCH1 = new ComboBox();
        lblPitch = new Label();
        cboCH2 = new ComboBox();
        lblThrottle = new Label();
        cboCH3 = new ComboBox();
        lblCh4 = new Label();
        cboCH4 = new ComboBox();
        btnApplyMapping = new Button();
        btnPresetAetr = new Button();
        btnPresetRtae = new Button();
        btnPresetReat = new Button();
        grpChannelTest = new GroupBox();
        btnTestRoll = new Button();
        btnTestPitch = new Button();
        btnTestThrottle = new Button();
        pnlSticks = new Panel();
        pnlLeftStick = new Panel();
        pnlLeftStickIndicator = new Panel();
        pnlRightStick = new Panel();
        pnlRightStickIndicator = new Panel();
        channelVisualLayout = new Panel();
        lblChannelVisualTitle = new Label();
        lblChannelVisual = new Label();
        lblChannelValueTitle = new Label();
        lblChannelValue = new Label();
        lblRollAngleTitle = new Label();
        lblRollAngle = new Label();
        lblPitchAngleTitle = new Label();
        lblPitchAngle = new Label();
        channelInputsLayout = new FlowLayoutPanel();
        lblTargetDeg = new Label();
        lblSettleSec = new Label();
        nudSettleSec = new NumericUpDown();
        lblBaselineSec = new Label();
        nudBaselineSec = new NumericUpDown();
        lblThrottleUs = new Label();
        nudThrottleUs = new NumericUpDown();
        nudTargetDeg = new NumericUpDown();
        grpPidWorkflow = new GroupBox();
        btnTuneRoll = new Button();
        lblActiveAxis = new Label();
        lblActiveAxisTitle = new Label();
        btnTunePitch = new Button();
        btnRetestAxis = new Button();
        lblPidValuesTitle = new Label();
        btnFinishAxis = new Button();
        btnApplyRecommendedPid = new Button();
        cmbManualAxis = new ComboBox();
        cmbManualGain = new ComboBox();
        cmbManualPoints = new ComboBox();
        btnManualPidMinus = new Button();
        btnManualPidPlus = new Button();
        btnReadFcPid = new Button();
        btnSaveFcPid = new Button();
        lvTuningRuns = new ListView();
        colRun = new ColumnHeader();
        colAxis = new ColumnHeader();
        colScore = new ColumnHeader();
        colDecision = new ColumnHeader();
        grpTelemetry = new GroupBox();
        telemetryButtonLayout = new Panel();
        btnTelemetryStart = new Button();
        btnTelemetryStop = new Button();
        btnTelemetrySnapshot = new Button();
        telemetryValueLayout = new Panel();
        lblTelemetryRollTitle = new Label();
        lblTelemetryRoll = new Label();
        lblTelemetryPitchTitle = new Label();
        lblTelemetryPitch = new Label();
        lblTelemetryYawTitle = new Label();
        lblTelemetryYaw = new Label();
        pnlScoreChart = new Panel();
        txtPidValues = new TextBox();
        txtPidRecommendation = new TextBox();
        rootLayout.SuspendLayout();
        grpUsb.SuspendLayout();
        grpMapping.SuspendLayout();
        grpChannelTest.SuspendLayout();
        pnlSticks.SuspendLayout();
        pnlLeftStick.SuspendLayout();
        pnlRightStick.SuspendLayout();
        channelVisualLayout.SuspendLayout();
        channelInputsLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).BeginInit();
        grpPidWorkflow.SuspendLayout();
        grpTelemetry.SuspendLayout();
        telemetryButtonLayout.SuspendLayout();
        telemetryValueLayout.SuspendLayout();
        pnlScoreChart.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 3;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.7464F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.34407F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.9095268F));
        rootLayout.Controls.Add(grpUsb, 0, 0);
        rootLayout.Controls.Add(grpMapping, 1, 0);
        rootLayout.Controls.Add(grpChannelTest, 2, 0);
        rootLayout.Controls.Add(grpPidWorkflow, 0, 1);
        rootLayout.Controls.Add(lvTuningRuns, 1, 1);
        rootLayout.Controls.Add(grpTelemetry, 2, 1);
        rootLayout.Controls.Add(pnlScoreChart, 0, 2);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(10);
        rootLayout.RowCount = 3;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 22.3060341F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 15.625F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 62.0689659F));
        rootLayout.Size = new Size(1479, 948);
        rootLayout.TabIndex = 0;
        // 
        // grpUsb
        // 
        grpUsb.Controls.Add(lblPort);
        grpUsb.Controls.Add(lblArduinoStatus);
        grpUsb.Controls.Add(cboPort);
        grpUsb.Controls.Add(cboBaud);
        grpUsb.Controls.Add(btnFcConnect);
        grpUsb.Controls.Add(btnFcDisconnect);
        grpUsb.Controls.Add(btnRefreshPorts);
        grpUsb.Controls.Add(lblArduinoPort);
        grpUsb.Controls.Add(cboArduinoPort);
        grpUsb.Controls.Add(cboArduinoBaud);
        grpUsb.Controls.Add(lblTrainerPin);
        grpUsb.Controls.Add(cboTrainerPin);
        grpUsb.Controls.Add(chkSimulation);
        grpUsb.Controls.Add(btnArduinoConnect);
        grpUsb.Controls.Add(btnArduinoDisconnect);
        grpUsb.Controls.Add(lblFCStatus);
        grpUsb.Dock = DockStyle.Fill;
        grpUsb.Location = new Point(13, 13);
        grpUsb.Name = "grpUsb";
        grpUsb.Padding = new Padding(10);
        grpUsb.Size = new Size(428, 201);
        grpUsb.TabIndex = 0;
        grpUsb.TabStop = false;
        grpUsb.Text = "Serial Ports";
        // 
        // lblPort
        // 
        lblPort.Anchor = AnchorStyles.Left;
        lblPort.Location = new Point(13, 50);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(62, 15);
        lblPort.TabIndex = 0;
        lblPort.Text = "FC USB";
        // 
        // lblArduinoStatus
        // 
        lblArduinoStatus.Location = new Point(276, 113);
        lblArduinoStatus.Margin = new Padding(3, 3, 3, 0);
        lblArduinoStatus.Name = "lblArduinoStatus";
        lblArduinoStatus.Size = new Size(247, 15);
        lblArduinoStatus.TabIndex = 14;
        lblArduinoStatus.Text = "Waiting...";
        lblArduinoStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cboPort
        // 
        cboPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPort.FormattingEnabled = true;
        cboPort.Location = new Point(80, 33);
        cboPort.Name = "cboPort";
        cboPort.Size = new Size(68, 23);
        cboPort.TabIndex = 1;
        // 
        // cboBaud
        // 
        cboBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBaud.FormattingEnabled = true;
        cboBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboBaud.Location = new Point(149, 33);
        cboBaud.Name = "cboBaud";
        cboBaud.Size = new Size(64, 23);
        cboBaud.TabIndex = 2;
        // 
        // btnFcConnect
        // 
        btnFcConnect.Location = new Point(217, 32);
        btnFcConnect.Name = "btnFcConnect";
        btnFcConnect.Size = new Size(64, 24);
        btnFcConnect.TabIndex = 3;
        btnFcConnect.Text = "Connect";
        btnFcConnect.UseVisualStyleBackColor = true;
        btnFcConnect.Click += btnConnect_Click;
        // 
        // btnFcDisconnect
        // 
        btnFcDisconnect.Location = new Point(283, 32);
        btnFcDisconnect.Name = "btnFcDisconnect";
        btnFcDisconnect.Size = new Size(64, 24);
        btnFcDisconnect.TabIndex = 4;
        btnFcDisconnect.Text = "Disconnect";
        btnFcDisconnect.UseVisualStyleBackColor = true;
        btnFcDisconnect.Click += btnDisconnect_Click;
        // 
        // btnRefreshPorts
        // 
        btnRefreshPorts.ImageAlign = ContentAlignment.MiddleLeft;
        btnRefreshPorts.Location = new Point(349, 32);
        btnRefreshPorts.Name = "btnRefreshPorts";
        btnRefreshPorts.Size = new Size(66, 24);
        btnRefreshPorts.TabIndex = 5;
        btnRefreshPorts.Text = "Refresh";
        btnRefreshPorts.UseVisualStyleBackColor = true;
        btnRefreshPorts.Click += btnRefreshPorts_Click;
        // 
        // lblArduinoPort
        // 
        lblArduinoPort.Anchor = AnchorStyles.Left;
        lblArduinoPort.Location = new Point(13, 79);
        lblArduinoPort.Name = "lblArduinoPort";
        lblArduinoPort.Size = new Size(62, 15);
        lblArduinoPort.TabIndex = 7;
        lblArduinoPort.Text = "Arduino";
        // 
        // cboArduinoPort
        // 
        cboArduinoPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoPort.FormattingEnabled = true;
        cboArduinoPort.Location = new Point(80, 62);
        cboArduinoPort.Name = "cboArduinoPort";
        cboArduinoPort.Size = new Size(68, 23);
        cboArduinoPort.TabIndex = 8;
        // 
        // cboArduinoBaud
        // 
        cboArduinoBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoBaud.FormattingEnabled = true;
        cboArduinoBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboArduinoBaud.Location = new Point(149, 62);
        cboArduinoBaud.Name = "cboArduinoBaud";
        cboArduinoBaud.Size = new Size(64, 23);
        cboArduinoBaud.TabIndex = 9;
        // 
        // lblTrainerPin
        // 
        lblTrainerPin.Location = new Point(13, 89);
        lblTrainerPin.Name = "lblTrainerPin";
        lblTrainerPin.Size = new Size(62, 18);
        lblTrainerPin.TabIndex = 15;
        lblTrainerPin.Text = "Trainer Pin";
        lblTrainerPin.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cboTrainerPin
        // 
        cboTrainerPin.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrainerPin.FormattingEnabled = true;
        cboTrainerPin.Items.AddRange(new object[] { "3", "5", "6", "9", "10", "11" });
        cboTrainerPin.Location = new Point(80, 88);
        cboTrainerPin.Name = "cboTrainerPin";
        cboTrainerPin.Size = new Size(68, 23);
        cboTrainerPin.TabIndex = 16;
        // 
        // chkSimulation
        // 
        chkSimulation.AutoSize = true;
        chkSimulation.Location = new Point(149, 91);
        chkSimulation.Name = "chkSimulation";
        chkSimulation.Size = new Size(83, 19);
        chkSimulation.TabIndex = 17;
        chkSimulation.Text = "Simulation";
        chkSimulation.UseVisualStyleBackColor = true;
        // 
        // btnArduinoConnect
        // 
        btnArduinoConnect.Location = new Point(217, 61);
        btnArduinoConnect.Name = "btnArduinoConnect";
        btnArduinoConnect.Size = new Size(64, 24);
        btnArduinoConnect.TabIndex = 10;
        btnArduinoConnect.Text = "Connect";
        btnArduinoConnect.UseVisualStyleBackColor = true;
        btnArduinoConnect.Click += btnArduinoConnect_Click;
        // 
        // btnArduinoDisconnect
        // 
        btnArduinoDisconnect.Location = new Point(283, 61);
        btnArduinoDisconnect.Name = "btnArduinoDisconnect";
        btnArduinoDisconnect.Size = new Size(64, 24);
        btnArduinoDisconnect.TabIndex = 11;
        btnArduinoDisconnect.Text = "Disconnect";
        btnArduinoDisconnect.UseVisualStyleBackColor = true;
        btnArduinoDisconnect.Click += btnArduinoDisconnect_Click;
        // 
        // lblFCStatus
        // 
        lblFCStatus.Anchor = AnchorStyles.Left;
        lblFCStatus.Location = new Point(13, 129);
        lblFCStatus.Margin = new Padding(3, 3, 3, 0);
        lblFCStatus.Name = "lblFCStatus";
        lblFCStatus.Size = new Size(240, 15);
        lblFCStatus.TabIndex = 13;
        lblFCStatus.Text = "Waiting...";
        lblFCStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grpMapping
        // 
        grpMapping.Controls.Add(lblRoll);
        grpMapping.Controls.Add(cboCH1);
        grpMapping.Controls.Add(lblPitch);
        grpMapping.Controls.Add(cboCH2);
        grpMapping.Controls.Add(lblThrottle);
        grpMapping.Controls.Add(cboCH3);
        grpMapping.Controls.Add(lblCh4);
        grpMapping.Controls.Add(cboCH4);
        grpMapping.Controls.Add(btnApplyMapping);
        grpMapping.Controls.Add(btnPresetAetr);
        grpMapping.Controls.Add(btnPresetRtae);
        grpMapping.Controls.Add(btnPresetReat);
        grpMapping.Dock = DockStyle.Fill;
        grpMapping.Location = new Point(447, 13);
        grpMapping.Name = "grpMapping";
        grpMapping.Padding = new Padding(10);
        grpMapping.Size = new Size(319, 201);
        grpMapping.TabIndex = 1;
        grpMapping.TabStop = false;
        grpMapping.Text = "Transmitter Channel Mapping";
        // 
        // lblRoll
        // 
        lblRoll.Anchor = AnchorStyles.Left;
        lblRoll.Location = new Point(3, 49);
        lblRoll.Name = "lblRoll";
        lblRoll.Size = new Size(38, 15);
        lblRoll.TabIndex = 0;
        lblRoll.Text = "Ch 1";
        // 
        // cboCH1
        // 
        cboCH1.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH1.FormattingEnabled = true;
        cboCH1.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH1.Location = new Point(47, 31);
        cboCH1.Name = "cboCH1";
        cboCH1.Size = new Size(52, 23);
        cboCH1.TabIndex = 1;
        // 
        // lblPitch
        // 
        lblPitch.Anchor = AnchorStyles.Left;
        lblPitch.Location = new Point(3, 75);
        lblPitch.Name = "lblPitch";
        lblPitch.Size = new Size(38, 15);
        lblPitch.TabIndex = 2;
        lblPitch.Text = "Ch 2";
        // 
        // cboCH2
        // 
        cboCH2.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH2.FormattingEnabled = true;
        cboCH2.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH2.Location = new Point(47, 57);
        cboCH2.Name = "cboCH2";
        cboCH2.Size = new Size(52, 23);
        cboCH2.TabIndex = 3;
        // 
        // lblThrottle
        // 
        lblThrottle.Anchor = AnchorStyles.Left;
        lblThrottle.Location = new Point(3, 101);
        lblThrottle.Name = "lblThrottle";
        lblThrottle.Size = new Size(38, 15);
        lblThrottle.TabIndex = 4;
        lblThrottle.Text = "Ch 3";
        // 
        // cboCH3
        // 
        cboCH3.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH3.FormattingEnabled = true;
        cboCH3.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH3.Location = new Point(47, 84);
        cboCH3.Name = "cboCH3";
        cboCH3.Size = new Size(52, 23);
        cboCH3.TabIndex = 5;
        // 
        // lblCh4
        // 
        lblCh4.Anchor = AnchorStyles.Left;
        lblCh4.Location = new Point(3, 128);
        lblCh4.Name = "lblCh4";
        lblCh4.Size = new Size(38, 15);
        lblCh4.TabIndex = 7;
        lblCh4.Text = "Ch 4";
        // 
        // cboCH4
        // 
        cboCH4.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH4.FormattingEnabled = true;
        cboCH4.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH4.Location = new Point(47, 110);
        cboCH4.Name = "cboCH4";
        cboCH4.Size = new Size(52, 23);
        cboCH4.TabIndex = 8;
        // 
        // btnApplyMapping
        // 
        btnApplyMapping.Location = new Point(99, 31);
        btnApplyMapping.Name = "btnApplyMapping";
        btnApplyMapping.Size = new Size(75, 22);
        btnApplyMapping.TabIndex = 6;
        btnApplyMapping.Text = "Apply";
        btnApplyMapping.UseVisualStyleBackColor = true;
        btnApplyMapping.Click += btnApplyMapping_Click;
        // 
        // btnPresetAetr
        // 
        btnPresetAetr.Location = new Point(99, 57);
        btnPresetAetr.Name = "btnPresetAetr";
        btnPresetAetr.Size = new Size(75, 22);
        btnPresetAetr.TabIndex = 9;
        btnPresetAetr.Text = "AETR";
        btnPresetAetr.UseVisualStyleBackColor = true;
        btnPresetAetr.Click += btnPresetAetr_Click;
        // 
        // btnPresetRtae
        // 
        btnPresetRtae.Location = new Point(99, 84);
        btnPresetRtae.Name = "btnPresetRtae";
        btnPresetRtae.Size = new Size(75, 22);
        btnPresetRtae.TabIndex = 10;
        btnPresetRtae.Text = "RTAE";
        btnPresetRtae.UseVisualStyleBackColor = true;
        btnPresetRtae.Click += btnPresetRtae_Click;
        // 
        // btnPresetReat
        // 
        btnPresetReat.Location = new Point(99, 110);
        btnPresetReat.Name = "btnPresetReat";
        btnPresetReat.Size = new Size(75, 22);
        btnPresetReat.TabIndex = 11;
        btnPresetReat.Text = "REAT";
        btnPresetReat.UseVisualStyleBackColor = true;
        btnPresetReat.Click += btnPresetReat_Click;
        // 
        // grpChannelTest
        // 
        grpChannelTest.Controls.Add(btnTestRoll);
        grpChannelTest.Controls.Add(btnTestPitch);
        grpChannelTest.Controls.Add(btnTestThrottle);
        grpChannelTest.Controls.Add(pnlSticks);
        grpChannelTest.Controls.Add(channelVisualLayout);
        grpChannelTest.Controls.Add(channelInputsLayout);
        grpChannelTest.Dock = DockStyle.Fill;
        grpChannelTest.Location = new Point(772, 13);
        grpChannelTest.Name = "grpChannelTest";
        grpChannelTest.Padding = new Padding(10);
        grpChannelTest.Size = new Size(694, 201);
        grpChannelTest.TabIndex = 0;
        grpChannelTest.TabStop = false;
        grpChannelTest.Text = "Channel Test";
        // 
        // btnTestRoll
        // 
        btnTestRoll.Location = new Point(0, 30);
        btnTestRoll.Name = "btnTestRoll";
        btnTestRoll.Size = new Size(78, 29);
        btnTestRoll.TabIndex = 0;
        btnTestRoll.Text = "Roll";
        btnTestRoll.UseVisualStyleBackColor = true;
        btnTestRoll.Click += btnTestRoll_Click;
        // 
        // btnTestPitch
        // 
        btnTestPitch.Location = new Point(0, 62);
        btnTestPitch.Name = "btnTestPitch";
        btnTestPitch.Size = new Size(78, 29);
        btnTestPitch.TabIndex = 1;
        btnTestPitch.Text = "Pitch";
        btnTestPitch.UseVisualStyleBackColor = true;
        btnTestPitch.Click += btnTestPitch_Click;
        // 
        // btnTestThrottle
        // 
        btnTestThrottle.Location = new Point(0, 97);
        btnTestThrottle.Name = "btnTestThrottle";
        btnTestThrottle.Size = new Size(78, 29);
        btnTestThrottle.TabIndex = 2;
        btnTestThrottle.Text = "Throttle";
        btnTestThrottle.UseVisualStyleBackColor = true;
        btnTestThrottle.Click += btnTestThrottle_Click;
        // 
        // pnlSticks
        // 
        pnlSticks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlSticks.Controls.Add(pnlLeftStick);
        pnlSticks.Controls.Add(pnlRightStick);
        pnlSticks.Location = new Point(99, 30);
        pnlSticks.Name = "pnlSticks";
        pnlSticks.Size = new Size(322, 103);
        pnlSticks.TabIndex = 2;
        // 
        // pnlLeftStick
        // 
        pnlLeftStick.BorderStyle = BorderStyle.FixedSingle;
        pnlLeftStick.Controls.Add(pnlLeftStickIndicator);
        pnlLeftStick.Location = new Point(0, 0);
        pnlLeftStick.Name = "pnlLeftStick";
        pnlLeftStick.Size = new Size(162, 103);
        pnlLeftStick.TabIndex = 0;
        // 
        // pnlLeftStickIndicator
        // 
        pnlLeftStickIndicator.Anchor = AnchorStyles.None;
        pnlLeftStickIndicator.BackColor = Color.Red;
        pnlLeftStickIndicator.Location = new Point(76, 50);
        pnlLeftStickIndicator.Name = "pnlLeftStickIndicator";
        pnlLeftStickIndicator.Size = new Size(10, 10);
        pnlLeftStickIndicator.TabIndex = 0;
        // 
        // pnlRightStick
        // 
        pnlRightStick.BorderStyle = BorderStyle.FixedSingle;
        pnlRightStick.Controls.Add(pnlRightStickIndicator);
        pnlRightStick.Location = new Point(170, 0);
        pnlRightStick.Name = "pnlRightStick";
        pnlRightStick.Size = new Size(154, 103);
        pnlRightStick.TabIndex = 1;
        // 
        // pnlRightStickIndicator
        // 
        pnlRightStickIndicator.Anchor = AnchorStyles.None;
        pnlRightStickIndicator.BackColor = Color.Blue;
        pnlRightStickIndicator.Location = new Point(72, 50);
        pnlRightStickIndicator.Name = "pnlRightStickIndicator";
        pnlRightStickIndicator.Size = new Size(10, 10);
        pnlRightStickIndicator.TabIndex = 0;
        // 
        // channelVisualLayout
        // 
        channelVisualLayout.Controls.Add(lblChannelVisualTitle);
        channelVisualLayout.Controls.Add(lblChannelVisual);
        channelVisualLayout.Controls.Add(lblChannelValueTitle);
        channelVisualLayout.Controls.Add(lblChannelValue);
        channelVisualLayout.Controls.Add(lblRollAngleTitle);
        channelVisualLayout.Controls.Add(lblRollAngle);
        channelVisualLayout.Controls.Add(lblPitchAngleTitle);
        channelVisualLayout.Controls.Add(lblPitchAngle);
        channelVisualLayout.Location = new Point(455, 30);
        channelVisualLayout.Name = "channelVisualLayout";
        channelVisualLayout.Size = new Size(195, 104);
        channelVisualLayout.TabIndex = 1;
        // 
        // lblChannelVisualTitle
        // 
        lblChannelVisualTitle.Anchor = AnchorStyles.Left;
        lblChannelVisualTitle.Location = new Point(7, 7);
        lblChannelVisualTitle.Name = "lblChannelVisualTitle";
        lblChannelVisualTitle.Size = new Size(42, 15);
        lblChannelVisualTitle.TabIndex = 0;
        lblChannelVisualTitle.Text = "Status:";
        // 
        // lblChannelVisual
        // 
        lblChannelVisual.Anchor = AnchorStyles.Left;
        lblChannelVisual.Location = new Point(55, 7);
        lblChannelVisual.Name = "lblChannelVisual";
        lblChannelVisual.Size = new Size(26, 15);
        lblChannelVisual.TabIndex = 1;
        lblChannelVisual.Text = "Idle";
        // 
        // lblChannelValueTitle
        // 
        lblChannelValueTitle.Anchor = AnchorStyles.Left;
        lblChannelValueTitle.Location = new Point(7, 31);
        lblChannelValueTitle.Name = "lblChannelValueTitle";
        lblChannelValueTitle.Size = new Size(38, 15);
        lblChannelValueTitle.TabIndex = 2;
        lblChannelValueTitle.Text = "Pulse:";
        // 
        // lblChannelValue
        // 
        lblChannelValue.Anchor = AnchorStyles.Left;
        lblChannelValue.Location = new Point(51, 30);
        lblChannelValue.Name = "lblChannelValue";
        lblChannelValue.Size = new Size(46, 15);
        lblChannelValue.TabIndex = 3;
        lblChannelValue.Text = "1500 us";
        // 
        // lblRollAngleTitle
        // 
        lblRollAngleTitle.Anchor = AnchorStyles.Left;
        lblRollAngleTitle.Location = new Point(7, 55);
        lblRollAngleTitle.Name = "lblRollAngleTitle";
        lblRollAngleTitle.Size = new Size(62, 15);
        lblRollAngleTitle.TabIndex = 4;
        lblRollAngleTitle.Text = "Roll angle:";
        // 
        // lblRollAngle
        // 
        lblRollAngle.Anchor = AnchorStyles.Left;
        lblRollAngle.Location = new Point(75, 55);
        lblRollAngle.Name = "lblRollAngle";
        lblRollAngle.Size = new Size(27, 15);
        lblRollAngle.TabIndex = 5;
        lblRollAngle.Text = "0.0°";
        // 
        // lblPitchAngleTitle
        // 
        lblPitchAngleTitle.Anchor = AnchorStyles.Left;
        lblPitchAngleTitle.Location = new Point(7, 79);
        lblPitchAngleTitle.Name = "lblPitchAngleTitle";
        lblPitchAngleTitle.Size = new Size(69, 15);
        lblPitchAngleTitle.TabIndex = 6;
        lblPitchAngleTitle.Text = "Pitch angle:";
        // 
        // lblPitchAngle
        // 
        lblPitchAngle.Anchor = AnchorStyles.Left;
        lblPitchAngle.Location = new Point(75, 79);
        lblPitchAngle.Name = "lblPitchAngle";
        lblPitchAngle.Size = new Size(27, 15);
        lblPitchAngle.TabIndex = 7;
        lblPitchAngle.Text = "0.0°";
        // 
        // channelInputsLayout
        // 
        channelInputsLayout.Controls.Add(lblTargetDeg);
        channelInputsLayout.Controls.Add(nudTargetDeg);
        channelInputsLayout.Controls.Add(lblThrottleUs);
        channelInputsLayout.Controls.Add(nudThrottleUs);
        channelInputsLayout.Controls.Add(lblSettleSec);
        channelInputsLayout.Controls.Add(nudSettleSec);
        channelInputsLayout.Controls.Add(lblBaselineSec);
        channelInputsLayout.Controls.Add(nudBaselineSec);
        channelInputsLayout.Location = new Point(1, 140);
        channelInputsLayout.Name = "channelInputsLayout";
        channelInputsLayout.Size = new Size(649, 48);
        channelInputsLayout.TabIndex = 3;
        // 
        // lblTargetDeg
        // 
        lblTargetDeg.Anchor = AnchorStyles.None;
        lblTargetDeg.Location = new Point(3, 0);
        lblTargetDeg.Name = "lblTargetDeg";
        lblTargetDeg.Size = new Size(60, 35);
        lblTargetDeg.TabIndex = 0;
        lblTargetDeg.Text = "Target Δ°";
        lblTargetDeg.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblSettleSec
        // 
        lblSettleSec.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        lblSettleSec.Location = new Point(268, 0);
        lblSettleSec.Name = "lblSettleSec";
        lblSettleSec.Size = new Size(81, 35);
        lblSettleSec.TabIndex = 2;
        lblSettleSec.Text = "Pre-wait (sec)";
        lblSettleSec.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudSettleSec
        // 
        nudSettleSec.Anchor = AnchorStyles.None;
        nudSettleSec.DecimalPlaces = 1;
        nudSettleSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudSettleSec.Location = new Point(355, 6);
        nudSettleSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudSettleSec.Name = "nudSettleSec";
        nudSettleSec.Size = new Size(68, 23);
        nudSettleSec.TabIndex = 3;
        nudSettleSec.TextAlign = HorizontalAlignment.Center;
        nudSettleSec.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblBaselineSec
        // 
        lblBaselineSec.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        lblBaselineSec.Location = new Point(429, 0);
        lblBaselineSec.Name = "lblBaselineSec";
        lblBaselineSec.Size = new Size(125, 35);
        lblBaselineSec.TabIndex = 4;
        lblBaselineSec.Text = "Seconds on Target Δ°";
        lblBaselineSec.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudBaselineSec
        // 
        nudBaselineSec.DecimalPlaces = 1;
        nudBaselineSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudBaselineSec.Location = new Point(560, 3);
        nudBaselineSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudBaselineSec.Name = "nudBaselineSec";
        nudBaselineSec.Size = new Size(50, 23);
        nudBaselineSec.TabIndex = 5;
        nudBaselineSec.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblThrottleUs
        // 
        lblThrottleUs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        lblThrottleUs.Location = new Point(132, 0);
        lblThrottleUs.Name = "lblThrottleUs";
        lblThrottleUs.Size = new Size(74, 35);
        lblThrottleUs.TabIndex = 6;
        lblThrottleUs.Text = "Throttle";
        lblThrottleUs.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudThrottleUs
        // 
        nudThrottleUs.Increment = new decimal(new int[] { 10, 0, 0, 0 });
        nudThrottleUs.Location = new Point(212, 3);
        nudThrottleUs.Maximum = new decimal(new int[] { 1300, 0, 0, 0 });
        nudThrottleUs.Minimum = new decimal(new int[] { 1150, 0, 0, 0 });
        nudThrottleUs.Name = "nudThrottleUs";
        nudThrottleUs.Size = new Size(50, 23);
        nudThrottleUs.TabIndex = 7;
        nudThrottleUs.Value = new decimal(new int[] { 1150, 0, 0, 0 });
        // 
        // nudTargetDeg
        // 
        nudTargetDeg.Anchor = AnchorStyles.None;
        nudTargetDeg.DecimalPlaces = 1;
        nudTargetDeg.Location = new Point(69, 3);
        nudTargetDeg.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
        nudTargetDeg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTargetDeg.Name = "nudTargetDeg";
        nudTargetDeg.Size = new Size(57, 23);
        nudTargetDeg.TabIndex = 1;
        nudTargetDeg.TextAlign = HorizontalAlignment.Center;
        nudTargetDeg.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // grpPidWorkflow
        // 
        grpPidWorkflow.Controls.Add(btnTuneRoll);
        grpPidWorkflow.Controls.Add(lblActiveAxis);
        grpPidWorkflow.Controls.Add(lblActiveAxisTitle);
        grpPidWorkflow.Controls.Add(btnTunePitch);
        grpPidWorkflow.Controls.Add(btnRetestAxis);
        grpPidWorkflow.Controls.Add(lblPidValuesTitle);
        grpPidWorkflow.Controls.Add(btnFinishAxis);
        grpPidWorkflow.Controls.Add(btnApplyRecommendedPid);
        grpPidWorkflow.Controls.Add(cmbManualAxis);
        grpPidWorkflow.Controls.Add(cmbManualGain);
        grpPidWorkflow.Controls.Add(cmbManualPoints);
        grpPidWorkflow.Controls.Add(btnManualPidMinus);
        grpPidWorkflow.Controls.Add(btnManualPidPlus);
        grpPidWorkflow.Controls.Add(btnReadFcPid);
        grpPidWorkflow.Controls.Add(btnSaveFcPid);
        grpPidWorkflow.Location = new Point(13, 220);
        grpPidWorkflow.Name = "grpPidWorkflow";
        grpPidWorkflow.Padding = new Padding(10);
        grpPidWorkflow.Size = new Size(428, 139);
        grpPidWorkflow.TabIndex = 2;
        grpPidWorkflow.TabStop = false;
        grpPidWorkflow.Text = "INAV PID / FF Adjustment";
        // 
        // btnTuneRoll
        // 
        btnTuneRoll.Location = new Point(896, 39);
        btnTuneRoll.Name = "btnTuneRoll";
        btnTuneRoll.Size = new Size(98, 34);
        btnTuneRoll.TabIndex = 0;
        btnTuneRoll.Text = "Roll";
        btnTuneRoll.UseVisualStyleBackColor = true;
        btnTuneRoll.Click += btnTuneRoll_Click;
        // 
        // lblActiveAxis
        // 
        lblActiveAxis.Anchor = AnchorStyles.Left;
        lblActiveAxis.Location = new Point(559, 108);
        lblActiveAxis.Name = "lblActiveAxis";
        lblActiveAxis.Size = new Size(48, 15);
        lblActiveAxis.TabIndex = 2;
        lblActiveAxis.Text = "N/A";
        // 
        // lblActiveAxisTitle
        // 
        lblActiveAxisTitle.Anchor = AnchorStyles.Left;
        lblActiveAxisTitle.Location = new Point(481, 108);
        lblActiveAxisTitle.Name = "lblActiveAxisTitle";
        lblActiveAxisTitle.Size = new Size(75, 15);
        lblActiveAxisTitle.TabIndex = 1;
        lblActiveAxisTitle.Text = "Active Axis:";
        lblActiveAxisTitle.Click += lblActiveAxisTitle_Click;
        // 
        // btnTunePitch
        // 
        btnTunePitch.Location = new Point(1002, 39);
        btnTunePitch.Name = "btnTunePitch";
        btnTunePitch.Size = new Size(98, 34);
        btnTunePitch.TabIndex = 1;
        btnTunePitch.Text = "Pitch";
        btnTunePitch.UseVisualStyleBackColor = true;
        btnTunePitch.Click += btnTunePitch_Click;
        // 
        // btnRetestAxis
        // 
        btnRetestAxis.Location = new Point(896, 80);
        btnRetestAxis.Name = "btnRetestAxis";
        btnRetestAxis.Size = new Size(98, 34);
        btnRetestAxis.TabIndex = 2;
        btnRetestAxis.Text = "Re-test";
        btnRetestAxis.UseVisualStyleBackColor = true;
        btnRetestAxis.Click += btnRetestAxis_Click;
        // 
        // lblPidValuesTitle
        // 
        lblPidValuesTitle.Anchor = AnchorStyles.Left;
        lblPidValuesTitle.Location = new Point(18, 16);
        lblPidValuesTitle.Name = "lblPidValuesTitle";
        lblPidValuesTitle.Size = new Size(140, 15);
        lblPidValuesTitle.TabIndex = 4;
        lblPidValuesTitle.Text = "Send / Manual PID";
        // 
        // btnFinishAxis
        // 
        btnFinishAxis.Location = new Point(1002, 80);
        btnFinishAxis.Name = "btnFinishAxis";
        btnFinishAxis.Size = new Size(98, 34);
        btnFinishAxis.TabIndex = 3;
        btnFinishAxis.Text = "Finish";
        btnFinishAxis.UseVisualStyleBackColor = true;
        btnFinishAxis.Click += btnFinishAxis_Click;
        // 
        // btnApplyRecommendedPid
        // 
        btnApplyRecommendedPid.Location = new Point(430, 39);
        btnApplyRecommendedPid.Name = "btnApplyRecommendedPid";
        btnApplyRecommendedPid.Size = new Size(170, 34);
        btnApplyRecommendedPid.TabIndex = 4;
        btnApplyRecommendedPid.Text = "Send PID";
        btnApplyRecommendedPid.UseVisualStyleBackColor = true;
        btnApplyRecommendedPid.Click += btnApplyRecommendedPid_Click;
        // 
        // cmbManualAxis
        // 
        cmbManualAxis.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualAxis.FormattingEnabled = true;
        cmbManualAxis.Items.AddRange(new object[] { "Roll", "Pitch" });
        cmbManualAxis.Location = new Point(18, 72);
        cmbManualAxis.Name = "cmbManualAxis";
        cmbManualAxis.Size = new Size(80, 23);
        cmbManualAxis.TabIndex = 5;
        // 
        // cmbManualGain
        // 
        cmbManualGain.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualGain.FormattingEnabled = true;
        cmbManualGain.Items.AddRange(new object[] { "P", "I", "D" });
        cmbManualGain.Location = new Point(104, 72);
        cmbManualGain.Name = "cmbManualGain";
        cmbManualGain.Size = new Size(56, 23);
        cmbManualGain.TabIndex = 6;
        // 
        // cmbManualPoints
        // 
        cmbManualPoints.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualPoints.FormattingEnabled = true;
        cmbManualPoints.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
        cmbManualPoints.Location = new Point(166, 72);
        cmbManualPoints.Name = "cmbManualPoints";
        cmbManualPoints.Size = new Size(58, 23);
        cmbManualPoints.TabIndex = 7;
        // 
        // btnManualPidMinus
        // 
        btnManualPidMinus.Location = new Point(230, 69);
        btnManualPidMinus.Name = "btnManualPidMinus";
        btnManualPidMinus.Size = new Size(82, 32);
        btnManualPidMinus.TabIndex = 8;
        btnManualPidMinus.Text = "PID -";
        btnManualPidMinus.UseVisualStyleBackColor = true;
        btnManualPidMinus.Click += btnManualPidMinus_Click;
        // 
        // btnManualPidPlus
        // 
        btnManualPidPlus.Location = new Point(318, 69);
        btnManualPidPlus.Name = "btnManualPidPlus";
        btnManualPidPlus.Size = new Size(82, 32);
        btnManualPidPlus.TabIndex = 9;
        btnManualPidPlus.Text = "PID +";
        btnManualPidPlus.UseVisualStyleBackColor = true;
        btnManualPidPlus.Click += btnManualPidPlus_Click;
        // 
        // btnReadFcPid
        // 
        btnReadFcPid.Location = new Point(430, 80);
        btnReadFcPid.Name = "btnReadFcPid";
        btnReadFcPid.Size = new Size(170, 34);
        btnReadFcPid.TabIndex = 10;
        btnReadFcPid.Text = "Read FC";
        btnReadFcPid.UseVisualStyleBackColor = true;
        btnReadFcPid.Click += btnReadFcPid_Click;
        // 
        // btnSaveFcPid
        // 
        btnSaveFcPid.Location = new Point(430, 121);
        btnSaveFcPid.Name = "btnSaveFcPid";
        btnSaveFcPid.Size = new Size(170, 34);
        btnSaveFcPid.TabIndex = 11;
        btnSaveFcPid.Text = "Save to FC";
        btnSaveFcPid.UseVisualStyleBackColor = true;
        btnSaveFcPid.Click += btnSaveFcPid_Click;
        // 
        // lvTuningRuns
        // 
        lvTuningRuns.Columns.AddRange(new ColumnHeader[] { colRun, colAxis, colScore, colDecision });
        lvTuningRuns.FullRowSelect = true;
        lvTuningRuns.Location = new Point(447, 220);
        lvTuningRuns.Name = "lvTuningRuns";
        lvTuningRuns.Size = new Size(319, 124);
        lvTuningRuns.TabIndex = 1;
        lvTuningRuns.UseCompatibleStateImageBehavior = false;
        lvTuningRuns.View = View.Details;
        // 
        // colRun
        // 
        colRun.Text = "Run";
        colRun.Width = 55;
        // 
        // colAxis
        // 
        colAxis.Text = "Axis";
        colAxis.Width = 70;
        // 
        // colScore
        // 
        colScore.Text = "Score";
        colScore.Width = 70;
        // 
        // colDecision
        // 
        colDecision.Text = "Recommendation";
        colDecision.Width = 430;
        // 
        // grpTelemetry
        // 
        grpTelemetry.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        grpTelemetry.Controls.Add(telemetryButtonLayout);
        grpTelemetry.Controls.Add(telemetryValueLayout);
        grpTelemetry.Location = new Point(772, 220);
        grpTelemetry.Name = "grpTelemetry";
        grpTelemetry.Padding = new Padding(10);
        grpTelemetry.Size = new Size(694, 130);
        grpTelemetry.TabIndex = 1;
        grpTelemetry.TabStop = false;
        grpTelemetry.Text = "Telemetry";
        // 
        // telemetryButtonLayout
        // 
        telemetryButtonLayout.Controls.Add(btnTelemetryStart);
        telemetryButtonLayout.Controls.Add(btnTelemetryStop);
        telemetryButtonLayout.Controls.Add(btnTelemetrySnapshot);
        telemetryButtonLayout.Location = new Point(13, 29);
        telemetryButtonLayout.Name = "telemetryButtonLayout";
        telemetryButtonLayout.Size = new Size(548, 32);
        telemetryButtonLayout.TabIndex = 0;
        // 
        // btnTelemetryStart
        // 
        btnTelemetryStart.Location = new Point(3, 3);
        btnTelemetryStart.Name = "btnTelemetryStart";
        btnTelemetryStart.Size = new Size(98, 29);
        btnTelemetryStart.TabIndex = 0;
        btnTelemetryStart.Text = "Start Live";
        btnTelemetryStart.UseVisualStyleBackColor = true;
        btnTelemetryStart.Click += btnTelemetryStart_Click;
        // 
        // btnTelemetryStop
        // 
        btnTelemetryStop.Enabled = false;
        btnTelemetryStop.Location = new Point(107, 3);
        btnTelemetryStop.Name = "btnTelemetryStop";
        btnTelemetryStop.Size = new Size(98, 29);
        btnTelemetryStop.TabIndex = 1;
        btnTelemetryStop.Text = "Stop Live";
        btnTelemetryStop.UseVisualStyleBackColor = true;
        btnTelemetryStop.Click += btnTelemetryStop_Click;
        // 
        // btnTelemetrySnapshot
        // 
        btnTelemetrySnapshot.Location = new Point(211, 3);
        btnTelemetrySnapshot.Name = "btnTelemetrySnapshot";
        btnTelemetrySnapshot.Size = new Size(98, 29);
        btnTelemetrySnapshot.TabIndex = 2;
        btnTelemetrySnapshot.Text = "Snapshot";
        btnTelemetrySnapshot.UseVisualStyleBackColor = true;
        btnTelemetrySnapshot.Click += btnTelemetrySnapshot_Click;
        // 
        // telemetryValueLayout
        // 
        telemetryValueLayout.Controls.Add(lblTelemetryRollTitle);
        telemetryValueLayout.Controls.Add(lblTelemetryRoll);
        telemetryValueLayout.Controls.Add(lblTelemetryPitchTitle);
        telemetryValueLayout.Controls.Add(lblTelemetryPitch);
        telemetryValueLayout.Controls.Add(lblTelemetryYawTitle);
        telemetryValueLayout.Controls.Add(lblTelemetryYaw);
        telemetryValueLayout.Location = new Point(13, 67);
        telemetryValueLayout.Name = "telemetryValueLayout";
        telemetryValueLayout.Size = new Size(548, 25);
        telemetryValueLayout.TabIndex = 1;
        // 
        // lblTelemetryRollTitle
        // 
        lblTelemetryRollTitle.Anchor = AnchorStyles.Left;
        lblTelemetryRollTitle.Location = new Point(3, 5);
        lblTelemetryRollTitle.Name = "lblTelemetryRollTitle";
        lblTelemetryRollTitle.Size = new Size(30, 15);
        lblTelemetryRollTitle.TabIndex = 0;
        lblTelemetryRollTitle.Text = "Roll:";
        // 
        // lblTelemetryRoll
        // 
        lblTelemetryRoll.Anchor = AnchorStyles.Left;
        lblTelemetryRoll.Location = new Point(38, 5);
        lblTelemetryRoll.Name = "lblTelemetryRoll";
        lblTelemetryRoll.Size = new Size(48, 15);
        lblTelemetryRoll.TabIndex = 1;
        lblTelemetryRoll.Text = "--.- deg";
        // 
        // lblTelemetryPitchTitle
        // 
        lblTelemetryPitchTitle.Anchor = AnchorStyles.Left;
        lblTelemetryPitchTitle.Location = new Point(128, 5);
        lblTelemetryPitchTitle.Name = "lblTelemetryPitchTitle";
        lblTelemetryPitchTitle.Size = new Size(37, 15);
        lblTelemetryPitchTitle.TabIndex = 2;
        lblTelemetryPitchTitle.Text = "Pitch:";
        // 
        // lblTelemetryPitch
        // 
        lblTelemetryPitch.Anchor = AnchorStyles.Left;
        lblTelemetryPitch.Location = new Point(166, 5);
        lblTelemetryPitch.Name = "lblTelemetryPitch";
        lblTelemetryPitch.Size = new Size(48, 15);
        lblTelemetryPitch.TabIndex = 3;
        lblTelemetryPitch.Text = "--.- deg";
        // 
        // lblTelemetryYawTitle
        // 
        lblTelemetryYawTitle.Anchor = AnchorStyles.Left;
        lblTelemetryYawTitle.Location = new Point(256, 5);
        lblTelemetryYawTitle.Name = "lblTelemetryYawTitle";
        lblTelemetryYawTitle.Size = new Size(31, 15);
        lblTelemetryYawTitle.TabIndex = 4;
        lblTelemetryYawTitle.Text = "Yaw:";
        // 
        // lblTelemetryYaw
        // 
        lblTelemetryYaw.Anchor = AnchorStyles.Left;
        lblTelemetryYaw.Location = new Point(291, 5);
        lblTelemetryYaw.Name = "lblTelemetryYaw";
        lblTelemetryYaw.Size = new Size(48, 15);
        lblTelemetryYaw.TabIndex = 5;
        lblTelemetryYaw.Text = "--.- deg";
        // 
        // pnlScoreChart
        // 
        pnlScoreChart.BackColor = Color.White;
        pnlScoreChart.BorderStyle = BorderStyle.FixedSingle;
        rootLayout.SetColumnSpan(pnlScoreChart, 3);
        pnlScoreChart.Controls.Add(txtPidValues);
        pnlScoreChart.Controls.Add(txtPidRecommendation);
        pnlScoreChart.Dock = DockStyle.Fill;
        pnlScoreChart.Location = new Point(13, 365);
        pnlScoreChart.Name = "pnlScoreChart";
        pnlScoreChart.Size = new Size(1453, 570);
        pnlScoreChart.TabIndex = 0;
        pnlScoreChart.Paint += pnlScoreChart_Paint;
        // 
        // txtPidValues
        // 
        txtPidValues.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        txtPidValues.Location = new Point(993, 33);
        txtPidValues.Multiline = true;
        txtPidValues.Name = "txtPidValues";
        txtPidValues.ReadOnly = true;
        txtPidValues.Size = new Size(297, 509);
        txtPidValues.TabIndex = 5;
        txtPidValues.Text = "Roll P/I/D: --/--/--\r\nPitch P/I/D: --/--/--";
        // 
        // txtPidRecommendation
        // 
        txtPidRecommendation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        txtPidRecommendation.Location = new Point(640, 360);
        txtPidRecommendation.Multiline = true;
        txtPidRecommendation.Name = "txtPidRecommendation";
        txtPidRecommendation.ReadOnly = true;
        txtPidRecommendation.Size = new Size(297, 124);
        txtPidRecommendation.TabIndex = 3;
        txtPidRecommendation.Text = "Tune Roll or Pitch to generate a recommendation.";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1479, 948);
        Controls.Add(rootLayout);
        MinimumSize = new Size(898, 475);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Drone PID Tuning Assistant (WinForms)";
        rootLayout.ResumeLayout(false);
        grpUsb.ResumeLayout(false);
        grpUsb.PerformLayout();
        grpMapping.ResumeLayout(false);
        grpChannelTest.ResumeLayout(false);
        pnlSticks.ResumeLayout(false);
        pnlLeftStick.ResumeLayout(false);
        pnlRightStick.ResumeLayout(false);
        channelVisualLayout.ResumeLayout(false);
        channelInputsLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).EndInit();
        grpPidWorkflow.ResumeLayout(false);
        grpTelemetry.ResumeLayout(false);
        telemetryButtonLayout.ResumeLayout(false);
        telemetryValueLayout.ResumeLayout(false);
        pnlScoreChart.ResumeLayout(false);
        pnlScoreChart.PerformLayout();
        ResumeLayout(false);
    }

    private TableLayoutPanel rootLayout;
    private GroupBox grpUsb;
    private Label lblPort;
    private ComboBox cboPort;
    private ComboBox cboBaud;
    private Button btnFcConnect;
    private Button btnFcDisconnect;
    private Label lblArduinoPort;
    private ComboBox cboArduinoPort;
    private ComboBox cboArduinoBaud;
    private Label lblTrainerPin;
    private ComboBox cboTrainerPin;
    private CheckBox chkSimulation;
    private Button btnArduinoConnect;
    private Button btnArduinoDisconnect;
    private Button btnRefreshPorts;
    private GroupBox grpMapping;
    private Label lblRoll;
    private ComboBox cboCH1;
    private Label lblPitch;
    private ComboBox cboCH2;
    private Label lblThrottle;
    private ComboBox cboCH3;
    private Label lblCh4;
    private ComboBox cboCH4;
    private Button btnApplyMapping;
    private Button btnPresetAetr;
    private Button btnPresetRtae;
    private Button btnPresetReat;
    private GroupBox grpChannelTest;
    private GroupBox grpTelemetry;
    private GroupBox grpPidWorkflow;
    private Button btnTuneRoll;
    private Button btnTunePitch;
    private Button btnRetestAxis;
    private Button btnFinishAxis;
    private Button btnApplyRecommendedPid;
    private ComboBox cmbManualAxis;
    private ComboBox cmbManualGain;
    private ComboBox cmbManualPoints;
    private Button btnManualPidMinus;
    private Button btnManualPidPlus;
    private Button btnReadFcPid;
    private Button btnSaveFcPid;
    private Label lblActiveAxisTitle;
    private Label lblActiveAxis;
    private Label lblPidValuesTitle;
    private TextBox txtPidValues;
    private TextBox txtPidRecommendation;
    private Panel pnlScoreChart;
    private ListView lvTuningRuns;
    private ColumnHeader colRun;
    private ColumnHeader colAxis;
    private ColumnHeader colScore;
    private ColumnHeader colDecision;
    private Panel telemetryButtonLayout;
    private Button btnTelemetryStart;
    private Button btnTelemetryStop;
    private Button btnTelemetrySnapshot;
    private Panel telemetryValueLayout;
    private Label lblTelemetryRollTitle;
    private Label lblTelemetryRoll;
    private Label lblTelemetryPitchTitle;
    private Label lblTelemetryPitch;
    private Label lblTelemetryYawTitle;
    private Label lblTelemetryYaw;
    private Panel channelVisualLayout;
    private Label lblChannelVisualTitle;
    private Label lblChannelVisual;
    private Label lblChannelValueTitle;
    private Label lblChannelValue;
    private Label lblRollAngleTitle;
    private Label lblRollAngle;
    private Label lblPitchAngleTitle;
    private Label lblPitchAngle;
    private Label lblFCStatus;
    private Label lblArduinoStatus;
    private Button btnTestRoll;
    private Button btnTestPitch;
    private Button btnTestThrottle;
    private Panel pnlSticks;
    private Panel pnlLeftStick;
    private Panel pnlLeftStickIndicator;
    private Panel pnlRightStick;
    private Panel pnlRightStickIndicator;
    private FlowLayoutPanel channelInputsLayout;
    private Label lblTargetDeg;
    private Label lblSettleSec;
    private NumericUpDown nudSettleSec;
    private Label lblBaselineSec;
    private NumericUpDown nudBaselineSec;
    private Label lblThrottleUs;
    private NumericUpDown nudThrottleUs;
    private NumericUpDown nudTargetDeg;
}



