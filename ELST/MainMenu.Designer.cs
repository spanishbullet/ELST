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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openLogToolStripMenuItem = new ToolStripMenuItem();
            chooseToolStripMenuItem = new ToolStripMenuItem();
            logPropertiesToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            analyzeToolStripMenuItem = new ToolStripMenuItem();
            recordNumbersToolStripMenuItem = new ToolStripMenuItem();
            timeCToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            resetCellsToolStripMenuItem1 = new ToolStripMenuItem();
            seeToolStripMenuItem = new ToolStripMenuItem();
            devicesToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            configureToolStripMenuItem = new ToolStripMenuItem();
            columnsToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            newFilterToolStripMenuItem = new ToolStripMenuItem();
            clearFilterToolStripMenuItem = new ToolStripMenuItem();
            dirTreeView = new TreeView();
            dgvEvents = new DataGridView();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            devicesCLB = new CheckedListBox();
            splitter2 = new Splitter();
            tableLayoutPanel1 = new TableLayoutPanel();
            uncheckAllDevicesButton = new Button();
            checkAllDevicesButton = new Button();
            splitter1 = new Splitter();
            splitter3 = new Splitter();
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
            resetSearchButton = new Button();
            mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, analyzeToolStripMenuItem, resetToolStripMenuItem, seeToolStripMenuItem, searchToolStripMenuItem, configureToolStripMenuItem, filterToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Padding = new Padding(4, 1, 0, 1);
            mainMenuStrip.Size = new Size(1064, 34);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openLogToolStripMenuItem, logPropertiesToolStripMenuItem, exportToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 32);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openLogToolStripMenuItem
            // 
            openLogToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chooseToolStripMenuItem });
            openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            openLogToolStripMenuItem.Size = new Size(188, 26);
            openLogToolStripMenuItem.Text = "&Open Log";
            // 
            // chooseToolStripMenuItem
            // 
            chooseToolStripMenuItem.Name = "chooseToolStripMenuItem";
            chooseToolStripMenuItem.Size = new Size(141, 26);
            chooseToolStripMenuItem.Text = "&Choose";
            chooseToolStripMenuItem.Click += chooseToolStripMenuItem_Click;
            // 
            // logPropertiesToolStripMenuItem
            // 
            logPropertiesToolStripMenuItem.Name = "logPropertiesToolStripMenuItem";
            logPropertiesToolStripMenuItem.Size = new Size(188, 26);
            logPropertiesToolStripMenuItem.Text = "&Log Properties";
            logPropertiesToolStripMenuItem.Click += logPropertiesToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(188, 26);
            exportToolStripMenuItem.Text = "&Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(188, 26);
            exitToolStripMenuItem.Text = "E&xit";
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
            timeCToolStripMenuItem.Text = "&Time";
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
            // seeToolStripMenuItem
            // 
            seeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { devicesToolStripMenuItem });
            seeToolStripMenuItem.Name = "seeToolStripMenuItem";
            seeToolStripMenuItem.Size = new Size(47, 32);
            seeToolStripMenuItem.Text = "&See";
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
            // configureToolStripMenuItem
            // 
            configureToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { columnsToolStripMenuItem });
            configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            configureToolStripMenuItem.Size = new Size(88, 32);
            configureToolStripMenuItem.Text = "&Configure";
            // 
            // columnsToolStripMenuItem
            // 
            columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            columnsToolStripMenuItem.Size = new Size(149, 26);
            columnsToolStripMenuItem.Text = "&Columns";
            columnsToolStripMenuItem.Click += columnsToolStripMenuItem_Click;
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newFilterToolStripMenuItem, clearFilterToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(56, 32);
            filterToolStripMenuItem.Text = "&Filter";
            // 
            // newFilterToolStripMenuItem
            // 
            newFilterToolStripMenuItem.Name = "newFilterToolStripMenuItem";
            newFilterToolStripMenuItem.Size = new Size(166, 26);
            newFilterToolStripMenuItem.Text = "&New Filter";
            newFilterToolStripMenuItem.Click += newFilterToolStripMenuItem_Click;
            // 
            // clearFilterToolStripMenuItem
            // 
            clearFilterToolStripMenuItem.Name = "clearFilterToolStripMenuItem";
            clearFilterToolStripMenuItem.Size = new Size(166, 26);
            clearFilterToolStripMenuItem.Text = "&Apply filter";
            clearFilterToolStripMenuItem.Click += clearFilterToolStripMenuItem_Click;
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
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.AllowUserToOrderColumns = true;
            dgvEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvEvents.DefaultCellStyle = dataGridViewCellStyle8;
            dgvEvents.Location = new Point(0, 0);
            dgvEvents.Name = "dgvEvents";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvEvents.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvEvents.RowHeadersWidth = 51;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(splitter1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitter3);
            splitContainer1.Panel2.Controls.Add(searchGB);
            splitContainer1.Panel2.Controls.Add(eventsStatusStrip);
            splitContainer1.Panel2.Controls.Add(timeControlGB);
            splitContainer1.Panel2.Controls.Add(pathStatusStrip);
            splitContainer1.Panel2.Controls.Add(dgvEvents);
            splitContainer1.Size = new Size(1064, 602);
            splitContainer1.SplitterDistance = 227;
            splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(devicesCLB);
            panel2.Controls.Add(splitter2);
            panel2.Controls.Add(dirTreeView);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(227, 564);
            panel2.TabIndex = 4;
            // 
            // devicesCLB
            // 
            devicesCLB.Dock = DockStyle.Fill;
            devicesCLB.FormattingEnabled = true;
            devicesCLB.Location = new Point(0, 273);
            devicesCLB.Name = "devicesCLB";
            devicesCLB.Size = new Size(227, 291);
            devicesCLB.TabIndex = 2;
            devicesCLB.ItemCheck += devicesCLB_ItemCheck;
            // 
            // splitter2
            // 
            splitter2.Dock = DockStyle.Top;
            splitter2.Location = new Point(0, 269);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(227, 4);
            splitter2.TabIndex = 2;
            splitter2.TabStop = false;
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
            uncheckAllDevicesButton.Dock = DockStyle.Fill;
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
            checkAllDevicesButton.Dock = DockStyle.Fill;
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
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(227, 4);
            splitter1.TabIndex = 3;
            splitter1.TabStop = false;
            // 
            // splitter3
            // 
            splitter3.Dock = DockStyle.Bottom;
            splitter3.Location = new Point(0, 546);
            splitter3.Name = "splitter3";
            splitter3.Size = new Size(833, 4);
            splitter3.TabIndex = 5;
            splitter3.TabStop = false;
            // 
            // searchGB
            // 
            searchGB.Anchor = AnchorStyles.None;
            searchGB.Controls.Add(resetSearchButton);
            searchGB.Controls.Add(caseSensitiveCheckBox);
            searchGB.Controls.Add(closeSearchButton);
            searchGB.Controls.Add(searchButton);
            searchGB.Controls.Add(searchTextBox);
            searchGB.Location = new Point(455, 311);
            searchGB.Name = "searchGB";
            searchGB.Size = new Size(378, 174);
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
            closeSearchButton.Location = new Point(248, 126);
            closeSearchButton.Name = "closeSearchButton";
            closeSearchButton.Size = new Size(94, 29);
            closeSearchButton.TabIndex = 3;
            closeSearchButton.Text = "Close";
            closeSearchButton.UseVisualStyleBackColor = true;
            closeSearchButton.Click += cancelSearchButton_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(132, 126);
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
            PathTSSLabel.Size = new Size(108, 20);
            PathTSSLabel.Text = "Current Path(s):";
            PathTSSLabel.TextAlign = ContentAlignment.TopLeft;
            // 
            // ActualPathTSSLabel
            // 
            ActualPathTSSLabel.Name = "ActualPathTSSLabel";
            ActualPathTSSLabel.Size = new Size(39, 20);
            ActualPathTSSLabel.Text = "path";
            ActualPathTSSLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // resetSearchButton
            // 
            resetSearchButton.Location = new Point(206, 81);
            resetSearchButton.Name = "resetSearchButton";
            resetSearchButton.Size = new Size(136, 29);
            resetSearchButton.TabIndex = 5;
            resetSearchButton.Text = "Reset Highlight";
            resetSearchButton.UseVisualStyleBackColor = true;
            resetSearchButton.Click += resetSearchButton_Click;
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
            StartPosition = FormStartPosition.CenterScreen;
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
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
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
        private ToolStripMenuItem seeToolStripMenuItem;
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
        private ToolStripMenuItem chooseToolStripMenuItem;
        private ToolStripMenuItem configureToolStripMenuItem;
        private ToolStripMenuItem columnsToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private Panel panel2;
        private Splitter splitter2;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem newFilterToolStripMenuItem;
        private ToolStripMenuItem clearFilterToolStripMenuItem;
        private Splitter splitter3;
        private ToolStripMenuItem logPropertiesToolStripMenuItem;
        private Button resetSearchButton;
    }
}
