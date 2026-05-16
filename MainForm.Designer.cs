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
        topLayout = new TableLayoutPanel();
        grpUsb = new GroupBox();
        usbLayout = new TableLayoutPanel();
        lblPort = new Label();
        cboPort = new ComboBox();
        cboBaud = new ComboBox();
        btnRefreshPorts = new Button();
        btnConnect = new Button();
        btnDisconnect = new Button();
        lblArduinoPort = new Label();
        cboArduinoPort = new ComboBox();
        cboArduinoBaud = new ComboBox();
        btnArduinoConnect = new Button();
        btnArduinoDisconnect = new Button();
        lblStatus = new Label();
        grpMapping = new GroupBox();
        mappingLayout = new TableLayoutPanel();
        lblRoll = new Label();
        cboCH1 = new ComboBox();
        lblPitch = new Label();
        cboCH2 = new ComboBox();
        lblThrottle = new Label();
        cboCH3 = new ComboBox();
        lblCh4 = new Label();
        cboCH4 = new ComboBox();
        btnApplyMapping = new Button();
        grpPortingArea = new Panel();
        grpChannelTest = new GroupBox();
        channelTestLayout = new TableLayoutPanel();
        channelActionLayout = new FlowLayoutPanel();
        btnTestRoll = new Button();
        btnTestPitch = new Button();
        btnTestThrottle = new Button();
        channelVisualLayout = new TableLayoutPanel();
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
        lblSettleSec = new Label();
        nudSettleSec = new NumericUpDown();
        lblBaselineSec = new Label();
        nudBaselineSec = new NumericUpDown();
        lblThrottleUs = new Label();
        nudThrottleUs = new NumericUpDown();
        nudTargetDeg = new NumericUpDown();
        grpTelemetry = new GroupBox();
        telemetryLayout = new TableLayoutPanel();
        telemetryButtonLayout = new FlowLayoutPanel();
        btnTelemetryStart = new Button();
        btnTelemetryStop = new Button();
        btnTelemetrySnapshot = new Button();
        telemetryValueLayout = new TableLayoutPanel();
        lblTelemetryRollTitle = new Label();
        lblTelemetryRoll = new Label();
        lblTelemetryPitchTitle = new Label();
        lblTelemetryPitch = new Label();
        lblTelemetryYawTitle = new Label();
        lblTelemetryYaw = new Label();
        grpPidWorkflow = new GroupBox();
        pidWorkflowLayout = new TableLayoutPanel();
        pidButtonLayout = new FlowLayoutPanel();
        btnTuneRoll = new Button();
        btnTunePitch = new Button();
        btnRetestAxis = new Button();
        btnFinishAxis = new Button();
        btnApplyRecommendedPid = new Button();
        cmbManualAxis = new ComboBox();
        cmbManualGain = new ComboBox();
        cmbManualPoints = new ComboBox();
        btnManualPidMinus = new Button();
        btnManualPidPlus = new Button();
        btnReadFcPid = new Button();
        btnSaveFcPid = new Button();
        txtPidValues = new TextBox();
        lblActiveAxisTitle = new Label();
        lblActiveAxis = new Label();
        lblPidValuesTitle = new Label();
        txtPidRecommendation = new TextBox();
        grpTuningProgress = new GroupBox();
        tuningProgressLayout = new TableLayoutPanel();
        pnlScoreChart = new Panel();
        lvTuningRuns = new ListView();
        colRun = new ColumnHeader();
        colAxis = new ColumnHeader();
        colScore = new ColumnHeader();
        colDecision = new ColumnHeader();
        pnlStatus = new Panel();
        panel1 = new Panel();
        rootLayout.SuspendLayout();
        topLayout.SuspendLayout();
        grpUsb.SuspendLayout();
        usbLayout.SuspendLayout();
        grpMapping.SuspendLayout();
        mappingLayout.SuspendLayout();
        grpPortingArea.SuspendLayout();
        grpChannelTest.SuspendLayout();
        channelTestLayout.SuspendLayout();
        channelActionLayout.SuspendLayout();
        channelVisualLayout.SuspendLayout();
        channelInputsLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).BeginInit();
        grpTelemetry.SuspendLayout();
        telemetryLayout.SuspendLayout();
        telemetryButtonLayout.SuspendLayout();
        telemetryValueLayout.SuspendLayout();
        grpPidWorkflow.SuspendLayout();
        pidWorkflowLayout.SuspendLayout();
        pidButtonLayout.SuspendLayout();
        grpTuningProgress.SuspendLayout();
        tuningProgressLayout.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(topLayout, 0, 0);
        rootLayout.Controls.Add(grpPortingArea, 0, 1);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(10);
        rootLayout.RowCount = 2;
        rootLayout.RowStyles.Add(new RowStyle());
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(1389, 983);
        rootLayout.TabIndex = 0;
        // 
        // topLayout
        // 
        topLayout.AutoSize = true;
        topLayout.ColumnCount = 2;
        topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        topLayout.Controls.Add(grpUsb, 0, 0);
        topLayout.Controls.Add(grpMapping, 1, 0);
        topLayout.Dock = DockStyle.Fill;
        topLayout.Location = new Point(13, 13);
        topLayout.Name = "topLayout";
        topLayout.RowCount = 1;
        topLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        topLayout.Size = new Size(1363, 187);
        topLayout.TabIndex = 0;
        // 
        // grpUsb
        // 
        grpUsb.AutoSize = true;
        grpUsb.Controls.Add(usbLayout);
        grpUsb.Dock = DockStyle.Fill;
        grpUsb.Location = new Point(3, 3);
        grpUsb.Name = "grpUsb";
        grpUsb.Padding = new Padding(10);
        grpUsb.Size = new Size(539, 181);
        grpUsb.TabIndex = 0;
        grpUsb.TabStop = false;
        grpUsb.Text = "Serial Ports";
        // 
        // usbLayout
        // 
        usbLayout.ColumnCount = 7;
        usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
        usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 182F));
        usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        usbLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        usbLayout.Controls.Add(lblPort, 0, 0);
        usbLayout.Controls.Add(cboPort, 1, 0);
        usbLayout.Controls.Add(cboBaud, 2, 0);
        usbLayout.Controls.Add(btnRefreshPorts, 4, 0);
        usbLayout.Controls.Add(btnConnect, 5, 0);
        usbLayout.Controls.Add(btnDisconnect, 6, 0);
        usbLayout.Controls.Add(lblArduinoPort, 0, 1);
        usbLayout.Controls.Add(cboArduinoPort, 1, 1);
        usbLayout.Controls.Add(cboArduinoBaud, 2, 1);
        usbLayout.Controls.Add(btnArduinoConnect, 5, 1);
        usbLayout.Controls.Add(btnArduinoDisconnect, 6, 1);
        usbLayout.Controls.Add(lblStatus, 0, 2);
        usbLayout.Location = new Point(10, 26);
        usbLayout.Name = "usbLayout";
        usbLayout.RowCount = 3;
        usbLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        usbLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        usbLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        usbLayout.Size = new Size(520, 90);
        usbLayout.TabIndex = 0;
        // 
        // lblPort
        // 
        lblPort.Anchor = AnchorStyles.Left;
        lblPort.Location = new Point(3, 7);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(45, 15);
        lblPort.TabIndex = 0;
        lblPort.Text = "FC USB";
        // 
        // cboPort
        // 
        cboPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPort.FormattingEnabled = true;
        cboPort.Location = new Point(61, 3);
        cboPort.Name = "cboPort";
        cboPort.Size = new Size(170, 23);
        cboPort.TabIndex = 1;
        // 
        // cboBaud
        // 
        cboBaud.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        cboBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBaud.FormattingEnabled = true;
        cboBaud.Location = new Point(243, 3);
        cboBaud.Name = "cboBaud";
        cboBaud.Size = new Size(114, 23);
        cboBaud.TabIndex = 2;
        // 
        // btnRefreshPorts
        // 
        btnRefreshPorts.Location = new Point(483, 3);
        btnRefreshPorts.Name = "btnRefreshPorts";
        btnRefreshPorts.Size = new Size(75, 24);
        btnRefreshPorts.TabIndex = 4;
        btnRefreshPorts.Text = "Refresh";
        btnRefreshPorts.UseVisualStyleBackColor = true;
        btnRefreshPorts.Click += btnRefreshPorts_Click;
        // 
        // btnConnect
        // 
        btnConnect.Location = new Point(603, 3);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(75, 24);
        btnConnect.TabIndex = 5;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // btnDisconnect
        // 
        btnDisconnect.Location = new Point(723, 3);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(75, 24);
        btnDisconnect.TabIndex = 6;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // lblArduinoPort
        // 
        lblArduinoPort.Anchor = AnchorStyles.Left;
        lblArduinoPort.Location = new Point(3, 37);
        lblArduinoPort.Name = "lblArduinoPort";
        lblArduinoPort.Size = new Size(50, 15);
        lblArduinoPort.TabIndex = 7;
        lblArduinoPort.Text = "Arduino";
        // 
        // cboArduinoPort
        // 
        cboArduinoPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoPort.FormattingEnabled = true;
        cboArduinoPort.Location = new Point(61, 33);
        cboArduinoPort.Name = "cboArduinoPort";
        cboArduinoPort.Size = new Size(170, 23);
        cboArduinoPort.TabIndex = 8;
        // 
        // cboArduinoBaud
        // 
        cboArduinoBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoBaud.FormattingEnabled = true;
        cboArduinoBaud.Location = new Point(243, 33);
        cboArduinoBaud.Name = "cboArduinoBaud";
        cboArduinoBaud.Size = new Size(100, 23);
        cboArduinoBaud.TabIndex = 9;
        // 
        // btnArduinoConnect
        // 
        btnArduinoConnect.Location = new Point(603, 33);
        btnArduinoConnect.Name = "btnArduinoConnect";
        btnArduinoConnect.Size = new Size(75, 24);
        btnArduinoConnect.TabIndex = 11;
        btnArduinoConnect.Text = "Connect";
        btnArduinoConnect.UseVisualStyleBackColor = true;
        btnArduinoConnect.Click += btnArduinoConnect_Click;
        // 
        // btnArduinoDisconnect
        // 
        btnArduinoDisconnect.Location = new Point(723, 33);
        btnArduinoDisconnect.Name = "btnArduinoDisconnect";
        btnArduinoDisconnect.Size = new Size(75, 24);
        btnArduinoDisconnect.TabIndex = 12;
        btnArduinoDisconnect.Text = "Disconnect";
        btnArduinoDisconnect.UseVisualStyleBackColor = true;
        btnArduinoDisconnect.Click += btnArduinoDisconnect_Click;
        // 
        // lblStatus
        // 
        lblStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        usbLayout.SetColumnSpan(lblStatus, 7);
        lblStatus.Location = new Point(3, 67);
        lblStatus.Margin = new Padding(3, 3, 3, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(834, 19);
        lblStatus.TabIndex = 13;
        lblStatus.Text = "Ready.";
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grpMapping
        // 
        grpMapping.AutoSize = true;
        grpMapping.Controls.Add(mappingLayout);
        grpMapping.Dock = DockStyle.Fill;
        grpMapping.Location = new Point(548, 3);
        grpMapping.Name = "grpMapping";
        grpMapping.Padding = new Padding(10);
        grpMapping.Size = new Size(812, 181);
        grpMapping.TabIndex = 1;
        grpMapping.TabStop = false;
        grpMapping.Text = "Transmitter Channel Mapping";
        // 
        // mappingLayout
        // 
        mappingLayout.ColumnCount = 3;
        mappingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        mappingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        mappingLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        mappingLayout.Controls.Add(lblRoll, 0, 0);
        mappingLayout.Controls.Add(cboCH1, 1, 0);
        mappingLayout.Controls.Add(lblPitch, 0, 1);
        mappingLayout.Controls.Add(cboCH2, 1, 1);
        mappingLayout.Controls.Add(lblThrottle, 0, 2);
        mappingLayout.Controls.Add(cboCH3, 1, 2);
        mappingLayout.Controls.Add(lblCh4, 0, 3);
        mappingLayout.Controls.Add(cboCH4, 1, 3);
        mappingLayout.Controls.Add(btnApplyMapping, 2, 0);
        mappingLayout.Location = new Point(10, 26);
        mappingLayout.Name = "mappingLayout";
        mappingLayout.RowCount = 4;
        mappingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        mappingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        mappingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        mappingLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        mappingLayout.Size = new Size(791, 126);
        mappingLayout.TabIndex = 0;
        // 
        // lblRoll
        // 
        lblRoll.Anchor = AnchorStyles.Left;
        lblRoll.Location = new Point(3, 7);
        lblRoll.Name = "lblRoll";
        lblRoll.Size = new Size(31, 15);
        lblRoll.TabIndex = 0;
        lblRoll.Text = "Ch 1";
        // 
        // cboCH1
        // 
        cboCH1.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH1.FormattingEnabled = true;
        cboCH1.Location = new Point(123, 3);
        cboCH1.Name = "cboCH1";
        cboCH1.Size = new Size(70, 23);
        cboCH1.TabIndex = 1;
        // 
        // lblPitch
        // 
        lblPitch.Anchor = AnchorStyles.Left;
        lblPitch.Location = new Point(3, 37);
        lblPitch.Name = "lblPitch";
        lblPitch.Size = new Size(31, 15);
        lblPitch.TabIndex = 2;
        lblPitch.Text = "Ch 2";
        // 
        // cboCH2
        // 
        cboCH2.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH2.FormattingEnabled = true;
        cboCH2.Location = new Point(123, 33);
        cboCH2.Name = "cboCH2";
        cboCH2.Size = new Size(70, 23);
        cboCH2.TabIndex = 3;
        // 
        // lblThrottle
        // 
        lblThrottle.Anchor = AnchorStyles.Left;
        lblThrottle.Location = new Point(3, 67);
        lblThrottle.Name = "lblThrottle";
        lblThrottle.Size = new Size(31, 15);
        lblThrottle.TabIndex = 4;
        lblThrottle.Text = "Ch 3";
        // 
        // cboCH3
        // 
        cboCH3.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH3.FormattingEnabled = true;
        cboCH3.Location = new Point(123, 63);
        cboCH3.Name = "cboCH3";
        cboCH3.Size = new Size(70, 23);
        cboCH3.TabIndex = 5;
        // 
        // lblCh4
        // 
        lblCh4.Anchor = AnchorStyles.Left;
        lblCh4.Location = new Point(3, 100);
        lblCh4.Name = "lblCh4";
        lblCh4.Size = new Size(31, 15);
        lblCh4.TabIndex = 7;
        lblCh4.Text = "Ch 4";
        // 
        // cboCH4
        // 
        cboCH4.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH4.FormattingEnabled = true;
        cboCH4.Location = new Point(123, 93);
        cboCH4.Name = "cboCH4";
        cboCH4.Size = new Size(70, 23);
        cboCH4.TabIndex = 8;
        // 
        // btnApplyMapping
        // 
        btnApplyMapping.Location = new Point(243, 3);
        btnApplyMapping.Name = "btnApplyMapping";
        mappingLayout.SetRowSpan(btnApplyMapping, 4);
        btnApplyMapping.Size = new Size(75, 28);
        btnApplyMapping.TabIndex = 6;
        btnApplyMapping.Text = "Apply";
        btnApplyMapping.UseVisualStyleBackColor = true;
        btnApplyMapping.Click += btnApplyMapping_Click;
        // 
        // grpPortingArea
        // 
        grpPortingArea.Controls.Add(grpChannelTest);
        grpPortingArea.Controls.Add(grpTelemetry);
        grpPortingArea.Controls.Add(grpPidWorkflow);
        grpPortingArea.Controls.Add(grpTuningProgress);
        grpPortingArea.Dock = DockStyle.Fill;
        grpPortingArea.Location = new Point(13, 206);
        grpPortingArea.Name = "grpPortingArea";
        grpPortingArea.Padding = new Padding(10);
        grpPortingArea.Size = new Size(1363, 764);
        grpPortingArea.TabIndex = 1;
        // 
        // grpChannelTest
        // 
        grpChannelTest.Controls.Add(channelTestLayout);
        grpChannelTest.Dock = DockStyle.Top;
        grpChannelTest.Location = new Point(10, 341);
        grpChannelTest.Name = "grpChannelTest";
        grpChannelTest.Padding = new Padding(10);
        grpChannelTest.Size = new Size(1343, 221);
        grpChannelTest.TabIndex = 0;
        grpChannelTest.TabStop = false;
        grpChannelTest.Text = "Channel Test";
        // 
        // channelTestLayout
        // 
        channelTestLayout.ColumnCount = 1;
        channelTestLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        channelTestLayout.Controls.Add(channelActionLayout, 0, 0);
        channelTestLayout.Controls.Add(channelVisualLayout, 0, 1);
        channelTestLayout.Controls.Add(channelInputsLayout, 0, 3);
        channelTestLayout.Dock = DockStyle.Fill;
        channelTestLayout.Location = new Point(10, 26);
        channelTestLayout.Name = "channelTestLayout";
        channelTestLayout.RowCount = 4;
        channelTestLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        channelTestLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        channelTestLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
        channelTestLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        channelTestLayout.Size = new Size(1323, 185);
        channelTestLayout.TabIndex = 0;
        // 
        // channelActionLayout
        // 
        channelActionLayout.Controls.Add(btnTestRoll);
        channelActionLayout.Controls.Add(btnTestPitch);
        channelActionLayout.Controls.Add(btnTestThrottle);
        channelActionLayout.Location = new Point(3, 3);
        channelActionLayout.Name = "channelActionLayout";
        channelActionLayout.Size = new Size(1317, 35);
        channelActionLayout.TabIndex = 0;
        // 
        // btnTestRoll
        // 
        btnTestRoll.Location = new Point(3, 3);
        btnTestRoll.Name = "btnTestRoll";
        btnTestRoll.Size = new Size(90, 29);
        btnTestRoll.TabIndex = 0;
        btnTestRoll.Text = "Roll";
        btnTestRoll.UseVisualStyleBackColor = true;
        btnTestRoll.Click += btnTestRoll_Click;
        // 
        // btnTestPitch
        // 
        btnTestPitch.Location = new Point(99, 3);
        btnTestPitch.Name = "btnTestPitch";
        btnTestPitch.Size = new Size(90, 29);
        btnTestPitch.TabIndex = 1;
        btnTestPitch.Text = "Pitch";
        btnTestPitch.UseVisualStyleBackColor = true;
        btnTestPitch.Click += btnTestPitch_Click;
        // 
        // btnTestThrottle
        // 
        btnTestThrottle.Location = new Point(195, 3);
        btnTestThrottle.Name = "btnTestThrottle";
        btnTestThrottle.Size = new Size(90, 29);
        btnTestThrottle.TabIndex = 2;
        btnTestThrottle.Text = "Throttle";
        btnTestThrottle.UseVisualStyleBackColor = true;
        btnTestThrottle.Click += btnTestThrottle_Click;
        // 
        // channelVisualLayout
        // 
        channelVisualLayout.ColumnCount = 8;
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelVisualLayout.Controls.Add(lblChannelVisualTitle, 0, 0);
        channelVisualLayout.Controls.Add(lblChannelVisual, 1, 0);
        channelVisualLayout.Controls.Add(lblChannelValueTitle, 2, 0);
        channelVisualLayout.Controls.Add(lblChannelValue, 3, 0);
        channelVisualLayout.Controls.Add(lblRollAngleTitle, 4, 0);
        channelVisualLayout.Controls.Add(lblRollAngle, 5, 0);
        channelVisualLayout.Controls.Add(lblPitchAngleTitle, 6, 0);
        channelVisualLayout.Controls.Add(lblPitchAngle, 7, 0);
        channelVisualLayout.Location = new Point(3, 55);
        channelVisualLayout.Name = "channelVisualLayout";
        channelVisualLayout.RowCount = 1;
        channelVisualLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        channelVisualLayout.Size = new Size(1317, 15);
        channelVisualLayout.TabIndex = 1;
        // 
        // lblChannelVisualTitle
        // 
        lblChannelVisualTitle.Anchor = AnchorStyles.Left;
        lblChannelVisualTitle.Location = new Point(3, 42);
        lblChannelVisualTitle.Name = "lblChannelVisualTitle";
        lblChannelVisualTitle.Size = new Size(42, 15);
        lblChannelVisualTitle.TabIndex = 0;
        lblChannelVisualTitle.Text = "Status:";
        // 
        // lblChannelVisual
        // 
        lblChannelVisual.Anchor = AnchorStyles.Left;
        lblChannelVisual.Location = new Point(123, 42);
        lblChannelVisual.Name = "lblChannelVisual";
        lblChannelVisual.Size = new Size(26, 15);
        lblChannelVisual.TabIndex = 1;
        lblChannelVisual.Text = "Idle";
        // 
        // lblChannelValueTitle
        // 
        lblChannelValueTitle.Anchor = AnchorStyles.Left;
        lblChannelValueTitle.Location = new Point(243, 42);
        lblChannelValueTitle.Name = "lblChannelValueTitle";
        lblChannelValueTitle.Size = new Size(38, 15);
        lblChannelValueTitle.TabIndex = 2;
        lblChannelValueTitle.Text = "Pulse:";
        // 
        // lblChannelValue
        // 
        lblChannelValue.Anchor = AnchorStyles.Left;
        lblChannelValue.Location = new Point(363, 42);
        lblChannelValue.Name = "lblChannelValue";
        lblChannelValue.Size = new Size(46, 15);
        lblChannelValue.TabIndex = 3;
        lblChannelValue.Text = "1500 us";
        // 
        // lblRollAngleTitle
        // 
        lblRollAngleTitle.Anchor = AnchorStyles.Left;
        lblRollAngleTitle.Location = new Point(483, 42);
        lblRollAngleTitle.Name = "lblRollAngleTitle";
        lblRollAngleTitle.Size = new Size(62, 15);
        lblRollAngleTitle.TabIndex = 4;
        lblRollAngleTitle.Text = "Roll angle:";
        // 
        // lblRollAngle
        // 
        lblRollAngle.Anchor = AnchorStyles.Left;
        lblRollAngle.Location = new Point(603, 42);
        lblRollAngle.Name = "lblRollAngle";
        lblRollAngle.Size = new Size(27, 15);
        lblRollAngle.TabIndex = 5;
        lblRollAngle.Text = "0.0°";
        // 
        // lblPitchAngleTitle
        // 
        lblPitchAngleTitle.Anchor = AnchorStyles.Left;
        lblPitchAngleTitle.Location = new Point(723, 42);
        lblPitchAngleTitle.Name = "lblPitchAngleTitle";
        lblPitchAngleTitle.Size = new Size(69, 15);
        lblPitchAngleTitle.TabIndex = 6;
        lblPitchAngleTitle.Text = "Pitch angle:";
        // 
        // lblPitchAngle
        // 
        lblPitchAngle.Anchor = AnchorStyles.Left;
        lblPitchAngle.Location = new Point(843, 42);
        lblPitchAngle.Name = "lblPitchAngle";
        lblPitchAngle.Size = new Size(27, 15);
        lblPitchAngle.TabIndex = 7;
        lblPitchAngle.Text = "0.0°";
        // 
        // channelInputsLayout
        // 
        channelInputsLayout.ColumnCount = 8;
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        channelInputsLayout.Controls.Add(lblTargetDeg, 0, 0);
        channelInputsLayout.Controls.Add(lblSettleSec, 2, 0);
        channelInputsLayout.Controls.Add(nudSettleSec, 3, 0);
        channelInputsLayout.Controls.Add(lblBaselineSec, 4, 0);
        channelInputsLayout.Controls.Add(nudBaselineSec, 5, 0);
        channelInputsLayout.Controls.Add(lblThrottleUs, 6, 0);
        channelInputsLayout.Controls.Add(nudThrottleUs, 7, 0);
        channelInputsLayout.Controls.Add(nudTargetDeg, 1, 0);
        channelInputsLayout.Location = new Point(3, 93);
        channelInputsLayout.Name = "channelInputsLayout";
        channelInputsLayout.RowCount = 1;
        channelInputsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        channelInputsLayout.Size = new Size(1317, 41);
        channelInputsLayout.TabIndex = 3;
        // 
        // lblTargetDeg
        // 
        lblTargetDeg.Anchor = AnchorStyles.Left;
        lblTargetDeg.Location = new Point(3, 42);
        lblTargetDeg.Name = "lblTargetDeg";
        lblTargetDeg.Size = new Size(55, 15);
        lblTargetDeg.TabIndex = 0;
        lblTargetDeg.Text = "Target Δ°";
        // 
        // lblSettleSec
        // 
        lblSettleSec.Anchor = AnchorStyles.Left;
        lblSettleSec.Location = new Point(243, 42);
        lblSettleSec.Name = "lblSettleSec";
        lblSettleSec.Size = new Size(92, 15);
        lblSettleSec.TabIndex = 2;
        lblSettleSec.Text = "Pre-Test Wait (s)";
        // 
        // nudSettleSec
        // 
        nudSettleSec.DecimalPlaces = 1;
        nudSettleSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudSettleSec.Location = new Point(363, 3);
        nudSettleSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudSettleSec.Name = "nudSettleSec";
        nudSettleSec.Size = new Size(64, 23);
        nudSettleSec.TabIndex = 3;
        nudSettleSec.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblBaselineSec
        // 
        lblBaselineSec.Anchor = AnchorStyles.Left;
        lblBaselineSec.Location = new Point(483, 42);
        lblBaselineSec.Name = "lblBaselineSec";
        lblBaselineSec.Size = new Size(114, 15);
        lblBaselineSec.TabIndex = 4;
        lblBaselineSec.Text = "Wait Between Steps (s)";
        // 
        // nudBaselineSec
        // 
        nudBaselineSec.DecimalPlaces = 1;
        nudBaselineSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudBaselineSec.Location = new Point(603, 3);
        nudBaselineSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudBaselineSec.Name = "nudBaselineSec";
        nudBaselineSec.Size = new Size(64, 23);
        nudBaselineSec.TabIndex = 5;
        nudBaselineSec.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblThrottleUs
        // 
        lblThrottleUs.Anchor = AnchorStyles.Left;
        lblThrottleUs.Location = new Point(723, 42);
        lblThrottleUs.Name = "lblThrottleUs";
        lblThrottleUs.Size = new Size(71, 15);
        lblThrottleUs.TabIndex = 6;
        lblThrottleUs.Text = "Throttle (us)";
        // 
        // nudThrottleUs
        // 
        nudThrottleUs.Increment = new decimal(new int[] { 10, 0, 0, 0 });
        nudThrottleUs.Location = new Point(843, 3);
        nudThrottleUs.Maximum = new decimal(new int[] { 1300, 0, 0, 0 });
        nudThrottleUs.Minimum = new decimal(new int[] { 1150, 0, 0, 0 });
        nudThrottleUs.Name = "nudThrottleUs";
        nudThrottleUs.Size = new Size(72, 23);
        nudThrottleUs.TabIndex = 7;
        nudThrottleUs.Value = new decimal(new int[] { 1150, 0, 0, 0 });
        // 
        // nudTargetDeg
        // 
        nudTargetDeg.DecimalPlaces = 1;
        nudTargetDeg.Location = new Point(123, 3);
        nudTargetDeg.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
        nudTargetDeg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTargetDeg.Name = "nudTargetDeg";
        nudTargetDeg.Size = new Size(64, 23);
        nudTargetDeg.TabIndex = 1;
        nudTargetDeg.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // grpTelemetry
        // 
        grpTelemetry.Controls.Add(telemetryLayout);
        grpTelemetry.Dock = DockStyle.Top;
        grpTelemetry.Location = new Point(10, 200);
        grpTelemetry.Name = "grpTelemetry";
        grpTelemetry.Padding = new Padding(10);
        grpTelemetry.Size = new Size(1343, 141);
        grpTelemetry.TabIndex = 1;
        grpTelemetry.TabStop = false;
        grpTelemetry.Text = "Telemetry";
        // 
        // telemetryLayout
        // 
        telemetryLayout.ColumnCount = 1;
        telemetryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        telemetryLayout.Controls.Add(telemetryButtonLayout, 0, 0);
        telemetryLayout.Controls.Add(telemetryValueLayout, 0, 1);
        telemetryLayout.Location = new Point(10, 26);
        telemetryLayout.Name = "telemetryLayout";
        telemetryLayout.RowCount = 2;
        telemetryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        telemetryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        telemetryLayout.Size = new Size(1323, 105);
        telemetryLayout.TabIndex = 0;
        // 
        // telemetryButtonLayout
        // 
        telemetryButtonLayout.Controls.Add(btnTelemetryStart);
        telemetryButtonLayout.Controls.Add(btnTelemetryStop);
        telemetryButtonLayout.Controls.Add(btnTelemetrySnapshot);
        telemetryButtonLayout.Location = new Point(3, 3);
        telemetryButtonLayout.Name = "telemetryButtonLayout";
        telemetryButtonLayout.Size = new Size(1317, 24);
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
        telemetryValueLayout.ColumnCount = 6;
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        telemetryValueLayout.Controls.Add(lblTelemetryRollTitle, 0, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryRoll, 1, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryPitchTitle, 2, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryPitch, 3, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryYawTitle, 4, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryYaw, 5, 0);
        telemetryValueLayout.Location = new Point(3, 33);
        telemetryValueLayout.Name = "telemetryValueLayout";
        telemetryValueLayout.RowCount = 1;
        telemetryValueLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        telemetryValueLayout.Size = new Size(1317, 58);
        telemetryValueLayout.TabIndex = 1;
        // 
        // lblTelemetryRollTitle
        // 
        lblTelemetryRollTitle.Anchor = AnchorStyles.Left;
        lblTelemetryRollTitle.Location = new Point(3, 42);
        lblTelemetryRollTitle.Name = "lblTelemetryRollTitle";
        lblTelemetryRollTitle.Size = new Size(30, 15);
        lblTelemetryRollTitle.TabIndex = 0;
        lblTelemetryRollTitle.Text = "Roll:";
        // 
        // lblTelemetryRoll
        // 
        lblTelemetryRoll.Anchor = AnchorStyles.Left;
        lblTelemetryRoll.Location = new Point(123, 42);
        lblTelemetryRoll.Name = "lblTelemetryRoll";
        lblTelemetryRoll.Size = new Size(48, 15);
        lblTelemetryRoll.TabIndex = 1;
        lblTelemetryRoll.Text = "--.- deg";
        // 
        // lblTelemetryPitchTitle
        // 
        lblTelemetryPitchTitle.Anchor = AnchorStyles.Left;
        lblTelemetryPitchTitle.Location = new Point(243, 42);
        lblTelemetryPitchTitle.Name = "lblTelemetryPitchTitle";
        lblTelemetryPitchTitle.Size = new Size(37, 15);
        lblTelemetryPitchTitle.TabIndex = 2;
        lblTelemetryPitchTitle.Text = "Pitch:";
        // 
        // lblTelemetryPitch
        // 
        lblTelemetryPitch.Anchor = AnchorStyles.Left;
        lblTelemetryPitch.Location = new Point(363, 42);
        lblTelemetryPitch.Name = "lblTelemetryPitch";
        lblTelemetryPitch.Size = new Size(48, 15);
        lblTelemetryPitch.TabIndex = 3;
        lblTelemetryPitch.Text = "--.- deg";
        // 
        // lblTelemetryYawTitle
        // 
        lblTelemetryYawTitle.Anchor = AnchorStyles.Left;
        lblTelemetryYawTitle.Location = new Point(483, 42);
        lblTelemetryYawTitle.Name = "lblTelemetryYawTitle";
        lblTelemetryYawTitle.Size = new Size(31, 15);
        lblTelemetryYawTitle.TabIndex = 4;
        lblTelemetryYawTitle.Text = "Yaw:";
        // 
        // lblTelemetryYaw
        // 
        lblTelemetryYaw.Anchor = AnchorStyles.Left;
        lblTelemetryYaw.Location = new Point(603, 42);
        lblTelemetryYaw.Name = "lblTelemetryYaw";
        lblTelemetryYaw.Size = new Size(48, 15);
        lblTelemetryYaw.TabIndex = 5;
        lblTelemetryYaw.Text = "--.- deg";
        // 
        // grpPidWorkflow
        // 
        grpPidWorkflow.Controls.Add(pidWorkflowLayout);
        grpPidWorkflow.Dock = DockStyle.Top;
        grpPidWorkflow.Location = new Point(10, 10);
        grpPidWorkflow.Name = "grpPidWorkflow";
        grpPidWorkflow.Padding = new Padding(10);
        grpPidWorkflow.Size = new Size(1343, 190);
        grpPidWorkflow.TabIndex = 2;
        grpPidWorkflow.TabStop = false;
        grpPidWorkflow.Text = "PID Tuning Workflow";
        // 
        // pidWorkflowLayout
        // 
        pidWorkflowLayout.ColumnCount = 2;
        pidWorkflowLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        pidWorkflowLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        pidWorkflowLayout.Controls.Add(pidButtonLayout, 0, 0);
        pidWorkflowLayout.Controls.Add(txtPidValues, 1, 3);
        pidWorkflowLayout.Controls.Add(lblActiveAxisTitle, 1, 0);
        pidWorkflowLayout.Controls.Add(lblActiveAxis, 1, 1);
        pidWorkflowLayout.Controls.Add(lblPidValuesTitle, 1, 2);
        pidWorkflowLayout.Controls.Add(txtPidRecommendation, 0, 1);
        pidWorkflowLayout.Location = new Point(10, 26);
        pidWorkflowLayout.Name = "pidWorkflowLayout";
        pidWorkflowLayout.RowCount = 4;
        pidWorkflowLayout.RowStyles.Add(new RowStyle());
        pidWorkflowLayout.RowStyles.Add(new RowStyle());
        pidWorkflowLayout.RowStyles.Add(new RowStyle());
        pidWorkflowLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        pidWorkflowLayout.Size = new Size(1323, 154);
        pidWorkflowLayout.TabIndex = 0;
        // 
        // pidButtonLayout
        // 
        pidButtonLayout.Controls.Add(btnTuneRoll);
        pidButtonLayout.Controls.Add(btnTunePitch);
        pidButtonLayout.Controls.Add(btnRetestAxis);
        pidButtonLayout.Controls.Add(btnFinishAxis);
        pidButtonLayout.Controls.Add(btnApplyRecommendedPid);
        pidButtonLayout.Controls.Add(cmbManualAxis);
        pidButtonLayout.Controls.Add(cmbManualGain);
        pidButtonLayout.Controls.Add(cmbManualPoints);
        pidButtonLayout.Controls.Add(btnManualPidMinus);
        pidButtonLayout.Controls.Add(btnManualPidPlus);
        pidButtonLayout.Controls.Add(btnReadFcPid);
        pidButtonLayout.Controls.Add(btnSaveFcPid);
        pidButtonLayout.Location = new Point(3, 3);
        pidButtonLayout.Name = "pidButtonLayout";
        pidButtonLayout.Size = new Size(544, 52);
        pidButtonLayout.TabIndex = 0;
        // 
        // btnTuneRoll
        // 
        btnTuneRoll.Location = new Point(3, 3);
        btnTuneRoll.Name = "btnTuneRoll";
        btnTuneRoll.Size = new Size(90, 29);
        btnTuneRoll.TabIndex = 0;
        btnTuneRoll.Text = "Run Roll";
        btnTuneRoll.UseVisualStyleBackColor = true;
        btnTuneRoll.Click += btnTuneRoll_Click;
        // 
        // btnTunePitch
        // 
        btnTunePitch.Location = new Point(99, 3);
        btnTunePitch.Name = "btnTunePitch";
        btnTunePitch.Size = new Size(90, 29);
        btnTunePitch.TabIndex = 1;
        btnTunePitch.Text = "Run Pitch";
        btnTunePitch.UseVisualStyleBackColor = true;
        btnTunePitch.Click += btnTunePitch_Click;
        // 
        // btnRetestAxis
        // 
        btnRetestAxis.Location = new Point(195, 3);
        btnRetestAxis.Name = "btnRetestAxis";
        btnRetestAxis.Size = new Size(90, 29);
        btnRetestAxis.TabIndex = 2;
        btnRetestAxis.Text = "Re-test";
        btnRetestAxis.UseVisualStyleBackColor = true;
        btnRetestAxis.Click += btnRetestAxis_Click;
        // 
        // btnFinishAxis
        // 
        btnFinishAxis.Location = new Point(291, 3);
        btnFinishAxis.Name = "btnFinishAxis";
        btnFinishAxis.Size = new Size(90, 29);
        btnFinishAxis.TabIndex = 3;
        btnFinishAxis.Text = "Finish Axis";
        btnFinishAxis.UseVisualStyleBackColor = true;
        btnFinishAxis.Click += btnFinishAxis_Click;
        // 
        // btnApplyRecommendedPid
        // 
        btnApplyRecommendedPid.Location = new Point(3, 38);
        btnApplyRecommendedPid.Name = "btnApplyRecommendedPid";
        btnApplyRecommendedPid.Size = new Size(160, 29);
        btnApplyRecommendedPid.TabIndex = 4;
        btnApplyRecommendedPid.Text = "Apply Recommended PID";
        btnApplyRecommendedPid.UseVisualStyleBackColor = true;
        btnApplyRecommendedPid.Click += btnApplyRecommendedPid_Click;
        // 
        // cmbManualAxis
        // 
        cmbManualAxis.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualAxis.FormattingEnabled = true;
        cmbManualAxis.Location = new Point(169, 38);
        cmbManualAxis.Name = "cmbManualAxis";
        cmbManualAxis.Size = new Size(84, 23);
        cmbManualAxis.TabIndex = 5;
        // 
        // cmbManualGain
        // 
        cmbManualGain.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualGain.FormattingEnabled = true;
        cmbManualGain.Location = new Point(259, 38);
        cmbManualGain.Name = "cmbManualGain";
        cmbManualGain.Size = new Size(60, 23);
        cmbManualGain.TabIndex = 6;
        // 
        // cmbManualPoints
        // 
        cmbManualPoints.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualPoints.FormattingEnabled = true;
        cmbManualPoints.Location = new Point(325, 38);
        cmbManualPoints.Name = "cmbManualPoints";
        cmbManualPoints.Size = new Size(60, 23);
        cmbManualPoints.TabIndex = 7;
        // 
        // btnManualPidMinus
        // 
        btnManualPidMinus.Location = new Point(391, 38);
        btnManualPidMinus.Name = "btnManualPidMinus";
        btnManualPidMinus.Size = new Size(58, 28);
        btnManualPidMinus.TabIndex = 8;
        btnManualPidMinus.Text = "PID -";
        btnManualPidMinus.UseVisualStyleBackColor = true;
        btnManualPidMinus.Click += btnManualPidMinus_Click;
        // 
        // btnManualPidPlus
        // 
        btnManualPidPlus.Location = new Point(455, 38);
        btnManualPidPlus.Name = "btnManualPidPlus";
        btnManualPidPlus.Size = new Size(58, 28);
        btnManualPidPlus.TabIndex = 9;
        btnManualPidPlus.Text = "PID +";
        btnManualPidPlus.UseVisualStyleBackColor = true;
        btnManualPidPlus.Click += btnManualPidPlus_Click;
        // 
        // btnReadFcPid
        // 
        btnReadFcPid.Location = new Point(3, 73);
        btnReadFcPid.Name = "btnReadFcPid";
        btnReadFcPid.Size = new Size(75, 28);
        btnReadFcPid.TabIndex = 10;
        btnReadFcPid.Text = "Read FC";
        btnReadFcPid.UseVisualStyleBackColor = true;
        btnReadFcPid.Click += btnReadFcPid_Click;
        // 
        // btnSaveFcPid
        // 
        btnSaveFcPid.Location = new Point(84, 73);
        btnSaveFcPid.Name = "btnSaveFcPid";
        btnSaveFcPid.Size = new Size(75, 28);
        btnSaveFcPid.TabIndex = 11;
        btnSaveFcPid.Text = "Save FC";
        btnSaveFcPid.UseVisualStyleBackColor = true;
        btnSaveFcPid.Click += btnSaveFcPid_Click;
        // 
        // txtPidValues
        // 
        txtPidValues.Dock = DockStyle.Fill;
        txtPidValues.Location = new Point(929, 91);
        txtPidValues.Multiline = true;
        txtPidValues.Name = "txtPidValues";
        txtPidValues.ReadOnly = true;
        txtPidValues.Size = new Size(391, 60);
        txtPidValues.TabIndex = 5;
        txtPidValues.Text = "Roll P/I/D: --/--/--\r\nPitch P/I/D: --/--/--";
        // 
        // lblActiveAxisTitle
        // 
        lblActiveAxisTitle.Anchor = AnchorStyles.Left;
        lblActiveAxisTitle.Location = new Point(929, 21);
        lblActiveAxisTitle.Name = "lblActiveAxisTitle";
        lblActiveAxisTitle.Size = new Size(65, 15);
        lblActiveAxisTitle.TabIndex = 1;
        lblActiveAxisTitle.Text = "Active Axis";
        // 
        // lblActiveAxis
        // 
        lblActiveAxis.Anchor = AnchorStyles.Left;
        lblActiveAxis.Location = new Point(929, 58);
        lblActiveAxis.Name = "lblActiveAxis";
        lblActiveAxis.Size = new Size(29, 15);
        lblActiveAxis.TabIndex = 2;
        lblActiveAxis.Text = "N/A";
        // 
        // lblPidValuesTitle
        // 
        lblPidValuesTitle.Anchor = AnchorStyles.Left;
        lblPidValuesTitle.Location = new Point(929, 73);
        lblPidValuesTitle.Name = "lblPidValuesTitle";
        lblPidValuesTitle.Size = new Size(94, 15);
        lblPidValuesTitle.TabIndex = 4;
        lblPidValuesTitle.Text = "FC PID Snapshot";
        // 
        // txtPidRecommendation
        // 
        txtPidRecommendation.Dock = DockStyle.Fill;
        txtPidRecommendation.Location = new Point(3, 61);
        txtPidRecommendation.Multiline = true;
        txtPidRecommendation.Name = "txtPidRecommendation";
        txtPidRecommendation.ReadOnly = true;
        pidWorkflowLayout.SetRowSpan(txtPidRecommendation, 3);
        txtPidRecommendation.Size = new Size(920, 90);
        txtPidRecommendation.TabIndex = 3;
        txtPidRecommendation.Text = "Run Roll or Pitch to generate a recommendation.";
        // 
        // grpTuningProgress
        // 
        grpTuningProgress.Controls.Add(tuningProgressLayout);
        grpTuningProgress.Dock = DockStyle.Fill;
        grpTuningProgress.Location = new Point(10, 10);
        grpTuningProgress.Name = "grpTuningProgress";
        grpTuningProgress.Padding = new Padding(10);
        grpTuningProgress.Size = new Size(1343, 744);
        grpTuningProgress.TabIndex = 3;
        grpTuningProgress.TabStop = false;
        grpTuningProgress.Text = "Tuning Progression Charts and Recommendations";
        // 
        // tuningProgressLayout
        // 
        tuningProgressLayout.ColumnCount = 2;
        tuningProgressLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tuningProgressLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tuningProgressLayout.Controls.Add(pnlScoreChart, 0, 0);
        tuningProgressLayout.Controls.Add(lvTuningRuns, 1, 0);
        tuningProgressLayout.Dock = DockStyle.Fill;
        tuningProgressLayout.Location = new Point(10, 26);
        tuningProgressLayout.Name = "tuningProgressLayout";
        tuningProgressLayout.RowCount = 1;
        tuningProgressLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tuningProgressLayout.Size = new Size(1323, 708);
        tuningProgressLayout.TabIndex = 0;
        // 
        // pnlScoreChart
        // 
        pnlScoreChart.BackColor = Color.White;
        pnlScoreChart.BorderStyle = BorderStyle.FixedSingle;
        pnlScoreChart.Dock = DockStyle.Fill;
        pnlScoreChart.Location = new Point(3, 3);
        pnlScoreChart.Name = "pnlScoreChart";
        pnlScoreChart.Size = new Size(655, 702);
        pnlScoreChart.TabIndex = 0;
        pnlScoreChart.Paint += pnlScoreChart_Paint;
        // 
        // lvTuningRuns
        // 
        lvTuningRuns.Columns.AddRange(new ColumnHeader[] { colRun, colAxis, colScore, colDecision });
        lvTuningRuns.Dock = DockStyle.Fill;
        lvTuningRuns.FullRowSelect = true;
        lvTuningRuns.Location = new Point(664, 3);
        lvTuningRuns.Name = "lvTuningRuns";
        lvTuningRuns.Size = new Size(656, 702);
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
        // pnlStatus
        // 
        pnlStatus.Location = new Point(0, 0);
        pnlStatus.Name = "pnlStatus";
        pnlStatus.Size = new Size(200, 100);
        pnlStatus.TabIndex = 0;
        // 
        // panel1
        // 
        panel1.Location = new Point(-5000, -5000);
        panel1.Name = "panel1";
        panel1.Size = new Size(1, 1);
        panel1.TabIndex = 2;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1389, 983);
        Controls.Add(rootLayout);
        MinimumSize = new Size(900, 560);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Drone PID Tuning Assistant (WinForms)";
        rootLayout.ResumeLayout(false);
        rootLayout.PerformLayout();
        topLayout.ResumeLayout(false);
        topLayout.PerformLayout();
        grpUsb.ResumeLayout(false);
        usbLayout.ResumeLayout(false);
        grpMapping.ResumeLayout(false);
        mappingLayout.ResumeLayout(false);
        grpPortingArea.ResumeLayout(false);
        grpChannelTest.ResumeLayout(false);
        channelTestLayout.ResumeLayout(false);
        channelActionLayout.ResumeLayout(false);
        channelVisualLayout.ResumeLayout(false);
        channelInputsLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).EndInit();
        grpTelemetry.ResumeLayout(false);
        telemetryLayout.ResumeLayout(false);
        telemetryButtonLayout.ResumeLayout(false);
        telemetryValueLayout.ResumeLayout(false);
        grpPidWorkflow.ResumeLayout(false);
        pidWorkflowLayout.ResumeLayout(false);
        pidWorkflowLayout.PerformLayout();
        pidButtonLayout.ResumeLayout(false);
        grpTuningProgress.ResumeLayout(false);
        tuningProgressLayout.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel rootLayout;
    private TableLayoutPanel topLayout;
    private GroupBox grpUsb;
    private TableLayoutPanel usbLayout;
    private Label lblPort;
    private ComboBox cboPort;
    private ComboBox cboBaud;
    private Label lblArduinoPort;
    private ComboBox cboArduinoPort;
    private ComboBox cboArduinoBaud;
    private Button btnRefreshPorts;
    private Button btnConnect;
    private Button btnDisconnect;
    private Button btnArduinoConnect;
    private Button btnArduinoDisconnect;
    private GroupBox grpMapping;
    private TableLayoutPanel mappingLayout;
    private Label lblRoll;
    private ComboBox cboCH1;
    private Label lblPitch;
    private ComboBox cboCH2;
    private Label lblThrottle;
    private ComboBox cboCH3;
    private Label lblCh4;
    private ComboBox cboCH4;
    private Button btnApplyMapping;
    private Panel grpPortingArea;
    private GroupBox grpChannelTest;
    private GroupBox grpTelemetry;
    private GroupBox grpPidWorkflow;
    private GroupBox grpTuningProgress;
    private TableLayoutPanel pidWorkflowLayout;
    private FlowLayoutPanel pidButtonLayout;
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
    private TableLayoutPanel tuningProgressLayout;
    private Panel pnlScoreChart;
    private ListView lvTuningRuns;
    private ColumnHeader colRun;
    private ColumnHeader colAxis;
    private ColumnHeader colScore;
    private ColumnHeader colDecision;
    private TableLayoutPanel telemetryLayout;
    private FlowLayoutPanel telemetryButtonLayout;
    private Button btnTelemetryStart;
    private Button btnTelemetryStop;
    private Button btnTelemetrySnapshot;
    private TableLayoutPanel telemetryValueLayout;
    private Label lblTelemetryRollTitle;
    private Label lblTelemetryRoll;
    private Label lblTelemetryPitchTitle;
    private Label lblTelemetryPitch;
    private Label lblTelemetryYawTitle;
    private Label lblTelemetryYaw;
    private TableLayoutPanel channelTestLayout;
    private FlowLayoutPanel channelActionLayout;
    private Button btnTestRoll;
    private Button btnTestPitch;
    private Button btnTestThrottle;
    private TableLayoutPanel channelVisualLayout;
    private Label lblChannelVisualTitle;
    private Label lblChannelVisual;
    private Label lblChannelValueTitle;
    private Label lblChannelValue;
    private Label lblRollAngleTitle;
    private Label lblRollAngle;
    private Label lblPitchAngleTitle;
    private Label lblPitchAngle;
    private TableLayoutPanel channelInputsLayout;
    private Label lblTargetDeg;
    private NumericUpDown nudTargetDeg;
    private Label lblSettleSec;
    private NumericUpDown nudSettleSec;
    private Label lblBaselineSec;
    private NumericUpDown nudBaselineSec;
    private Label lblThrottleUs;
    private NumericUpDown nudThrottleUs;
    private Panel pnlStatus;
    private Label lblStatus;
    private Panel panel1;
}



