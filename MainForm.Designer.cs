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
        rootLayout = new Panel();
        grpPortingArea = new Panel();
        grpPidWorkflow = new GroupBox();
        pidWorkflowLayout = new Panel();
        pidButtonLayout = new Panel();
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
        grpTuningProgress = new GroupBox();
        tuningProgressLayout = new Panel();
        pnlScoreChart = new Panel();
        grpTelemetry = new GroupBox();
        telemetryLayout = new Panel();
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
        lvTuningRuns = new ListView();
        colRun = new ColumnHeader();
        colAxis = new ColumnHeader();
        colScore = new ColumnHeader();
        colDecision = new ColumnHeader();
        channelVisualLayout = new Panel();
        lblChannelVisualTitle = new Label();
        lblChannelVisual = new Label();
        lblChannelValueTitle = new Label();
        lblChannelValue = new Label();
        lblRollAngleTitle = new Label();
        lblRollAngle = new Label();
        lblPitchAngleTitle = new Label();
        lblPitchAngle = new Label();
        txtPidValues = new TextBox();
        txtPidRecommendation = new TextBox();
        topLayout = new Panel();
        grpUsb = new GroupBox();
        usbLayout = new Panel();
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
        btnArduinoConnect = new Button();
        btnArduinoDisconnect = new Button();
        lblFCStatus = new Label();
        grpMapping = new GroupBox();
        mappingLayout = new Panel();
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
        channelTestLayout = new Panel();
        channelActionLayout = new Panel();
        btnTestRoll = new Button();
        btnTestPitch = new Button();
        btnTestThrottle = new Button();
        channelInputsLayout = new Panel();
        lblTargetDeg = new Label();
        lblSettleSec = new Label();
        nudSettleSec = new NumericUpDown();
        lblBaselineSec = new Label();
        nudBaselineSec = new NumericUpDown();
        lblThrottleUs = new Label();
        nudThrottleUs = new NumericUpDown();
        nudTargetDeg = new NumericUpDown();
        pnlStatus = new Panel();
        panel1 = new Panel();
        rootLayout.SuspendLayout();
        grpPortingArea.SuspendLayout();
        grpPidWorkflow.SuspendLayout();
        pidWorkflowLayout.SuspendLayout();
        pidButtonLayout.SuspendLayout();
        grpTuningProgress.SuspendLayout();
        tuningProgressLayout.SuspendLayout();
        pnlScoreChart.SuspendLayout();
        telemetryLayout.SuspendLayout();
        telemetryButtonLayout.SuspendLayout();
        telemetryValueLayout.SuspendLayout();
        channelVisualLayout.SuspendLayout();
        topLayout.SuspendLayout();
        grpUsb.SuspendLayout();
        usbLayout.SuspendLayout();
        grpMapping.SuspendLayout();
        mappingLayout.SuspendLayout();
        grpChannelTest.SuspendLayout();
        channelTestLayout.SuspendLayout();
        channelActionLayout.SuspendLayout();
        channelInputsLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).BeginInit();
        SuspendLayout();
        // 
        // rootLayout
        // 
        rootLayout.Controls.Add(topLayout);
        rootLayout.Controls.Add(pidButtonLayout);
        rootLayout.Controls.Add(grpPortingArea);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.Padding = new Padding(10);
        rootLayout.Size = new Size(1389, 1077);
        rootLayout.TabIndex = 0;
        // 
        // grpPortingArea
        // 
        grpPortingArea.Anchor = AnchorStyles.None;
        grpPortingArea.Controls.Add(grpPidWorkflow);
        grpPortingArea.Controls.Add(grpTuningProgress);
        grpPortingArea.Location = new Point(13, 385);
        grpPortingArea.Name = "grpPortingArea";
        grpPortingArea.Padding = new Padding(10);
        grpPortingArea.Size = new Size(1363, 552);
        grpPortingArea.TabIndex = 1;
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
        pidWorkflowLayout.Controls.Add(lblActiveAxisTitle);
        pidWorkflowLayout.Controls.Add(lblActiveAxis);
        pidWorkflowLayout.Controls.Add(lblPidValuesTitle);
        pidWorkflowLayout.Location = new Point(10, 26);
        pidWorkflowLayout.Name = "pidWorkflowLayout";
        pidWorkflowLayout.Size = new Size(1222, 133);
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
        pidButtonLayout.Location = new Point(746, 262);
        pidButtonLayout.Name = "pidButtonLayout";
        pidButtonLayout.Size = new Size(509, 127);
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
        btnApplyRecommendedPid.Location = new Point(243, 73);
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
        // lblActiveAxisTitle
        // 
        lblActiveAxisTitle.Anchor = AnchorStyles.Left;
        lblActiveAxisTitle.Location = new Point(858, 21);
        lblActiveAxisTitle.Name = "lblActiveAxisTitle";
        lblActiveAxisTitle.Size = new Size(65, 15);
        lblActiveAxisTitle.TabIndex = 1;
        lblActiveAxisTitle.Text = "Active Axis";
        // 
        // lblActiveAxis
        // 
        lblActiveAxis.Anchor = AnchorStyles.Left;
        lblActiveAxis.Location = new Point(858, 58);
        lblActiveAxis.Name = "lblActiveAxis";
        lblActiveAxis.Size = new Size(29, 15);
        lblActiveAxis.TabIndex = 2;
        lblActiveAxis.Text = "N/A";
        // 
        // lblPidValuesTitle
        // 
        lblPidValuesTitle.Anchor = AnchorStyles.Left;
        lblPidValuesTitle.Location = new Point(858, 73);
        lblPidValuesTitle.Name = "lblPidValuesTitle";
        lblPidValuesTitle.Size = new Size(94, 15);
        lblPidValuesTitle.TabIndex = 4;
        lblPidValuesTitle.Text = "FC PID Snapshot";
        // 
        // grpTuningProgress
        // 
        grpTuningProgress.Controls.Add(tuningProgressLayout);
        grpTuningProgress.Dock = DockStyle.Fill;
        grpTuningProgress.Location = new Point(10, 10);
        grpTuningProgress.Name = "grpTuningProgress";
        grpTuningProgress.Padding = new Padding(10);
        grpTuningProgress.Size = new Size(1343, 532);
        grpTuningProgress.TabIndex = 3;
        grpTuningProgress.TabStop = false;
        grpTuningProgress.Text = "Tuning Progression Charts and Recommendations";
        // 
        // tuningProgressLayout
        // 
        tuningProgressLayout.Controls.Add(pnlScoreChart);
        tuningProgressLayout.Dock = DockStyle.Fill;
        tuningProgressLayout.Location = new Point(10, 26);
        tuningProgressLayout.Name = "tuningProgressLayout";
        tuningProgressLayout.Size = new Size(1323, 496);
        tuningProgressLayout.TabIndex = 0;
        // 
        // pnlScoreChart
        // 
        pnlScoreChart.Anchor = AnchorStyles.None;
        pnlScoreChart.BackColor = Color.White;
        pnlScoreChart.BorderStyle = BorderStyle.FixedSingle;
        pnlScoreChart.Controls.Add(grpTelemetry);
        pnlScoreChart.Controls.Add(telemetryLayout);
        pnlScoreChart.Controls.Add(lvTuningRuns);
        pnlScoreChart.Controls.Add(channelVisualLayout);
        pnlScoreChart.Controls.Add(txtPidValues);
        pnlScoreChart.Controls.Add(txtPidRecommendation);
        pnlScoreChart.Location = new Point(211, 3);
        pnlScoreChart.Name = "pnlScoreChart";
        pnlScoreChart.Size = new Size(892, 490);
        pnlScoreChart.TabIndex = 0;
        pnlScoreChart.Paint += pnlScoreChart_Paint;
        // 
        // grpTelemetry
        // 
        grpTelemetry.Anchor = AnchorStyles.None;
        grpTelemetry.Location = new Point(47, 155);
        grpTelemetry.Name = "grpTelemetry";
        grpTelemetry.Padding = new Padding(10);
        grpTelemetry.Size = new Size(385, 81);
        grpTelemetry.TabIndex = 1;
        grpTelemetry.TabStop = false;
        grpTelemetry.Text = "Telemetry";
        // 
        // telemetryLayout
        // 
        telemetryLayout.Controls.Add(telemetryButtonLayout);
        telemetryLayout.Controls.Add(telemetryValueLayout);
        telemetryLayout.Location = new Point(15, 440);
        telemetryLayout.Name = "telemetryLayout";
        telemetryLayout.Size = new Size(269, 105);
        telemetryLayout.TabIndex = 0;
        // 
        // telemetryButtonLayout
        // 
        telemetryButtonLayout.Controls.Add(btnTelemetryStart);
        telemetryButtonLayout.Controls.Add(btnTelemetryStop);
        telemetryButtonLayout.Controls.Add(btnTelemetrySnapshot);
        telemetryButtonLayout.Location = new Point(3, 3);
        telemetryButtonLayout.Name = "telemetryButtonLayout";
        telemetryButtonLayout.Size = new Size(263, 24);
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
        btnTelemetrySnapshot.Location = new Point(3, 38);
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
        telemetryValueLayout.Location = new Point(3, 33);
        telemetryValueLayout.Name = "telemetryValueLayout";
        telemetryValueLayout.Size = new Size(263, 58);
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
        // lvTuningRuns
        // 
        lvTuningRuns.Anchor = AnchorStyles.None;
        lvTuningRuns.Columns.AddRange(new ColumnHeader[] { colRun, colAxis, colScore, colDecision });
        lvTuningRuns.FullRowSelect = true;
        lvTuningRuns.Location = new Point(59, 260);
        lvTuningRuns.Name = "lvTuningRuns";
        lvTuningRuns.Size = new Size(294, 99);
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
        // channelVisualLayout
        // 
        channelVisualLayout.Anchor = AnchorStyles.None;
        channelVisualLayout.Controls.Add(lblChannelVisualTitle);
        channelVisualLayout.Controls.Add(lblChannelVisual);
        channelVisualLayout.Controls.Add(lblChannelValueTitle);
        channelVisualLayout.Controls.Add(lblChannelValue);
        channelVisualLayout.Controls.Add(lblRollAngleTitle);
        channelVisualLayout.Controls.Add(lblRollAngle);
        channelVisualLayout.Controls.Add(lblPitchAngleTitle);
        channelVisualLayout.Controls.Add(lblPitchAngle);
        channelVisualLayout.Location = new Point(385, 324);
        channelVisualLayout.Name = "channelVisualLayout";
        channelVisualLayout.Size = new Size(416, 69);
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
        lblChannelVisual.Location = new Point(72, 42);
        lblChannelVisual.Name = "lblChannelVisual";
        lblChannelVisual.Size = new Size(26, 15);
        lblChannelVisual.TabIndex = 1;
        lblChannelVisual.Text = "Idle";
        // 
        // lblChannelValueTitle
        // 
        lblChannelValueTitle.Anchor = AnchorStyles.Left;
        lblChannelValueTitle.Location = new Point(190, 42);
        lblChannelValueTitle.Name = "lblChannelValueTitle";
        lblChannelValueTitle.Size = new Size(38, 15);
        lblChannelValueTitle.TabIndex = 2;
        lblChannelValueTitle.Text = "Pulse:";
        // 
        // lblChannelValue
        // 
        lblChannelValue.Anchor = AnchorStyles.Left;
        lblChannelValue.Location = new Point(259, 42);
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
        // txtPidValues
        // 
        txtPidValues.Anchor = AnchorStyles.None;
        txtPidValues.Location = new Point(388, 251);
        txtPidValues.Multiline = true;
        txtPidValues.Name = "txtPidValues";
        txtPidValues.ReadOnly = true;
        txtPidValues.Size = new Size(361, 60);
        txtPidValues.TabIndex = 5;
        txtPidValues.Text = "Roll P/I/D: --/--/--\r\nPitch P/I/D: --/--/--";
        // 
        // txtPidRecommendation
        // 
        txtPidRecommendation.Anchor = AnchorStyles.None;
        txtPidRecommendation.Location = new Point(347, 422);
        txtPidRecommendation.Multiline = true;
        txtPidRecommendation.Name = "txtPidRecommendation";
        txtPidRecommendation.ReadOnly = true;
        txtPidRecommendation.Size = new Size(454, 90);
        txtPidRecommendation.TabIndex = 3;
        txtPidRecommendation.Text = "Run Roll or Pitch to generate a recommendation.";
        // 
        // topLayout
        // 
        topLayout.Controls.Add(grpUsb);
        topLayout.Controls.Add(grpMapping);
        topLayout.Controls.Add(grpChannelTest);
        topLayout.Location = new Point(13, 13);
        topLayout.Name = "topLayout";
        topLayout.Size = new Size(1363, 149);
        topLayout.TabIndex = 0;
        // 
        // grpUsb
        // 
        grpUsb.Controls.Add(usbLayout);
        grpUsb.Location = new Point(3, 3);
        grpUsb.Name = "grpUsb";
        grpUsb.Padding = new Padding(10);
        grpUsb.Size = new Size(534, 234);
        grpUsb.TabIndex = 0;
        grpUsb.TabStop = false;
        grpUsb.Text = "Serial Ports";
        // 
        // usbLayout
        // 
        usbLayout.Controls.Add(lblPort);
        usbLayout.Controls.Add(lblArduinoStatus);
        usbLayout.Controls.Add(cboPort);
        usbLayout.Controls.Add(cboBaud);
        usbLayout.Controls.Add(btnFcConnect);
        usbLayout.Controls.Add(btnFcDisconnect);
        usbLayout.Controls.Add(btnRefreshPorts);
        usbLayout.Controls.Add(lblArduinoPort);
        usbLayout.Controls.Add(cboArduinoPort);
        usbLayout.Controls.Add(cboArduinoBaud);
        usbLayout.Controls.Add(btnArduinoConnect);
        usbLayout.Controls.Add(btnArduinoDisconnect);
        usbLayout.Controls.Add(lblFCStatus);
        usbLayout.Location = new Point(10, 26);
        usbLayout.Name = "usbLayout";
        usbLayout.Size = new Size(516, 115);
        usbLayout.TabIndex = 0;
        // 
        // lblPort
        // 
        lblPort.Anchor = AnchorStyles.Left;
        lblPort.Location = new Point(3, 14);
        lblPort.Name = "lblPort";
        lblPort.Size = new Size(45, 15);
        lblPort.TabIndex = 0;
        lblPort.Text = "FC USB";
        // 
        // lblArduinoStatus
        // 
        lblArduinoStatus.Location = new Point(273, 76);
        lblArduinoStatus.Margin = new Padding(3, 3, 3, 0);
        lblArduinoStatus.Name = "lblArduinoStatus";
        lblArduinoStatus.Size = new Size(244, 24);
        lblArduinoStatus.TabIndex = 14;
        lblArduinoStatus.Text = "Waiting...";
        lblArduinoStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // cboPort
        // 
        cboPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPort.FormattingEnabled = true;
        cboPort.Location = new Point(89, 3);
        cboPort.Name = "cboPort";
        cboPort.Size = new Size(62, 23);
        cboPort.TabIndex = 1;
        // 
        // cboBaud
        // 
        cboBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboBaud.FormattingEnabled = true;
        cboBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboBaud.Location = new Point(175, 3);
        cboBaud.Name = "cboBaud";
        cboBaud.Size = new Size(69, 23);
        cboBaud.TabIndex = 2;
        // 
        // btnFcConnect
        // 
        btnFcConnect.Location = new Point(261, 3);
        btnFcConnect.Name = "btnFcConnect";
        btnFcConnect.Size = new Size(79, 24);
        btnFcConnect.TabIndex = 3;
        btnFcConnect.Text = "Connect";
        btnFcConnect.UseVisualStyleBackColor = true;
        btnFcConnect.Click += btnConnect_Click;
        // 
        // btnFcDisconnect
        // 
        btnFcDisconnect.Location = new Point(347, 3);
        btnFcDisconnect.Name = "btnFcDisconnect";
        btnFcDisconnect.Size = new Size(80, 24);
        btnFcDisconnect.TabIndex = 4;
        btnFcDisconnect.Text = "Disconnect";
        btnFcDisconnect.UseVisualStyleBackColor = true;
        btnFcDisconnect.Click += btnDisconnect_Click;
        // 
        // btnRefreshPorts
        // 
        btnRefreshPorts.ImageAlign = ContentAlignment.MiddleLeft;
        btnRefreshPorts.Location = new Point(433, 3);
        btnRefreshPorts.Name = "btnRefreshPorts";
        btnRefreshPorts.Size = new Size(80, 24);
        btnRefreshPorts.TabIndex = 5;
        btnRefreshPorts.Text = "Refresh Ports";
        btnRefreshPorts.UseVisualStyleBackColor = true;
        btnRefreshPorts.Click += btnRefreshPorts_Click;
        // 
        // lblArduinoPort
        // 
        lblArduinoPort.Anchor = AnchorStyles.Left;
        lblArduinoPort.Location = new Point(3, 54);
        lblArduinoPort.Name = "lblArduinoPort";
        lblArduinoPort.Size = new Size(50, 15);
        lblArduinoPort.TabIndex = 7;
        lblArduinoPort.Text = "Arduino";
        // 
        // cboArduinoPort
        // 
        cboArduinoPort.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoPort.FormattingEnabled = true;
        cboArduinoPort.Location = new Point(89, 43);
        cboArduinoPort.Name = "cboArduinoPort";
        cboArduinoPort.Size = new Size(62, 23);
        cboArduinoPort.TabIndex = 8;
        // 
        // cboArduinoBaud
        // 
        cboArduinoBaud.DropDownStyle = ComboBoxStyle.DropDownList;
        cboArduinoBaud.FormattingEnabled = true;
        cboArduinoBaud.Items.AddRange(new object[] { "9600", "115200" });
        cboArduinoBaud.Location = new Point(175, 43);
        cboArduinoBaud.Name = "cboArduinoBaud";
        cboArduinoBaud.Size = new Size(69, 23);
        cboArduinoBaud.TabIndex = 9;
        // 
        // btnArduinoConnect
        // 
        btnArduinoConnect.Location = new Point(261, 43);
        btnArduinoConnect.Name = "btnArduinoConnect";
        btnArduinoConnect.Size = new Size(79, 24);
        btnArduinoConnect.TabIndex = 10;
        btnArduinoConnect.Text = "Connect";
        btnArduinoConnect.UseVisualStyleBackColor = true;
        btnArduinoConnect.Click += btnArduinoConnect_Click;
        // 
        // btnArduinoDisconnect
        // 
        btnArduinoDisconnect.Location = new Point(347, 43);
        btnArduinoDisconnect.Name = "btnArduinoDisconnect";
        btnArduinoDisconnect.Size = new Size(80, 24);
        btnArduinoDisconnect.TabIndex = 11;
        btnArduinoDisconnect.Text = "Disconnect";
        btnArduinoDisconnect.UseVisualStyleBackColor = true;
        btnArduinoDisconnect.Click += btnArduinoDisconnect_Click;
        // 
        // lblFCStatus
        // 
        lblFCStatus.Anchor = AnchorStyles.None;
        lblFCStatus.Location = new Point(3, 78);
        lblFCStatus.Margin = new Padding(3, 3, 3, 0);
        lblFCStatus.Name = "lblFCStatus";
        lblFCStatus.Size = new Size(244, 24);
        lblFCStatus.TabIndex = 13;
        lblFCStatus.Text = "Waiting...";
        lblFCStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // grpMapping
        // 
        grpMapping.Controls.Add(mappingLayout);
        grpMapping.Location = new Point(543, 3);
        grpMapping.Name = "grpMapping";
        grpMapping.Padding = new Padding(10);
        grpMapping.Size = new Size(202, 234);
        grpMapping.TabIndex = 1;
        grpMapping.TabStop = false;
        grpMapping.Text = "Transmitter Channel Mapping";
        // 
        // mappingLayout
        // 
        mappingLayout.Controls.Add(lblRoll);
        mappingLayout.Controls.Add(cboCH1);
        mappingLayout.Controls.Add(lblPitch);
        mappingLayout.Controls.Add(cboCH2);
        mappingLayout.Controls.Add(lblThrottle);
        mappingLayout.Controls.Add(cboCH3);
        mappingLayout.Controls.Add(lblCh4);
        mappingLayout.Controls.Add(cboCH4);
        mappingLayout.Controls.Add(btnApplyMapping);
        mappingLayout.Controls.Add(btnPresetAetr);
        mappingLayout.Controls.Add(btnPresetRtae);
        mappingLayout.Controls.Add(btnPresetReat);
        mappingLayout.Location = new Point(10, 26);
        mappingLayout.Name = "mappingLayout";
        mappingLayout.Size = new Size(184, 115);
        mappingLayout.TabIndex = 0;
        // 
        // lblRoll
        // 
        lblRoll.Anchor = AnchorStyles.Left;
        lblRoll.Location = new Point(3, 6);
        lblRoll.Name = "lblRoll";
        lblRoll.Size = new Size(31, 15);
        lblRoll.TabIndex = 0;
        lblRoll.Text = "Ch 1";
        // 
        // cboCH1
        // 
        cboCH1.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH1.FormattingEnabled = true;
        cboCH1.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH1.Location = new Point(47, 3);
        cboCH1.Name = "cboCH1";
        cboCH1.Size = new Size(39, 23);
        cboCH1.TabIndex = 1;
        // 
        // lblPitch
        // 
        lblPitch.Anchor = AnchorStyles.Left;
        lblPitch.Location = new Point(3, 34);
        lblPitch.Name = "lblPitch";
        lblPitch.Size = new Size(31, 15);
        lblPitch.TabIndex = 2;
        lblPitch.Text = "Ch 2";
        // 
        // cboCH2
        // 
        cboCH2.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH2.FormattingEnabled = true;
        cboCH2.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH2.Location = new Point(47, 31);
        cboCH2.Name = "cboCH2";
        cboCH2.Size = new Size(39, 23);
        cboCH2.TabIndex = 3;
        // 
        // lblThrottle
        // 
        lblThrottle.Anchor = AnchorStyles.Left;
        lblThrottle.Location = new Point(3, 62);
        lblThrottle.Name = "lblThrottle";
        lblThrottle.Size = new Size(31, 15);
        lblThrottle.TabIndex = 4;
        lblThrottle.Text = "Ch 3";
        // 
        // cboCH3
        // 
        cboCH3.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH3.FormattingEnabled = true;
        cboCH3.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH3.Location = new Point(47, 59);
        cboCH3.Name = "cboCH3";
        cboCH3.Size = new Size(39, 23);
        cboCH3.TabIndex = 5;
        // 
        // lblCh4
        // 
        lblCh4.Anchor = AnchorStyles.Left;
        lblCh4.Location = new Point(3, 94);
        lblCh4.Name = "lblCh4";
        lblCh4.Size = new Size(31, 15);
        lblCh4.TabIndex = 7;
        lblCh4.Text = "Ch 4";
        // 
        // cboCH4
        // 
        cboCH4.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCH4.FormattingEnabled = true;
        cboCH4.Items.AddRange(new object[] { "A", "E", "T", "R" });
        cboCH4.Location = new Point(47, 87);
        cboCH4.Name = "cboCH4";
        cboCH4.Size = new Size(39, 23);
        cboCH4.TabIndex = 8;
        // 
        // btnApplyMapping
        // 
        btnApplyMapping.Location = new Point(99, 3);
        btnApplyMapping.Name = "btnApplyMapping";
        btnApplyMapping.Size = new Size(75, 22);
        btnApplyMapping.TabIndex = 6;
        btnApplyMapping.Text = "Apply";
        btnApplyMapping.UseVisualStyleBackColor = true;
        btnApplyMapping.Click += btnApplyMapping_Click;
        // 
        // btnPresetAetr
        // 
        btnPresetAetr.Location = new Point(99, 31);
        btnPresetAetr.Name = "btnPresetAetr";
        btnPresetAetr.Size = new Size(75, 22);
        btnPresetAetr.TabIndex = 9;
        btnPresetAetr.Text = "AETR";
        btnPresetAetr.UseVisualStyleBackColor = true;
        btnPresetAetr.Click += btnPresetAetr_Click;
        // 
        // btnPresetRtae
        // 
        btnPresetRtae.Location = new Point(99, 59);
        btnPresetRtae.Name = "btnPresetRtae";
        btnPresetRtae.Size = new Size(75, 22);
        btnPresetRtae.TabIndex = 10;
        btnPresetRtae.Text = "RTAE";
        btnPresetRtae.UseVisualStyleBackColor = true;
        btnPresetRtae.Click += btnPresetRtae_Click;
        // 
        // btnPresetReat
        // 
        btnPresetReat.Location = new Point(99, 87);
        btnPresetReat.Name = "btnPresetReat";
        btnPresetReat.Size = new Size(75, 24);
        btnPresetReat.TabIndex = 11;
        btnPresetReat.Text = "REAT";
        btnPresetReat.UseVisualStyleBackColor = true;
        btnPresetReat.Click += btnPresetReat_Click;
        // 
        // grpChannelTest
        // 
        grpChannelTest.Controls.Add(channelTestLayout);
        grpChannelTest.Location = new Point(771, 3);
        grpChannelTest.Name = "grpChannelTest";
        grpChannelTest.Padding = new Padding(10);
        grpChannelTest.Size = new Size(592, 234);
        grpChannelTest.TabIndex = 0;
        grpChannelTest.TabStop = false;
        grpChannelTest.Text = "Channel Test";
        // 
        // channelTestLayout
        // 
        channelTestLayout.Controls.Add(channelActionLayout);
        channelTestLayout.Controls.Add(channelInputsLayout);
        channelTestLayout.Location = new Point(13, 26);
        channelTestLayout.Name = "channelTestLayout";
        channelTestLayout.Size = new Size(572, 208);
        channelTestLayout.TabIndex = 0;
        // 
        // channelActionLayout
        // 
        channelActionLayout.Controls.Add(btnTestRoll);
        channelActionLayout.Controls.Add(btnTestPitch);
        channelActionLayout.Controls.Add(btnTestThrottle);
        channelActionLayout.Location = new Point(3, 3);
        channelActionLayout.Name = "channelActionLayout";
        channelActionLayout.Size = new Size(96, 112);
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
        btnTestPitch.Location = new Point(3, 38);
        btnTestPitch.Name = "btnTestPitch";
        btnTestPitch.Size = new Size(90, 29);
        btnTestPitch.TabIndex = 1;
        btnTestPitch.Text = "Pitch";
        btnTestPitch.UseVisualStyleBackColor = true;
        btnTestPitch.Click += btnTestPitch_Click;
        // 
        // btnTestThrottle
        // 
        btnTestThrottle.Location = new Point(3, 73);
        btnTestThrottle.Name = "btnTestThrottle";
        btnTestThrottle.Size = new Size(90, 29);
        btnTestThrottle.TabIndex = 2;
        btnTestThrottle.Text = "Throttle";
        btnTestThrottle.UseVisualStyleBackColor = true;
        btnTestThrottle.Click += btnTestThrottle_Click;
        // 
        // channelInputsLayout
        // 
        channelInputsLayout.Anchor = AnchorStyles.None;
        channelInputsLayout.Controls.Add(lblTargetDeg);
        channelInputsLayout.Controls.Add(lblSettleSec);
        channelInputsLayout.Controls.Add(nudSettleSec);
        channelInputsLayout.Controls.Add(lblBaselineSec);
        channelInputsLayout.Controls.Add(nudBaselineSec);
        channelInputsLayout.Controls.Add(lblThrottleUs);
        channelInputsLayout.Controls.Add(nudThrottleUs);
        channelInputsLayout.Controls.Add(nudTargetDeg);
        channelInputsLayout.Location = new Point(3, 209);
        channelInputsLayout.Name = "channelInputsLayout";
        channelInputsLayout.Size = new Size(566, 41);
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
        ClientSize = new Size(1389, 1077);
        Controls.Add(rootLayout);
        MinimumSize = new Size(900, 560);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Drone PID Tuning Assistant (WinForms)";
        rootLayout.ResumeLayout(false);
        grpPortingArea.ResumeLayout(false);
        grpPidWorkflow.ResumeLayout(false);
        pidWorkflowLayout.ResumeLayout(false);
        pidButtonLayout.ResumeLayout(false);
        grpTuningProgress.ResumeLayout(false);
        tuningProgressLayout.ResumeLayout(false);
        pnlScoreChart.ResumeLayout(false);
        pnlScoreChart.PerformLayout();
        telemetryLayout.ResumeLayout(false);
        telemetryButtonLayout.ResumeLayout(false);
        telemetryValueLayout.ResumeLayout(false);
        channelVisualLayout.ResumeLayout(false);
        topLayout.ResumeLayout(false);
        grpUsb.ResumeLayout(false);
        usbLayout.ResumeLayout(false);
        grpMapping.ResumeLayout(false);
        mappingLayout.ResumeLayout(false);
        grpChannelTest.ResumeLayout(false);
        channelTestLayout.ResumeLayout(false);
        channelActionLayout.ResumeLayout(false);
        channelInputsLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)nudSettleSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBaselineSec).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudThrottleUs).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTargetDeg).EndInit();
        ResumeLayout(false);
    }

    private Panel rootLayout;
    private Panel topLayout;
    private GroupBox grpUsb;
    private Panel usbLayout;
    private Label lblPort;
    private ComboBox cboPort;
    private ComboBox cboBaud;
    private Button btnFcConnect;
    private Button btnFcDisconnect;
    private Label lblArduinoPort;
    private ComboBox cboArduinoPort;
    private ComboBox cboArduinoBaud;
    private Button btnArduinoConnect;
    private Button btnArduinoDisconnect;
    private Button btnRefreshPorts;
    private GroupBox grpMapping;
    private Panel mappingLayout;
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
    private Panel grpPortingArea;
    private GroupBox grpChannelTest;
    private GroupBox grpTelemetry;
    private GroupBox grpPidWorkflow;
    private GroupBox grpTuningProgress;
    private Panel pidWorkflowLayout;
    private Panel pidButtonLayout;
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
    private Panel tuningProgressLayout;
    private Panel pnlScoreChart;
    private ListView lvTuningRuns;
    private ColumnHeader colRun;
    private ColumnHeader colAxis;
    private ColumnHeader colScore;
    private ColumnHeader colDecision;
    private Panel telemetryLayout;
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
    private Panel pnlStatus;
    private Label lblFCStatus;
    private Label lblArduinoStatus;
    private Panel panel1;
    private Panel channelTestLayout;
    private Panel channelActionLayout;
    private Button btnTestRoll;
    private Button btnTestPitch;
    private Button btnTestThrottle;
    private Panel channelInputsLayout;
    private Label lblTargetDeg;
    private Label lblSettleSec;
    private NumericUpDown nudSettleSec;
    private Label lblBaselineSec;
    private NumericUpDown nudBaselineSec;
    private Label lblThrottleUs;
    private NumericUpDown nudThrottleUs;
    private NumericUpDown nudTargetDeg;
}



