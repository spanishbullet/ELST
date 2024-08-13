namespace ELST
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openLogToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            analyzeToolStripMenuItem = new ToolStripMenuItem();
            recordNumbersToolStripMenuItem = new ToolStripMenuItem();
            timeCToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            resetCellsToolStripMenuItem1 = new ToolStripMenuItem();
            resetTimeToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            devicesToolStripMenuItem = new ToolStripMenuItem();
            adjustToolStripMenuItem = new ToolStripMenuItem();
            timeframeToolStripMenuItem = new ToolStripMenuItem();
            dirTreeView = new TreeView();
            dgvEvents = new DataGridView();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            timeframeStatusStrip = new StatusStrip();
            timeframeTSSLabel = new ToolStripStatusLabel();
            timeControlGB = new GroupBox();
            cancelTimeFrameButton = new Button();
            applyTimeFrameButton = new Button();
            endDTP = new DateTimePicker();
            endTimeLabel = new Label();
            startTimeLabel = new Label();
            startDTP = new DateTimePicker();
            pathStatusStrip = new StatusStrip();
            PathTSSLabel = new ToolStripStatusLabel();
            ActualPathTSSLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            timeframeStatusStrip.SuspendLayout();
            timeControlGB.SuspendLayout();
            pathStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, analyzeToolStripMenuItem, resetToolStripMenuItem, viewToolStripMenuItem, adjustToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(1064, 26);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openLogToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openLogToolStripMenuItem
            // 
            openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            openLogToolStripMenuItem.Size = new Size(157, 26);
            openLogToolStripMenuItem.Text = "&Open Log";
            openLogToolStripMenuItem.Click += openLogToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(157, 26);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { infoToolStripMenuItem, aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(55, 24);
            aboutToolStripMenuItem.Text = "&Help";
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(133, 26);
            infoToolStripMenuItem.Text = "&Help";
            infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(133, 26);
            aboutToolStripMenuItem1.Text = "&About";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // analyzeToolStripMenuItem
            // 
            analyzeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { recordNumbersToolStripMenuItem, timeCToolStripMenuItem });
            analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            analyzeToolStripMenuItem.Size = new Size(75, 24);
            analyzeToolStripMenuItem.Text = "&Analyze";
            // 
            // recordNumbersToolStripMenuItem
            // 
            recordNumbersToolStripMenuItem.Name = "recordNumbersToolStripMenuItem";
            recordNumbersToolStripMenuItem.Size = new Size(203, 26);
            recordNumbersToolStripMenuItem.Text = "&Record Numbers";
            recordNumbersToolStripMenuItem.Click += recordNumbersToolStripMenuItem_Click;
            // 
            // timeCToolStripMenuItem
            // 
            timeCToolStripMenuItem.Name = "timeCToolStripMenuItem";
            timeCToolStripMenuItem.Size = new Size(203, 26);
            timeCToolStripMenuItem.Text = "&Time Change";
            timeCToolStripMenuItem.Click += timeCToolStripMenuItem_Click;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetCellsToolStripMenuItem1, resetTimeToolStripMenuItem });
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(59, 24);
            resetToolStripMenuItem.Text = "&Reset";
            // 
            // resetCellsToolStripMenuItem1
            // 
            resetCellsToolStripMenuItem1.Name = "resetCellsToolStripMenuItem1";
            resetCellsToolStripMenuItem1.Size = new Size(204, 26);
            resetCellsToolStripMenuItem1.Text = "Reset &Cells";
            resetCellsToolStripMenuItem1.Click += resetToolStripMenuItem1_Click;
            // 
            // resetTimeToolStripMenuItem
            // 
            resetTimeToolStripMenuItem.Name = "resetTimeToolStripMenuItem";
            resetTimeToolStripMenuItem.Size = new Size(204, 26);
            resetTimeToolStripMenuItem.Text = "Reset &Timeframe";
            resetTimeToolStripMenuItem.Click += resetTimeToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { devicesToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 24);
            viewToolStripMenuItem.Text = "&View";
            // 
            // devicesToolStripMenuItem
            // 
            devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            devicesToolStripMenuItem.Size = new Size(143, 26);
            devicesToolStripMenuItem.Text = "&Devices";
            devicesToolStripMenuItem.Click += devicesToolStripMenuItem_Click;
            // 
            // adjustToolStripMenuItem
            // 
            adjustToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { timeframeToolStripMenuItem });
            adjustToolStripMenuItem.Name = "adjustToolStripMenuItem";
            adjustToolStripMenuItem.Size = new Size(65, 24);
            adjustToolStripMenuItem.Text = "A&djust";
            // 
            // timeframeToolStripMenuItem
            // 
            timeframeToolStripMenuItem.Name = "timeframeToolStripMenuItem";
            timeframeToolStripMenuItem.Size = new Size(164, 26);
            timeframeToolStripMenuItem.Text = "&Timeframe";
            timeframeToolStripMenuItem.Click += timeframeToolStripMenuItem_Click;
            // 
            // dirTreeView
            // 
            dirTreeView.Dock = DockStyle.Fill;
            dirTreeView.Location = new Point(0, 0);
            dirTreeView.Margin = new Padding(2);
            dirTreeView.Name = "dirTreeView";
            dirTreeView.Size = new Size(227, 609);
            dirTreeView.TabIndex = 1;
            dirTreeView.NodeMouseDoubleClick += DirTreeViewNode_DoubleClick;
            // 
            // dgvEvents
            // 
            dgvEvents.AllowUserToOrderColumns = true;
            dgvEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEvents.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEvents.Location = new Point(0, 0);
            dgvEvents.Name = "dgvEvents";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvEvents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvEvents.RowHeadersWidth = 51;
            dgvEvents.Size = new Size(833, 554);
            dgvEvents.TabIndex = 0;
            dgvEvents.MouseClick += dgvEvents_MouseClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(1064, 609);
            panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dirTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(timeframeStatusStrip);
            splitContainer1.Panel2.Controls.Add(timeControlGB);
            splitContainer1.Panel2.Controls.Add(pathStatusStrip);
            splitContainer1.Panel2.Controls.Add(dgvEvents);
            splitContainer1.Size = new Size(1064, 609);
            splitContainer1.SplitterDistance = 227;
            splitContainer1.TabIndex = 0;
            // 
            // timeframeStatusStrip
            // 
            timeframeStatusStrip.ImageScalingSize = new Size(20, 20);
            timeframeStatusStrip.Items.AddRange(new ToolStripItem[] { timeframeTSSLabel });
            timeframeStatusStrip.Location = new Point(0, 557);
            timeframeStatusStrip.Name = "timeframeStatusStrip";
            timeframeStatusStrip.Size = new Size(833, 26);
            timeframeStatusStrip.TabIndex = 3;
            timeframeStatusStrip.Text = "statusStrip2";
            // 
            // timeframeTSSLabel
            // 
            timeframeTSSLabel.Name = "timeframeTSSLabel";
            timeframeTSSLabel.Size = new Size(124, 20);
            timeframeTSSLabel.Text = "Timeframe: None";
            // 
            // timeControlGB
            // 
            timeControlGB.BackColor = SystemColors.Control;
            timeControlGB.Controls.Add(cancelTimeFrameButton);
            timeControlGB.Controls.Add(applyTimeFrameButton);
            timeControlGB.Controls.Add(endDTP);
            timeControlGB.Controls.Add(endTimeLabel);
            timeControlGB.Controls.Add(startTimeLabel);
            timeControlGB.Controls.Add(startDTP);
            timeControlGB.Location = new Point(452, 3);
            timeControlGB.Name = "timeControlGB";
            timeControlGB.Size = new Size(378, 205);
            timeControlGB.TabIndex = 2;
            timeControlGB.TabStop = false;
            timeControlGB.Text = "Adjust Timeframe";
            timeControlGB.Visible = false;
            // 
            // cancelTimeFrameButton
            // 
            cancelTimeFrameButton.Location = new Point(248, 158);
            cancelTimeFrameButton.Name = "cancelTimeFrameButton";
            cancelTimeFrameButton.Size = new Size(94, 29);
            cancelTimeFrameButton.TabIndex = 5;
            cancelTimeFrameButton.Text = "Cancel";
            cancelTimeFrameButton.UseVisualStyleBackColor = true;
            cancelTimeFrameButton.Click += cancelTimeFrameButton_Click;
            // 
            // applyTimeFrameButton
            // 
            applyTimeFrameButton.Location = new Point(92, 158);
            applyTimeFrameButton.Name = "applyTimeFrameButton";
            applyTimeFrameButton.Size = new Size(94, 29);
            applyTimeFrameButton.TabIndex = 4;
            applyTimeFrameButton.Text = "Apply";
            applyTimeFrameButton.UseVisualStyleBackColor = true;
            applyTimeFrameButton.Click += applyTimeFrameButton_Click;
            // 
            // endDTP
            // 
            endDTP.Format = DateTimePickerFormat.Custom;
            endDTP.Location = new Point(92, 102);
            endDTP.Name = "endDTP";
            endDTP.Size = new Size(250, 27);
            endDTP.TabIndex = 3;
            // 
            // endTimeLabel
            // 
            endTimeLabel.AutoSize = true;
            endTimeLabel.Location = new Point(17, 107);
            endTimeLabel.Name = "endTimeLabel";
            endTimeLabel.Size = new Size(34, 20);
            endTimeLabel.TabIndex = 2;
            endTimeLabel.Text = "End";
            // 
            // startTimeLabel
            // 
            startTimeLabel.AutoSize = true;
            startTimeLabel.Location = new Point(17, 56);
            startTimeLabel.Name = "startTimeLabel";
            startTimeLabel.Size = new Size(40, 20);
            startTimeLabel.TabIndex = 1;
            startTimeLabel.Text = "Start";
            // 
            // startDTP
            // 
            startDTP.Format = DateTimePickerFormat.Custom;
            startDTP.Location = new Point(92, 51);
            startDTP.Name = "startDTP";
            startDTP.Size = new Size(250, 27);
            startDTP.TabIndex = 0;
            // 
            // pathStatusStrip
            // 
            pathStatusStrip.ImageScalingSize = new Size(20, 20);
            pathStatusStrip.Items.AddRange(new ToolStripItem[] { PathTSSLabel, ActualPathTSSLabel });
            pathStatusStrip.Location = new Point(0, 583);
            pathStatusStrip.Name = "pathStatusStrip";
            pathStatusStrip.Size = new Size(833, 26);
            pathStatusStrip.TabIndex = 1;
            pathStatusStrip.Text = "statusStrip1";
            // 
            // PathTSSLabel
            // 
            PathTSSLabel.Name = "PathTSSLabel";
            PathTSSLabel.Size = new Size(92, 20);
            PathTSSLabel.Text = "Current Path:";
            // 
            // ActualPathTSSLabel
            // 
            ActualPathTSSLabel.Name = "ActualPathTSSLabel";
            ActualPathTSSLabel.Size = new Size(39, 20);
            ActualPathTSSLabel.Text = "path";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 635);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            Name = "MainMenu";
            Text = "ELST Main Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            timeframeStatusStrip.ResumeLayout(false);
            timeframeStatusStrip.PerformLayout();
            timeControlGB.ResumeLayout(false);
            timeControlGB.PerformLayout();
            pathStatusStrip.ResumeLayout(false);
            pathStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openLogToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private TreeView dirTreeView;
        private DataGridView dgvEvents;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem analyzeToolStripMenuItem;
        private ToolStripMenuItem recordNumbersToolStripMenuItem;
        private ToolStripMenuItem timeCToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem resetCellsToolStripMenuItem1;
        private StatusStrip pathStatusStrip;
        private ToolStripStatusLabel PathTSSLabel;
        private ToolStripStatusLabel ActualPathTSSLabel;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem devicesToolStripMenuItem;
        private ToolStripMenuItem resetTimeToolStripMenuItem;
        private ToolStripMenuItem adjustToolStripMenuItem;
        private ToolStripMenuItem timeframeToolStripMenuItem;
        private GroupBox timeControlGB;
        private DateTimePicker endDTP;
        private Label endTimeLabel;
        private Label startTimeLabel;
        private DateTimePicker startDTP;
        private Button cancelTimeFrameButton;
        private Button applyTimeFrameButton;
        private StatusStrip timeframeStatusStrip;
        private ToolStripStatusLabel timeframeTSSLabel;
    }
}
