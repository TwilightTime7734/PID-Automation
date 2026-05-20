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
        tblUsb = new TableLayoutPanel();
        lblPort = new Label();
        lblArduinoPort = new Label();
        lblTrainerPin = new Label();
        cboPort = new ComboBox();
        cboBaud = new ComboBox();
        cboArduinoPort = new ComboBox();
        cboArduinoBaud = new ComboBox();
        cboTrainerPin = new ComboBox();
        btnFcDisconnect = new Button();
        btnArduinoDisconnect = new Button();
        btnFcConnect = new Button();
        btnArduinoConnect = new Button();
        btnSimulationToggle = new Button();
        btnRefreshPorts = new Button();
        lblArduinoStatus = new Label();
        lblFCStatus = new Label();
        grpMapping = new GroupBox();
        mappingTable = new TableLayoutPanel();
        lblRoll = new Label();
        lblPitch = new Label();
        lblThrottle = new Label();
        lblYaw = new Label();
        btnPresetReat = new Button();
        btnPresetRtae = new Button();
        btnPresetAetr = new Button();
        btnApplyMapping = new Button();
        cboCH1 = new ComboBox();
        cboCH2 = new ComboBox();
        cboCH3 = new ComboBox();
        cboCH4 = new ComboBox();
        grpChannelTest = new GroupBox();
        tableLayoutPanel6 = new TableLayoutPanel();
        tableLayoutPanel2 = new TableLayoutPanel();
        nudBaselineSec = new NumericUpDown();
        lblTargetDeg = new Label();
        lblBaselineSec = new Label();
        nudTargetDeg = new NumericUpDown();
        lblSettleSec = new Label();
        nudSettleSec = new NumericUpDown();
        lblThrottleUs = new Label();
        nudThrottleUs = new NumericUpDown();
        tableLayoutPanel1 = new TableLayoutPanel();
        btnTestRoll = new Button();
        btnTestPitch = new Button();
        btnTestThrottle = new Button();
        btnTestYaw = new Button();
        tableLayoutPanel5 = new TableLayoutPanel();
        pnlRightStick = new Panel();
        pnlRightStickIndicator = new Panel();
        pnlLeftStick = new Panel();
        pnlLeftStickIndicator = new Panel();
        grpPidWorkflow = new GroupBox();
        tblPidModeInfo = new TableLayoutPanel();
        lblFlightMode = new Label();
        txtFlightMode = new TextBox();
        lblAirMode = new Label();
        txtAirMode = new TextBox();
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
        btnReadFcPid = new Button();
        btnPidEditable = new Button();
        btnSaveFcPid = new Button();
        pnlScoreChart = new Panel();
        grpLiveData = new GroupBox();
        attitudeIndicator = new DronePidTuningAssistant.WinForms.Controls.AttitudeIndicatorControl();
        tableLayoutPanel3 = new TableLayoutPanel();
        lblPitchAngle = new Label();
        lblRollAngle = new Label();
        lblChannelValue = new Label();
        lblChannelVisual = new Label();
        lblChannelVisualTitle = new Label();
        lblChannelValueTitle = new Label();
        lblRollAngleTitle = new Label();
        lblPitchAngleTitle = new Label();
        groupBox1 = new GroupBox();
        tableLayoutPanel7 = new TableLayoutPanel();
        tableLayoutPanel4 = new TableLayoutPanel();
        btnTuneRoll = new Button();
        btnTunePitch = new Button();
        btnTuneYaw = new Button();
        btnThrottlePos = new Button();
        btnThrottleNeg = new Button();
        textBox1 = new TextBox();
        splitContainer1 = new SplitContainer();
        tableLayoutPanel8 = new TableLayoutPanel();
        lblPitchKp = new Label();
        nudPitchKd = new NumericUpDown();
        lblRollKp = new Label();
        nudPitchKi = new NumericUpDown();
        nudRollKp = new NumericUpDown();
        nudPitchKp = new NumericUpDown();
        nudRollKi = new NumericUpDown();
        nudRollKd = new NumericUpDown();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        pidCompassPanel = new TableLayoutPanel();
        btnPitchDn = new Button();
        btnRollRight = new Button();
        btnRollLeft = new Button();
        btnPitchUp = new Button();
        btnLevelOut = new Button();
        btnFinishAxis = new Button();
        lblActiveAxis = new Label();
        lblActiveAxisTitle = new Label();
        btnRetestAxis = new Button();
        lblPidValuesTitle = new Label();
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
        rootLayout.SuspendLayout();
        grpUsb.SuspendLayout();
        tblUsb.SuspendLayout();
        grpMapping.SuspendLayout();
        mappingTable.SuspendLayout();
        grpChannelTest.SuspendLayout();
        tableLayoutPanel6.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).BeginInit();
        tableLayoutPanel1.SuspendLayout();
        tableLayoutPanel5.SuspendLayout();
        pnlRightStick.SuspendLayout();
        pnlLeftStick.SuspendLayout();
        grpPidWorkflow.SuspendLayout();
        tblPidModeInfo.SuspendLayout();
        tblPidMatrix.SuspendLayout();
        grpLiveData.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        groupBox1.SuspendLayout();
        tableLayoutPanel7.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        tableLayoutPanel8.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudPitchKd).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPitchKi).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudRollKp).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPitchKp).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudRollKi).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudRollKd).BeginInit();
        pidCompassPanel.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.AutoSize = true;
        rootLayout.ColumnCount = 3;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.9629631F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.397727F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.68182F));
        rootLayout.Controls.Add(grpUsb, 0, 0);
        rootLayout.Controls.Add(grpMapping, 1, 0);
        rootLayout.Controls.Add(grpChannelTest, 2, 0);
        rootLayout.Controls.Add(grpPidWorkflow, 0, 1);
        rootLayout.Controls.Add(pnlScoreChart, 0, 2);
        rootLayout.Controls.Add(grpLiveData, 1, 1);
        rootLayout.Controls.Add(groupBox1, 2, 1);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(10);
        rootLayout.RowCount = 3;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 31.97531F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 43.209877F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 24.8148155F));
        rootLayout.Size = new Size(1780, 847);
        rootLayout.TabIndex = 0;
        // 
        // grpUsb
        // 
        grpUsb.Controls.Add(tblUsb);
        grpUsb.Dock = DockStyle.Top;
        grpUsb.Location = new Point(13, 13);
        grpUsb.Name = "grpUsb";
        grpUsb.Padding = new Padding(10);
        grpUsb.Size = new Size(679, 203);
        grpUsb.TabIndex = 0;
        grpUsb.TabStop = false;
        grpUsb.Text = "Serial Ports";
        // 
        // tblUsb
        // 
        tblUsb.ColumnCount = 5;
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.008316F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1791048F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.2313442F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.6716413F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.6865654F));
        tblUsb.Controls.Add(lblPort, 0, 0);
        tblUsb.Controls.Add(lblArduinoPort, 0, 1);
        tblUsb.Controls.Add(lblTrainerPin, 0, 2);
        tblUsb.Controls.Add(cboPort, 1, 0);
        tblUsb.Controls.Add(cboBaud, 2, 0);
        tblUsb.Controls.Add(cboArduinoPort, 1, 1);
        tblUsb.Controls.Add(cboArduinoBaud, 2, 1);
        tblUsb.Controls.Add(cboTrainerPin, 1, 2);
        tblUsb.Controls.Add(btnFcDisconnect, 4, 0);
        tblUsb.Controls.Add(btnArduinoDisconnect, 4, 1);
        tblUsb.Controls.Add(btnFcConnect, 3, 0);
        tblUsb.Controls.Add(btnArduinoConnect, 3, 1);
        tblUsb.Controls.Add(btnSimulationToggle, 4, 2);
        tblUsb.Controls.Add(btnRefreshPorts, 3, 2);
        tblUsb.Controls.Add(lblArduinoStatus, 3, 4);
        tblUsb.Controls.Add(lblFCStatus, 0, 4);
        tblUsb.Dock = DockStyle.Top;
        tblUsb.Location = new Point(10, 26);
        tblUsb.Name = "tblUsb";
        tblUsb.RowCount = 5;
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tblUsb.Size = new Size(659, 159);
        tblUsb.TabIndex = 0;
        tblUsb.Paint += TblUsb_Paint;
        // 
        // lblPort
        // 
        lblPort.Dock = DockStyle.Top;
        lblPort.Location = new Point(3, 0);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(99, 23);
        lblPort.TabIndex = 0;
        lblPort.Text = "FC USB";
        lblPort.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblArduinoPort
        // 
        lblArduinoPort.Dock = DockStyle.Top;
        lblArduinoPort.Location = new Point(3, 34);
        lblArduinoPort.Name = "lblArduinoPort";
        lblArduinoPort.Size = new Size(99, 23);
        lblArduinoPort.TabIndex = 7;
        lblArduinoPort.Text = "Arduino";
        lblArduinoPort.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTrainerPin
        // 
        lblTrainerPin.Dock = DockStyle.Top;
        lblTrainerPin.Location = new Point(3, 68);
        lblTrainerPin.Name = "lblTrainerPin";
        lblTrainerPin.Size = new Size(99, 23);
        lblTrainerPin.TabIndex = 15;
        lblTrainerPin.Text = "Trainer Pin";
        lblTrainerPin.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // cboPort
        // 
        cboPort.Dock = DockStyle.Fill;
        cboPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPort.FormattingEnabled = true;
        cboPort.Location = new Point(108, 3);
        cboPort.Name = "cboPort";
        cboPort.Size = new Size(87, 23);
        cboPort.TabIndex = 1;
        // 
        // cboBaud
        // 
        cboBaud.Dock = DockStyle.Fill;
        cboBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBaud.FormattingEnabled = true;
        cboBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboBaud.Location = new Point(201, 3);
        cboBaud.Name = "cboBaud";
        cboBaud.Size = new Size(101, 23);
        cboBaud.TabIndex = 2;
        // 
        // cboArduinoPort
        // 
        cboArduinoPort.Dock = DockStyle.Fill;
        cboArduinoPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoPort.FormattingEnabled = true;
        cboArduinoPort.Location = new Point(108, 37);
        cboArduinoPort.Name = "cboArduinoPort";
        cboArduinoPort.Size = new Size(87, 23);
        cboArduinoPort.TabIndex = 8;
        // 
        // cboArduinoBaud
        // 
        cboArduinoBaud.Dock = DockStyle.Fill;
        cboArduinoBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoBaud.FormattingEnabled = true;
        cboArduinoBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboArduinoBaud.Location = new Point(201, 37);
        cboArduinoBaud.Name = "cboArduinoBaud";
        cboArduinoBaud.Size = new Size(101, 23);
        cboArduinoBaud.TabIndex = 9;
        // 
        // cboTrainerPin
        // 
        cboTrainerPin.Dock = DockStyle.Fill;
        cboTrainerPin.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrainerPin.FormattingEnabled = true;
        cboTrainerPin.Items.AddRange(new object[] { "3", "5", "6", "9", "10", "11" });
        cboTrainerPin.Location = new Point(108, 71);
        cboTrainerPin.Name = "cboTrainerPin";
        cboTrainerPin.Size = new Size(87, 23);
        cboTrainerPin.TabIndex = 16;
        // 
        // btnFcDisconnect
        // 
        btnFcDisconnect.Location = new Point(411, 3);
        btnFcDisconnect.Name = "btnFcDisconnect";
        btnFcDisconnect.Size = new Size(206, 25);
        btnFcDisconnect.TabIndex = 4;
        btnFcDisconnect.Text = "Disconnect";
        btnFcDisconnect.UseVisualStyleBackColor = true;
        btnFcDisconnect.Click += btnDisconnect_Click;
        // 
        // btnArduinoDisconnect
        // 
        btnArduinoDisconnect.Location = new Point(411, 37);
        btnArduinoDisconnect.Name = "btnArduinoDisconnect";
        btnArduinoDisconnect.Size = new Size(206, 25);
        btnArduinoDisconnect.TabIndex = 11;
        btnArduinoDisconnect.Text = "Disconnect";
        btnArduinoDisconnect.UseVisualStyleBackColor = true;
        btnArduinoDisconnect.Click += btnArduinoDisconnect_Click;
        // 
        // btnFcConnect
        // 
        btnFcConnect.Dock = DockStyle.Top;
        btnFcConnect.Location = new Point(308, 3);
        btnFcConnect.Name = "btnFcConnect";
        btnFcConnect.Size = new Size(97, 25);
        btnFcConnect.TabIndex = 3;
        btnFcConnect.Text = "Connect";
        btnFcConnect.UseVisualStyleBackColor = true;
        btnFcConnect.Click += btnConnect_Click;
        // 
        // btnArduinoConnect
        // 
        btnArduinoConnect.Dock = DockStyle.Top;
        btnArduinoConnect.Location = new Point(308, 37);
        btnArduinoConnect.Name = "btnArduinoConnect";
        btnArduinoConnect.Size = new Size(97, 25);
        btnArduinoConnect.TabIndex = 10;
        btnArduinoConnect.Text = "Connect";
        btnArduinoConnect.UseVisualStyleBackColor = true;
        btnArduinoConnect.Click += btnArduinoConnect_Click;
        // 
        // btnSimulationToggle
        // 
        btnSimulationToggle.Location = new Point(411, 71);
        btnSimulationToggle.Name = "btnSimulationToggle";
        btnSimulationToggle.Size = new Size(206, 25);
        btnSimulationToggle.TabIndex = 17;
        btnSimulationToggle.Text = "Simulation: Off";
        btnSimulationToggle.UseVisualStyleBackColor = true;
        // 
        // btnRefreshPorts
        // 
        btnRefreshPorts.Dock = DockStyle.Top;
        btnRefreshPorts.ImageAlign = ContentAlignment.MiddleLeft;
        btnRefreshPorts.Location = new Point(308, 71);
        btnRefreshPorts.Name = "btnRefreshPorts";
        btnRefreshPorts.Size = new Size(97, 25);
        btnRefreshPorts.TabIndex = 5;
        btnRefreshPorts.Text = "Refresh";
        btnRefreshPorts.UseVisualStyleBackColor = true;
        btnRefreshPorts.Click += btnRefreshPorts_Click;
        // 
        // lblArduinoStatus
        // 
        tblUsb.SetColumnSpan(lblArduinoStatus, 2);
        lblArduinoStatus.Dock = DockStyle.Top;
        lblArduinoStatus.Location = new Point(308, 139);
        lblArduinoStatus.Margin = new Padding(3, 3, 3, 0);
        lblArduinoStatus.Name = "lblArduinoStatus";
        lblArduinoStatus.Size = new Size(348, 20);
        lblArduinoStatus.TabIndex = 14;
        lblArduinoStatus.Text = "Waiting...";
        lblArduinoStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblFCStatus
        // 
        tblUsb.SetColumnSpan(lblFCStatus, 3);
        lblFCStatus.Dock = DockStyle.Top;
        lblFCStatus.Location = new Point(3, 139);
        lblFCStatus.Margin = new Padding(3, 3, 3, 0);
        lblFCStatus.Name = "lblFCStatus";
        lblFCStatus.Size = new Size(299, 20);
        lblFCStatus.TabIndex = 13;
        lblFCStatus.Text = "Waiting...";
        lblFCStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grpMapping
        // 
        grpMapping.Controls.Add(mappingTable);
        grpMapping.Dock = DockStyle.Top;
        grpMapping.Location = new Point(698, 13);
        grpMapping.Name = "grpMapping";
        grpMapping.Padding = new Padding(10);
        grpMapping.Size = new Size(264, 203);
        grpMapping.TabIndex = 1;
        grpMapping.TabStop = false;
        grpMapping.Text = "Transmitter Channel Mapping";
        // 
        // mappingTable
        // 
        mappingTable.ColumnCount = 3;
        mappingTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.562418F));
        mappingTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5375366F));
        mappingTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.90004F));
        mappingTable.Controls.Add(lblRoll, 0, 0);
        mappingTable.Controls.Add(lblPitch, 0, 1);
        mappingTable.Controls.Add(lblThrottle, 0, 2);
        mappingTable.Controls.Add(lblYaw, 0, 3);
        mappingTable.Controls.Add(btnPresetReat, 2, 3);
        mappingTable.Controls.Add(btnPresetRtae, 2, 2);
        mappingTable.Controls.Add(btnPresetAetr, 2, 1);
        mappingTable.Controls.Add(btnApplyMapping, 2, 0);
        mappingTable.Controls.Add(cboCH1, 1, 0);
        mappingTable.Controls.Add(cboCH2, 1, 1);
        mappingTable.Controls.Add(cboCH3, 1, 2);
        mappingTable.Controls.Add(cboCH4, 1, 3);
        mappingTable.Dock = DockStyle.Top;
        mappingTable.Location = new Point(10, 26);
        mappingTable.MinimumSize = new Size(180, 70);
        mappingTable.Name = "mappingTable";
        mappingTable.RowCount = 4;
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.Size = new Size(244, 166);
        mappingTable.TabIndex = 0;
        // 
        // lblRoll
        // 
        lblRoll.AutoSize = true;
        lblRoll.Dock = DockStyle.Top;
        lblRoll.Location = new Point(3, 7);
        lblRoll.Margin = new Padding(3, 7, 3, 0);
        lblRoll.Name = "lblRoll";
        lblRoll.Size = new Size(41, 15);
        lblRoll.TabIndex = 0;
        lblRoll.Text = "Ch 1";
        lblRoll.TextAlign = ContentAlignment.MiddleRight;
        lblRoll.Click += lblRoll_Click;
        // 
        // lblPitch
        // 
        lblPitch.AutoSize = true;
        lblPitch.Dock = DockStyle.Top;
        lblPitch.Location = new Point(3, 48);
        lblPitch.Margin = new Padding(3, 7, 3, 0);
        lblPitch.Name = "lblPitch";
        lblPitch.Size = new Size(41, 15);
        lblPitch.TabIndex = 2;
        lblPitch.Text = "Ch 2";
        lblPitch.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblThrottle
        // 
        lblThrottle.AutoSize = true;
        lblThrottle.Dock = DockStyle.Top;
        lblThrottle.Location = new Point(3, 89);
        lblThrottle.Margin = new Padding(3, 7, 3, 0);
        lblThrottle.Name = "lblThrottle";
        lblThrottle.Size = new Size(41, 15);
        lblThrottle.TabIndex = 4;
        lblThrottle.Text = "Ch 3";
        lblThrottle.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblYaw
        // 
        lblYaw.AutoSize = true;
        lblYaw.Dock = DockStyle.Top;
        lblYaw.Location = new Point(3, 130);
        lblYaw.Margin = new Padding(3, 7, 3, 0);
        lblYaw.Name = "lblYaw";
        lblYaw.Size = new Size(41, 15);
        lblYaw.TabIndex = 7;
        lblYaw.Text = "Ch 4";
        lblYaw.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnPresetReat
        // 
        btnPresetReat.AutoSize = true;
        btnPresetReat.Dock = DockStyle.Top;
        btnPresetReat.Location = new Point(141, 126);
        btnPresetReat.Name = "btnPresetReat";
        btnPresetReat.Size = new Size(100, 25);
        btnPresetReat.TabIndex = 11;
        btnPresetReat.Text = "REAT";
        btnPresetReat.UseVisualStyleBackColor = true;
        btnPresetReat.Click += btnPresetReat_Click;
        // 
        // btnPresetRtae
        // 
        btnPresetRtae.AutoSize = true;
        btnPresetRtae.Dock = DockStyle.Top;
        btnPresetRtae.Location = new Point(141, 85);
        btnPresetRtae.Name = "btnPresetRtae";
        btnPresetRtae.Size = new Size(100, 25);
        btnPresetRtae.TabIndex = 10;
        btnPresetRtae.Text = "RTAE";
        btnPresetRtae.UseVisualStyleBackColor = true;
        btnPresetRtae.Click += btnPresetRtae_Click;
        // 
        // btnPresetAetr
        // 
        btnPresetAetr.AutoSize = true;
        btnPresetAetr.Dock = DockStyle.Top;
        btnPresetAetr.Location = new Point(141, 44);
        btnPresetAetr.Name = "btnPresetAetr";
        btnPresetAetr.Size = new Size(100, 25);
        btnPresetAetr.TabIndex = 9;
        btnPresetAetr.Text = "AETR";
        btnPresetAetr.UseVisualStyleBackColor = true;
        btnPresetAetr.Click += btnPresetAetr_Click;
        // 
        // btnApplyMapping
        // 
        btnApplyMapping.Dock = DockStyle.Top;
        btnApplyMapping.Location = new Point(141, 3);
        btnApplyMapping.Margin = new Padding(3, 3, 3, 6);
        btnApplyMapping.Name = "btnApplyMapping";
        btnApplyMapping.Size = new Size(100, 25);
        btnApplyMapping.TabIndex = 6;
        btnApplyMapping.Text = "Apply";
        btnApplyMapping.UseVisualStyleBackColor = true;
        btnApplyMapping.Click += btnApplyMapping_Click;
        // 
        // cboCH1
        // 
        cboCH1.Dock = DockStyle.Top;
        cboCH1.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH1.FormattingEnabled = true;
        cboCH1.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH1.Location = new Point(50, 3);
        cboCH1.Margin = new Padding(3, 3, 6, 3);
        cboCH1.Name = "cboCH1";
        cboCH1.Size = new Size(82, 23);
        cboCH1.TabIndex = 1;
        // 
        // cboCH2
        // 
        cboCH2.Dock = DockStyle.Fill;
        cboCH2.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH2.FormattingEnabled = true;
        cboCH2.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH2.Location = new Point(50, 44);
        cboCH2.Margin = new Padding(3, 3, 6, 3);
        cboCH2.Name = "cboCH2";
        cboCH2.Size = new Size(82, 23);
        cboCH2.TabIndex = 3;
        // 
        // cboCH3
        // 
        cboCH3.Dock = DockStyle.Fill;
        cboCH3.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH3.FormattingEnabled = true;
        cboCH3.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH3.Location = new Point(50, 85);
        cboCH3.Margin = new Padding(3, 3, 6, 3);
        cboCH3.Name = "cboCH3";
        cboCH3.Size = new Size(82, 23);
        cboCH3.TabIndex = 5;
        // 
        // cboCH4
        // 
        cboCH4.Dock = DockStyle.Top;
        cboCH4.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH4.FormattingEnabled = true;
        cboCH4.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH4.Location = new Point(50, 126);
        cboCH4.Margin = new Padding(3, 3, 6, 3);
        cboCH4.Name = "cboCH4";
        cboCH4.Size = new Size(82, 23);
        cboCH4.TabIndex = 8;
        // 
        // grpChannelTest
        // 
        grpChannelTest.Controls.Add(tableLayoutPanel6);
        grpChannelTest.Dock = DockStyle.Top;
        grpChannelTest.Location = new Point(968, 13);
        grpChannelTest.Name = "grpChannelTest";
        grpChannelTest.Padding = new Padding(10);
        grpChannelTest.Size = new Size(799, 219);
        grpChannelTest.TabIndex = 0;
        grpChannelTest.TabStop = false;
        grpChannelTest.Text = "Channel Test";
        // 
        // tableLayoutPanel6
        // 
        tableLayoutPanel6.ColumnCount = 3;
        tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.8421059F));
        tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.1579F));
        tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 213F));
        tableLayoutPanel6.Controls.Add(tableLayoutPanel2, 2, 0);
        tableLayoutPanel6.Controls.Add(tableLayoutPanel1, 0, 0);
        tableLayoutPanel6.Controls.Add(tableLayoutPanel5, 1, 0);
        tableLayoutPanel6.Dock = DockStyle.Fill;
        tableLayoutPanel6.Location = new Point(10, 26);
        tableLayoutPanel6.Name = "tableLayoutPanel6";
        tableLayoutPanel6.RowCount = 1;
        tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel6.Size = new Size(779, 183);
        tableLayoutPanel6.TabIndex = 0;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.52381F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.47619F));
        tableLayoutPanel2.Controls.Add(nudBaselineSec, 1, 1);
        tableLayoutPanel2.Controls.Add(lblTargetDeg, 0, 0);
        tableLayoutPanel2.Controls.Add(lblBaselineSec, 0, 1);
        tableLayoutPanel2.Controls.Add(nudTargetDeg, 1, 0);
        tableLayoutPanel2.Controls.Add(lblSettleSec, 0, 2);
        tableLayoutPanel2.Controls.Add(nudSettleSec, 1, 2);
        tableLayoutPanel2.Controls.Add(lblThrottleUs, 0, 3);
        tableLayoutPanel2.Controls.Add(nudThrottleUs, 1, 3);
        tableLayoutPanel2.Dock = DockStyle.Top;
        tableLayoutPanel2.Location = new Point(568, 3);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 4;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.Size = new Size(208, 127);
        tableLayoutPanel2.TabIndex = 7;
        // 
        // nudBaselineSec
        // 
        nudBaselineSec.DecimalPlaces = 1;
        nudBaselineSec.Dock = DockStyle.Fill;
        nudBaselineSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudBaselineSec.Location = new Point(123, 35);
        nudBaselineSec.Margin = new Padding(0, 4, 0, 0);
        nudBaselineSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudBaselineSec.Name = "nudBaselineSec";
        nudBaselineSec.Size = new Size(85, 23);
        nudBaselineSec.TabIndex = 5;
        nudBaselineSec.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblTargetDeg
        // 
        lblTargetDeg.Dock = DockStyle.Fill;
        lblTargetDeg.Location = new Point(0, 0);
        lblTargetDeg.Margin = new Padding(0);
        lblTargetDeg.Name = "lblTargetDeg";
        lblTargetDeg.Size = new Size(123, 31);
        lblTargetDeg.TabIndex = 0;
        lblTargetDeg.Text = "Target Δ°";
        lblTargetDeg.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblBaselineSec
        // 
        lblBaselineSec.Dock = DockStyle.Fill;
        lblBaselineSec.Location = new Point(0, 31);
        lblBaselineSec.Margin = new Padding(0);
        lblBaselineSec.Name = "lblBaselineSec";
        lblBaselineSec.Size = new Size(123, 31);
        lblBaselineSec.TabIndex = 4;
        lblBaselineSec.Text = "Sec on Target Δ°";
        lblBaselineSec.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudTargetDeg
        // 
        nudTargetDeg.DecimalPlaces = 1;
        nudTargetDeg.Dock = DockStyle.Fill;
        nudTargetDeg.Location = new Point(123, 4);
        nudTargetDeg.Margin = new Padding(0, 4, 0, 0);
        nudTargetDeg.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
        nudTargetDeg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTargetDeg.Name = "nudTargetDeg";
        nudTargetDeg.Size = new Size(85, 23);
        nudTargetDeg.TabIndex = 1;
        nudTargetDeg.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // lblSettleSec
        // 
        lblSettleSec.Dock = DockStyle.Fill;
        lblSettleSec.Location = new Point(0, 62);
        lblSettleSec.Margin = new Padding(0);
        lblSettleSec.Name = "lblSettleSec";
        lblSettleSec.Size = new Size(123, 31);
        lblSettleSec.TabIndex = 2;
        lblSettleSec.Text = "Pre-wait (sec)";
        lblSettleSec.TextAlign = ContentAlignment.MiddleRight;
        lblSettleSec.Click += LblSettleSec_Click;
        // 
        // nudSettleSec
        // 
        nudSettleSec.DecimalPlaces = 1;
        nudSettleSec.Dock = DockStyle.Fill;
        nudSettleSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudSettleSec.Location = new Point(123, 66);
        nudSettleSec.Margin = new Padding(0, 4, 0, 0);
        nudSettleSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudSettleSec.Name = "nudSettleSec";
        nudSettleSec.Size = new Size(85, 23);
        nudSettleSec.TabIndex = 3;
        nudSettleSec.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblThrottleUs
        // 
        lblThrottleUs.Dock = DockStyle.Fill;
        lblThrottleUs.Location = new Point(0, 93);
        lblThrottleUs.Margin = new Padding(0);
        lblThrottleUs.Name = "lblThrottleUs";
        lblThrottleUs.Size = new Size(123, 34);
        lblThrottleUs.TabIndex = 6;
        lblThrottleUs.Text = "Throttle";
        lblThrottleUs.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudThrottleUs
        // 
        nudThrottleUs.Dock = DockStyle.Fill;
        nudThrottleUs.Increment = new decimal(new int[] { 10, 0, 0, 0 });
        nudThrottleUs.Location = new Point(123, 97);
        nudThrottleUs.Margin = new Padding(0, 4, 0, 0);
        nudThrottleUs.Maximum = new decimal(new int[] { 1300, 0, 0, 0 });
        nudThrottleUs.Minimum = new decimal(new int[] { 1100, 0, 0, 0 });
        nudThrottleUs.Name = "nudThrottleUs";
        nudThrottleUs.Size = new Size(85, 23);
        nudThrottleUs.TabIndex = 7;
        nudThrottleUs.Value = new decimal(new int[] { 1150, 0, 0, 0 });
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(btnTestRoll, 0, 0);
        tableLayoutPanel1.Controls.Add(btnTestPitch, 0, 1);
        tableLayoutPanel1.Controls.Add(btnTestThrottle, 0, 2);
        tableLayoutPanel1.Controls.Add(btnTestYaw, 0, 3);
        tableLayoutPanel1.Dock = DockStyle.Top;
        tableLayoutPanel1.Location = new Point(3, 3);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tableLayoutPanel1.Size = new Size(134, 126);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // btnTestRoll
        // 
        btnTestRoll.AutoSize = true;
        btnTestRoll.Dock = DockStyle.Top;
        btnTestRoll.Location = new Point(3, 3);
        btnTestRoll.Name = "btnTestRoll";
        btnTestRoll.Size = new Size(128, 25);
        btnTestRoll.TabIndex = 0;
        btnTestRoll.Text = "Test Roll";
        btnTestRoll.UseVisualStyleBackColor = true;
        btnTestRoll.Click += btnTestRoll_Click;
        // 
        // btnTestPitch
        // 
        btnTestPitch.AutoSize = true;
        btnTestPitch.Dock = DockStyle.Top;
        btnTestPitch.Location = new Point(3, 35);
        btnTestPitch.Name = "btnTestPitch";
        btnTestPitch.Size = new Size(128, 25);
        btnTestPitch.TabIndex = 1;
        btnTestPitch.Text = "Test Pitch";
        btnTestPitch.UseVisualStyleBackColor = true;
        btnTestPitch.Click += btnTestPitch_Click;
        // 
        // btnTestThrottle
        // 
        btnTestThrottle.AutoSize = true;
        btnTestThrottle.Dock = DockStyle.Top;
        btnTestThrottle.Location = new Point(3, 67);
        btnTestThrottle.Name = "btnTestThrottle";
        btnTestThrottle.Size = new Size(128, 25);
        btnTestThrottle.TabIndex = 2;
        btnTestThrottle.Text = "Test Throttle";
        btnTestThrottle.UseVisualStyleBackColor = true;
        btnTestThrottle.Click += btnTestThrottle_Click;
        // 
        // btnTestYaw
        // 
        btnTestYaw.AutoSize = true;
        btnTestYaw.Dock = DockStyle.Top;
        btnTestYaw.Location = new Point(3, 99);
        btnTestYaw.Name = "btnTestYaw";
        btnTestYaw.Size = new Size(128, 24);
        btnTestYaw.TabIndex = 3;
        btnTestYaw.Text = "Test Yaw";
        btnTestYaw.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel5
        // 
        tableLayoutPanel5.ColumnCount = 2;
        tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel5.Controls.Add(pnlRightStick, 1, 0);
        tableLayoutPanel5.Controls.Add(pnlLeftStick, 0, 0);
        tableLayoutPanel5.Dock = DockStyle.Top;
        tableLayoutPanel5.Location = new Point(143, 3);
        tableLayoutPanel5.Name = "tableLayoutPanel5";
        tableLayoutPanel5.RowCount = 1;
        tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel5.Size = new Size(419, 129);
        tableLayoutPanel5.TabIndex = 17;
        // 
        // pnlRightStick
        // 
        pnlRightStick.BorderStyle = BorderStyle.FixedSingle;
        pnlRightStick.Controls.Add(pnlRightStickIndicator);
        pnlRightStick.Dock = DockStyle.Fill;
        pnlRightStick.Location = new Point(212, 3);
        pnlRightStick.Name = "pnlRightStick";
        pnlRightStick.Size = new Size(204, 123);
        pnlRightStick.TabIndex = 1;
        // 
        // pnlRightStickIndicator
        // 
        pnlRightStickIndicator.Anchor = AnchorStyles.None;
        pnlRightStickIndicator.BackColor = Color.Blue;
        pnlRightStickIndicator.Location = new Point(97, 60);
        pnlRightStickIndicator.Name = "pnlRightStickIndicator";
        pnlRightStickIndicator.Size = new Size(10, 10);
        pnlRightStickIndicator.TabIndex = 0;
        // 
        // pnlLeftStick
        // 
        pnlLeftStick.BorderStyle = BorderStyle.FixedSingle;
        pnlLeftStick.Controls.Add(pnlLeftStickIndicator);
        pnlLeftStick.Dock = DockStyle.Fill;
        pnlLeftStick.Location = new Point(3, 3);
        pnlLeftStick.Name = "pnlLeftStick";
        pnlLeftStick.Size = new Size(203, 123);
        pnlLeftStick.TabIndex = 0;
        // 
        // pnlLeftStickIndicator
        // 
        pnlLeftStickIndicator.Anchor = AnchorStyles.None;
        pnlLeftStickIndicator.BackColor = Color.Red;
        pnlLeftStickIndicator.Location = new Point(96, 60);
        pnlLeftStickIndicator.Name = "pnlLeftStickIndicator";
        pnlLeftStickIndicator.Size = new Size(10, 10);
        pnlLeftStickIndicator.TabIndex = 0;
        // 
        // grpPidWorkflow
        // 
        grpPidWorkflow.Controls.Add(tblPidModeInfo);
        grpPidWorkflow.Controls.Add(tblPidMatrix);
        grpPidWorkflow.Controls.Add(btnFinishAxis);
        grpPidWorkflow.Dock = DockStyle.Top;
        grpPidWorkflow.Location = new Point(13, 277);
        grpPidWorkflow.Name = "grpPidWorkflow";
        grpPidWorkflow.Padding = new Padding(10);
        grpPidWorkflow.Size = new Size(679, 304);
        grpPidWorkflow.TabIndex = 2;
        grpPidWorkflow.TabStop = false;
        grpPidWorkflow.Text = "PID";
        // 
        // tblPidModeInfo
        // 
        tblPidModeInfo.ColumnCount = 2;
        tblPidModeInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        tblPidModeInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
        tblPidModeInfo.Controls.Add(lblFlightMode, 0, 1);
        tblPidModeInfo.Controls.Add(txtFlightMode, 1, 1);
        tblPidModeInfo.Controls.Add(lblAirMode, 0, 2);
        tblPidModeInfo.Controls.Add(txtAirMode, 1, 2);
        tblPidModeInfo.Dock = DockStyle.Top;
        tblPidModeInfo.Location = new Point(10, 144);
        tblPidModeInfo.Name = "tblPidModeInfo";
        tblPidModeInfo.RowCount = 4;
        tblPidModeInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidModeInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidModeInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidModeInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidModeInfo.Size = new Size(659, 96);
        tblPidModeInfo.TabIndex = 1;
        // 
        // lblFlightMode
        // 
        lblFlightMode.Anchor = AnchorStyles.Left;
        lblFlightMode.AutoSize = true;
        lblFlightMode.Location = new Point(3, 28);
        lblFlightMode.Name = "lblFlightMode";
        lblFlightMode.Size = new Size(74, 15);
        lblFlightMode.TabIndex = 0;
        lblFlightMode.Text = "Flight Mode:";
        // 
        // txtFlightMode
        // 
        txtFlightMode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtFlightMode.Location = new Point(233, 27);
        txtFlightMode.Name = "txtFlightMode";
        txtFlightMode.ReadOnly = true;
        txtFlightMode.Size = new Size(423, 23);
        txtFlightMode.TabIndex = 1;
        // 
        // lblAirMode
        // 
        lblAirMode.Anchor = AnchorStyles.Left;
        lblAirMode.AutoSize = true;
        lblAirMode.Location = new Point(3, 52);
        lblAirMode.Name = "lblAirMode";
        lblAirMode.Size = new Size(59, 15);
        lblAirMode.TabIndex = 2;
        lblAirMode.Text = "Air Mode:";
        // 
        // txtAirMode
        // 
        txtAirMode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtAirMode.Location = new Point(233, 51);
        txtAirMode.Name = "txtAirMode";
        txtAirMode.ReadOnly = true;
        txtAirMode.Size = new Size(423, 23);
        txtAirMode.TabIndex = 3;
        // 
        // tblPidMatrix
        // 
        tblPidMatrix.ColumnCount = 6;
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.8834352F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.95092F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.25767F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.5644169F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.3374233F));
        tblPidMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.006134F));
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
        tblPidMatrix.Dock = DockStyle.Top;
        tblPidMatrix.Location = new Point(10, 26);
        tblPidMatrix.Name = "tblPidMatrix";
        tblPidMatrix.RowCount = 4;
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 16.4556961F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 28.35821F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25.3731346F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 29.1044769F));
        tblPidMatrix.Size = new Size(659, 118);
        tblPidMatrix.TabIndex = 0;
        // 
        // lblPidHdrP
        // 
        lblPidHdrP.Anchor = AnchorStyles.None;
        lblPidHdrP.AutoSize = true;
        lblPidHdrP.Location = new Point(129, 2);
        lblPidHdrP.Name = "lblPidHdrP";
        lblPidHdrP.Size = new Size(14, 15);
        lblPidHdrP.TabIndex = 0;
        lblPidHdrP.Text = "P";
        // 
        // lblPidHdrI
        // 
        lblPidHdrI.Anchor = AnchorStyles.None;
        lblPidHdrI.AutoSize = true;
        lblPidHdrI.Location = new Point(237, 2);
        lblPidHdrI.Name = "lblPidHdrI";
        lblPidHdrI.Size = new Size(10, 15);
        lblPidHdrI.TabIndex = 1;
        lblPidHdrI.Text = "I";
        // 
        // lblPidHdrD
        // 
        lblPidHdrD.Anchor = AnchorStyles.None;
        lblPidHdrD.AutoSize = true;
        lblPidHdrD.Location = new Point(343, 2);
        lblPidHdrD.Name = "lblPidHdrD";
        lblPidHdrD.Size = new Size(15, 15);
        lblPidHdrD.TabIndex = 2;
        lblPidHdrD.Text = "D";
        // 
        // lblPidHdrFf
        // 
        lblPidHdrFf.Anchor = AnchorStyles.None;
        lblPidHdrFf.AutoSize = true;
        lblPidHdrFf.Location = new Point(446, 2);
        lblPidHdrFf.Name = "lblPidHdrFf";
        lblPidHdrFf.Size = new Size(19, 15);
        lblPidHdrFf.TabIndex = 3;
        lblPidHdrFf.Text = "FF";
        // 
        // lblPidRowRoll
        // 
        lblPidRowRoll.AutoSize = true;
        lblPidRowRoll.Dock = DockStyle.Top;
        lblPidRowRoll.Location = new Point(3, 19);
        lblPidRowRoll.Name = "lblPidRowRoll";
        lblPidRowRoll.Size = new Size(78, 15);
        lblPidRowRoll.TabIndex = 4;
        lblPidRowRoll.Text = "Roll";
        // 
        // lblPidRowPitch
        // 
        lblPidRowPitch.AutoSize = true;
        lblPidRowPitch.Dock = DockStyle.Top;
        lblPidRowPitch.Location = new Point(3, 52);
        lblPidRowPitch.Name = "lblPidRowPitch";
        lblPidRowPitch.Size = new Size(78, 15);
        lblPidRowPitch.TabIndex = 5;
        lblPidRowPitch.Text = "Pitch";
        // 
        // lblPidRowYaw
        // 
        lblPidRowYaw.AutoSize = true;
        lblPidRowYaw.Dock = DockStyle.Top;
        lblPidRowYaw.Location = new Point(3, 82);
        lblPidRowYaw.Name = "lblPidRowYaw";
        lblPidRowYaw.Size = new Size(78, 15);
        lblPidRowYaw.TabIndex = 6;
        lblPidRowYaw.Text = "Yaw";
        // 
        // txtRollP
        // 
        txtRollP.Dock = DockStyle.Top;
        txtRollP.Location = new Point(87, 22);
        txtRollP.Name = "txtRollP";
        txtRollP.ReadOnly = true;
        txtRollP.Size = new Size(99, 23);
        txtRollP.TabIndex = 7;
        txtRollP.Text = "0";
        // 
        // txtRollI
        // 
        txtRollI.Dock = DockStyle.Top;
        txtRollI.Location = new Point(192, 22);
        txtRollI.Name = "txtRollI";
        txtRollI.ReadOnly = true;
        txtRollI.Size = new Size(101, 23);
        txtRollI.TabIndex = 8;
        txtRollI.Text = "0";
        // 
        // txtRollD
        // 
        txtRollD.Dock = DockStyle.Top;
        txtRollD.Location = new Point(299, 22);
        txtRollD.Name = "txtRollD";
        txtRollD.ReadOnly = true;
        txtRollD.Size = new Size(103, 23);
        txtRollD.TabIndex = 9;
        txtRollD.Text = "0";
        // 
        // txtRollFf
        // 
        txtRollFf.Dock = DockStyle.Top;
        txtRollFf.Location = new Point(408, 22);
        txtRollFf.Name = "txtRollFf";
        txtRollFf.ReadOnly = true;
        txtRollFf.Size = new Size(95, 23);
        txtRollFf.TabIndex = 10;
        txtRollFf.Text = "0";
        // 
        // txtPitchP
        // 
        txtPitchP.Dock = DockStyle.Top;
        txtPitchP.Location = new Point(87, 55);
        txtPitchP.Name = "txtPitchP";
        txtPitchP.ReadOnly = true;
        txtPitchP.Size = new Size(99, 23);
        txtPitchP.TabIndex = 11;
        txtPitchP.Text = "0";
        // 
        // txtPitchI
        // 
        txtPitchI.Dock = DockStyle.Top;
        txtPitchI.Location = new Point(192, 55);
        txtPitchI.Name = "txtPitchI";
        txtPitchI.ReadOnly = true;
        txtPitchI.Size = new Size(101, 23);
        txtPitchI.TabIndex = 12;
        txtPitchI.Text = "0";
        // 
        // txtPitchD
        // 
        txtPitchD.Dock = DockStyle.Top;
        txtPitchD.Location = new Point(299, 55);
        txtPitchD.Name = "txtPitchD";
        txtPitchD.ReadOnly = true;
        txtPitchD.Size = new Size(103, 23);
        txtPitchD.TabIndex = 13;
        txtPitchD.Text = "0";
        // 
        // txtPitchFf
        // 
        txtPitchFf.Dock = DockStyle.Top;
        txtPitchFf.Location = new Point(408, 55);
        txtPitchFf.Name = "txtPitchFf";
        txtPitchFf.ReadOnly = true;
        txtPitchFf.Size = new Size(95, 23);
        txtPitchFf.TabIndex = 14;
        txtPitchFf.Text = "0";
        // 
        // txtYawP
        // 
        txtYawP.Dock = DockStyle.Top;
        txtYawP.Location = new Point(87, 85);
        txtYawP.Name = "txtYawP";
        txtYawP.ReadOnly = true;
        txtYawP.Size = new Size(99, 23);
        txtYawP.TabIndex = 15;
        txtYawP.Text = "0";
        // 
        // txtYawI
        // 
        txtYawI.Dock = DockStyle.Top;
        txtYawI.Location = new Point(192, 85);
        txtYawI.Name = "txtYawI";
        txtYawI.ReadOnly = true;
        txtYawI.Size = new Size(101, 23);
        txtYawI.TabIndex = 16;
        txtYawI.Text = "0";
        // 
        // txtYawD
        // 
        txtYawD.Dock = DockStyle.Top;
        txtYawD.Location = new Point(299, 85);
        txtYawD.Name = "txtYawD";
        txtYawD.ReadOnly = true;
        txtYawD.Size = new Size(103, 23);
        txtYawD.TabIndex = 17;
        txtYawD.Text = "0";
        // 
        // txtYawFf
        // 
        txtYawFf.Dock = DockStyle.Top;
        txtYawFf.Location = new Point(408, 85);
        txtYawFf.Name = "txtYawFf";
        txtYawFf.ReadOnly = true;
        txtYawFf.Size = new Size(95, 23);
        txtYawFf.TabIndex = 18;
        txtYawFf.Text = "0";
        // 
        // btnReadFcPid
        // 
        btnReadFcPid.Dock = DockStyle.Top;
        btnReadFcPid.Location = new Point(509, 22);
        btnReadFcPid.Name = "btnReadFcPid";
        btnReadFcPid.Size = new Size(147, 25);
        btnReadFcPid.TabIndex = 19;
        btnReadFcPid.Text = "Read FC";
        btnReadFcPid.UseVisualStyleBackColor = true;
        btnReadFcPid.Click += btnReadFcPid_Click;
        // 
        // btnPidEditable
        // 
        btnPidEditable.Dock = DockStyle.Top;
        btnPidEditable.Location = new Point(509, 55);
        btnPidEditable.Name = "btnPidEditable";
        btnPidEditable.Size = new Size(147, 24);
        btnPidEditable.TabIndex = 20;
        btnPidEditable.Text = "Editable";
        btnPidEditable.UseVisualStyleBackColor = true;
        btnPidEditable.Click += btnPidEditable_Click;
        // 
        // btnSaveFcPid
        // 
        btnSaveFcPid.Dock = DockStyle.Top;
        btnSaveFcPid.Location = new Point(509, 85);
        btnSaveFcPid.Name = "btnSaveFcPid";
        btnSaveFcPid.Size = new Size(147, 25);
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
        pnlScoreChart.Location = new Point(13, 634);
        pnlScoreChart.Name = "pnlScoreChart";
        pnlScoreChart.Size = new Size(1754, 200);
        pnlScoreChart.TabIndex = 0;
        pnlScoreChart.Paint += pnlScoreChart_Paint;
        // 
        // grpLiveData
        // 
        grpLiveData.Controls.Add(attitudeIndicator);
        grpLiveData.Controls.Add(tableLayoutPanel3);
        grpLiveData.Dock = DockStyle.Top;
        grpLiveData.Location = new Point(698, 277);
        grpLiveData.Name = "grpLiveData";
        grpLiveData.Size = new Size(264, 304);
        grpLiveData.TabIndex = 9;
        grpLiveData.TabStop = false;
        grpLiveData.Text = "Live";
        // 
        // attitudeIndicator
        // 
        attitudeIndicator.BackColor = Color.FromArgb(175, 175, 175);
        attitudeIndicator.Dock = DockStyle.Left;
        attitudeIndicator.Location = new Point(3, 96);
        attitudeIndicator.Name = "attitudeIndicator";
        attitudeIndicator.PitchDeg = 0D;
        attitudeIndicator.RollDeg = 0D;
        attitudeIndicator.Size = new Size(213, 205);
        attitudeIndicator.TabIndex = 9;
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.ColumnCount = 2;
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.1788635F));
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.8211365F));
        tableLayoutPanel3.Controls.Add(lblPitchAngle, 1, 3);
        tableLayoutPanel3.Controls.Add(lblRollAngle, 1, 2);
        tableLayoutPanel3.Controls.Add(lblChannelValue, 1, 1);
        tableLayoutPanel3.Controls.Add(lblChannelVisual, 1, 0);
        tableLayoutPanel3.Controls.Add(lblChannelVisualTitle, 0, 0);
        tableLayoutPanel3.Controls.Add(lblChannelValueTitle, 0, 1);
        tableLayoutPanel3.Controls.Add(lblRollAngleTitle, 0, 2);
        tableLayoutPanel3.Controls.Add(lblPitchAngleTitle, 0, 3);
        tableLayoutPanel3.Dock = DockStyle.Top;
        tableLayoutPanel3.Location = new Point(3, 19);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 4;
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel3.Size = new Size(258, 77);
        tableLayoutPanel3.TabIndex = 8;
        // 
        // lblPitchAngle
        // 
        lblPitchAngle.Anchor = AnchorStyles.Left;
        lblPitchAngle.Location = new Point(96, 59);
        lblPitchAngle.Name = "lblPitchAngle";
        lblPitchAngle.Size = new Size(27, 15);
        lblPitchAngle.TabIndex = 7;
        lblPitchAngle.Text = "0.0°";
        // 
        // lblRollAngle
        // 
        lblRollAngle.Anchor = AnchorStyles.Left;
        lblRollAngle.Location = new Point(96, 40);
        lblRollAngle.Name = "lblRollAngle";
        lblRollAngle.Size = new Size(27, 15);
        lblRollAngle.TabIndex = 5;
        lblRollAngle.Text = "0.0°";
        // 
        // lblChannelValue
        // 
        lblChannelValue.Anchor = AnchorStyles.Left;
        lblChannelValue.Location = new Point(96, 21);
        lblChannelValue.Name = "lblChannelValue";
        lblChannelValue.Size = new Size(46, 15);
        lblChannelValue.TabIndex = 3;
        lblChannelValue.Text = "1500 us";
        // 
        // lblChannelVisual
        // 
        lblChannelVisual.Anchor = AnchorStyles.Left;
        lblChannelVisual.Location = new Point(96, 0);
        lblChannelVisual.Name = "lblChannelVisual";
        lblChannelVisual.Size = new Size(101, 19);
        lblChannelVisual.TabIndex = 1;
        lblChannelVisual.Text = "Idle";
        // 
        // lblChannelVisualTitle
        // 
        lblChannelVisualTitle.Anchor = AnchorStyles.Left;
        lblChannelVisualTitle.Location = new Point(3, 2);
        lblChannelVisualTitle.Name = "lblChannelVisualTitle";
        lblChannelVisualTitle.Size = new Size(42, 15);
        lblChannelVisualTitle.TabIndex = 0;
        lblChannelVisualTitle.Text = "Status:";
        // 
        // lblChannelValueTitle
        // 
        lblChannelValueTitle.Anchor = AnchorStyles.Left;
        lblChannelValueTitle.Location = new Point(3, 21);
        lblChannelValueTitle.Name = "lblChannelValueTitle";
        lblChannelValueTitle.Size = new Size(38, 15);
        lblChannelValueTitle.TabIndex = 2;
        lblChannelValueTitle.Text = "Pulse:";
        // 
        // lblRollAngleTitle
        // 
        lblRollAngleTitle.Anchor = AnchorStyles.Left;
        lblRollAngleTitle.Location = new Point(3, 40);
        lblRollAngleTitle.Name = "lblRollAngleTitle";
        lblRollAngleTitle.Size = new Size(62, 15);
        lblRollAngleTitle.TabIndex = 4;
        lblRollAngleTitle.Text = "Roll angle:";
        // 
        // lblPitchAngleTitle
        // 
        lblPitchAngleTitle.Anchor = AnchorStyles.Left;
        lblPitchAngleTitle.Location = new Point(3, 59);
        lblPitchAngleTitle.Name = "lblPitchAngleTitle";
        lblPitchAngleTitle.Size = new Size(69, 15);
        lblPitchAngleTitle.TabIndex = 6;
        lblPitchAngleTitle.Text = "Pitch angle:";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(tableLayoutPanel7);
        groupBox1.Dock = DockStyle.Top;
        groupBox1.Location = new Point(968, 277);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(799, 304);
        groupBox1.TabIndex = 10;
        groupBox1.TabStop = false;
        groupBox1.Text = "Tune PID";
        // 
        // tableLayoutPanel7
        // 
        tableLayoutPanel7.ColumnCount = 3;
        tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
        tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
        tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 333F));
        tableLayoutPanel7.Controls.Add(tableLayoutPanel4, 0, 0);
        tableLayoutPanel7.Controls.Add(splitContainer1, 1, 0);
        tableLayoutPanel7.Location = new Point(16, 24);
        tableLayoutPanel7.Name = "tableLayoutPanel7";
        tableLayoutPanel7.RowCount = 1;
        tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel7.Size = new Size(800, 272);
        tableLayoutPanel7.TabIndex = 9;
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.ColumnCount = 1;
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel4.Controls.Add(btnTuneRoll, 0, 0);
        tableLayoutPanel4.Controls.Add(btnTunePitch, 0, 1);
        tableLayoutPanel4.Controls.Add(btnTuneYaw, 0, 2);
        tableLayoutPanel4.Controls.Add(btnThrottlePos, 0, 3);
        tableLayoutPanel4.Controls.Add(btnThrottleNeg, 0, 4);
        tableLayoutPanel4.Controls.Add(textBox1, 0, 5);
        tableLayoutPanel4.Dock = DockStyle.Top;
        tableLayoutPanel4.Location = new Point(3, 3);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 6;
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 34.7517738F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 31.2056732F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 34.2391319F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        tableLayoutPanel4.Size = new Size(169, 261);
        tableLayoutPanel4.TabIndex = 8;
        // 
        // btnTuneRoll
        // 
        btnTuneRoll.AutoSize = true;
        btnTuneRoll.Dock = DockStyle.Top;
        btnTuneRoll.Location = new Point(3, 3);
        btnTuneRoll.Name = "btnTuneRoll";
        btnTuneRoll.Size = new Size(163, 25);
        btnTuneRoll.TabIndex = 4;
        btnTuneRoll.Text = "Tune Roll";
        btnTuneRoll.UseVisualStyleBackColor = true;
        btnTuneRoll.Click += btnTuneRoll_Click;
        // 
        // btnTunePitch
        // 
        btnTunePitch.AutoSize = true;
        btnTunePitch.Dock = DockStyle.Top;
        btnTunePitch.Location = new Point(3, 46);
        btnTunePitch.Name = "btnTunePitch";
        btnTunePitch.Size = new Size(163, 25);
        btnTunePitch.TabIndex = 5;
        btnTunePitch.Text = "Tune Pitch";
        btnTunePitch.UseVisualStyleBackColor = true;
        btnTunePitch.Click += btnTunePitch_Click;
        // 
        // btnTuneYaw
        // 
        btnTuneYaw.AutoSize = true;
        btnTuneYaw.Dock = DockStyle.Top;
        btnTuneYaw.Location = new Point(3, 85);
        btnTuneYaw.Name = "btnTuneYaw";
        btnTuneYaw.Size = new Size(163, 25);
        btnTuneYaw.TabIndex = 6;
        btnTuneYaw.Text = "Tune Yaw";
        btnTuneYaw.UseVisualStyleBackColor = true;
        // 
        // btnThrottlePos
        // 
        btnThrottlePos.Dock = DockStyle.Top;
        btnThrottlePos.Location = new Point(3, 128);
        btnThrottlePos.Name = "btnThrottlePos";
        btnThrottlePos.Size = new Size(163, 25);
        btnThrottlePos.TabIndex = 7;
        btnThrottlePos.Text = "Throttle +";
        btnThrottlePos.UseVisualStyleBackColor = true;
        // 
        // btnThrottleNeg
        // 
        btnThrottleNeg.Dock = DockStyle.Top;
        btnThrottleNeg.Location = new Point(3, 169);
        btnThrottleNeg.Name = "btnThrottleNeg";
        btnThrottleNeg.Size = new Size(163, 25);
        btnThrottleNeg.TabIndex = 8;
        btnThrottleNeg.Text = "Throttle -";
        btnThrottleNeg.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Dock = DockStyle.Top;
        textBox1.Location = new Point(3, 211);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(163, 23);
        textBox1.TabIndex = 9;
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(178, 3);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(tableLayoutPanel8);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(pidCompassPanel);
        splitContainer1.Size = new Size(285, 266);
        splitContainer1.SplitterDistance = 113;
        splitContainer1.TabIndex = 9;
        // 
        // tableLayoutPanel8
        // 
        tableLayoutPanel8.ColumnCount = 4;
        tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.98361F));
        tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.01639F));
        tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 67F));
        tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 66F));
        tableLayoutPanel8.Controls.Add(lblPitchKp, 0, 2);
        tableLayoutPanel8.Controls.Add(nudPitchKd, 3, 2);
        tableLayoutPanel8.Controls.Add(lblRollKp, 0, 1);
        tableLayoutPanel8.Controls.Add(nudPitchKi, 2, 2);
        tableLayoutPanel8.Controls.Add(nudRollKp, 1, 1);
        tableLayoutPanel8.Controls.Add(nudPitchKp, 1, 2);
        tableLayoutPanel8.Controls.Add(nudRollKi, 2, 1);
        tableLayoutPanel8.Controls.Add(nudRollKd, 3, 1);
        tableLayoutPanel8.Controls.Add(label1, 1, 0);
        tableLayoutPanel8.Controls.Add(label2, 2, 0);
        tableLayoutPanel8.Controls.Add(label3, 3, 0);
        tableLayoutPanel8.Dock = DockStyle.Top;
        tableLayoutPanel8.Location = new Point(0, 0);
        tableLayoutPanel8.Name = "tableLayoutPanel8";
        tableLayoutPanel8.RowCount = 3;
        tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        tableLayoutPanel8.Size = new Size(285, 96);
        tableLayoutPanel8.TabIndex = 17;
        // 
        // lblPitchKp
        // 
        lblPitchKp.Dock = DockStyle.Top;
        lblPitchKp.Location = new Point(3, 48);
        lblPitchKp.Name = "lblPitchKp";
        lblPitchKp.Size = new Size(56, 20);
        lblPitchKp.TabIndex = 13;
        lblPitchKp.Text = "Pitch";
        lblPitchKp.TextAlign = ContentAlignment.BottomRight;
        // 
        // nudPitchKd
        // 
        nudPitchKd.DecimalPlaces = 3;
        nudPitchKd.Dock = DockStyle.Top;
        nudPitchKd.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
        nudPitchKd.Location = new Point(221, 51);
        nudPitchKd.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudPitchKd.Name = "nudPitchKd";
        nudPitchKd.Size = new Size(61, 23);
        nudPitchKd.TabIndex = 16;
        nudPitchKd.ValueChanged += nudPitchKd_ValueChanged;
        // 
        // lblRollKp
        // 
        lblRollKp.Dock = DockStyle.Top;
        lblRollKp.Location = new Point(3, 24);
        lblRollKp.Name = "lblRollKp";
        lblRollKp.Size = new Size(56, 20);
        lblRollKp.TabIndex = 9;
        lblRollKp.Text = "Roll";
        lblRollKp.TextAlign = ContentAlignment.BottomRight;
        // 
        // nudPitchKi
        // 
        nudPitchKi.DecimalPlaces = 3;
        nudPitchKi.Dock = DockStyle.Top;
        nudPitchKi.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
        nudPitchKi.Location = new Point(154, 51);
        nudPitchKi.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudPitchKi.Name = "nudPitchKi";
        nudPitchKi.Size = new Size(61, 23);
        nudPitchKi.TabIndex = 15;
        nudPitchKi.ValueChanged += nudPitchKi_ValueChanged;
        // 
        // nudRollKp
        // 
        nudRollKp.DecimalPlaces = 2;
        nudRollKp.Dock = DockStyle.Top;
        nudRollKp.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
        nudRollKp.Location = new Point(65, 27);
        nudRollKp.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudRollKp.Name = "nudRollKp";
        nudRollKp.Size = new Size(83, 23);
        nudRollKp.TabIndex = 10;
        nudRollKp.Value = new decimal(new int[] { 1, 0, 0, 0 });
        nudRollKp.ValueChanged += nudRollKp_ValueChanged;
        // 
        // nudPitchKp
        // 
        nudPitchKp.DecimalPlaces = 2;
        nudPitchKp.Dock = DockStyle.Top;
        nudPitchKp.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
        nudPitchKp.Location = new Point(65, 51);
        nudPitchKp.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudPitchKp.Name = "nudPitchKp";
        nudPitchKp.Size = new Size(83, 23);
        nudPitchKp.TabIndex = 14;
        nudPitchKp.Value = new decimal(new int[] { 1, 0, 0, 0 });
        nudPitchKp.ValueChanged += nudPitchKp_ValueChanged;
        // 
        // nudRollKi
        // 
        nudRollKi.DecimalPlaces = 3;
        nudRollKi.Dock = DockStyle.Top;
        nudRollKi.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
        nudRollKi.Location = new Point(154, 27);
        nudRollKi.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudRollKi.Name = "nudRollKi";
        nudRollKi.Size = new Size(61, 23);
        nudRollKi.TabIndex = 11;
        nudRollKi.ValueChanged += nudRollKi_ValueChanged;
        // 
        // nudRollKd
        // 
        nudRollKd.DecimalPlaces = 3;
        nudRollKd.Dock = DockStyle.Top;
        nudRollKd.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
        nudRollKd.Location = new Point(221, 27);
        nudRollKd.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudRollKd.Name = "nudRollKd";
        nudRollKd.Size = new Size(61, 23);
        nudRollKd.TabIndex = 12;
        nudRollKd.ValueChanged += nudRollKd_ValueChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Dock = DockStyle.Bottom;
        label1.Location = new Point(65, 9);
        label1.Name = "label1";
        label1.Size = new Size(83, 15);
        label1.TabIndex = 17;
        label1.Text = "P";
        label1.TextAlign = ContentAlignment.BottomCenter;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Dock = DockStyle.Bottom;
        label2.Location = new Point(154, 9);
        label2.Name = "label2";
        label2.Size = new Size(61, 15);
        label2.TabIndex = 18;
        label2.Text = "I";
        label2.TextAlign = ContentAlignment.BottomCenter;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Dock = DockStyle.Bottom;
        label3.Location = new Point(221, 9);
        label3.Name = "label3";
        label3.Size = new Size(61, 15);
        label3.TabIndex = 19;
        label3.Text = "D";
        label3.TextAlign = ContentAlignment.BottomCenter;
        // 
        // pidCompassPanel
        // 
        pidCompassPanel.ColumnCount = 3;
        pidCompassPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.93168F));
        pidCompassPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.06832F));
        pidCompassPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
        pidCompassPanel.Controls.Add(btnPitchDn, 1, 0);
        pidCompassPanel.Controls.Add(btnRollRight, 2, 1);
        pidCompassPanel.Controls.Add(btnRollLeft, 0, 1);
        pidCompassPanel.Controls.Add(btnPitchUp, 1, 2);
        pidCompassPanel.Controls.Add(btnLevelOut, 1, 1);
        pidCompassPanel.Dock = DockStyle.Fill;
        pidCompassPanel.Location = new Point(0, 0);
        pidCompassPanel.Name = "pidCompassPanel";
        pidCompassPanel.RowCount = 3;
        pidCompassPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 48.54369F));
        pidCompassPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 51.45631F));
        pidCompassPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        pidCompassPanel.Size = new Size(285, 149);
        pidCompassPanel.TabIndex = 18;
        // 
        // btnPitchDn
        // 
        btnPitchDn.Dock = DockStyle.Fill;
        btnPitchDn.Location = new Point(97, 3);
        btnPitchDn.Name = "btnPitchDn";
        btnPitchDn.Size = new Size(84, 44);
        btnPitchDn.TabIndex = 1;
        btnPitchDn.Text = "Pitch Down";
        btnPitchDn.UseVisualStyleBackColor = true;
        btnPitchDn.Click += btnCompassNorth_Click;
        // 
        // btnRollRight
        // 
        btnRollRight.Dock = DockStyle.Fill;
        btnRollRight.Location = new Point(187, 53);
        btnRollRight.Name = "btnRollRight";
        btnRollRight.Size = new Size(95, 47);
        btnRollRight.TabIndex = 2;
        btnRollRight.Text = "Roll Right";
        btnRollRight.UseVisualStyleBackColor = true;
        btnRollRight.Click += btnCompassEast_Click;
        // 
        // btnRollLeft
        // 
        btnRollLeft.Dock = DockStyle.Fill;
        btnRollLeft.Location = new Point(3, 53);
        btnRollLeft.Name = "btnRollLeft";
        btnRollLeft.Size = new Size(88, 47);
        btnRollLeft.TabIndex = 0;
        btnRollLeft.Text = "Roll Left";
        btnRollLeft.UseVisualStyleBackColor = true;
        btnRollLeft.Click += btnCompassWest_Click;
        // 
        // btnPitchUp
        // 
        btnPitchUp.Dock = DockStyle.Fill;
        btnPitchUp.Location = new Point(97, 106);
        btnPitchUp.Name = "btnPitchUp";
        btnPitchUp.Size = new Size(84, 40);
        btnPitchUp.TabIndex = 3;
        btnPitchUp.Text = "Pitch Up";
        btnPitchUp.UseVisualStyleBackColor = true;
        btnPitchUp.Click += btnCompassSouth_Click;
        // 
        // btnLevelOut
        // 
        btnLevelOut.Dock = DockStyle.Fill;
        btnLevelOut.Location = new Point(97, 53);
        btnLevelOut.Name = "btnLevelOut";
        btnLevelOut.Size = new Size(84, 47);
        btnLevelOut.TabIndex = 4;
        btnLevelOut.Text = "Level Out";
        btnLevelOut.UseVisualStyleBackColor = true;
        btnLevelOut.Click += btnCompassClear_Click;
        // 
        // btnFinishAxis
        // 
        btnFinishAxis.Location = new Point(464, 240);
        btnFinishAxis.Name = "btnFinishAxis";
        btnFinishAxis.Size = new Size(198, 39);
        btnFinishAxis.TabIndex = 10;
        btnFinishAxis.Text = "Finish";
        btnFinishAxis.UseVisualStyleBackColor = true;
        btnFinishAxis.Click += btnFinishAxis_Click;
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
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1780, 847);
        Controls.Add(rootLayout);
        MinimumSize = new Size(898, 475);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Drone PID Tuning Assistant (WinForms)";
        rootLayout.ResumeLayout(false);
        grpUsb.ResumeLayout(false);
        tblUsb.ResumeLayout(false);
        grpMapping.ResumeLayout(false);
        mappingTable.ResumeLayout(false);
        mappingTable.PerformLayout();
        grpChannelTest.ResumeLayout(false);
        tableLayoutPanel6.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).EndInit();
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        tableLayoutPanel5.ResumeLayout(false);
        pnlRightStick.ResumeLayout(false);
        pnlLeftStick.ResumeLayout(false);
        grpPidWorkflow.ResumeLayout(false);
        tblPidModeInfo.ResumeLayout(false);
        tblPidModeInfo.PerformLayout();
        tblPidMatrix.ResumeLayout(false);
        tblPidMatrix.PerformLayout();
        grpLiveData.ResumeLayout(false);
        tableLayoutPanel3.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        tableLayoutPanel7.ResumeLayout(false);
        tableLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel4.PerformLayout();
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        tableLayoutPanel8.ResumeLayout(false);
        tableLayoutPanel8.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudPitchKd).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPitchKi).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudRollKp).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPitchKp).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudRollKi).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudRollKd).EndInit();
        pidCompassPanel.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private TableLayoutPanel rootLayout;
    private GroupBox grpUsb;
    private TableLayoutPanel tblUsb;
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
    private TableLayoutPanel mappingTable;
    private Label lblRoll;
    private ComboBox cboCH1;
    private Label lblPitch;
    private ComboBox cboCH2;
    private Label lblThrottle;
    private ComboBox cboCH3;
    private Label lblYaw;
    private ComboBox cboCH4;
    private Button btnApplyMapping;
    private Button btnPresetAetr;
    private Button btnPresetRtae;
    private Button btnPresetReat;
    private GroupBox grpChannelTest;
    private GroupBox grpPidWorkflow;
    private TableLayoutPanel tblPidMatrix;
    private TableLayoutPanel tblPidModeInfo;
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
    private Button btnRetestAxis;
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
    private Panel pnlLeftStick;
    private Panel pnlLeftStickIndicator;
    private Panel pnlRightStick;
    private Panel pnlRightStickIndicator;
    private Label lblTargetDeg;
    private Label lblSettleSec;
    private NumericUpDown nudSettleSec;
    private Label lblBaselineSec;
    private NumericUpDown nudBaselineSec;
    private Label lblThrottleUs;
    private NumericUpDown nudThrottleUs;
    private NumericUpDown nudTargetDeg;
    private TableLayoutPanel tableLayoutPanel1;
    private Button btnTestYaw;
    private TableLayoutPanel tableLayoutPanel2;
    private TableLayoutPanel tableLayoutPanel3;
    private GroupBox grpLiveData;
    private Controls.AttitudeIndicatorControl attitudeIndicator;
    private GroupBox groupBox1;
    private Button btnTuneRoll;
    private Button btnTunePitch;
    private Button btnTuneYaw;
    private TableLayoutPanel tableLayoutPanel4;
    private Label lblFlightMode;
    private TextBox txtFlightMode;
    private Label lblAirMode;
    private TextBox txtAirMode;
    private Button btnThrottlePos;
    private Button btnThrottleNeg;
    private TextBox textBox1;
    private Label lblRollKp;
    private NumericUpDown nudRollKp;
    private NumericUpDown nudRollKi;
    private NumericUpDown nudRollKd;
    private Label lblPitchKp;
    private NumericUpDown nudPitchKp;
    private NumericUpDown nudPitchKi;
    private NumericUpDown nudPitchKd;
    private TableLayoutPanel tableLayoutPanel5;
    private TableLayoutPanel tableLayoutPanel6;
    private TableLayoutPanel tableLayoutPanel7;
    private TableLayoutPanel pidCompassPanel;
    private TableLayoutPanel tableLayoutPanel8;
    private Label label1;
    private Label label2;
    private Label label3;
    private SplitContainer splitContainer1;
    private Button btnPitchDn;
    private Button btnRollRight;
    private Button btnRollLeft;
    private Button btnPitchUp;
    private Button btnLevelOut;
    private Button btnFinishAxis;
}



