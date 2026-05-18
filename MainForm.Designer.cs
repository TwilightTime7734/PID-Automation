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
        lblArduinoStatus = new Label();
        btnArduinoDisconnect = new Button();
        btnFcDisconnect = new Button();
        btnFcConnect = new Button();
        btnArduinoConnect = new Button();
        btnSimulationToggle = new Button();
        btnRefreshPorts = new Button();
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
        tableLayoutPanel1 = new TableLayoutPanel();
        btnTestRoll = new Button();
        btnTestPitch = new Button();
        btnTestThrottle = new Button();
        btnTestYaw = new Button();
        pnlSticks = new Panel();
        tableLayoutPanel2 = new TableLayoutPanel();
        nudBaselineSec = new NumericUpDown();
        lblTargetDeg = new Label();
        lblBaselineSec = new Label();
        nudTargetDeg = new NumericUpDown();
        lblSettleSec = new Label();
        nudSettleSec = new NumericUpDown();
        lblThrottleUs = new Label();
        nudThrottleUs = new NumericUpDown();
        pnlRightStick = new Panel();
        pnlRightStickIndicator = new Panel();
        pnlLeftStick = new Panel();
        pnlLeftStickIndicator = new Panel();
        button1 = new Button();
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
        btnReadFcPid = new Button();
        btnPidEditable = new Button();
        btnSaveFcPid = new Button();
        pnlScoreChart = new Panel();
        grpLiveData = new GroupBox();
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
        tableLayoutPanel4 = new TableLayoutPanel();
        button2 = new Button();
        button3 = new Button();
        button5 = new Button();
        button4 = new Button();
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
        rootLayout.SuspendLayout();
        grpUsb.SuspendLayout();
        tblUsb.SuspendLayout();
        grpMapping.SuspendLayout();
        mappingTable.SuspendLayout();
        grpChannelTest.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        pnlSticks.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).BeginInit();
        pnlRightStick.SuspendLayout();
        pnlLeftStick.SuspendLayout();
        grpPidWorkflow.SuspendLayout();
        tblPidMatrix.SuspendLayout();
        grpLiveData.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        groupBox1.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.AutoSize = true;
        rootLayout.ColumnCount = 3;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.78173F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7259789F));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.4329758F));
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
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 23.4908142F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 53.412075F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 23.0414753F));
        rootLayout.Size = new Size(1567, 782);
        rootLayout.TabIndex = 0;
        // 
        // grpUsb
        // 
        grpUsb.Controls.Add(tblUsb);
        grpUsb.Dock = DockStyle.Top;
        grpUsb.Location = new Point(13, 13);
        grpUsb.Name = "grpUsb";
        grpUsb.Padding = new Padding(10);
        grpUsb.Size = new Size(578, 171);
        grpUsb.TabIndex = 0;
        grpUsb.TabStop = false;
        grpUsb.Text = "Serial Ports";
        // 
        // tblUsb
        // 
        tblUsb.ColumnCount = 5;
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.5992F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.4686346F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.4022141F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.1773548F));
        tblUsb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.21999F));
        tblUsb.Controls.Add(lblPort, 0, 0);
        tblUsb.Controls.Add(lblArduinoPort, 0, 1);
        tblUsb.Controls.Add(lblTrainerPin, 0, 2);
        tblUsb.Controls.Add(cboPort, 1, 0);
        tblUsb.Controls.Add(cboBaud, 2, 0);
        tblUsb.Controls.Add(cboArduinoPort, 1, 1);
        tblUsb.Controls.Add(cboArduinoBaud, 2, 1);
        tblUsb.Controls.Add(cboTrainerPin, 1, 2);
        tblUsb.Controls.Add(lblArduinoStatus, 3, 3);
        tblUsb.Controls.Add(btnArduinoDisconnect, 4, 0);
        tblUsb.Controls.Add(btnFcDisconnect, 4, 1);
        tblUsb.Controls.Add(btnFcConnect, 3, 0);
        tblUsb.Controls.Add(btnArduinoConnect, 3, 1);
        tblUsb.Controls.Add(btnSimulationToggle, 4, 2);
        tblUsb.Controls.Add(btnRefreshPorts, 3, 2);
        tblUsb.Controls.Add(lblFCStatus, 1, 3);
        tblUsb.Dock = DockStyle.Left;
        tblUsb.Location = new Point(10, 26);
        tblUsb.Name = "tblUsb";
        tblUsb.RowCount = 4;
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblUsb.Size = new Size(542, 135);
        tblUsb.TabIndex = 0;
        tblUsb.Paint += TblUsb_Paint;
        // 
        // lblPort
        // 
        lblPort.Dock = DockStyle.Top;
        lblPort.Location = new Point(3, 0);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(56, 23);
        lblPort.TabIndex = 0;
        lblPort.Text = "FC USB";
        lblPort.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblArduinoPort
        // 
        lblArduinoPort.Dock = DockStyle.Top;
        lblArduinoPort.Location = new Point(3, 33);
        lblArduinoPort.Name = "lblArduinoPort";
        lblArduinoPort.Size = new Size(56, 23);
        lblArduinoPort.TabIndex = 7;
        lblArduinoPort.Text = "Arduino";
        lblArduinoPort.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTrainerPin
        // 
        lblTrainerPin.Dock = DockStyle.Top;
        lblTrainerPin.Location = new Point(3, 66);
        lblTrainerPin.Name = "lblTrainerPin";
        lblTrainerPin.Size = new Size(56, 23);
        lblTrainerPin.TabIndex = 15;
        lblTrainerPin.Text = "Trainer Pin";
        lblTrainerPin.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // cboPort
        // 
        cboPort.Dock = DockStyle.Fill;
        cboPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPort.FormattingEnabled = true;
        cboPort.Location = new Point(65, 3);
        cboPort.Name = "cboPort";
        cboPort.Size = new Size(67, 23);
        cboPort.TabIndex = 1;
        // 
        // cboBaud
        // 
        cboBaud.Dock = DockStyle.Fill;
        cboBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBaud.FormattingEnabled = true;
        cboBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboBaud.Location = new Point(138, 3);
        cboBaud.Name = "cboBaud";
        cboBaud.Size = new Size(110, 23);
        cboBaud.TabIndex = 2;
        // 
        // cboArduinoPort
        // 
        cboArduinoPort.Dock = DockStyle.Fill;
        cboArduinoPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoPort.FormattingEnabled = true;
        cboArduinoPort.Location = new Point(65, 36);
        cboArduinoPort.Name = "cboArduinoPort";
        cboArduinoPort.Size = new Size(67, 23);
        cboArduinoPort.TabIndex = 8;
        // 
        // cboArduinoBaud
        // 
        cboArduinoBaud.Dock = DockStyle.Fill;
        cboArduinoBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoBaud.FormattingEnabled = true;
        cboArduinoBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboArduinoBaud.Location = new Point(138, 36);
        cboArduinoBaud.Name = "cboArduinoBaud";
        cboArduinoBaud.Size = new Size(110, 23);
        cboArduinoBaud.TabIndex = 9;
        // 
        // cboTrainerPin
        // 
        cboTrainerPin.Dock = DockStyle.Fill;
        cboTrainerPin.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTrainerPin.FormattingEnabled = true;
        cboTrainerPin.Items.AddRange(new object[] { "3", "5", "6", "9", "10", "11" });
        cboTrainerPin.Location = new Point(65, 69);
        cboTrainerPin.Name = "cboTrainerPin";
        cboTrainerPin.Size = new Size(67, 23);
        cboTrainerPin.TabIndex = 16;
        // 
        // lblArduinoStatus
        // 
        tblUsb.SetColumnSpan(lblArduinoStatus, 2);
        lblArduinoStatus.Dock = DockStyle.Top;
        lblArduinoStatus.Location = new Point(254, 102);
        lblArduinoStatus.Margin = new Padding(3, 3, 3, 0);
        lblArduinoStatus.Name = "lblArduinoStatus";
        lblArduinoStatus.Size = new Size(285, 24);
        lblArduinoStatus.TabIndex = 14;
        lblArduinoStatus.Text = "Waiting...";
        lblArduinoStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnArduinoDisconnect
        // 
        btnArduinoDisconnect.Dock = DockStyle.Top;
        btnArduinoDisconnect.Location = new Point(368, 3);
        btnArduinoDisconnect.Name = "btnArduinoDisconnect";
        btnArduinoDisconnect.Size = new Size(171, 25);
        btnArduinoDisconnect.TabIndex = 11;
        btnArduinoDisconnect.Text = "Disconnect";
        btnArduinoDisconnect.UseVisualStyleBackColor = true;
        btnArduinoDisconnect.Click += btnArduinoDisconnect_Click;
        // 
        // btnFcDisconnect
        // 
        btnFcDisconnect.Dock = DockStyle.Top;
        btnFcDisconnect.Location = new Point(368, 36);
        btnFcDisconnect.Name = "btnFcDisconnect";
        btnFcDisconnect.Size = new Size(171, 25);
        btnFcDisconnect.TabIndex = 4;
        btnFcDisconnect.Text = "Disconnect";
        btnFcDisconnect.UseVisualStyleBackColor = true;
        btnFcDisconnect.Click += btnDisconnect_Click;
        // 
        // btnFcConnect
        // 
        btnFcConnect.Dock = DockStyle.Top;
        btnFcConnect.Location = new Point(254, 3);
        btnFcConnect.Name = "btnFcConnect";
        btnFcConnect.Size = new Size(108, 25);
        btnFcConnect.TabIndex = 3;
        btnFcConnect.Text = "Connect";
        btnFcConnect.UseVisualStyleBackColor = true;
        btnFcConnect.Click += btnConnect_Click;
        // 
        // btnArduinoConnect
        // 
        btnArduinoConnect.Dock = DockStyle.Top;
        btnArduinoConnect.Location = new Point(254, 36);
        btnArduinoConnect.Name = "btnArduinoConnect";
        btnArduinoConnect.Size = new Size(108, 25);
        btnArduinoConnect.TabIndex = 10;
        btnArduinoConnect.Text = "Connect";
        btnArduinoConnect.UseVisualStyleBackColor = true;
        btnArduinoConnect.Click += btnArduinoConnect_Click;
        // 
        // btnSimulationToggle
        // 
        btnSimulationToggle.Dock = DockStyle.Top;
        btnSimulationToggle.Location = new Point(368, 69);
        btnSimulationToggle.Name = "btnSimulationToggle";
        btnSimulationToggle.Size = new Size(171, 25);
        btnSimulationToggle.TabIndex = 17;
        btnSimulationToggle.Text = "Simulation: Off";
        btnSimulationToggle.UseVisualStyleBackColor = true;
        // 
        // btnRefreshPorts
        // 
        btnRefreshPorts.Dock = DockStyle.Top;
        btnRefreshPorts.ImageAlign = ContentAlignment.MiddleLeft;
        btnRefreshPorts.Location = new Point(254, 69);
        btnRefreshPorts.Name = "btnRefreshPorts";
        btnRefreshPorts.Size = new Size(108, 25);
        btnRefreshPorts.TabIndex = 5;
        btnRefreshPorts.Text = "Refresh";
        btnRefreshPorts.UseVisualStyleBackColor = true;
        btnRefreshPorts.Click += btnRefreshPorts_Click;
        // 
        // lblFCStatus
        // 
        tblUsb.SetColumnSpan(lblFCStatus, 2);
        lblFCStatus.Dock = DockStyle.Top;
        lblFCStatus.Location = new Point(65, 102);
        lblFCStatus.Margin = new Padding(3, 3, 3, 0);
        lblFCStatus.Name = "lblFCStatus";
        lblFCStatus.Size = new Size(183, 24);
        lblFCStatus.TabIndex = 13;
        lblFCStatus.Text = "Waiting...";
        lblFCStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grpMapping
        // 
        grpMapping.Controls.Add(mappingTable);
        grpMapping.Dock = DockStyle.Top;
        grpMapping.Location = new Point(597, 13);
        grpMapping.Name = "grpMapping";
        grpMapping.Padding = new Padding(10);
        grpMapping.Size = new Size(252, 171);
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
        mappingTable.Dock = DockStyle.Left;
        mappingTable.Location = new Point(10, 26);
        mappingTable.MinimumSize = new Size(180, 70);
        mappingTable.Name = "mappingTable";
        mappingTable.RowCount = 4;
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        mappingTable.Size = new Size(213, 135);
        mappingTable.TabIndex = 0;
        // 
        // lblRoll
        // 
        lblRoll.AutoSize = true;
        lblRoll.Dock = DockStyle.Top;
        lblRoll.Location = new Point(3, 7);
        lblRoll.Margin = new Padding(3, 7, 3, 0);
        lblRoll.Name = "lblRoll";
        lblRoll.Size = new Size(35, 15);
        lblRoll.TabIndex = 0;
        lblRoll.Text = "Ch 1";
        lblRoll.TextAlign = ContentAlignment.MiddleRight;
        lblRoll.Click += lblRoll_Click;
        // 
        // lblPitch
        // 
        lblPitch.AutoSize = true;
        lblPitch.Dock = DockStyle.Top;
        lblPitch.Location = new Point(3, 40);
        lblPitch.Margin = new Padding(3, 7, 3, 0);
        lblPitch.Name = "lblPitch";
        lblPitch.Size = new Size(35, 15);
        lblPitch.TabIndex = 2;
        lblPitch.Text = "Ch 2";
        lblPitch.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblThrottle
        // 
        lblThrottle.AutoSize = true;
        lblThrottle.Dock = DockStyle.Top;
        lblThrottle.Location = new Point(3, 73);
        lblThrottle.Margin = new Padding(3, 7, 3, 0);
        lblThrottle.Name = "lblThrottle";
        lblThrottle.Size = new Size(35, 15);
        lblThrottle.TabIndex = 4;
        lblThrottle.Text = "Ch 3";
        lblThrottle.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblYaw
        // 
        lblYaw.AutoSize = true;
        lblYaw.Dock = DockStyle.Top;
        lblYaw.Location = new Point(3, 106);
        lblYaw.Margin = new Padding(3, 7, 3, 0);
        lblYaw.Name = "lblYaw";
        lblYaw.Size = new Size(35, 15);
        lblYaw.TabIndex = 7;
        lblYaw.Text = "Ch 4";
        lblYaw.TextAlign = ContentAlignment.MiddleRight;
        // 
        // btnPresetReat
        // 
        btnPresetReat.AutoSize = true;
        btnPresetReat.Dock = DockStyle.Top;
        btnPresetReat.Location = new Point(123, 102);
        btnPresetReat.Name = "btnPresetReat";
        btnPresetReat.Size = new Size(87, 25);
        btnPresetReat.TabIndex = 11;
        btnPresetReat.Text = "REAT";
        btnPresetReat.UseVisualStyleBackColor = true;
        btnPresetReat.Click += btnPresetReat_Click;
        // 
        // btnPresetRtae
        // 
        btnPresetRtae.AutoSize = true;
        btnPresetRtae.Dock = DockStyle.Top;
        btnPresetRtae.Location = new Point(123, 69);
        btnPresetRtae.Name = "btnPresetRtae";
        btnPresetRtae.Size = new Size(87, 25);
        btnPresetRtae.TabIndex = 10;
        btnPresetRtae.Text = "RTAE";
        btnPresetRtae.UseVisualStyleBackColor = true;
        btnPresetRtae.Click += btnPresetRtae_Click;
        // 
        // btnPresetAetr
        // 
        btnPresetAetr.AutoSize = true;
        btnPresetAetr.Dock = DockStyle.Top;
        btnPresetAetr.Location = new Point(123, 36);
        btnPresetAetr.Name = "btnPresetAetr";
        btnPresetAetr.Size = new Size(87, 25);
        btnPresetAetr.TabIndex = 9;
        btnPresetAetr.Text = "AETR";
        btnPresetAetr.UseVisualStyleBackColor = true;
        btnPresetAetr.Click += btnPresetAetr_Click;
        // 
        // btnApplyMapping
        // 
        btnApplyMapping.Dock = DockStyle.Top;
        btnApplyMapping.Location = new Point(123, 3);
        btnApplyMapping.Margin = new Padding(3, 3, 3, 6);
        btnApplyMapping.Name = "btnApplyMapping";
        btnApplyMapping.Size = new Size(87, 23);
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
        cboCH1.Location = new Point(44, 3);
        cboCH1.Margin = new Padding(3, 3, 6, 3);
        cboCH1.Name = "cboCH1";
        cboCH1.Size = new Size(70, 23);
        cboCH1.TabIndex = 1;
        // 
        // cboCH2
        // 
        cboCH2.Dock = DockStyle.Fill;
        cboCH2.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH2.FormattingEnabled = true;
        cboCH2.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH2.Location = new Point(44, 36);
        cboCH2.Margin = new Padding(3, 3, 6, 3);
        cboCH2.Name = "cboCH2";
        cboCH2.Size = new Size(70, 23);
        cboCH2.TabIndex = 3;
        // 
        // cboCH3
        // 
        cboCH3.Dock = DockStyle.Fill;
        cboCH3.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH3.FormattingEnabled = true;
        cboCH3.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH3.Location = new Point(44, 69);
        cboCH3.Margin = new Padding(3, 3, 6, 3);
        cboCH3.Name = "cboCH3";
        cboCH3.Size = new Size(70, 23);
        cboCH3.TabIndex = 5;
        // 
        // cboCH4
        // 
        cboCH4.Dock = DockStyle.Top;
        cboCH4.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH4.FormattingEnabled = true;
        cboCH4.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH4.Location = new Point(44, 102);
        cboCH4.Margin = new Padding(3, 3, 6, 3);
        cboCH4.Name = "cboCH4";
        cboCH4.Size = new Size(70, 23);
        cboCH4.TabIndex = 8;
        // 
        // grpChannelTest
        // 
        grpChannelTest.Controls.Add(tableLayoutPanel1);
        grpChannelTest.Controls.Add(button1);
        grpChannelTest.Dock = DockStyle.Top;
        grpChannelTest.Location = new Point(855, 13);
        grpChannelTest.Name = "grpChannelTest";
        grpChannelTest.Padding = new Padding(10);
        grpChannelTest.Size = new Size(699, 163);
        grpChannelTest.TabIndex = 0;
        grpChannelTest.TabStop = false;
        grpChannelTest.Text = "Channel Test";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 508F));
        tableLayoutPanel1.Controls.Add(btnTestRoll, 0, 0);
        tableLayoutPanel1.Controls.Add(btnTestPitch, 0, 1);
        tableLayoutPanel1.Controls.Add(btnTestThrottle, 0, 2);
        tableLayoutPanel1.Controls.Add(btnTestYaw, 0, 3);
        tableLayoutPanel1.Controls.Add(pnlSticks, 1, 0);
        tableLayoutPanel1.Dock = DockStyle.Left;
        tableLayoutPanel1.Location = new Point(10, 26);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tableLayoutPanel1.Size = new Size(598, 127);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // btnTestRoll
        // 
        btnTestRoll.AutoSize = true;
        btnTestRoll.Dock = DockStyle.Left;
        btnTestRoll.Location = new Point(3, 3);
        btnTestRoll.Name = "btnTestRoll";
        btnTestRoll.Size = new Size(84, 26);
        btnTestRoll.TabIndex = 0;
        btnTestRoll.Text = "Test Roll";
        btnTestRoll.UseVisualStyleBackColor = true;
        btnTestRoll.Click += btnTestRoll_Click;
        // 
        // btnTestPitch
        // 
        btnTestPitch.AutoSize = true;
        btnTestPitch.Dock = DockStyle.Left;
        btnTestPitch.Location = new Point(3, 35);
        btnTestPitch.Name = "btnTestPitch";
        btnTestPitch.Size = new Size(84, 26);
        btnTestPitch.TabIndex = 1;
        btnTestPitch.Text = "Test Pitch";
        btnTestPitch.UseVisualStyleBackColor = true;
        btnTestPitch.Click += btnTestPitch_Click;
        // 
        // btnTestThrottle
        // 
        btnTestThrottle.AutoSize = true;
        btnTestThrottle.Dock = DockStyle.Left;
        btnTestThrottle.Location = new Point(3, 67);
        btnTestThrottle.Name = "btnTestThrottle";
        btnTestThrottle.Size = new Size(84, 26);
        btnTestThrottle.TabIndex = 2;
        btnTestThrottle.Text = "Test Throttle";
        btnTestThrottle.UseVisualStyleBackColor = true;
        btnTestThrottle.Click += btnTestThrottle_Click;
        // 
        // btnTestYaw
        // 
        btnTestYaw.AutoSize = true;
        btnTestYaw.Dock = DockStyle.Left;
        btnTestYaw.Location = new Point(3, 99);
        btnTestYaw.Name = "btnTestYaw";
        btnTestYaw.Size = new Size(84, 25);
        btnTestYaw.TabIndex = 3;
        btnTestYaw.Text = "Test Yaw";
        btnTestYaw.UseVisualStyleBackColor = true;
        // 
        // pnlSticks
        // 
        pnlSticks.Controls.Add(tableLayoutPanel2);
        pnlSticks.Controls.Add(pnlRightStick);
        pnlSticks.Controls.Add(pnlLeftStick);
        pnlSticks.Location = new Point(93, 3);
        pnlSticks.Name = "pnlSticks";
        tableLayoutPanel1.SetRowSpan(pnlSticks, 4);
        pnlSticks.Size = new Size(502, 121);
        pnlSticks.TabIndex = 2;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.8139534F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.1860466F));
        tableLayoutPanel2.Controls.Add(nudBaselineSec, 1, 1);
        tableLayoutPanel2.Controls.Add(lblTargetDeg, 0, 0);
        tableLayoutPanel2.Controls.Add(lblBaselineSec, 0, 1);
        tableLayoutPanel2.Controls.Add(nudTargetDeg, 1, 0);
        tableLayoutPanel2.Controls.Add(lblSettleSec, 0, 2);
        tableLayoutPanel2.Controls.Add(nudSettleSec, 1, 2);
        tableLayoutPanel2.Controls.Add(lblThrottleUs, 0, 3);
        tableLayoutPanel2.Controls.Add(nudThrottleUs, 1, 3);
        tableLayoutPanel2.Dock = DockStyle.Left;
        tableLayoutPanel2.Location = new Point(324, 0);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 4;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel2.Size = new Size(172, 121);
        tableLayoutPanel2.TabIndex = 7;
        // 
        // nudBaselineSec
        // 
        nudBaselineSec.Anchor = AnchorStyles.Left;
        nudBaselineSec.DecimalPlaces = 1;
        nudBaselineSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudBaselineSec.Location = new Point(96, 35);
        nudBaselineSec.Margin = new Padding(0, 4, 0, 0);
        nudBaselineSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudBaselineSec.Name = "nudBaselineSec";
        nudBaselineSec.Size = new Size(64, 23);
        nudBaselineSec.TabIndex = 5;
        nudBaselineSec.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblTargetDeg
        // 
        lblTargetDeg.Anchor = AnchorStyles.Right;
        lblTargetDeg.Location = new Point(36, 3);
        lblTargetDeg.Margin = new Padding(0);
        lblTargetDeg.Name = "lblTargetDeg";
        lblTargetDeg.Size = new Size(60, 23);
        lblTargetDeg.TabIndex = 0;
        lblTargetDeg.Text = "Target Δ°";
        lblTargetDeg.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblBaselineSec
        // 
        lblBaselineSec.Anchor = AnchorStyles.Right;
        lblBaselineSec.Location = new Point(1, 33);
        lblBaselineSec.Margin = new Padding(0);
        lblBaselineSec.Name = "lblBaselineSec";
        lblBaselineSec.Size = new Size(95, 23);
        lblBaselineSec.TabIndex = 4;
        lblBaselineSec.Text = "Sec on Target Δ°";
        lblBaselineSec.TextAlign = ContentAlignment.MiddleRight;
        // 
        // nudTargetDeg
        // 
        nudTargetDeg.Anchor = AnchorStyles.Left;
        nudTargetDeg.DecimalPlaces = 1;
        nudTargetDeg.Location = new Point(96, 5);
        nudTargetDeg.Margin = new Padding(0, 4, 0, 0);
        nudTargetDeg.Maximum = new decimal(new int[] { 45, 0, 0, 0 });
        nudTargetDeg.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudTargetDeg.Name = "nudTargetDeg";
        nudTargetDeg.Size = new Size(64, 23);
        nudTargetDeg.TabIndex = 1;
        nudTargetDeg.Value = new decimal(new int[] { 20, 0, 0, 0 });
        // 
        // lblSettleSec
        // 
        lblSettleSec.Anchor = AnchorStyles.Right;
        lblSettleSec.Location = new Point(15, 63);
        lblSettleSec.Margin = new Padding(0);
        lblSettleSec.Name = "lblSettleSec";
        lblSettleSec.Size = new Size(81, 23);
        lblSettleSec.TabIndex = 2;
        lblSettleSec.Text = "Pre-wait (sec)";
        lblSettleSec.TextAlign = ContentAlignment.MiddleRight;
        lblSettleSec.Click += LblSettleSec_Click;
        // 
        // nudSettleSec
        // 
        nudSettleSec.Anchor = AnchorStyles.Left;
        nudSettleSec.DecimalPlaces = 1;
        nudSettleSec.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        nudSettleSec.Location = new Point(96, 65);
        nudSettleSec.Margin = new Padding(0, 4, 0, 0);
        nudSettleSec.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        nudSettleSec.Name = "nudSettleSec";
        nudSettleSec.Size = new Size(65, 23);
        nudSettleSec.TabIndex = 3;
        nudSettleSec.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // lblThrottleUs
        // 
        lblThrottleUs.Anchor = AnchorStyles.Right;
        lblThrottleUs.Location = new Point(22, 94);
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
        nudThrottleUs.Location = new Point(96, 96);
        nudThrottleUs.Margin = new Padding(0, 4, 0, 0);
        nudThrottleUs.Maximum = new decimal(new int[] { 1300, 0, 0, 0 });
        nudThrottleUs.Minimum = new decimal(new int[] { 1100, 0, 0, 0 });
        nudThrottleUs.Name = "nudThrottleUs";
        nudThrottleUs.Size = new Size(73, 23);
        nudThrottleUs.TabIndex = 7;
        nudThrottleUs.Value = new decimal(new int[] { 1150, 0, 0, 0 });
        // 
        // pnlRightStick
        // 
        pnlRightStick.BorderStyle = BorderStyle.FixedSingle;
        pnlRightStick.Controls.Add(pnlRightStickIndicator);
        pnlRightStick.Dock = DockStyle.Left;
        pnlRightStick.Location = new Point(162, 0);
        pnlRightStick.Name = "pnlRightStick";
        pnlRightStick.Size = new Size(162, 121);
        pnlRightStick.TabIndex = 1;
        // 
        // pnlRightStickIndicator
        // 
        pnlRightStickIndicator.Anchor = AnchorStyles.None;
        pnlRightStickIndicator.BackColor = Color.Blue;
        pnlRightStickIndicator.Location = new Point(76, 59);
        pnlRightStickIndicator.Name = "pnlRightStickIndicator";
        pnlRightStickIndicator.Size = new Size(10, 10);
        pnlRightStickIndicator.TabIndex = 0;
        // 
        // pnlLeftStick
        // 
        pnlLeftStick.BorderStyle = BorderStyle.FixedSingle;
        pnlLeftStick.Controls.Add(pnlLeftStickIndicator);
        pnlLeftStick.Dock = DockStyle.Left;
        pnlLeftStick.Location = new Point(0, 0);
        pnlLeftStick.Name = "pnlLeftStick";
        pnlLeftStick.Size = new Size(162, 121);
        pnlLeftStick.TabIndex = 0;
        // 
        // pnlLeftStickIndicator
        // 
        pnlLeftStickIndicator.Anchor = AnchorStyles.None;
        pnlLeftStickIndicator.BackColor = Color.Red;
        pnlLeftStickIndicator.Location = new Point(76, 59);
        pnlLeftStickIndicator.Name = "pnlLeftStickIndicator";
        pnlLeftStickIndicator.Size = new Size(10, 10);
        pnlLeftStickIndicator.TabIndex = 0;
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Left;
        button1.Location = new Point(608, 120);
        button1.Name = "button1";
        button1.Size = new Size(81, 32);
        button1.TabIndex = 0;
        button1.Text = "<-- Set";
        button1.TextAlign = ContentAlignment.MiddleLeft;
        button1.UseVisualStyleBackColor = true;
        // 
        // grpPidWorkflow
        // 
        grpPidWorkflow.Controls.Add(tblPidMatrix);
        grpPidWorkflow.Dock = DockStyle.Top;
        grpPidWorkflow.Location = new Point(13, 192);
        grpPidWorkflow.Name = "grpPidWorkflow";
        grpPidWorkflow.Padding = new Padding(10);
        grpPidWorkflow.Size = new Size(578, 171);
        grpPidWorkflow.TabIndex = 2;
        grpPidWorkflow.TabStop = false;
        grpPidWorkflow.Text = "PID";
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
        tblPidMatrix.Dock = DockStyle.Left;
        tblPidMatrix.Location = new Point(10, 26);
        tblPidMatrix.Name = "tblPidMatrix";
        tblPidMatrix.RowCount = 4;
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tblPidMatrix.Size = new Size(326, 135);
        tblPidMatrix.TabIndex = 0;
        // 
        // lblPidHdrP
        // 
        lblPidHdrP.Anchor = AnchorStyles.None;
        lblPidHdrP.AutoSize = true;
        lblPidHdrP.Location = new Point(61, 9);
        lblPidHdrP.Name = "lblPidHdrP";
        lblPidHdrP.Size = new Size(14, 15);
        lblPidHdrP.TabIndex = 0;
        lblPidHdrP.Text = "P";
        // 
        // lblPidHdrI
        // 
        lblPidHdrI.Anchor = AnchorStyles.None;
        lblPidHdrI.AutoSize = true;
        lblPidHdrI.Location = new Point(115, 9);
        lblPidHdrI.Name = "lblPidHdrI";
        lblPidHdrI.Size = new Size(10, 15);
        lblPidHdrI.TabIndex = 1;
        lblPidHdrI.Text = "I";
        // 
        // lblPidHdrD
        // 
        lblPidHdrD.Anchor = AnchorStyles.None;
        lblPidHdrD.AutoSize = true;
        lblPidHdrD.Location = new Point(166, 9);
        lblPidHdrD.Name = "lblPidHdrD";
        lblPidHdrD.Size = new Size(15, 15);
        lblPidHdrD.TabIndex = 2;
        lblPidHdrD.Text = "D";
        // 
        // lblPidHdrFf
        // 
        lblPidHdrFf.Anchor = AnchorStyles.None;
        lblPidHdrFf.AutoSize = true;
        lblPidHdrFf.Location = new Point(216, 9);
        lblPidHdrFf.Name = "lblPidHdrFf";
        lblPidHdrFf.Size = new Size(19, 15);
        lblPidHdrFf.TabIndex = 3;
        lblPidHdrFf.Text = "FF";
        // 
        // lblPidRowRoll
        // 
        lblPidRowRoll.Anchor = AnchorStyles.Left;
        lblPidRowRoll.AutoSize = true;
        lblPidRowRoll.Location = new Point(3, 42);
        lblPidRowRoll.Name = "lblPidRowRoll";
        lblPidRowRoll.Size = new Size(27, 15);
        lblPidRowRoll.TabIndex = 4;
        lblPidRowRoll.Text = "Roll";
        // 
        // lblPidRowPitch
        // 
        lblPidRowPitch.Anchor = AnchorStyles.Left;
        lblPidRowPitch.AutoSize = true;
        lblPidRowPitch.Location = new Point(3, 75);
        lblPidRowPitch.Name = "lblPidRowPitch";
        lblPidRowPitch.Size = new Size(34, 15);
        lblPidRowPitch.TabIndex = 5;
        lblPidRowPitch.Text = "Pitch";
        // 
        // lblPidRowYaw
        // 
        lblPidRowYaw.Anchor = AnchorStyles.Left;
        lblPidRowYaw.AutoSize = true;
        lblPidRowYaw.Location = new Point(3, 109);
        lblPidRowYaw.Name = "lblPidRowYaw";
        lblPidRowYaw.Size = new Size(28, 15);
        lblPidRowYaw.TabIndex = 6;
        lblPidRowYaw.Text = "Yaw";
        // 
        // txtRollP
        // 
        txtRollP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollP.Location = new Point(45, 38);
        txtRollP.Name = "txtRollP";
        txtRollP.ReadOnly = true;
        txtRollP.Size = new Size(46, 23);
        txtRollP.TabIndex = 7;
        txtRollP.Text = "0";
        // 
        // txtRollI
        // 
        txtRollI.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollI.Location = new Point(97, 38);
        txtRollI.Name = "txtRollI";
        txtRollI.ReadOnly = true;
        txtRollI.Size = new Size(47, 23);
        txtRollI.TabIndex = 8;
        txtRollI.Text = "0";
        // 
        // txtRollD
        // 
        txtRollD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollD.Location = new Point(150, 38);
        txtRollD.Name = "txtRollD";
        txtRollD.ReadOnly = true;
        txtRollD.Size = new Size(48, 23);
        txtRollD.TabIndex = 9;
        txtRollD.Text = "0";
        // 
        // txtRollFf
        // 
        txtRollFf.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtRollFf.Location = new Point(204, 38);
        txtRollFf.Name = "txtRollFf";
        txtRollFf.ReadOnly = true;
        txtRollFf.Size = new Size(44, 23);
        txtRollFf.TabIndex = 10;
        txtRollFf.Text = "0";
        // 
        // txtPitchP
        // 
        txtPitchP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchP.Location = new Point(45, 71);
        txtPitchP.Name = "txtPitchP";
        txtPitchP.ReadOnly = true;
        txtPitchP.Size = new Size(46, 23);
        txtPitchP.TabIndex = 11;
        txtPitchP.Text = "0";
        // 
        // txtPitchI
        // 
        txtPitchI.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchI.Location = new Point(97, 71);
        txtPitchI.Name = "txtPitchI";
        txtPitchI.ReadOnly = true;
        txtPitchI.Size = new Size(47, 23);
        txtPitchI.TabIndex = 12;
        txtPitchI.Text = "0";
        // 
        // txtPitchD
        // 
        txtPitchD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchD.Location = new Point(150, 71);
        txtPitchD.Name = "txtPitchD";
        txtPitchD.ReadOnly = true;
        txtPitchD.Size = new Size(48, 23);
        txtPitchD.TabIndex = 13;
        txtPitchD.Text = "0";
        // 
        // txtPitchFf
        // 
        txtPitchFf.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPitchFf.Location = new Point(204, 71);
        txtPitchFf.Name = "txtPitchFf";
        txtPitchFf.ReadOnly = true;
        txtPitchFf.Size = new Size(44, 23);
        txtPitchFf.TabIndex = 14;
        txtPitchFf.Text = "0";
        // 
        // txtYawP
        // 
        txtYawP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawP.Location = new Point(45, 105);
        txtYawP.Name = "txtYawP";
        txtYawP.ReadOnly = true;
        txtYawP.Size = new Size(46, 23);
        txtYawP.TabIndex = 15;
        txtYawP.Text = "0";
        // 
        // txtYawI
        // 
        txtYawI.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawI.Location = new Point(97, 105);
        txtYawI.Name = "txtYawI";
        txtYawI.ReadOnly = true;
        txtYawI.Size = new Size(47, 23);
        txtYawI.TabIndex = 16;
        txtYawI.Text = "0";
        // 
        // txtYawD
        // 
        txtYawD.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawD.Location = new Point(150, 105);
        txtYawD.Name = "txtYawD";
        txtYawD.ReadOnly = true;
        txtYawD.Size = new Size(48, 23);
        txtYawD.TabIndex = 17;
        txtYawD.Text = "0";
        // 
        // txtYawFf
        // 
        txtYawFf.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtYawFf.Location = new Point(204, 105);
        txtYawFf.Name = "txtYawFf";
        txtYawFf.ReadOnly = true;
        txtYawFf.Size = new Size(44, 23);
        txtYawFf.TabIndex = 18;
        txtYawFf.Text = "0";
        // 
        // btnReadFcPid
        // 
        btnReadFcPid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        btnReadFcPid.Location = new Point(254, 37);
        btnReadFcPid.Name = "btnReadFcPid";
        btnReadFcPid.Size = new Size(69, 25);
        btnReadFcPid.TabIndex = 19;
        btnReadFcPid.Text = "Read FC";
        btnReadFcPid.UseVisualStyleBackColor = true;
        btnReadFcPid.Click += btnReadFcPid_Click;
        // 
        // btnPidEditable
        // 
        btnPidEditable.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        btnPidEditable.Location = new Point(254, 70);
        btnPidEditable.Name = "btnPidEditable";
        btnPidEditable.Size = new Size(69, 25);
        btnPidEditable.TabIndex = 20;
        btnPidEditable.Text = "Editable";
        btnPidEditable.UseVisualStyleBackColor = true;
        btnPidEditable.Click += btnPidEditable_Click;
        // 
        // btnSaveFcPid
        // 
        btnSaveFcPid.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        btnSaveFcPid.Location = new Point(254, 104);
        btnSaveFcPid.Name = "btnSaveFcPid";
        btnSaveFcPid.Size = new Size(69, 25);
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
        pnlScoreChart.Location = new Point(13, 599);
        pnlScoreChart.Name = "pnlScoreChart";
        pnlScoreChart.Size = new Size(1541, 170);
        pnlScoreChart.TabIndex = 0;
        pnlScoreChart.Paint += pnlScoreChart_Paint;
        // 
        // grpLiveData
        // 
        grpLiveData.Controls.Add(tableLayoutPanel3);
        grpLiveData.Dock = DockStyle.Top;
        grpLiveData.Location = new Point(597, 192);
        grpLiveData.Name = "grpLiveData";
        grpLiveData.Size = new Size(252, 171);
        grpLiveData.TabIndex = 9;
        grpLiveData.TabStop = false;
        grpLiveData.Text = "Live";
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
        tableLayoutPanel3.Size = new Size(246, 77);
        tableLayoutPanel3.TabIndex = 8;
        // 
        // lblPitchAngle
        // 
        lblPitchAngle.Anchor = AnchorStyles.Left;
        lblPitchAngle.Location = new Point(92, 59);
        lblPitchAngle.Name = "lblPitchAngle";
        lblPitchAngle.Size = new Size(27, 15);
        lblPitchAngle.TabIndex = 7;
        lblPitchAngle.Text = "0.0°";
        // 
        // lblRollAngle
        // 
        lblRollAngle.Anchor = AnchorStyles.Left;
        lblRollAngle.Location = new Point(92, 40);
        lblRollAngle.Name = "lblRollAngle";
        lblRollAngle.Size = new Size(27, 15);
        lblRollAngle.TabIndex = 5;
        lblRollAngle.Text = "0.0°";
        // 
        // lblChannelValue
        // 
        lblChannelValue.Anchor = AnchorStyles.Left;
        lblChannelValue.Location = new Point(92, 21);
        lblChannelValue.Name = "lblChannelValue";
        lblChannelValue.Size = new Size(46, 15);
        lblChannelValue.TabIndex = 3;
        lblChannelValue.Text = "1500 us";
        // 
        // lblChannelVisual
        // 
        lblChannelVisual.Anchor = AnchorStyles.Left;
        lblChannelVisual.Location = new Point(92, 0);
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
        groupBox1.Controls.Add(tableLayoutPanel4);
        groupBox1.Dock = DockStyle.Top;
        groupBox1.Location = new Point(855, 192);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(699, 171);
        groupBox1.TabIndex = 10;
        groupBox1.TabStop = false;
        groupBox1.Text = "Tune PID";
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.ColumnCount = 1;
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel4.Controls.Add(button2, 0, 0);
        tableLayoutPanel4.Controls.Add(button3, 0, 1);
        tableLayoutPanel4.Controls.Add(button5, 0, 3);
        tableLayoutPanel4.Controls.Add(button4, 0, 2);
        tableLayoutPanel4.Dock = DockStyle.Left;
        tableLayoutPanel4.Location = new Point(3, 19);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 4;
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel4.Size = new Size(93, 149);
        tableLayoutPanel4.TabIndex = 8;
        // 
        // button2
        // 
        button2.AutoSize = true;
        button2.Location = new Point(3, 3);
        button2.Name = "button2";
        button2.Size = new Size(84, 26);
        button2.TabIndex = 4;
        button2.Text = "Test Roll";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.AutoSize = true;
        button3.Location = new Point(3, 40);
        button3.Name = "button3";
        button3.Size = new Size(84, 26);
        button3.TabIndex = 5;
        button3.Text = "Test Pitch";
        button3.UseVisualStyleBackColor = true;
        // 
        // button5
        // 
        button5.AutoSize = true;
        button5.Location = new Point(3, 114);
        button5.Name = "button5";
        button5.Size = new Size(84, 25);
        button5.TabIndex = 7;
        button5.Text = "Test Yaw";
        button5.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.AutoSize = true;
        button4.Location = new Point(3, 77);
        button4.Name = "button4";
        button4.Size = new Size(84, 26);
        button4.TabIndex = 6;
        button4.Text = "Test Throttle";
        button4.UseVisualStyleBackColor = true;
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
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1567, 782);
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
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        pnlSticks.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).EndInit();
        pnlRightStick.ResumeLayout(false);
        pnlLeftStick.ResumeLayout(false);
        grpPidWorkflow.ResumeLayout(false);
        tblPidMatrix.ResumeLayout(false);
        tblPidMatrix.PerformLayout();
        grpLiveData.ResumeLayout(false);
        tableLayoutPanel3.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        tableLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel4.PerformLayout();
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
    private GroupBox groupBox1;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private TableLayoutPanel tableLayoutPanel4;
}



