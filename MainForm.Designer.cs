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
        btnSimulationToggle = new Button();
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
        channelInputsLayout = new TableLayoutPanel();
        lblTargetDeg = new Label();
        nudTargetDeg = new NumericUpDown();
        lblThrottleUs = new Label();
        nudThrottleUs = new NumericUpDown();
        lblSettleSec = new Label();
        nudSettleSec = new NumericUpDown();
        lblBaselineSec = new Label();
        nudBaselineSec = new NumericUpDown();
        grpPidWorkflow = new GroupBox();
        tblPidMatrix = new TableLayoutPanel();
        lblPidHdrP = new Label();
        lblPidHdrI = new Label();
        lblPidHdrD = new Label();
        lblPidHdrFf = new Label();
        lblPidRowRoll = new Label();
        lblPidRowPitch = new Label();
        lblPidRowYaw = new Label();
        txtRollP = new TextBox();
        txtRollI = new TextBox();
        txtRollD = new TextBox();
        txtRollFf = new TextBox();
        txtPitchP = new TextBox();
        txtPitchI = new TextBox();
        txtPitchD = new TextBox();
        txtPitchFf = new TextBox();
        txtYawP = new TextBox();
        txtYawI = new TextBox();
        txtYawD = new TextBox();
        txtYawFf = new TextBox();
        btnPidEditable = new Button();
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
        cmbManualAxis2 = new ComboBox();
        cmbManualGain2 = new ComboBox();
        cmbManualPoints2 = new ComboBox();
        btnManualPidMinus2 = new Button();
        btnManualPidPlus2 = new Button();
        btnReadFcPid = new Button();
        btnSaveFcPid = new Button();
        pnlScoreChart = new Panel();
        lvTuningRuns = new ListView();
        colRun = new ColumnHeader();
        colAxis = new ColumnHeader();
        colScore = new ColumnHeader();
        colDecision = new ColumnHeader();
        rootLayout.SuspendLayout();
        grpUsb.SuspendLayout();
        grpMapping.SuspendLayout();
        grpChannelTest.SuspendLayout();
        pnlSticks.SuspendLayout();
        pnlLeftStick.SuspendLayout();
        pnlRightStick.SuspendLayout();
        channelVisualLayout.SuspendLayout();
        channelInputsLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).BeginInit();
        grpPidWorkflow.SuspendLayout();
        tblPidMatrix.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 3;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.23545F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.25397F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.4444427F));
        rootLayout.Controls.Add(grpUsb, 0, 0);
        rootLayout.Controls.Add(grpMapping, 1, 0);
        rootLayout.Controls.Add(grpChannelTest, 2, 0);
        rootLayout.Controls.Add(grpPidWorkflow, 0, 1);
        rootLayout.Controls.Add(pnlScoreChart, 0, 2);
        rootLayout.Controls.Add(lvTuningRuns, 2, 1);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(10);
        rootLayout.RowCount = 3;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 22.3060341F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 18.64224F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 59.0517235F));
        rootLayout.Size = new Size(1532, 948);
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
        grpUsb.Controls.Add(btnSimulationToggle);
        grpUsb.Controls.Add(btnArduinoConnect);
        grpUsb.Controls.Add(btnArduinoDisconnect);
        grpUsb.Controls.Add(lblFCStatus);
        grpUsb.Dock = DockStyle.Fill;
        grpUsb.Location = new Point(13, 13);
        grpUsb.Name = "grpUsb";
        grpUsb.Padding = new Padding(10);
        grpUsb.Size = new Size(557, 201);
        grpUsb.TabIndex = 0;
        grpUsb.TabStop = false;
        grpUsb.Text = "Serial Ports";
        // 
        // lblPort
        // 
        lblPort.Anchor = AnchorStyles.Left;
        lblPort.Location = new Point(16, 32);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(62, 24);
        lblPort.TabIndex = 0;
        lblPort.Text = "FC USB";
        // 
        // lblArduinoStatus
        // 
        lblArduinoStatus.Location = new Point(272, 136);
        lblArduinoStatus.Margin = new Padding(3, 3, 3, 0);
        lblArduinoStatus.Name = "lblArduinoStatus";
        lblArduinoStatus.Size = new Size(247, 24);
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
        btnFcDisconnect.Size = new Size(85, 24);
        btnFcDisconnect.TabIndex = 4;
        btnFcDisconnect.Text = "Disconnect";
        btnFcDisconnect.UseVisualStyleBackColor = true;
        btnFcDisconnect.Click += btnDisconnect_Click;
        // 
        // btnRefreshPorts
        // 
        btnRefreshPorts.ImageAlign = ContentAlignment.MiddleLeft;
        btnRefreshPorts.Location = new Point(376, 32);
        btnRefreshPorts.Name = "btnRefreshPorts";
        btnRefreshPorts.Size = new Size(120, 24);
        btnRefreshPorts.TabIndex = 5;
        btnRefreshPorts.Text = "Refresh";
        btnRefreshPorts.UseVisualStyleBackColor = true;
        btnRefreshPorts.Click += btnRefreshPorts_Click;
        // 
        // lblArduinoPort
        // 
        lblArduinoPort.Anchor = AnchorStyles.Left;
        lblArduinoPort.Location = new Point(16, 64);
        lblArduinoPort.Name = "lblArduinoPort";
        lblArduinoPort.Size = new Size(62, 26);
        lblArduinoPort.TabIndex = 7;
        lblArduinoPort.Text = "Arduino";
        // 
        // cboArduinoPort
        // 
        cboArduinoPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoPort.FormattingEnabled = true;
        cboArduinoPort.Location = new Point(80, 66);
        cboArduinoPort.Name = "cboArduinoPort";
        cboArduinoPort.Size = new Size(68, 23);
        cboArduinoPort.TabIndex = 8;
        // 
        // cboArduinoBaud
        // 
        cboArduinoBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoBaud.FormattingEnabled = true;
        cboArduinoBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboArduinoBaud.Location = new Point(149, 66);
        cboArduinoBaud.Name = "cboArduinoBaud";
        cboArduinoBaud.Size = new Size(64, 23);
        cboArduinoBaud.TabIndex = 9;
        // 
        // lblTrainerPin
        // 
        lblTrainerPin.Location = new Point(8, 96);
        lblTrainerPin.Name = "lblTrainerPin";
        lblTrainerPin.Size = new Size(62, 23);
        lblTrainerPin.TabIndex = 15;
        lblTrainerPin.Text = "Trainer Pin";
        lblTrainerPin.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cboTrainerPin
        // 
        cboTrainerPin.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrainerPin.FormattingEnabled = true;
        cboTrainerPin.Items.AddRange(new object[] { "3", "5", "6", "9", "10", "11" });
        cboTrainerPin.Location = new Point(80, 96);
        cboTrainerPin.Name = "cboTrainerPin";
        cboTrainerPin.Size = new Size(68, 23);
        cboTrainerPin.TabIndex = 16;
        // 
        // btnSimulationToggle
        // 
        btnSimulationToggle.Location = new Point(376, 64);
        btnSimulationToggle.Name = "btnSimulationToggle";
        btnSimulationToggle.Size = new Size(123, 26);
        btnSimulationToggle.TabIndex = 17;
        btnSimulationToggle.Text = "Simulation: Off";
        btnSimulationToggle.UseVisualStyleBackColor = true;
        // 
        // btnArduinoConnect
        // 
        btnArduinoConnect.Location = new Point(217, 64);
        btnArduinoConnect.Name = "btnArduinoConnect";
        btnArduinoConnect.Size = new Size(64, 26);
        btnArduinoConnect.TabIndex = 10;
        btnArduinoConnect.Text = "Connect";
        btnArduinoConnect.UseVisualStyleBackColor = true;
        btnArduinoConnect.Click += btnArduinoConnect_Click;
        // 
        // btnArduinoDisconnect
        // 
        btnArduinoDisconnect.Location = new Point(283, 64);
        btnArduinoDisconnect.Name = "btnArduinoDisconnect";
        btnArduinoDisconnect.Size = new Size(85, 26);
        btnArduinoDisconnect.TabIndex = 11;
        btnArduinoDisconnect.Text = "Disconnect";
        btnArduinoDisconnect.UseVisualStyleBackColor = true;
        btnArduinoDisconnect.Click += btnArduinoDisconnect_Click;
        // 
        // lblFCStatus
        // 
        lblFCStatus.Anchor = AnchorStyles.Left;
        lblFCStatus.Location = new Point(13, 136);
        lblFCStatus.Margin = new Padding(3, 3, 3, 0);
        lblFCStatus.Name = "lblFCStatus";
        lblFCStatus.Size = new Size(247, 24);
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
        grpMapping.Location = new Point(576, 13);
        grpMapping.Name = "grpMapping";
        grpMapping.Padding = new Padding(10);
        grpMapping.Size = new Size(270, 201);
        grpMapping.TabIndex = 1;
        grpMapping.TabStop = false;
        grpMapping.Text = "Transmitter Channel Mapping";
        // 
        // lblRoll
        // 
        lblRoll.Anchor = AnchorStyles.Left;
        lblRoll.Location = new Point(16, 48);
        lblRoll.Name = "lblRoll";
        lblRoll.Size = new Size(45, 24);
        lblRoll.TabIndex = 0;
        lblRoll.Text = "Ch 1";
        lblRoll.TextAlign = ContentAlignment.MiddleRight;
        lblRoll.Click += lblRoll_Click;
        // 
        // cboCH1
        // 
        cboCH1.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH1.FormattingEnabled = true;
        cboCH1.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH1.Location = new Point(64, 48);
        cboCH1.Name = "cboCH1";
        cboCH1.Size = new Size(80, 23);
        cboCH1.TabIndex = 1;
        // 
        // lblPitch
        // 
        lblPitch.Anchor = AnchorStyles.Left;
        lblPitch.Location = new Point(16, 80);
        lblPitch.Name = "lblPitch";
        lblPitch.Size = new Size(45, 24);
        lblPitch.TabIndex = 2;
        lblPitch.Text = "Ch 2";
        lblPitch.TextAlign = ContentAlignment.MiddleRight;
        // 
        // cboCH2
        // 
        cboCH2.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH2.FormattingEnabled = true;
        cboCH2.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH2.Location = new Point(64, 80);
        cboCH2.Name = "cboCH2";
        cboCH2.Size = new Size(80, 23);
        cboCH2.TabIndex = 3;
        // 
        // lblThrottle
        // 
        lblThrottle.Anchor = AnchorStyles.Left;
        lblThrottle.Location = new Point(16, 112);
        lblThrottle.Name = "lblThrottle";
        lblThrottle.Size = new Size(45, 24);
        lblThrottle.TabIndex = 4;
        lblThrottle.Text = "Ch 3";
        lblThrottle.TextAlign = ContentAlignment.MiddleRight;
        // 
        // cboCH3
        // 
        cboCH3.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH3.FormattingEnabled = true;
        cboCH3.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH3.Location = new Point(64, 112);
        cboCH3.Name = "cboCH3";
        cboCH3.Size = new Size(80, 23);
        cboCH3.TabIndex = 5;
        // 
        // lblCh4
        // 
        lblCh4.Anchor = AnchorStyles.Left;
        lblCh4.Location = new Point(16, 144);
        lblCh4.Name = "lblCh4";
        lblCh4.Size = new Size(45, 24);
        lblCh4.TabIndex = 7;
        lblCh4.Text = "Ch 4";
        lblCh4.TextAlign = ContentAlignment.MiddleRight;
        // 
        // cboCH4
        // 
        cboCH4.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH4.FormattingEnabled = true;
        cboCH4.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH4.Location = new Point(64, 144);
        cboCH4.Name = "cboCH4";
        cboCH4.Size = new Size(80, 23);
        cboCH4.TabIndex = 8;
        // 
        // btnApplyMapping
        // 
        btnApplyMapping.Location = new Point(152, 48);
        btnApplyMapping.Name = "btnApplyMapping";
        btnApplyMapping.Size = new Size(80, 24);
        btnApplyMapping.TabIndex = 6;
        btnApplyMapping.Text = "Apply";
        btnApplyMapping.UseVisualStyleBackColor = true;
        btnApplyMapping.Click += btnApplyMapping_Click;
        // 
        // btnPresetAetr
        // 
        btnPresetAetr.Location = new Point(152, 80);
        btnPresetAetr.Name = "btnPresetAetr";
        btnPresetAetr.Size = new Size(80, 22);
        btnPresetAetr.TabIndex = 9;
        btnPresetAetr.Text = "AETR";
        btnPresetAetr.UseVisualStyleBackColor = true;
        btnPresetAetr.Click += btnPresetAetr_Click;
        // 
        // btnPresetRtae
        // 
        btnPresetRtae.Location = new Point(152, 112);
        btnPresetRtae.Name = "btnPresetRtae";
        btnPresetRtae.Size = new Size(80, 24);
        btnPresetRtae.TabIndex = 10;
        btnPresetRtae.Text = "RTAE";
        btnPresetRtae.UseVisualStyleBackColor = true;
        btnPresetRtae.Click += btnPresetRtae_Click;
        // 
        // btnPresetReat
        // 
        btnPresetReat.Location = new Point(152, 144);
        btnPresetReat.Name = "btnPresetReat";
        btnPresetReat.Size = new Size(80, 26);
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
        grpChannelTest.Location = new Point(852, 13);
        grpChannelTest.Name = "grpChannelTest";
        grpChannelTest.Padding = new Padding(10);
        grpChannelTest.Size = new Size(667, 201);
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
        pnlSticks.Size = new Size(333, 103);
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
        pnlRightStick.Size = new Size(162, 103);
        pnlRightStick.TabIndex = 1;
        // 
        // pnlRightStickIndicator
        // 
        pnlRightStickIndicator.Anchor = AnchorStyles.None;
        pnlRightStickIndicator.BackColor = Color.Blue;
        pnlRightStickIndicator.Location = new Point(76, 50);
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
        lblChannelVisual.Size = new Size(129, 25);
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
        channelInputsLayout.ColumnCount = 8;
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 63F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 74F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 81F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 68F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        channelInputsLayout.Controls.Add(lblTargetDeg, 0, 0);
        channelInputsLayout.Controls.Add(nudTargetDeg, 1, 0);
        channelInputsLayout.Controls.Add(lblThrottleUs, 2, 0);
        channelInputsLayout.Controls.Add(nudThrottleUs, 3, 0);
        channelInputsLayout.Controls.Add(lblSettleSec, 4, 0);
        channelInputsLayout.Controls.Add(nudSettleSec, 5, 0);
        channelInputsLayout.Controls.Add(lblBaselineSec, 6, 0);
        channelInputsLayout.Controls.Add(nudBaselineSec, 7, 0);
        channelInputsLayout.Location = new Point(1, 140);
        channelInputsLayout.Name = "channelInputsLayout";
        channelInputsLayout.RowCount = 1;
        channelInputsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        channelInputsLayout.Size = new Size(649, 48);
        channelInputsLayout.TabIndex = 3;
        // 
        // lblTargetDeg
        // 
        lblTargetDeg.Anchor = AnchorStyles.Right;
        lblTargetDeg.Location = new Point(0, 12);
        lblTargetDeg.Margin = new Padding(0);
        lblTargetDeg.Name = "lblTargetDeg";
        lblTargetDeg.Size = new Size(60, 23);
        lblTargetDeg.TabIndex = 0;
        lblTargetDeg.Text = "Target Δ°";
        lblTargetDeg.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudTargetDeg
        // 
        nudTargetDeg.Anchor = AnchorStyles.Left;
        nudTargetDeg.DecimalPlaces = 1;
        nudTargetDeg.Location = new Point(60, 14);
        nudTargetDeg.Margin = new Padding(0, 4, 0, 0);
        nudTargetDeg.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
        nudTargetDeg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTargetDeg.Name = "nudTargetDeg";
        nudTargetDeg.Size = new Size(57, 23);
        nudTargetDeg.TabIndex = 1;
        nudTargetDeg.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // lblThrottleUs
        // 
        lblThrottleUs.Anchor = AnchorStyles.Right;
        lblThrottleUs.Location = new Point(123, 12);
        lblThrottleUs.Margin = new Padding(0);
        lblThrottleUs.Name = "lblThrottleUs";
        lblThrottleUs.Size = new Size(74, 23);
        lblThrottleUs.TabIndex = 6;
        lblThrottleUs.Text = "Throttle";
        lblThrottleUs.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudThrottleUs
        // 
        nudThrottleUs.Anchor = AnchorStyles.Left;
        nudThrottleUs.Increment = new decimal(new int[] { 10, 0, 0, 0 });
        nudThrottleUs.Location = new Point(197, 14);
        nudThrottleUs.Margin = new Padding(0, 4, 0, 0);
        nudThrottleUs.Maximum = new decimal(new int[] { 1300, 0, 0, 0 });
        nudThrottleUs.Minimum = new decimal(new int[] { 1150, 0, 0, 0 });
        nudThrottleUs.Name = "nudThrottleUs";
        nudThrottleUs.Size = new Size(50, 23);
        nudThrottleUs.TabIndex = 7;
        nudThrottleUs.Value = new decimal(new int[] { 1150, 0, 0, 0 });
        // 
        // lblSettleSec
        // 
        lblSettleSec.Anchor = AnchorStyles.Right;
        lblSettleSec.Location = new Point(253, 12);
        lblSettleSec.Margin = new Padding(0);
        lblSettleSec.Name = "lblSettleSec";
        lblSettleSec.Size = new Size(81, 23);
        lblSettleSec.TabIndex = 2;
        lblSettleSec.Text = "Pre-wait (sec)";
        lblSettleSec.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudSettleSec
        // 
        nudSettleSec.Anchor = AnchorStyles.Left;
        nudSettleSec.DecimalPlaces = 1;
        nudSettleSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudSettleSec.Location = new Point(334, 14);
        nudSettleSec.Margin = new Padding(0, 4, 0, 0);
        nudSettleSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudSettleSec.Name = "nudSettleSec";
        nudSettleSec.Size = new Size(68, 23);
        nudSettleSec.TabIndex = 3;
        nudSettleSec.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblBaselineSec
        // 
        lblBaselineSec.Anchor = AnchorStyles.Right;
        lblBaselineSec.Location = new Point(402, 12);
        lblBaselineSec.Margin = new Padding(0);
        lblBaselineSec.Name = "lblBaselineSec";
        lblBaselineSec.Size = new Size(125, 23);
        lblBaselineSec.TabIndex = 4;
        lblBaselineSec.Text = "Seconds on Target Δ°";
        lblBaselineSec.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudBaselineSec
        // 
        nudBaselineSec.Anchor = AnchorStyles.Left;
        nudBaselineSec.DecimalPlaces = 1;
        nudBaselineSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudBaselineSec.Location = new Point(527, 14);
        nudBaselineSec.Margin = new Padding(0, 4, 0, 0);
        nudBaselineSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudBaselineSec.Name = "nudBaselineSec";
        nudBaselineSec.Size = new Size(50, 23);
        nudBaselineSec.TabIndex = 5;
        nudBaselineSec.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // grpPidWorkflow
        // 
        grpPidWorkflow.Controls.Add(tblPidMatrix);
        grpPidWorkflow.Dock = DockStyle.Fill;
        grpPidWorkflow.Location = new Point(13, 220);
        grpPidWorkflow.Name = "grpPidWorkflow";
        grpPidWorkflow.Padding = new Padding(10);
        grpPidWorkflow.Size = new Size(557, 167);
        grpPidWorkflow.TabIndex = 2;
        grpPidWorkflow.TabStop = false;
        grpPidWorkflow.Text = "INAV PID / FF Adjustment";
        // 
        // tblPidMatrix
        // 
        tblPidMatrix.ColumnCount = 6;
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
        tblPidMatrix.Controls.Add(lblPidHdrP, 1, 0);
        tblPidMatrix.Controls.Add(lblPidHdrI, 2, 0);
        tblPidMatrix.Controls.Add(lblPidHdrD, 3, 0);
        tblPidMatrix.Controls.Add(lblPidHdrFf, 4, 0);
        tblPidMatrix.Controls.Add(lblPidRowRoll, 0, 1);
        tblPidMatrix.Controls.Add(lblPidRowPitch, 0, 2);
        tblPidMatrix.Controls.Add(lblPidRowYaw, 0, 3);
        tblPidMatrix.Controls.Add(txtRollP, 1, 1);
        tblPidMatrix.Controls.Add(txtRollI, 2, 1);
        tblPidMatrix.Controls.Add(txtRollD, 3, 1);
        tblPidMatrix.Controls.Add(txtRollFf, 4, 1);
        tblPidMatrix.Controls.Add(txtPitchP, 1, 2);
        tblPidMatrix.Controls.Add(txtPitchI, 2, 2);
        tblPidMatrix.Controls.Add(txtPitchD, 3, 2);
        tblPidMatrix.Controls.Add(txtPitchFf, 4, 2);
        tblPidMatrix.Controls.Add(txtYawP, 1, 3);
        tblPidMatrix.Controls.Add(txtYawI, 2, 3);
        tblPidMatrix.Controls.Add(txtYawD, 3, 3);
        tblPidMatrix.Controls.Add(txtYawFf, 4, 3);
        tblPidMatrix.Controls.Add(btnReadFcPid, 5, 1);
        tblPidMatrix.Controls.Add(btnPidEditable, 5, 2);
        tblPidMatrix.Controls.Add(btnSaveFcPid, 5, 3);
        tblPidMatrix.Dock = DockStyle.Fill;
        tblPidMatrix.Location = new Point(10, 26);
        tblPidMatrix.Name = "tblPidMatrix";
        tblPidMatrix.RowCount = 4;
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.Size = new Size(537, 131);
        tblPidMatrix.TabIndex = 0;
        // 
        // lblPidHdrP
        // 
        lblPidHdrP.Anchor = AnchorStyles.None;
        lblPidHdrP.AutoSize = true;
        lblPidHdrP.Location = new Point(198, 8);
        lblPidHdrP.Name = "lblPidHdrP";
        lblPidHdrP.Size = new Size(14, 15);
        lblPidHdrP.TabIndex = 0;
        lblPidHdrP.Text = "P";
        // 
        // lblPidHdrI
        // 
        lblPidHdrI.Anchor = AnchorStyles.None;
        lblPidHdrI.AutoSize = true;
        lblPidHdrI.Location = new Point(291, 8);
        lblPidHdrI.Name = "lblPidHdrI";
        lblPidHdrI.Size = new Size(9, 15);
        lblPidHdrI.TabIndex = 1;
        lblPidHdrI.Text = "I";
        // 
        // lblPidHdrD
        // 
        lblPidHdrD.Anchor = AnchorStyles.None;
        lblPidHdrD.AutoSize = true;
        lblPidHdrD.Location = new Point(384, 8);
        lblPidHdrD.Name = "lblPidHdrD";
        lblPidHdrD.Size = new Size(15, 15);
        lblPidHdrD.TabIndex = 2;
        lblPidHdrD.Text = "D";
        // 
        // lblPidHdrFf
        // 
        lblPidHdrFf.Anchor = AnchorStyles.None;
        lblPidHdrFf.AutoSize = true;
        lblPidHdrFf.Location = new Point(472, 8);
        lblPidHdrFf.Name = "lblPidHdrFf";
        lblPidHdrFf.Size = new Size(18, 15);
        lblPidHdrFf.TabIndex = 3;
        lblPidHdrFf.Text = "FF";
        // 
        // lblPidRowRoll
        // 
        lblPidRowRoll.Anchor = AnchorStyles.Left;
        lblPidRowRoll.AutoSize = true;
        lblPidRowRoll.Location = new Point(3, 40);
        lblPidRowRoll.Name = "lblPidRowRoll";
        lblPidRowRoll.Size = new Size(27, 15);
        lblPidRowRoll.TabIndex = 4;
        lblPidRowRoll.Text = "Roll";
        // 
        // lblPidRowPitch
        // 
        lblPidRowPitch.Anchor = AnchorStyles.Left;
        lblPidRowPitch.AutoSize = true;
        lblPidRowPitch.Location = new Point(3, 72);
        lblPidRowPitch.Name = "lblPidRowPitch";
        lblPidRowPitch.Size = new Size(34, 15);
        lblPidRowPitch.TabIndex = 5;
        lblPidRowPitch.Text = "Pitch";
        // 
        // lblPidRowYaw
        // 
        lblPidRowYaw.Anchor = AnchorStyles.Left;
        lblPidRowYaw.AutoSize = true;
        lblPidRowYaw.Location = new Point(3, 105);
        lblPidRowYaw.Name = "lblPidRowYaw";
        lblPidRowYaw.Size = new Size(30, 15);
        lblPidRowYaw.TabIndex = 6;
        lblPidRowYaw.Text = "Yaw";
        // 
        // txtRollP
        // 
        txtRollP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollP.Location = new Point(164, 36);
        txtRollP.Name = "txtRollP";
        txtRollP.ReadOnly = true;
        txtRollP.Size = new Size(87, 23);
        txtRollP.TabIndex = 7;
        txtRollP.Text = "0";
        // 
        // txtRollI
        // 
        txtRollI.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollI.Location = new Point(257, 36);
        txtRollI.Name = "txtRollI";
        txtRollI.ReadOnly = true;
        txtRollI.Size = new Size(87, 23);
        txtRollI.TabIndex = 8;
        txtRollI.Text = "0";
        // 
        // txtRollD
        // 
        txtRollD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollD.Location = new Point(350, 36);
        txtRollD.Name = "txtRollD";
        txtRollD.ReadOnly = true;
        txtRollD.Size = new Size(87, 23);
        txtRollD.TabIndex = 9;
        txtRollD.Text = "0";
        // 
        // txtRollFf
        // 
        txtRollFf.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollFf.Location = new Point(443, 36);
        txtRollFf.Name = "txtRollFf";
        txtRollFf.ReadOnly = true;
        txtRollFf.Size = new Size(91, 23);
        txtRollFf.TabIndex = 10;
        txtRollFf.Text = "0";
        // 
        // txtPitchP
        // 
        txtPitchP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchP.Location = new Point(164, 68);
        txtPitchP.Name = "txtPitchP";
        txtPitchP.ReadOnly = true;
        txtPitchP.Size = new Size(87, 23);
        txtPitchP.TabIndex = 11;
        txtPitchP.Text = "0";
        // 
        // txtPitchI
        // 
        txtPitchI.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchI.Location = new Point(257, 68);
        txtPitchI.Name = "txtPitchI";
        txtPitchI.ReadOnly = true;
        txtPitchI.Size = new Size(87, 23);
        txtPitchI.TabIndex = 12;
        txtPitchI.Text = "0";
        // 
        // txtPitchD
        // 
        txtPitchD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchD.Location = new Point(350, 68);
        txtPitchD.Name = "txtPitchD";
        txtPitchD.ReadOnly = true;
        txtPitchD.Size = new Size(87, 23);
        txtPitchD.TabIndex = 13;
        txtPitchD.Text = "0";
        // 
        // txtPitchFf
        // 
        txtPitchFf.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchFf.Location = new Point(443, 68);
        txtPitchFf.Name = "txtPitchFf";
        txtPitchFf.ReadOnly = true;
        txtPitchFf.Size = new Size(91, 23);
        txtPitchFf.TabIndex = 14;
        txtPitchFf.Text = "0";
        // 
        // txtYawP
        // 
        txtYawP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawP.Location = new Point(164, 101);
        txtYawP.Name = "txtYawP";
        txtYawP.ReadOnly = true;
        txtYawP.Size = new Size(87, 23);
        txtYawP.TabIndex = 15;
        txtYawP.Text = "0";
        // 
        // txtYawI
        // 
        txtYawI.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawI.Location = new Point(257, 101);
        txtYawI.Name = "txtYawI";
        txtYawI.ReadOnly = true;
        txtYawI.Size = new Size(87, 23);
        txtYawI.TabIndex = 16;
        txtYawI.Text = "0";
        // 
        // txtYawD
        // 
        txtYawD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawD.Location = new Point(350, 101);
        txtYawD.Name = "txtYawD";
        txtYawD.ReadOnly = true;
        txtYawD.Size = new Size(87, 23);
        txtYawD.TabIndex = 17;
        txtYawD.Text = "0";
        // 
        // txtYawFf
        // 
        txtYawFf.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawFf.Location = new Point(443, 101);
        txtYawFf.Name = "txtYawFf";
        txtYawFf.ReadOnly = true;
        txtYawFf.Size = new Size(91, 23);
        txtYawFf.TabIndex = 18;
        txtYawFf.Text = "0";
        // 
        // btnPidEditable
        // 
        btnPidEditable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        btnPidEditable.Location = new Point(442, 67);
        btnPidEditable.Name = "btnPidEditable";
        btnPidEditable.Size = new Size(92, 25);
        btnPidEditable.TabIndex = 20;
        btnPidEditable.Text = "Editable";
        btnPidEditable.UseVisualStyleBackColor = true;
        btnPidEditable.Click += btnPidEditable_Click;
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
        lblActiveAxis.Location = new Point(559, 104);
        lblActiveAxis.Name = "lblActiveAxis";
        lblActiveAxis.Size = new Size(48, 15);
        lblActiveAxis.TabIndex = 2;
        lblActiveAxis.Text = "N/A";
        // 
        // lblActiveAxisTitle
        // 
        lblActiveAxisTitle.Anchor = AnchorStyles.Left;
        lblActiveAxisTitle.Location = new Point(481, 104);
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
        lblPidValuesTitle.Location = new Point(248, 40);
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
        // cmbManualAxis2
        // 
        cmbManualAxis2.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualAxis2.FormattingEnabled = true;
        cmbManualAxis2.Items.AddRange(new object[] { "Roll", "Pitch" });
        cmbManualAxis2.Location = new Point(18, 106);
        cmbManualAxis2.Name = "cmbManualAxis2";
        cmbManualAxis2.Size = new Size(80, 23);
        cmbManualAxis2.TabIndex = 12;
        // 
        // cmbManualGain2
        // 
        cmbManualGain2.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualGain2.FormattingEnabled = true;
        cmbManualGain2.Items.AddRange(new object[] { "P", "I", "D" });
        cmbManualGain2.Location = new Point(104, 106);
        cmbManualGain2.Name = "cmbManualGain2";
        cmbManualGain2.Size = new Size(56, 23);
        cmbManualGain2.TabIndex = 13;
        // 
        // cmbManualPoints2
        // 
        cmbManualPoints2.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualPoints2.FormattingEnabled = true;
        cmbManualPoints2.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
        cmbManualPoints2.Location = new Point(166, 106);
        cmbManualPoints2.Name = "cmbManualPoints2";
        cmbManualPoints2.Size = new Size(58, 23);
        cmbManualPoints2.TabIndex = 14;
        // 
        // btnManualPidMinus2
        // 
        btnManualPidMinus2.Location = new Point(230, 103);
        btnManualPidMinus2.Name = "btnManualPidMinus2";
        btnManualPidMinus2.Size = new Size(82, 32);
        btnManualPidMinus2.TabIndex = 15;
        btnManualPidMinus2.Text = "PID -";
        btnManualPidMinus2.UseVisualStyleBackColor = true;
        btnManualPidMinus2.Click += btnManualPidMinus2_Click;
        // 
        // btnManualPidPlus2
        // 
        btnManualPidPlus2.Location = new Point(318, 103);
        btnManualPidPlus2.Name = "btnManualPidPlus2";
        btnManualPidPlus2.Size = new Size(82, 32);
        btnManualPidPlus2.TabIndex = 16;
        btnManualPidPlus2.Text = "PID +";
        btnManualPidPlus2.UseVisualStyleBackColor = true;
        btnManualPidPlus2.Click += btnManualPidPlus2_Click;
        // 
        // btnReadFcPid
        // 
        btnReadFcPid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        btnReadFcPid.Location = new Point(442, 35);
        btnReadFcPid.Name = "btnReadFcPid";
        btnReadFcPid.Size = new Size(92, 25);
        btnReadFcPid.TabIndex = 19;
        btnReadFcPid.Text = "Read FC";
        btnReadFcPid.UseVisualStyleBackColor = true;
        btnReadFcPid.Click += btnReadFcPid_Click;
        // 
        // btnSaveFcPid
        // 
        btnSaveFcPid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        btnSaveFcPid.Location = new Point(442, 100);
        btnSaveFcPid.Name = "btnSaveFcPid";
        btnSaveFcPid.Size = new Size(92, 25);
        btnSaveFcPid.TabIndex = 21;
        btnSaveFcPid.Text = "Write FC";
        btnSaveFcPid.UseVisualStyleBackColor = true;
        btnSaveFcPid.Click += btnSaveFcPid_Click;
        // 
        // pnlScoreChart
        // 
        pnlScoreChart.BackColor = Color.White;
        pnlScoreChart.BorderStyle = BorderStyle.FixedSingle;
        rootLayout.SetColumnSpan(pnlScoreChart, 3);
        pnlScoreChart.Dock = DockStyle.Fill;
        pnlScoreChart.Location = new Point(13, 393);
        pnlScoreChart.Name = "pnlScoreChart";
        pnlScoreChart.Size = new Size(1506, 542);
        pnlScoreChart.TabIndex = 0;
        pnlScoreChart.Paint += pnlScoreChart_Paint;
        // 
        // lvTuningRuns
        // 
        lvTuningRuns.Columns.AddRange(new ColumnHeader[] { colRun, colAxis, colScore, colDecision });
        lvTuningRuns.FullRowSelect = true;
        lvTuningRuns.Location = new Point(852, 220);
        lvTuningRuns.Name = "lvTuningRuns";
        lvTuningRuns.Size = new Size(652, 139);
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
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1532, 948);
        Controls.Add(rootLayout);
        MinimumSize = new Size(898, 475);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Drone PID Tuning Assistant (WinForms)";
        rootLayout.ResumeLayout(false);
        grpUsb.ResumeLayout(false);
        grpMapping.ResumeLayout(false);
        grpChannelTest.ResumeLayout(false);
        pnlSticks.ResumeLayout(false);
        pnlLeftStick.ResumeLayout(false);
        pnlRightStick.ResumeLayout(false);
        channelVisualLayout.ResumeLayout(false);
        channelInputsLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).EndInit();
        tblPidMatrix.ResumeLayout(false);
        tblPidMatrix.PerformLayout();
        grpPidWorkflow.ResumeLayout(false);
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
    private Button btnSimulationToggle;
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
    private GroupBox grpPidWorkflow;
    private TableLayoutPanel tblPidMatrix;
    private Label lblPidHdrP;
    private Label lblPidHdrI;
    private Label lblPidHdrD;
    private Label lblPidHdrFf;
    private Label lblPidRowRoll;
    private Label lblPidRowPitch;
    private Label lblPidRowYaw;
    private TextBox txtRollP;
    private TextBox txtRollI;
    private TextBox txtRollD;
    private TextBox txtRollFf;
    private TextBox txtPitchP;
    private TextBox txtPitchI;
    private TextBox txtPitchD;
    private TextBox txtPitchFf;
    private TextBox txtYawP;
    private TextBox txtYawI;
    private TextBox txtYawD;
    private TextBox txtYawFf;
    private Button btnPidEditable;
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
    private ComboBox cmbManualAxis2;
    private ComboBox cmbManualGain2;
    private ComboBox cmbManualPoints2;
    private Button btnManualPidMinus2;
    private Button btnManualPidPlus2;
    private Button btnReadFcPid;
    private Button btnSaveFcPid;
    private Label lblActiveAxisTitle;
    private Label lblActiveAxis;
    private Label lblPidValuesTitle;
    private Panel pnlScoreChart;
    private ListView lvTuningRuns;
    private ColumnHeader colRun;
    private ColumnHeader colAxis;
    private ColumnHeader colScore;
    private ColumnHeader colDecision;
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
    private TableLayoutPanel channelInputsLayout;
    private Label lblTargetDeg;
    private Label lblSettleSec;
    private NumericUpDown nudSettleSec;
    private Label lblBaselineSec;
    private NumericUpDown nudBaselineSec;
    private Label lblThrottleUs;
    private NumericUpDown nudThrottleUs;
    private NumericUpDown nudTargetDeg;
}



