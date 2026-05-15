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
        lblBaud = new Label();
        lblBaudValue = new Label();
        btnRefreshPorts = new Button();
        btnConnect = new Button();
        btnDisconnect = new Button();
        lblArduinoPort = new Label();
        cboArduinoPort = new ComboBox();
        lblArduinoBaud = new Label();
        lblArduinoBaudValue = new Label();
        btnArduinoConnect = new Button();
        btnArduinoDisconnect = new Button();
        lblStatus = new Label();
        grpMapping = new GroupBox();
        mappingLayout = new TableLayoutPanel();
        lblRoll = new Label();
        cboRoll = new ComboBox();
        lblPitch = new Label();
        cboPitch = new ComboBox();
        lblThrottle = new Label();
        cboThrottle = new ComboBox();
        btnApplyMapping = new Button();
        grpPortingArea = new GroupBox();
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
        splitterChannel = new Splitter();
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
        splitterTelemetry = new Splitter();
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
        lblActiveAxisTitle = new Label();
        lblActiveAxis = new Label();
        lblPidValuesTitle = new Label();
        txtPidValues = new TextBox();
        txtPidRecommendation = new TextBox();
        splitterPid = new Splitter();
        grpTuningProgress = new GroupBox();
        tuningProgressLayout = new TableLayoutPanel();
        pnlScoreChart = new Panel();
        lvTuningRuns = new ListView();
        colRun = new ColumnHeader();
        colAxis = new ColumnHeader();
        colScore = new ColumnHeader();
        colDecision = new ColumnHeader();
        pnlStatus = new Panel();
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
        topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.25165F));
        topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.74835F));
        topLayout.Controls.Add(grpUsb, 0, 0);
        topLayout.Controls.Add(grpMapping, 1, 0);
        topLayout.Dock = DockStyle.Fill;
        topLayout.Location = new Point(13, 13);
        topLayout.Name = "topLayout";
        topLayout.RowCount = 1;
        topLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        topLayout.Size = new Size(1363, 132);
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
        grpUsb.Size = new Size(529, 126);
        grpUsb.TabIndex = 0;
        grpUsb.TabStop = false;
        grpUsb.Text = "Serial Ports";
        // 
        // usbLayout
        // 
        usbLayout.AutoSize = true;
        usbLayout.ColumnCount = 7;
        usbLayout.ColumnStyles.Add(new ColumnStyle());
        usbLayout.ColumnStyles.Add(new ColumnStyle());
        usbLayout.ColumnStyles.Add(new ColumnStyle());
        usbLayout.ColumnStyles.Add(new ColumnStyle());
        usbLayout.ColumnStyles.Add(new ColumnStyle());
        usbLayout.ColumnStyles.Add(new ColumnStyle());
        usbLayout.ColumnStyles.Add(new ColumnStyle());
        usbLayout.Controls.Add(lblPort, 0, 0);
        usbLayout.Controls.Add(cboPort, 1, 0);
        usbLayout.Controls.Add(lblBaud, 2, 0);
        usbLayout.Controls.Add(lblBaudValue, 3, 0);
        usbLayout.Controls.Add(btnRefreshPorts, 4, 0);
        usbLayout.Controls.Add(btnConnect, 5, 0);
        usbLayout.Controls.Add(btnDisconnect, 6, 0);
        usbLayout.Controls.Add(lblArduinoPort, 0, 1);
        usbLayout.Controls.Add(cboArduinoPort, 1, 1);
        usbLayout.Controls.Add(lblArduinoBaud, 2, 1);
        usbLayout.Controls.Add(lblArduinoBaudValue, 3, 1);
        usbLayout.Controls.Add(btnArduinoConnect, 5, 1);
        usbLayout.Controls.Add(btnArduinoDisconnect, 6, 1);
        usbLayout.Controls.Add(lblStatus, 0, 2);
        usbLayout.Dock = DockStyle.Top;
        usbLayout.Location = new Point(10, 26);
        usbLayout.Name = "usbLayout";
        usbLayout.RowCount = 3;
        usbLayout.RowStyles.Add(new RowStyle());
        usbLayout.RowStyles.Add(new RowStyle());
        usbLayout.RowStyles.Add(new RowStyle());
        usbLayout.Size = new Size(509, 90);
        usbLayout.TabIndex = 0;
        // 
        // lblPort
        // 
        lblPort.Anchor = AnchorStyles.Left;
        lblPort.AutoSize = true;
        lblPort.Location = new Point(3, 9);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(45, 15);
        lblPort.TabIndex = 0;
        lblPort.Text = "FC USB";
        // 
        // cboPort
        // 
        cboPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPort.FormattingEnabled = true;
        cboPort.Location = new Point(59, 3);
        cboPort.Name = "cboPort";
        cboPort.Size = new Size(81, 23);
        cboPort.TabIndex = 1;
        // 
        // lblBaud
        // 
        lblBaud.Anchor = AnchorStyles.Left;
        lblBaud.AutoSize = true;
        lblBaud.Location = new Point(146, 9);
        lblBaud.Name = "lblBaud";
        lblBaud.Size = new Size(34, 15);
        lblBaud.TabIndex = 2;
        lblBaud.Text = "Baud";
        // 
        // lblBaudValue
        // 
        lblBaudValue.Anchor = AnchorStyles.Left;
        lblBaudValue.AutoSize = true;
        lblBaudValue.Location = new Point(186, 9);
        lblBaudValue.Name = "lblBaudValue";
        lblBaudValue.Size = new Size(43, 15);
        lblBaudValue.TabIndex = 3;
        lblBaudValue.Text = "115200";
        // 
        // btnRefreshPorts
        // 
        btnRefreshPorts.Location = new Point(235, 3);
        btnRefreshPorts.Name = "btnRefreshPorts";
        btnRefreshPorts.Size = new Size(75, 28);
        btnRefreshPorts.TabIndex = 4;
        btnRefreshPorts.Text = "Refresh";
        btnRefreshPorts.UseVisualStyleBackColor = true;
        btnRefreshPorts.Click += btnRefreshPorts_Click;
        // 
        // btnConnect
        // 
        btnConnect.Location = new Point(316, 3);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(75, 28);
        btnConnect.TabIndex = 5;
        btnConnect.Text = "Connect";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // btnDisconnect
        // 
        btnDisconnect.Location = new Point(397, 3);
        btnDisconnect.Name = "btnDisconnect";
        btnDisconnect.Size = new Size(75, 28);
        btnDisconnect.TabIndex = 6;
        btnDisconnect.Text = "Disconnect";
        btnDisconnect.UseVisualStyleBackColor = true;
        btnDisconnect.Click += btnDisconnect_Click;
        // 
        // lblArduinoPort
        // 
        lblArduinoPort.Anchor = AnchorStyles.Left;
        lblArduinoPort.AutoSize = true;
        lblArduinoPort.Location = new Point(3, 43);
        lblArduinoPort.Name = "lblArduinoPort";
        lblArduinoPort.Size = new Size(50, 15);
        lblArduinoPort.TabIndex = 7;
        lblArduinoPort.Text = "Arduino";
        // 
        // cboArduinoPort
        // 
        cboArduinoPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoPort.FormattingEnabled = true;
        cboArduinoPort.Location = new Point(59, 37);
        cboArduinoPort.Name = "cboArduinoPort";
        cboArduinoPort.Size = new Size(79, 23);
        cboArduinoPort.TabIndex = 8;
        // 
        // lblArduinoBaud
        // 
        lblArduinoBaud.Anchor = AnchorStyles.Left;
        lblArduinoBaud.AutoSize = true;
        lblArduinoBaud.Location = new Point(146, 43);
        lblArduinoBaud.Name = "lblArduinoBaud";
        lblArduinoBaud.Size = new Size(34, 15);
        lblArduinoBaud.TabIndex = 9;
        lblArduinoBaud.Text = "Baud";
        // 
        // lblArduinoBaudValue
        // 
        lblArduinoBaudValue.Anchor = AnchorStyles.Left;
        lblArduinoBaudValue.AutoSize = true;
        lblArduinoBaudValue.Location = new Point(186, 43);
        lblArduinoBaudValue.Name = "lblArduinoBaudValue";
        lblArduinoBaudValue.Size = new Size(43, 15);
        lblArduinoBaudValue.TabIndex = 10;
        lblArduinoBaudValue.Text = "115200";
        // 
        // btnArduinoConnect
        // 
        btnArduinoConnect.Location = new Point(316, 37);
        btnArduinoConnect.Name = "btnArduinoConnect";
        btnArduinoConnect.Size = new Size(75, 28);
        btnArduinoConnect.TabIndex = 11;
        btnArduinoConnect.Text = "Connect";
        btnArduinoConnect.UseVisualStyleBackColor = true;
        btnArduinoConnect.Click += btnArduinoConnect_Click;
        // 
        // btnArduinoDisconnect
        // 
        btnArduinoDisconnect.Location = new Point(397, 37);
        btnArduinoDisconnect.Name = "btnArduinoDisconnect";
        btnArduinoDisconnect.Size = new Size(75, 28);
        btnArduinoDisconnect.TabIndex = 12;
        btnArduinoDisconnect.Text = "Disconnect";
        btnArduinoDisconnect.UseVisualStyleBackColor = true;
        btnArduinoDisconnect.Click += btnArduinoDisconnect_Click;
        // 
        // lblStatus
        // 
        lblStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        usbLayout.SetColumnSpan(lblStatus, 7);
        lblStatus.Location = new Point(3, 71);
        lblStatus.Margin = new Padding(3, 3, 3, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(649, 19);
        lblStatus.TabIndex = 13;
        lblStatus.Text = "Ready.";
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grpMapping
        // 
        grpMapping.AutoSize = true;
        grpMapping.Controls.Add(mappingLayout);
        grpMapping.Dock = DockStyle.Fill;
        grpMapping.Location = new Point(538, 3);
        grpMapping.Name = "grpMapping";
        grpMapping.Padding = new Padding(10);
        grpMapping.Size = new Size(822, 126);
        grpMapping.TabIndex = 1;
        grpMapping.TabStop = false;
        grpMapping.Text = "Transmitter PPM Channel Mapping";
        // 
        // mappingLayout
        // 
        mappingLayout.AutoSize = true;
        mappingLayout.ColumnCount = 3;
        mappingLayout.ColumnStyles.Add(new ColumnStyle());
        mappingLayout.ColumnStyles.Add(new ColumnStyle());
        mappingLayout.ColumnStyles.Add(new ColumnStyle());
        mappingLayout.Controls.Add(lblRoll, 0, 0);
        mappingLayout.Controls.Add(cboRoll, 1, 0);
        mappingLayout.Controls.Add(lblPitch, 0, 1);
        mappingLayout.Controls.Add(cboPitch, 1, 1);
        mappingLayout.Controls.Add(lblThrottle, 0, 2);
        mappingLayout.Controls.Add(cboThrottle, 1, 2);
        mappingLayout.Controls.Add(btnApplyMapping, 2, 0);
        mappingLayout.Dock = DockStyle.Top;
        mappingLayout.Location = new Point(10, 26);
        mappingLayout.Name = "mappingLayout";
        mappingLayout.RowCount = 3;
        mappingLayout.RowStyles.Add(new RowStyle());
        mappingLayout.RowStyles.Add(new RowStyle());
        mappingLayout.RowStyles.Add(new RowStyle());
        mappingLayout.Size = new Size(802, 87);
        mappingLayout.TabIndex = 0;
        // 
        // lblRoll
        // 
        lblRoll.Anchor = AnchorStyles.Left;
        lblRoll.AutoSize = true;
        lblRoll.Location = new Point(3, 7);
        lblRoll.Name = "lblRoll";
        lblRoll.Size = new Size(27, 15);
        lblRoll.TabIndex = 0;
        lblRoll.Text = "Roll";
        // 
        // cboRoll
        // 
        cboRoll.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRoll.FormattingEnabled = true;
        cboRoll.Location = new Point(57, 3);
        cboRoll.Name = "cboRoll";
        cboRoll.Size = new Size(70, 23);
        cboRoll.TabIndex = 1;
        // 
        // lblPitch
        // 
        lblPitch.Anchor = AnchorStyles.Left;
        lblPitch.AutoSize = true;
        lblPitch.Location = new Point(3, 36);
        lblPitch.Name = "lblPitch";
        lblPitch.Size = new Size(34, 15);
        lblPitch.TabIndex = 2;
        lblPitch.Text = "Pitch";
        // 
        // cboPitch
        // 
        cboPitch.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPitch.FormattingEnabled = true;
        cboPitch.Location = new Point(57, 32);
        cboPitch.Name = "cboPitch";
        cboPitch.Size = new Size(70, 23);
        cboPitch.TabIndex = 3;
        // 
        // lblThrottle
        // 
        lblThrottle.Anchor = AnchorStyles.Left;
        lblThrottle.AutoSize = true;
        lblThrottle.Location = new Point(3, 65);
        lblThrottle.Name = "lblThrottle";
        lblThrottle.Size = new Size(48, 15);
        lblThrottle.TabIndex = 4;
        lblThrottle.Text = "Throttle";
        // 
        // cboThrottle
        // 
        cboThrottle.DropDownStyle = ComboBoxStyle.DropDownList;
        cboThrottle.FormattingEnabled = true;
        cboThrottle.Location = new Point(57, 61);
        cboThrottle.Name = "cboThrottle";
        cboThrottle.Size = new Size(70, 23);
        cboThrottle.TabIndex = 5;
        // 
        // btnApplyMapping
        // 
        btnApplyMapping.Location = new Point(133, 3);
        btnApplyMapping.Name = "btnApplyMapping";
        mappingLayout.SetRowSpan(btnApplyMapping, 3);
        btnApplyMapping.Size = new Size(75, 28);
        btnApplyMapping.TabIndex = 6;
        btnApplyMapping.Text = "Apply";
        btnApplyMapping.UseVisualStyleBackColor = true;
        btnApplyMapping.Click += btnApplyMapping_Click;
        // 
        // grpPortingArea
        // 
        grpPortingArea.Controls.Add(grpChannelTest);
        grpPortingArea.Controls.Add(splitterChannel);
        grpPortingArea.Controls.Add(grpTelemetry);
        grpPortingArea.Controls.Add(splitterTelemetry);
        grpPortingArea.Controls.Add(grpPidWorkflow);
        grpPortingArea.Controls.Add(splitterPid);
        grpPortingArea.Controls.Add(grpTuningProgress);
        grpPortingArea.Dock = DockStyle.Fill;
        grpPortingArea.Location = new Point(13, 151);
        grpPortingArea.Name = "grpPortingArea";
        grpPortingArea.Padding = new Padding(10);
        grpPortingArea.Size = new Size(1363, 819);
        grpPortingArea.TabIndex = 1;
        grpPortingArea.TabStop = false;
        grpPortingArea.Text = "Porting Area";
        // 
        // grpChannelTest
        // 
        grpChannelTest.Controls.Add(channelTestLayout);
        grpChannelTest.Dock = DockStyle.Top;
        grpChannelTest.Location = new Point(10, 379);
        grpChannelTest.Name = "grpChannelTest";
        grpChannelTest.Padding = new Padding(10);
        grpChannelTest.Size = new Size(1343, 167);
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
        channelTestLayout.RowStyles.Add(new RowStyle());
        channelTestLayout.RowStyles.Add(new RowStyle());
        channelTestLayout.RowStyles.Add(new RowStyle());
        channelTestLayout.RowStyles.Add(new RowStyle());
        channelTestLayout.Size = new Size(1323, 131);
        channelTestLayout.TabIndex = 0;
        // 
        // channelActionLayout
        // 
        channelActionLayout.AutoSize = true;
        channelActionLayout.Controls.Add(btnTestRoll);
        channelActionLayout.Controls.Add(btnTestPitch);
        channelActionLayout.Controls.Add(btnTestThrottle);
        channelActionLayout.Dock = DockStyle.Fill;
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
        channelVisualLayout.AutoSize = true;
        channelVisualLayout.ColumnCount = 8;
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.ColumnStyles.Add(new ColumnStyle());
        channelVisualLayout.Controls.Add(lblChannelVisualTitle, 0, 0);
        channelVisualLayout.Controls.Add(lblChannelVisual, 1, 0);
        channelVisualLayout.Controls.Add(lblChannelValueTitle, 2, 0);
        channelVisualLayout.Controls.Add(lblChannelValue, 3, 0);
        channelVisualLayout.Controls.Add(lblRollAngleTitle, 4, 0);
        channelVisualLayout.Controls.Add(lblRollAngle, 5, 0);
        channelVisualLayout.Controls.Add(lblPitchAngleTitle, 6, 0);
        channelVisualLayout.Controls.Add(lblPitchAngle, 7, 0);
        channelVisualLayout.Dock = DockStyle.Fill;
        channelVisualLayout.Location = new Point(3, 44);
        channelVisualLayout.Name = "channelVisualLayout";
        channelVisualLayout.RowCount = 1;
        channelVisualLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        channelVisualLayout.Size = new Size(1317, 15);
        channelVisualLayout.TabIndex = 1;
        // 
        // lblChannelVisualTitle
        // 
        lblChannelVisualTitle.Anchor = AnchorStyles.Left;
        lblChannelVisualTitle.AutoSize = true;
        lblChannelVisualTitle.Location = new Point(3, 0);
        lblChannelVisualTitle.Name = "lblChannelVisualTitle";
        lblChannelVisualTitle.Size = new Size(42, 15);
        lblChannelVisualTitle.TabIndex = 0;
        lblChannelVisualTitle.Text = "Status:";
        // 
        // lblChannelVisual
        // 
        lblChannelVisual.Anchor = AnchorStyles.Left;
        lblChannelVisual.AutoSize = true;
        lblChannelVisual.Location = new Point(51, 0);
        lblChannelVisual.Name = "lblChannelVisual";
        lblChannelVisual.Size = new Size(26, 15);
        lblChannelVisual.TabIndex = 1;
        lblChannelVisual.Text = "Idle";
        // 
        // lblChannelValueTitle
        // 
        lblChannelValueTitle.Anchor = AnchorStyles.Left;
        lblChannelValueTitle.AutoSize = true;
        lblChannelValueTitle.Location = new Point(83, 0);
        lblChannelValueTitle.Name = "lblChannelValueTitle";
        lblChannelValueTitle.Size = new Size(38, 15);
        lblChannelValueTitle.TabIndex = 2;
        lblChannelValueTitle.Text = "Pulse:";
        // 
        // lblChannelValue
        // 
        lblChannelValue.Anchor = AnchorStyles.Left;
        lblChannelValue.AutoSize = true;
        lblChannelValue.Location = new Point(127, 0);
        lblChannelValue.Name = "lblChannelValue";
        lblChannelValue.Size = new Size(46, 15);
        lblChannelValue.TabIndex = 3;
        lblChannelValue.Text = "1500 us";
        // 
        // lblRollAngleTitle
        // 
        lblRollAngleTitle.Anchor = AnchorStyles.Left;
        lblRollAngleTitle.AutoSize = true;
        lblRollAngleTitle.Location = new Point(179, 0);
        lblRollAngleTitle.Name = "lblRollAngleTitle";
        lblRollAngleTitle.Size = new Size(62, 15);
        lblRollAngleTitle.TabIndex = 4;
        lblRollAngleTitle.Text = "Roll angle:";
        // 
        // lblRollAngle
        // 
        lblRollAngle.Anchor = AnchorStyles.Left;
        lblRollAngle.AutoSize = true;
        lblRollAngle.Location = new Point(247, 0);
        lblRollAngle.Name = "lblRollAngle";
        lblRollAngle.Size = new Size(27, 15);
        lblRollAngle.TabIndex = 5;
        lblRollAngle.Text = "0.0°";
        // 
        // lblPitchAngleTitle
        // 
        lblPitchAngleTitle.Anchor = AnchorStyles.Left;
        lblPitchAngleTitle.AutoSize = true;
        lblPitchAngleTitle.Location = new Point(280, 0);
        lblPitchAngleTitle.Name = "lblPitchAngleTitle";
        lblPitchAngleTitle.Size = new Size(69, 15);
        lblPitchAngleTitle.TabIndex = 6;
        lblPitchAngleTitle.Text = "Pitch angle:";
        // 
        // lblPitchAngle
        // 
        lblPitchAngle.Anchor = AnchorStyles.Left;
        lblPitchAngle.AutoSize = true;
        lblPitchAngle.Location = new Point(355, 0);
        lblPitchAngle.Name = "lblPitchAngle";
        lblPitchAngle.Size = new Size(27, 15);
        lblPitchAngle.TabIndex = 7;
        lblPitchAngle.Text = "0.0°";
        // 
        // channelInputsLayout
        // 
        channelInputsLayout.AutoSize = true;
        channelInputsLayout.ColumnCount = 8;
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.ColumnStyles.Add(new ColumnStyle());
        channelInputsLayout.Controls.Add(lblTargetDeg, 0, 0);
        channelInputsLayout.Controls.Add(lblSettleSec, 2, 0);
        channelInputsLayout.Controls.Add(nudSettleSec, 3, 0);
        channelInputsLayout.Controls.Add(lblBaselineSec, 4, 0);
        channelInputsLayout.Controls.Add(nudBaselineSec, 5, 0);
        channelInputsLayout.Controls.Add(lblThrottleUs, 6, 0);
        channelInputsLayout.Controls.Add(nudThrottleUs, 7, 0);
        channelInputsLayout.Controls.Add(nudTargetDeg, 1, 0);
        channelInputsLayout.Dock = DockStyle.Fill;
        channelInputsLayout.Location = new Point(3, 65);
        channelInputsLayout.Name = "channelInputsLayout";
        channelInputsLayout.RowCount = 1;
        channelInputsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        channelInputsLayout.Size = new Size(1317, 63);
        channelInputsLayout.TabIndex = 3;
        // 
        // lblTargetDeg
        // 
        lblTargetDeg.Anchor = AnchorStyles.Left;
        lblTargetDeg.AutoSize = true;
        lblTargetDeg.Location = new Point(3, 24);
        lblTargetDeg.Name = "lblTargetDeg";
        lblTargetDeg.Size = new Size(55, 15);
        lblTargetDeg.TabIndex = 0;
        lblTargetDeg.Text = "Target Δ°";
        // 
        // lblSettleSec
        // 
        lblSettleSec.Anchor = AnchorStyles.Left;
        lblSettleSec.AutoSize = true;
        lblSettleSec.Location = new Point(134, 24);
        lblSettleSec.Name = "lblSettleSec";
        lblSettleSec.Size = new Size(92, 15);
        lblSettleSec.TabIndex = 2;
        lblSettleSec.Text = "Pre-Test Wait (s)";
        // 
        // nudSettleSec
        // 
        nudSettleSec.DecimalPlaces = 1;
        nudSettleSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudSettleSec.Location = new Point(232, 3);
        nudSettleSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudSettleSec.Name = "nudSettleSec";
        nudSettleSec.Size = new Size(64, 23);
        nudSettleSec.TabIndex = 3;
        nudSettleSec.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblBaselineSec
        // 
        lblBaselineSec.Anchor = AnchorStyles.Left;
        lblBaselineSec.AutoSize = true;
        lblBaselineSec.Location = new Point(302, 24);
        lblBaselineSec.Name = "lblBaselineSec";
        lblBaselineSec.Size = new Size(126, 15);
        lblBaselineSec.TabIndex = 4;
        lblBaselineSec.Text = "Wait Between Steps (s)";
        // 
        // nudBaselineSec
        // 
        nudBaselineSec.DecimalPlaces = 1;
        nudBaselineSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudBaselineSec.Location = new Point(434, 3);
        nudBaselineSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudBaselineSec.Name = "nudBaselineSec";
        nudBaselineSec.Size = new Size(64, 23);
        nudBaselineSec.TabIndex = 5;
        nudBaselineSec.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblThrottleUs
        // 
        lblThrottleUs.Anchor = AnchorStyles.Left;
        lblThrottleUs.AutoSize = true;
        lblThrottleUs.Location = new Point(504, 24);
        lblThrottleUs.Name = "lblThrottleUs";
        lblThrottleUs.Size = new Size(71, 15);
        lblThrottleUs.TabIndex = 6;
        lblThrottleUs.Text = "Throttle (us)";
        // 
        // nudThrottleUs
        // 
        nudThrottleUs.Increment = new decimal(new int[] { 10, 0, 0, 0 });
        nudThrottleUs.Location = new Point(581, 3);
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
        nudTargetDeg.Location = new Point(64, 3);
        nudTargetDeg.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
        nudTargetDeg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTargetDeg.Name = "nudTargetDeg";
        nudTargetDeg.Size = new Size(64, 23);
        nudTargetDeg.TabIndex = 1;
        nudTargetDeg.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // splitterChannel
        // 
        splitterChannel.BackColor = SystemColors.ControlDark;
        splitterChannel.Dock = DockStyle.Top;
        splitterChannel.Location = new Point(10, 373);
        splitterChannel.MinExtra = 80;
        splitterChannel.MinSize = 80;
        splitterChannel.Name = "splitterChannel";
        splitterChannel.Size = new Size(1343, 6);
        splitterChannel.TabIndex = 5;
        splitterChannel.TabStop = false;
        // 
        // grpTelemetry
        // 
        grpTelemetry.Controls.Add(telemetryLayout);
        grpTelemetry.Dock = DockStyle.Top;
        grpTelemetry.Location = new Point(10, 232);
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
        telemetryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        telemetryLayout.Controls.Add(telemetryButtonLayout, 0, 0);
        telemetryLayout.Controls.Add(telemetryValueLayout, 0, 1);
        telemetryLayout.Dock = DockStyle.Fill;
        telemetryLayout.Location = new Point(10, 26);
        telemetryLayout.Name = "telemetryLayout";
        telemetryLayout.RowCount = 2;
        telemetryLayout.RowStyles.Add(new RowStyle());
        telemetryLayout.RowStyles.Add(new RowStyle());
        telemetryLayout.Size = new Size(1323, 105);
        telemetryLayout.TabIndex = 0;
        // 
        // telemetryButtonLayout
        // 
        telemetryButtonLayout.AutoSize = true;
        telemetryButtonLayout.Controls.Add(btnTelemetryStart);
        telemetryButtonLayout.Controls.Add(btnTelemetryStop);
        telemetryButtonLayout.Controls.Add(btnTelemetrySnapshot);
        telemetryButtonLayout.Dock = DockStyle.Fill;
        telemetryButtonLayout.Location = new Point(3, 3);
        telemetryButtonLayout.Name = "telemetryButtonLayout";
        telemetryButtonLayout.Size = new Size(1317, 35);
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
        telemetryValueLayout.AutoSize = true;
        telemetryValueLayout.ColumnCount = 6;
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle());
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle());
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle());
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle());
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle());
        telemetryValueLayout.ColumnStyles.Add(new ColumnStyle());
        telemetryValueLayout.Controls.Add(lblTelemetryRollTitle, 0, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryRoll, 1, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryPitchTitle, 2, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryPitch, 3, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryYawTitle, 4, 0);
        telemetryValueLayout.Controls.Add(lblTelemetryYaw, 5, 0);
        telemetryValueLayout.Dock = DockStyle.Fill;
        telemetryValueLayout.Location = new Point(3, 44);
        telemetryValueLayout.Name = "telemetryValueLayout";
        telemetryValueLayout.RowCount = 1;
        telemetryValueLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        telemetryValueLayout.Size = new Size(1317, 58);
        telemetryValueLayout.TabIndex = 1;
        // 
        // lblTelemetryRollTitle
        // 
        lblTelemetryRollTitle.Anchor = AnchorStyles.Left;
        lblTelemetryRollTitle.AutoSize = true;
        lblTelemetryRollTitle.Location = new Point(3, 21);
        lblTelemetryRollTitle.Name = "lblTelemetryRollTitle";
        lblTelemetryRollTitle.Size = new Size(30, 15);
        lblTelemetryRollTitle.TabIndex = 0;
        lblTelemetryRollTitle.Text = "Roll:";
        // 
        // lblTelemetryRoll
        // 
        lblTelemetryRoll.Anchor = AnchorStyles.Left;
        lblTelemetryRoll.AutoSize = true;
        lblTelemetryRoll.Location = new Point(39, 21);
        lblTelemetryRoll.Name = "lblTelemetryRoll";
        lblTelemetryRoll.Size = new Size(48, 15);
        lblTelemetryRoll.TabIndex = 1;
        lblTelemetryRoll.Text = "--.- deg";
        // 
        // lblTelemetryPitchTitle
        // 
        lblTelemetryPitchTitle.Anchor = AnchorStyles.Left;
        lblTelemetryPitchTitle.AutoSize = true;
        lblTelemetryPitchTitle.Location = new Point(93, 21);
        lblTelemetryPitchTitle.Name = "lblTelemetryPitchTitle";
        lblTelemetryPitchTitle.Size = new Size(37, 15);
        lblTelemetryPitchTitle.TabIndex = 2;
        lblTelemetryPitchTitle.Text = "Pitch:";
        // 
        // lblTelemetryPitch
        // 
        lblTelemetryPitch.Anchor = AnchorStyles.Left;
        lblTelemetryPitch.AutoSize = true;
        lblTelemetryPitch.Location = new Point(136, 21);
        lblTelemetryPitch.Name = "lblTelemetryPitch";
        lblTelemetryPitch.Size = new Size(48, 15);
        lblTelemetryPitch.TabIndex = 3;
        lblTelemetryPitch.Text = "--.- deg";
        // 
        // lblTelemetryYawTitle
        // 
        lblTelemetryYawTitle.Anchor = AnchorStyles.Left;
        lblTelemetryYawTitle.AutoSize = true;
        lblTelemetryYawTitle.Location = new Point(190, 21);
        lblTelemetryYawTitle.Name = "lblTelemetryYawTitle";
        lblTelemetryYawTitle.Size = new Size(31, 15);
        lblTelemetryYawTitle.TabIndex = 4;
        lblTelemetryYawTitle.Text = "Yaw:";
        // 
        // lblTelemetryYaw
        // 
        lblTelemetryYaw.Anchor = AnchorStyles.Left;
        lblTelemetryYaw.AutoSize = true;
        lblTelemetryYaw.Location = new Point(227, 21);
        lblTelemetryYaw.Name = "lblTelemetryYaw";
        lblTelemetryYaw.Size = new Size(48, 15);
        lblTelemetryYaw.TabIndex = 5;
        lblTelemetryYaw.Text = "--.- deg";
        // 
        // splitterTelemetry
        // 
        splitterTelemetry.BackColor = SystemColors.ControlDark;
        splitterTelemetry.Dock = DockStyle.Top;
        splitterTelemetry.Location = new Point(10, 226);
        splitterTelemetry.MinExtra = 80;
        splitterTelemetry.MinSize = 80;
        splitterTelemetry.Name = "splitterTelemetry";
        splitterTelemetry.Size = new Size(1343, 6);
        splitterTelemetry.TabIndex = 4;
        splitterTelemetry.TabStop = false;
        // 
        // grpPidWorkflow
        // 
        grpPidWorkflow.Controls.Add(pidWorkflowLayout);
        grpPidWorkflow.Dock = DockStyle.Top;
        grpPidWorkflow.Location = new Point(10, 36);
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
        pidWorkflowLayout.Controls.Add(lblActiveAxisTitle, 1, 0);
        pidWorkflowLayout.Controls.Add(lblActiveAxis, 1, 1);
        pidWorkflowLayout.Controls.Add(lblPidValuesTitle, 1, 2);
        pidWorkflowLayout.Controls.Add(txtPidValues, 1, 3);
        pidWorkflowLayout.Controls.Add(txtPidRecommendation, 0, 1);
        pidWorkflowLayout.Dock = DockStyle.Fill;
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
        pidButtonLayout.AutoSize = true;
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
        pidButtonLayout.Dock = DockStyle.Fill;
        pidButtonLayout.Location = new Point(3, 3);
        pidButtonLayout.Name = "pidButtonLayout";
        pidButtonLayout.Size = new Size(920, 69);
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
        btnApplyRecommendedPid.Location = new Point(387, 3);
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
        cmbManualAxis.Location = new Point(553, 3);
        cmbManualAxis.Name = "cmbManualAxis";
        cmbManualAxis.Size = new Size(84, 23);
        cmbManualAxis.TabIndex = 5;
        // 
        // cmbManualGain
        // 
        cmbManualGain.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualGain.FormattingEnabled = true;
        cmbManualGain.Location = new Point(643, 3);
        cmbManualGain.Name = "cmbManualGain";
        cmbManualGain.Size = new Size(60, 23);
        cmbManualGain.TabIndex = 6;
        // 
        // cmbManualPoints
        // 
        cmbManualPoints.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbManualPoints.FormattingEnabled = true;
        cmbManualPoints.Location = new Point(709, 3);
        cmbManualPoints.Name = "cmbManualPoints";
        cmbManualPoints.Size = new Size(60, 23);
        cmbManualPoints.TabIndex = 7;
        // 
        // btnManualPidMinus
        // 
        btnManualPidMinus.Location = new Point(775, 3);
        btnManualPidMinus.Name = "btnManualPidMinus";
        btnManualPidMinus.Size = new Size(58, 28);
        btnManualPidMinus.TabIndex = 8;
        btnManualPidMinus.Text = "PID -";
        btnManualPidMinus.UseVisualStyleBackColor = true;
        btnManualPidMinus.Click += btnManualPidMinus_Click;
        // 
        // btnManualPidPlus
        // 
        btnManualPidPlus.Location = new Point(839, 3);
        btnManualPidPlus.Name = "btnManualPidPlus";
        btnManualPidPlus.Size = new Size(58, 28);
        btnManualPidPlus.TabIndex = 9;
        btnManualPidPlus.Text = "PID +";
        btnManualPidPlus.UseVisualStyleBackColor = true;
        btnManualPidPlus.Click += btnManualPidPlus_Click;
        // 
        // btnReadFcPid
        // 
        btnReadFcPid.Location = new Point(3, 38);
        btnReadFcPid.Name = "btnReadFcPid";
        btnReadFcPid.Size = new Size(75, 28);
        btnReadFcPid.TabIndex = 10;
        btnReadFcPid.Text = "Read FC";
        btnReadFcPid.UseVisualStyleBackColor = true;
        btnReadFcPid.Click += btnReadFcPid_Click;
        // 
        // btnSaveFcPid
        // 
        btnSaveFcPid.Location = new Point(84, 38);
        btnSaveFcPid.Name = "btnSaveFcPid";
        btnSaveFcPid.Size = new Size(75, 28);
        btnSaveFcPid.TabIndex = 11;
        btnSaveFcPid.Text = "Save FC";
        btnSaveFcPid.UseVisualStyleBackColor = true;
        btnSaveFcPid.Click += btnSaveFcPid_Click;
        // 
        // lblActiveAxisTitle
        // 
        lblActiveAxisTitle.Anchor = AnchorStyles.Left;
        lblActiveAxisTitle.AutoSize = true;
        lblActiveAxisTitle.Location = new Point(929, 30);
        lblActiveAxisTitle.Name = "lblActiveAxisTitle";
        lblActiveAxisTitle.Size = new Size(65, 15);
        lblActiveAxisTitle.TabIndex = 1;
        lblActiveAxisTitle.Text = "Active Axis";
        // 
        // lblActiveAxis
        // 
        lblActiveAxis.Anchor = AnchorStyles.Left;
        lblActiveAxis.AutoSize = true;
        lblActiveAxis.Location = new Point(929, 75);
        lblActiveAxis.Name = "lblActiveAxis";
        lblActiveAxis.Size = new Size(29, 15);
        lblActiveAxis.TabIndex = 2;
        lblActiveAxis.Text = "N/A";
        // 
        // lblPidValuesTitle
        // 
        lblPidValuesTitle.Anchor = AnchorStyles.Left;
        lblPidValuesTitle.AutoSize = true;
        lblPidValuesTitle.Location = new Point(929, 90);
        lblPidValuesTitle.Name = "lblPidValuesTitle";
        lblPidValuesTitle.Size = new Size(94, 15);
        lblPidValuesTitle.TabIndex = 4;
        lblPidValuesTitle.Text = "FC PID Snapshot";
        // 
        // txtPidValues
        // 
        txtPidValues.Dock = DockStyle.Fill;
        txtPidValues.Location = new Point(929, 108);
        txtPidValues.Multiline = true;
        txtPidValues.Name = "txtPidValues";
        txtPidValues.ReadOnly = true;
        txtPidValues.Size = new Size(391, 43);
        txtPidValues.TabIndex = 5;
        txtPidValues.Text = "Roll P/I/D: --/--/--\r\nPitch P/I/D: --/--/--";
        // 
        // txtPidRecommendation
        // 
        txtPidRecommendation.Dock = DockStyle.Fill;
        txtPidRecommendation.Location = new Point(3, 78);
        txtPidRecommendation.Multiline = true;
        txtPidRecommendation.Name = "txtPidRecommendation";
        txtPidRecommendation.ReadOnly = true;
        pidWorkflowLayout.SetRowSpan(txtPidRecommendation, 3);
        txtPidRecommendation.Size = new Size(920, 73);
        txtPidRecommendation.TabIndex = 3;
        txtPidRecommendation.Text = "Run Roll or Pitch to generate a recommendation.";
        // 
        // splitterPid
        // 
        splitterPid.BackColor = SystemColors.ControlDark;
        splitterPid.Dock = DockStyle.Top;
        splitterPid.Location = new Point(10, 26);
        splitterPid.MinExtra = 80;
        splitterPid.MinSize = 80;
        splitterPid.Name = "splitterPid";
        splitterPid.Size = new Size(1343, 10);
        splitterPid.TabIndex = 6;
        splitterPid.TabStop = false;
        // 
        // grpTuningProgress
        // 
        grpTuningProgress.Controls.Add(tuningProgressLayout);
        grpTuningProgress.Dock = DockStyle.Fill;
        grpTuningProgress.Location = new Point(10, 26);
        grpTuningProgress.Name = "grpTuningProgress";
        grpTuningProgress.Padding = new Padding(10);
        grpTuningProgress.Size = new Size(1343, 783);
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
        tuningProgressLayout.Size = new Size(1323, 747);
        tuningProgressLayout.TabIndex = 0;
        // 
        // pnlScoreChart
        // 
        pnlScoreChart.BackColor = Color.White;
        pnlScoreChart.BorderStyle = BorderStyle.FixedSingle;
        pnlScoreChart.Dock = DockStyle.Fill;
        pnlScoreChart.Location = new Point(3, 3);
        pnlScoreChart.Name = "pnlScoreChart";
        pnlScoreChart.Size = new Size(655, 741);
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
        lvTuningRuns.Size = new Size(656, 741);
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
        grpUsb.PerformLayout();
        usbLayout.ResumeLayout(false);
        usbLayout.PerformLayout();
        grpMapping.ResumeLayout(false);
        grpMapping.PerformLayout();
        mappingLayout.ResumeLayout(false);
        mappingLayout.PerformLayout();
        grpPortingArea.ResumeLayout(false);
        grpChannelTest.ResumeLayout(false);
        channelTestLayout.ResumeLayout(false);
        channelTestLayout.PerformLayout();
        channelActionLayout.ResumeLayout(false);
        channelVisualLayout.ResumeLayout(false);
        channelVisualLayout.PerformLayout();
        channelInputsLayout.ResumeLayout(false);
        channelInputsLayout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).EndInit();
        grpTelemetry.ResumeLayout(false);
        telemetryLayout.ResumeLayout(false);
        telemetryLayout.PerformLayout();
        telemetryButtonLayout.ResumeLayout(false);
        telemetryValueLayout.ResumeLayout(false);
        telemetryValueLayout.PerformLayout();
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
    private Label lblBaud;
    private Label lblBaudValue;
    private Label lblArduinoPort;
    private ComboBox cboArduinoPort;
    private Label lblArduinoBaud;
    private Label lblArduinoBaudValue;
    private Button btnRefreshPorts;
    private Button btnConnect;
    private Button btnDisconnect;
    private Button btnArduinoConnect;
    private Button btnArduinoDisconnect;
    private GroupBox grpMapping;
    private TableLayoutPanel mappingLayout;
    private Label lblRoll;
    private ComboBox cboRoll;
    private Label lblPitch;
    private ComboBox cboPitch;
    private Label lblThrottle;
    private ComboBox cboThrottle;
    private Button btnApplyMapping;
    private GroupBox grpPortingArea;
    private GroupBox grpChannelTest;
    private Splitter splitterTelemetry;
    private Splitter splitterChannel;
    private Splitter splitterPid;
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
}
