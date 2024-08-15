﻿namespace ELST
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            mainMenuStrip = new MenuStrip();
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
            viewToolStripMenuItem = new ToolStripMenuItem();
            devicesToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            dirTreeView = new TreeView();
            dgvEvents = new DataGridView();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            devicesCLB = new CheckedListBox();
            searchGB = new GroupBox();
            caseSensitiveCheckBox = new CheckBox();
            closeSearchButton = new Button();
            searchButton = new Button();
            searchTextBox = new TextBox();
            timeframeStatusStrip = new StatusStrip();
            timeframeTSSLabel = new ToolStripStatusLabel();
            timeControlGB = new GroupBox();
            resetTimefreameButtom = new Button();
            applyTimeframeButton = new Button();
            endDTP = new DateTimePicker();
            endTimeLabel = new Label();
            timeArrowLabel = new Label();
            startDTP = new DateTimePicker();
            pathStatusStrip = new StatusStrip();
            PathTSSLabel = new ToolStripStatusLabel();
            ActualPathTSSLabel = new ToolStripStatusLabel();
            splitter1 = new Splitter();
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            searchGB.SuspendLayout();
            timeframeStatusStrip.SuspendLayout();
            timeControlGB.SuspendLayout();
            pathStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainMenuStrip.AutoSize = false;
            mainMenuStrip.Dock = DockStyle.None;
            mainMenuStrip.ImageScalingSize = new Size(20, 20);
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, analyzeToolStripMenuItem, resetToolStripMenuItem, viewToolStripMenuItem, searchToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(4, 1, 0, 1);
            mainMenuStrip.Size = new Size(1064, 34);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openLogToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 32);
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
            aboutToolStripMenuItem.Size = new Size(55, 32);
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
            analyzeToolStripMenuItem.Size = new Size(75, 32);
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
            resetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetCellsToolStripMenuItem1 });
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(59, 32);
            resetToolStripMenuItem.Text = "&Reset";
            // 
            // resetCellsToolStripMenuItem1
            // 
            resetCellsToolStripMenuItem1.Name = "resetCellsToolStripMenuItem1";
            resetCellsToolStripMenuItem1.Size = new Size(163, 26);
            resetCellsToolStripMenuItem1.Text = "Reset &Cells";
            resetCellsToolStripMenuItem1.Click += resetToolStripMenuItem1_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { devicesToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 32);
            viewToolStripMenuItem.Text = "&View";
            // 
            // devicesToolStripMenuItem
            // 
            devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            devicesToolStripMenuItem.Size = new Size(143, 26);
            devicesToolStripMenuItem.Text = "&Devices";
            devicesToolStripMenuItem.Click += devicesToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(67, 32);
            searchToolStripMenuItem.Text = "&Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // dirTreeView
            // 
            dirTreeView.Dock = DockStyle.Top;
            dirTreeView.Location = new Point(0, 0);
            dirTreeView.Margin = new Padding(2);
            dirTreeView.Name = "dirTreeView";
            dirTreeView.Size = new Size(227, 269);
            dirTreeView.TabIndex = 1;
            dirTreeView.NodeMouseDoubleClick += DirTreeViewNode_DoubleClick;
            // 
            // dgvEvents
            // 
            dgvEvents.AllowUserToOrderColumns = true;
            dgvEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvEvents.DefaultCellStyle = dataGridViewCellStyle5;
            dgvEvents.Location = new Point(0, 0);
            dgvEvents.Name = "dgvEvents";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvEvents.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvEvents.RowHeadersWidth = 51;
            dgvEvents.Size = new Size(833, 480);
            dgvEvents.TabIndex = 0;
            dgvEvents.MouseClick += dgvEvents_MouseClick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(splitContainer1);
            panel1.Location = new Point(0, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(1064, 602);
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
            splitContainer1.Panel1.Controls.Add(splitter1);
            splitContainer1.Panel1.Controls.Add(devicesCLB);
            splitContainer1.Panel1.Controls.Add(dirTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(searchGB);
            splitContainer1.Panel2.Controls.Add(timeframeStatusStrip);
            splitContainer1.Panel2.Controls.Add(timeControlGB);
            splitContainer1.Panel2.Controls.Add(pathStatusStrip);
            splitContainer1.Panel2.Controls.Add(dgvEvents);
            splitContainer1.Size = new Size(1064, 602);
            splitContainer1.SplitterDistance = 227;
            splitContainer1.TabIndex = 0;
            // 
            // devicesCLB
            // 
            devicesCLB.Dock = DockStyle.Fill;
            devicesCLB.FormattingEnabled = true;
            devicesCLB.Location = new Point(0, 269);
            devicesCLB.Name = "devicesCLB";
            devicesCLB.Size = new Size(227, 333);
            devicesCLB.TabIndex = 2;
            devicesCLB.ItemCheck += devicesCLB_ItemCheck;
            // 
            // searchGB
            // 
            searchGB.Anchor = AnchorStyles.None;
            searchGB.Controls.Add(caseSensitiveCheckBox);
            searchGB.Controls.Add(closeSearchButton);
            searchGB.Controls.Add(searchButton);
            searchGB.Controls.Add(searchTextBox);
            searchGB.Location = new Point(455, 205);
            searchGB.Name = "searchGB";
            searchGB.Size = new Size(378, 201);
            searchGB.TabIndex = 4;
            searchGB.TabStop = false;
            searchGB.Text = "Search";
            searchGB.Visible = false;
            searchGB.MouseDown += searchGB_MouseDown;
            searchGB.MouseMove += searchGB_MouseMove;
            // 
            // caseSensitiveCheckBox
            // 
            caseSensitiveCheckBox.AutoSize = true;
            caseSensitiveCheckBox.Location = new Point(39, 81);
            caseSensitiveCheckBox.Name = "caseSensitiveCheckBox";
            caseSensitiveCheckBox.Size = new Size(124, 24);
            caseSensitiveCheckBox.TabIndex = 4;
            caseSensitiveCheckBox.Text = "Case Sensitive";
            caseSensitiveCheckBox.UseVisualStyleBackColor = true;
            caseSensitiveCheckBox.CheckedChanged += caseSensitiveCheckBox_CheckedChanged;
            // 
            // closeSearchButton
            // 
            closeSearchButton.Location = new Point(207, 146);
            closeSearchButton.Name = "closeSearchButton";
            closeSearchButton.Size = new Size(94, 29);
            closeSearchButton.TabIndex = 3;
            closeSearchButton.Text = "Close";
            closeSearchButton.UseVisualStyleBackColor = true;
            closeSearchButton.Click += cancelSearchButton_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(70, 146);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(94, 29);
            searchButton.TabIndex = 2;
            searchButton.Text = "Go";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(35, 37);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(307, 27);
            searchTextBox.TabIndex = 1;
            searchTextBox.Text = "Search";
            // 
            // timeframeStatusStrip
            // 
            timeframeStatusStrip.ImageScalingSize = new Size(20, 20);
            timeframeStatusStrip.Items.AddRange(new ToolStripItem[] { timeframeTSSLabel });
            timeframeStatusStrip.Location = new Point(0, 550);
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
            timeControlGB.Controls.Add(resetTimefreameButtom);
            timeControlGB.Controls.Add(applyTimeframeButton);
            timeControlGB.Controls.Add(endDTP);
            timeControlGB.Controls.Add(endTimeLabel);
            timeControlGB.Controls.Add(timeArrowLabel);
            timeControlGB.Controls.Add(startDTP);
            timeControlGB.Location = new Point(50, 42);
            timeControlGB.Name = "timeControlGB";
            timeControlGB.Size = new Size(747, 125);
            timeControlGB.TabIndex = 2;
            timeControlGB.TabStop = false;
            timeControlGB.Visible = false;
            // 
            // resetTimefreameButtom
            // 
            resetTimefreameButtom.Location = new Point(635, 6);
            resetTimefreameButtom.Name = "resetTimefreameButtom";
            resetTimefreameButtom.Size = new Size(54, 30);
            resetTimefreameButtom.TabIndex = 5;
            resetTimefreameButtom.Text = "Reset";
            resetTimefreameButtom.UseVisualStyleBackColor = true;
            resetTimefreameButtom.Click += resetTimefreameButtom_Click;
            // 
            // applyTimeframeButton
            // 
            applyTimeframeButton.Location = new Point(559, 7);
            applyTimeframeButton.Name = "applyTimeframeButton";
            applyTimeframeButton.Size = new Size(56, 30);
            applyTimeframeButton.TabIndex = 4;
            applyTimeframeButton.Text = "Apply";
            applyTimeframeButton.UseVisualStyleBackColor = true;
            applyTimeframeButton.Click += applyTimeFrameButton_Click;
            // 
            // endDTP
            // 
            endDTP.Format = DateTimePickerFormat.Custom;
            endDTP.Location = new Point(303, 7);
            endDTP.Name = "endDTP";
            endDTP.Size = new Size(205, 27);
            endDTP.TabIndex = 3;
            // 
            // endTimeLabel
            // 
            endTimeLabel.AutoSize = true;
            endTimeLabel.Location = new Point(17, 107);
            endTimeLabel.Name = "endTimeLabel";
            endTimeLabel.Size = new Size(0, 20);
            endTimeLabel.TabIndex = 2;
            // 
            // timeArrowLabel
            // 
            timeArrowLabel.Font = new Font("Segoe UI", 14F);
            timeArrowLabel.Location = new Point(262, 3);
            timeArrowLabel.Name = "timeArrowLabel";
            timeArrowLabel.Size = new Size(35, 35);
            timeArrowLabel.TabIndex = 1;
            timeArrowLabel.Text = "↔";
            timeArrowLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startDTP
            // 
            startDTP.Format = DateTimePickerFormat.Custom;
            startDTP.Location = new Point(6, 7);
            startDTP.Name = "startDTP";
            startDTP.Size = new Size(205, 27);
            startDTP.TabIndex = 0;
            // 
            // pathStatusStrip
            // 
            pathStatusStrip.ImageScalingSize = new Size(20, 20);
            pathStatusStrip.Items.AddRange(new ToolStripItem[] { PathTSSLabel, ActualPathTSSLabel });
            pathStatusStrip.Location = new Point(0, 576);
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
            // splitter1
            // 
            splitter1.Dock = DockStyle.Top;
            splitter1.Location = new Point(0, 269);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(227, 4);
            splitter1.TabIndex = 3;
            splitter1.TabStop = false;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 635);
            Controls.Add(panel1);
            Controls.Add(mainMenuStrip);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = mainMenuStrip;
            Name = "MainMenu";
            Text = "ELST Main Menu";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            searchGB.ResumeLayout(false);
            searchGB.PerformLayout();
            timeframeStatusStrip.ResumeLayout(false);
            timeframeStatusStrip.PerformLayout();
            timeControlGB.ResumeLayout(false);
            timeControlGB.PerformLayout();
            pathStatusStrip.ResumeLayout(false);
            pathStatusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip mainMenuStrip;
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
        private StatusStrip timeframeStatusStrip;
        private ToolStripStatusLabel timeframeTSSLabel;
        private GroupBox searchGB;
        private TextBox searchTextBox;
        private Button searchButton;
        private Button closeSearchButton;
        private CheckBox caseSensitiveCheckBox;
        private ToolStripMenuItem searchToolStripMenuItem;
        private GroupBox timeControlGB;
        private Button applyTimeframeButton;
        private DateTimePicker endDTP;
        private Label endTimeLabel;
        private Label timeArrowLabel;
        private DateTimePicker startDTP;
        private Button resetTimefreameButtom;
        private CheckedListBox devicesCLB;
        private Splitter splitter1;
    }
}
