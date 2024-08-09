namespace ELST
{
    partial class Form1
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
            dirTreeView = new TreeView();
            dgvEvents = new DataGridView();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            resetToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, analyzeToolStripMenuItem, resetToolStripMenuItem });
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
            infoToolStripMenuItem.Size = new Size(224, 26);
            infoToolStripMenuItem.Text = "&Help";
            infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(224, 26);
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
            dgvEvents.Dock = DockStyle.Fill;
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
            dgvEvents.Size = new Size(833, 609);
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
            splitContainer1.Panel2.Controls.Add(dgvEvents);
            splitContainer1.Size = new Size(1064, 609);
            splitContainer1.SplitterDistance = 227;
            splitContainer1.TabIndex = 0;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetToolStripMenuItem1 });
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(59, 24);
            resetToolStripMenuItem.Text = "&Reset";
            // 
            // resetToolStripMenuItem1
            // 
            resetToolStripMenuItem1.Name = "resetToolStripMenuItem1";
            resetToolStripMenuItem1.Size = new Size(224, 26);
            resetToolStripMenuItem1.Text = "&Reset";
            resetToolStripMenuItem1.Click += resetToolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 635);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9F);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "ELST Main Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
        private ToolStripMenuItem resetToolStripMenuItem1;
    }
}
