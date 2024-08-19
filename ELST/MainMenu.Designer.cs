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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            tableLayoutPanel1 = new TableLayoutPanel();
            uncheckAllDevicesButton = new Button();
            checkAllDevicesButton = new Button();
            splitter1 = new Splitter();
            devicesCLB = new CheckedListBox();
            startupGB3 = new GroupBox();
            openFileButtonStartGB3 = new Button();
            startInfoLabelGB3 = new Label();
            startupGB2 = new GroupBox();
            openFileButtonStartGB2 = new Button();
            foundFilesTV = new TreeView();
            infoLabelStartGB2 = new Label();
            startupGB1 = new GroupBox();
            goButtonSGB = new Button();
            drivePathLabelSGB1 = new Label();
            selectDriveButtonSGB1 = new Button();
            infoLabelStartGB1 = new Label();
            searchGB = new GroupBox();
            caseSensitiveCheckBox = new CheckBox();
            closeSearchButton = new Button();
            searchButton = new Button();
            searchTextBox = new TextBox();
            eventsStatusStrip = new StatusStrip();
            eventsTSSLabel = new ToolStripStatusLabel();
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
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            startupGB3.SuspendLayout();
            startupGB2.SuspendLayout();
            startupGB1.SuspendLayout();
            searchGB.SuspendLayout();
            eventsStatusStrip.SuspendLayout();
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
            dgvEvents.Size = new Size(833, 547);
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
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(splitter1);
            splitContainer1.Panel1.Controls.Add(devicesCLB);
            splitContainer1.Panel1.Controls.Add(dirTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(startupGB3);
            splitContainer1.Panel2.Controls.Add(startupGB2);
            splitContainer1.Panel2.Controls.Add(startupGB1);
            splitContainer1.Panel2.Controls.Add(searchGB);
            splitContainer1.Panel2.Controls.Add(eventsStatusStrip);
            splitContainer1.Panel2.Controls.Add(timeControlGB);
            splitContainer1.Panel2.Controls.Add(pathStatusStrip);
            splitContainer1.Panel2.Controls.Add(dgvEvents);
            splitContainer1.Size = new Size(1064, 602);
            splitContainer1.SplitterDistance = 227;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(uncheckAllDevicesButton, 1, 0);
            tableLayoutPanel1.Controls.Add(checkAllDevicesButton, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 568);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(227, 34);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // uncheckAllDevicesButton
            // 
            uncheckAllDevicesButton.Location = new Point(116, 3);
            uncheckAllDevicesButton.Name = "uncheckAllDevicesButton";
            uncheckAllDevicesButton.Size = new Size(108, 28);
            uncheckAllDevicesButton.TabIndex = 1;
            uncheckAllDevicesButton.Text = "Uncheck All";
            uncheckAllDevicesButton.UseVisualStyleBackColor = true;
            uncheckAllDevicesButton.Click += uncheckAllDevicesButton_Click;
            // 
            // checkAllDevicesButton
            // 
            checkAllDevicesButton.Location = new Point(3, 3);
            checkAllDevicesButton.Name = "checkAllDevicesButton";
            checkAllDevicesButton.Size = new Size(107, 28);
            checkAllDevicesButton.TabIndex = 0;
            checkAllDevicesButton.Text = "Check All";
            checkAllDevicesButton.UseVisualStyleBackColor = true;
            checkAllDevicesButton.Click += checkAllDevicesButton_Click;
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
            // startupGB3
            // 
            startupGB3.Controls.Add(openFileButtonStartGB3);
            startupGB3.Controls.Add(startInfoLabelGB3);
            startupGB3.Location = new Point(6, 308);
            startupGB3.Name = "startupGB3";
            startupGB3.Size = new Size(352, 237);
            startupGB3.TabIndex = 7;
            startupGB3.TabStop = false;
            startupGB3.Text = "Start";
            startupGB3.Visible = false;
            // 
            // openFileButtonStartGB3
            // 
            openFileButtonStartGB3.Location = new Point(23, 114);
            openFileButtonStartGB3.Name = "openFileButtonStartGB3";
            openFileButtonStartGB3.Size = new Size(94, 29);
            openFileButtonStartGB3.TabIndex = 2;
            openFileButtonStartGB3.Text = "Open File";
            openFileButtonStartGB3.UseVisualStyleBackColor = true;
            openFileButtonStartGB3.Click += openFileButtonStartGB3_Click;
            // 
            // startInfoLabelGB3
            // 
            startInfoLabelGB3.AutoSize = true;
            startInfoLabelGB3.Location = new Point(19, 46);
            startInfoLabelGB3.Name = "startInfoLabelGB3";
            startInfoLabelGB3.Size = new Size(179, 20);
            startInfoLabelGB3.TabIndex = 0;
            startInfoLabelGB3.Text = "No FIles of interest found:";
            // 
            // startupGB2
            // 
            startupGB2.Controls.Add(openFileButtonStartGB2);
            startupGB2.Controls.Add(foundFilesTV);
            startupGB2.Controls.Add(infoLabelStartGB2);
            startupGB2.Location = new Point(364, 65);
            startupGB2.Name = "startupGB2";
            startupGB2.Size = new Size(457, 237);
            startupGB2.TabIndex = 6;
            startupGB2.TabStop = false;
            startupGB2.Text = "Start";
            startupGB2.Visible = false;
            // 
            // openFileButtonStartGB2
            // 
            openFileButtonStartGB2.Location = new Point(127, 179);
            openFileButtonStartGB2.Name = "openFileButtonStartGB2";
            openFileButtonStartGB2.Size = new Size(94, 29);
            openFileButtonStartGB2.TabIndex = 2;
            openFileButtonStartGB2.Text = "Open File";
            openFileButtonStartGB2.UseVisualStyleBackColor = true;
            openFileButtonStartGB2.Click += openFileButtonStartGB2_Click;
            // 
            // foundFilesTV
            // 
            foundFilesTV.Location = new Point(19, 83);
            foundFilesTV.Name = "foundFilesTV";
            foundFilesTV.Size = new Size(421, 77);
            foundFilesTV.TabIndex = 1;
            // 
            // infoLabelStartGB2
            // 
            infoLabelStartGB2.AutoSize = true;
            infoLabelStartGB2.Location = new Point(19, 46);
            infoLabelStartGB2.Name = "infoLabelStartGB2";
            infoLabelStartGB2.Size = new Size(168, 20);
            infoLabelStartGB2.TabIndex = 0;
            infoLabelStartGB2.Text = "# FIles of interest found:";
            // 
            // startupGB1
            // 
            startupGB1.Controls.Add(goButtonSGB);
            startupGB1.Controls.Add(drivePathLabelSGB1);
            startupGB1.Controls.Add(selectDriveButtonSGB1);
            startupGB1.Controls.Add(infoLabelStartGB1);
            startupGB1.Location = new Point(6, 65);
            startupGB1.Name = "startupGB1";
            startupGB1.Size = new Size(352, 237);
            startupGB1.TabIndex = 5;
            startupGB1.TabStop = false;
            startupGB1.Text = "Start";
            startupGB1.Visible = false;
            // 
            // goButtonSGB
            // 
            goButtonSGB.Location = new Point(6, 152);
            goButtonSGB.Name = "goButtonSGB";
            goButtonSGB.Size = new Size(111, 29);
            goButtonSGB.TabIndex = 3;
            goButtonSGB.Text = "Go";
            goButtonSGB.UseVisualStyleBackColor = true;
            goButtonSGB.Click += goButtonSGB_Click;
            // 
            // drivePathLabelSGB1
            // 
            drivePathLabelSGB1.AutoSize = true;
            drivePathLabelSGB1.Location = new Point(134, 100);
            drivePathLabelSGB1.Name = "drivePathLabelSGB1";
            drivePathLabelSGB1.Size = new Size(137, 20);
            drivePathLabelSGB1.TabIndex = 2;
            drivePathLabelSGB1.Text = "Selected drive path";
            // 
            // selectDriveButtonSGB1
            // 
            selectDriveButtonSGB1.Location = new Point(6, 96);
            selectDriveButtonSGB1.Name = "selectDriveButtonSGB1";
            selectDriveButtonSGB1.Size = new Size(111, 29);
            selectDriveButtonSGB1.TabIndex = 1;
            selectDriveButtonSGB1.Text = "Select Drive";
            selectDriveButtonSGB1.UseVisualStyleBackColor = true;
            selectDriveButtonSGB1.Click += selectDriveButtonSGB1_Click;
            // 
            // infoLabelStartGB1
            // 
            infoLabelStartGB1.AutoSize = true;
            infoLabelStartGB1.Location = new Point(6, 46);
            infoLabelStartGB1.Name = "infoLabelStartGB1";
            infoLabelStartGB1.Size = new Size(209, 20);
            infoLabelStartGB1.TabIndex = 0;
            infoLabelStartGB1.Text = "Please select a drive to search:";
            // 
            // searchGB
            // 
            searchGB.Anchor = AnchorStyles.None;
            searchGB.Controls.Add(caseSensitiveCheckBox);
            searchGB.Controls.Add(closeSearchButton);
            searchGB.Controls.Add(searchButton);
            searchGB.Controls.Add(searchTextBox);
            searchGB.Location = new Point(443, 344);
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
            // eventsStatusStrip
            // 
            eventsStatusStrip.ImageScalingSize = new Size(20, 20);
            eventsStatusStrip.Items.AddRange(new ToolStripItem[] { eventsTSSLabel });
            eventsStatusStrip.Location = new Point(0, 550);
            eventsStatusStrip.Name = "eventsStatusStrip";
            eventsStatusStrip.Size = new Size(833, 26);
            eventsStatusStrip.TabIndex = 3;
            eventsStatusStrip.Text = "Showing # of # Events";
            // 
            // eventsTSSLabel
            // 
            eventsTSSLabel.Name = "eventsTSSLabel";
            eventsTSSLabel.Size = new Size(156, 20);
            eventsTSSLabel.Text = "Showing # of # Events";
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
            timeControlGB.Location = new Point(6, 4);
            timeControlGB.Name = "timeControlGB";
            timeControlGB.Size = new Size(747, 52);
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
            tableLayoutPanel1.ResumeLayout(false);
            startupGB3.ResumeLayout(false);
            startupGB3.PerformLayout();
            startupGB2.ResumeLayout(false);
            startupGB2.PerformLayout();
            startupGB1.ResumeLayout(false);
            startupGB1.PerformLayout();
            searchGB.ResumeLayout(false);
            searchGB.PerformLayout();
            eventsStatusStrip.ResumeLayout(false);
            eventsStatusStrip.PerformLayout();
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
        private StatusStrip eventsStatusStrip;
        private ToolStripStatusLabel eventsTSSLabel;
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
        private Button uncheckAllDevicesButton;
        private Button checkAllDevicesButton;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox startupGB1;
        private Label infoLabelStartGB1;
        private Button goButtonSGB;
        private Label drivePathLabelSGB1;
        private Button selectDriveButtonSGB1;
        private GroupBox startupGB2;
        private Button openFileButtonStartGB2;
        private TreeView foundFilesTV;
        private Label infoLabelStartGB2;
        private GroupBox startupGB3;
        private Button openFileButtonStartGB3;
        private Label startInfoLabelGB3;
    }
}
