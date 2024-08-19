namespace ELST
{
    partial class DevicesPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            devicesPageMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            devicesStatusStrip = new StatusStrip();
            devicesTVSSTLabel = new ToolStripStatusLabel();
            devicesTV = new TreeView();
            splitContainer2 = new SplitContainer();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            dgvDevices = new DataGridView();
            otherEventsTS = new StatusStrip();
            otherEventsTSSLabel = new ToolStripStatusLabel();
            statusStrip2 = new StatusStrip();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            dgvDeviceEvents = new DataGridView();
            analyzeToolStripMenuItem = new ToolStripMenuItem();
            actionsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            devicesPageMenuStrip.SuspendLayout();
            panel1.SuspendLayout();
            devicesStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            otherEventsTS.SuspendLayout();
            statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeviceEvents).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(150, 100);
            splitContainer1.TabIndex = 0;
            // 
            // devicesPageMenuStrip
            // 
            devicesPageMenuStrip.ImageScalingSize = new Size(20, 20);
            devicesPageMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, analyzeToolStripMenuItem });
            devicesPageMenuStrip.Location = new Point(0, 0);
            devicesPageMenuStrip.Name = "devicesPageMenuStrip";
            devicesPageMenuStrip.Size = new Size(1062, 28);
            devicesPageMenuStrip.TabIndex = 0;
            devicesPageMenuStrip.Text = "menuStrip1";
            devicesPageMenuStrip.UseWaitCursor = true;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 26);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(devicesStatusStrip);
            panel1.Controls.Add(devicesTV);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 597);
            panel1.TabIndex = 1;
            panel1.UseWaitCursor = true;
            // 
            // devicesStatusStrip
            // 
            devicesStatusStrip.Dock = DockStyle.Top;
            devicesStatusStrip.ImageScalingSize = new Size(20, 20);
            devicesStatusStrip.Items.AddRange(new ToolStripItem[] { devicesTVSSTLabel });
            devicesStatusStrip.Location = new Point(0, 0);
            devicesStatusStrip.Name = "devicesStatusStrip";
            devicesStatusStrip.Size = new Size(250, 26);
            devicesStatusStrip.TabIndex = 1;
            devicesStatusStrip.UseWaitCursor = true;
            // 
            // devicesTVSSTLabel
            // 
            devicesTVSSTLabel.Name = "devicesTVSSTLabel";
            devicesTVSSTLabel.Size = new Size(76, 20);
            devicesTVSSTLabel.Text = "# Devices:";
            // 
            // devicesTV
            // 
            devicesTV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            devicesTV.Location = new Point(0, 25);
            devicesTV.Name = "devicesTV";
            devicesTV.Size = new Size(250, 572);
            devicesTV.TabIndex = 0;
            devicesTV.UseWaitCursor = true;
            devicesTV.NodeMouseDoubleClick += devicesTV_NodeMouseDoubleClick;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(250, 28);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(statusStrip1);
            splitContainer2.Panel1.Controls.Add(dgvDevices);
            splitContainer2.Panel1.UseWaitCursor = true;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(otherEventsTS);
            splitContainer2.Panel2.Controls.Add(statusStrip2);
            splitContainer2.Panel2.Controls.Add(dgvDeviceEvents);
            splitContainer2.Panel2.UseWaitCursor = true;
            splitContainer2.Size = new Size(812, 597);
            splitContainer2.SplitterDistance = 150;
            splitContainer2.TabIndex = 2;
            splitContainer2.UseWaitCursor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Top;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(812, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.UseWaitCursor = true;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(139, 20);
            toolStripStatusLabel1.Text = "Device Information:";
            // 
            // dgvDevices
            // 
            dgvDevices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Location = new Point(0, 25);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.RowHeadersWidth = 51;
            dgvDevices.Size = new Size(812, 125);
            dgvDevices.TabIndex = 0;
            dgvDevices.UseWaitCursor = true;
            // 
            // otherEventsTS
            // 
            otherEventsTS.ImageScalingSize = new Size(20, 20);
            otherEventsTS.Items.AddRange(new ToolStripItem[] { otherEventsTSSLabel });
            otherEventsTS.Location = new Point(0, 417);
            otherEventsTS.Name = "otherEventsTS";
            otherEventsTS.Size = new Size(812, 26);
            otherEventsTS.TabIndex = 2;
            otherEventsTS.Text = "statusStrip3";
            otherEventsTS.UseWaitCursor = true;
            // 
            // otherEventsTSSLabel
            // 
            otherEventsTSSLabel.Name = "otherEventsTSSLabel";
            otherEventsTSSLabel.Size = new Size(277, 20);
            otherEventsTSSLabel.Text = "Events Outside Current Timeframe: None";
            // 
            // statusStrip2
            // 
            statusStrip2.Dock = DockStyle.Top;
            statusStrip2.ImageScalingSize = new Size(20, 20);
            statusStrip2.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2 });
            statusStrip2.Location = new Point(0, 0);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Size = new Size(812, 26);
            statusStrip2.TabIndex = 1;
            statusStrip2.Text = "statusStrip2";
            statusStrip2.UseWaitCursor = true;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(103, 20);
            toolStripStatusLabel2.Text = "Device Events:";
            // 
            // dgvDeviceEvents
            // 
            dgvDeviceEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDeviceEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeviceEvents.Location = new Point(0, 25);
            dgvDeviceEvents.Name = "dgvDeviceEvents";
            dgvDeviceEvents.RowHeadersWidth = 51;
            dgvDeviceEvents.Size = new Size(812, 379);
            dgvDeviceEvents.TabIndex = 0;
            dgvDeviceEvents.UseWaitCursor = true;
            // 
            // analyzeToolStripMenuItem
            // 
            analyzeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { actionsToolStripMenuItem });
            analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            analyzeToolStripMenuItem.Size = new Size(75, 24);
            analyzeToolStripMenuItem.Text = "&Analyze";
            // 
            // actionsToolStripMenuItem
            // 
            actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            actionsToolStripMenuItem.Size = new Size(224, 26);
            actionsToolStripMenuItem.Text = "&Actions";
            actionsToolStripMenuItem.Click += actionsToolStripMenuItem_Click;
            // 
            // DevicesPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 625);
            Controls.Add(splitContainer2);
            Controls.Add(panel1);
            Controls.Add(devicesPageMenuStrip);
            MainMenuStrip = devicesPageMenuStrip;
            Name = "DevicesPage";
            Text = "Devices";
            UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            devicesPageMenuStrip.ResumeLayout(false);
            devicesPageMenuStrip.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            devicesStatusStrip.ResumeLayout(false);
            devicesStatusStrip.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            otherEventsTS.ResumeLayout(false);
            otherEventsTS.PerformLayout();
            statusStrip2.ResumeLayout(false);
            statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeviceEvents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SplitContainer splitContainer1;
        private MenuStrip devicesPageMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel panel1;
        private SplitContainer splitContainer2;
        private TreeView devicesTV;
        private DataGridView dgvDevices;
        private DataGridView dgvDeviceEvents;
        private StatusStrip devicesStatusStrip;
        private ToolStripStatusLabel devicesTVSSTLabel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private StatusStrip statusStrip2;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private StatusStrip otherEventsTS;
        private ToolStripStatusLabel otherEventsTSSLabel;
        private ToolStripMenuItem analyzeToolStripMenuItem;
        private ToolStripMenuItem actionsToolStripMenuItem;
    }
}