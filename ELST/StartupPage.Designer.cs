namespace ELST
{
    partial class StartupPage
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
            searchButtonDriveSearch = new Button();
            drivePathLabelDriveSearh = new Label();
            selectDriveButtonDriveSearch = new Button();
            infoLabelDriveSearch = new Label();
            openFileButtonDriveSearch = new Button();
            driveSearchGB = new GroupBox();
            removeAllButton = new Button();
            openTogetherButtonDriveSearch = new Button();
            foundFilesCLB = new CheckedListBox();
            foundFilesLabel = new Label();
            manualOpenGB = new GroupBox();
            openFileButtonManual = new Button();
            helpButton = new Button();
            groupBox1 = new GroupBox();
            removeSelectedButton = new Button();
            driveSearchGB.SuspendLayout();
            manualOpenGB.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // searchButtonDriveSearch
            // 
            searchButtonDriveSearch.Location = new Point(6, 84);
            searchButtonDriveSearch.Name = "searchButtonDriveSearch";
            searchButtonDriveSearch.Size = new Size(111, 29);
            searchButtonDriveSearch.TabIndex = 2;
            searchButtonDriveSearch.Text = "Search";
            searchButtonDriveSearch.UseVisualStyleBackColor = true;
            searchButtonDriveSearch.Click += searchButtonDriveSearch_Click;
            // 
            // drivePathLabelDriveSearh
            // 
            drivePathLabelDriveSearh.AutoSize = true;
            drivePathLabelDriveSearh.Location = new Point(123, 53);
            drivePathLabelDriveSearh.Name = "drivePathLabelDriveSearh";
            drivePathLabelDriveSearh.Size = new Size(137, 20);
            drivePathLabelDriveSearh.TabIndex = 8;
            drivePathLabelDriveSearh.Text = "Selected drive path";
            // 
            // selectDriveButtonDriveSearch
            // 
            selectDriveButtonDriveSearch.Location = new Point(6, 49);
            selectDriveButtonDriveSearch.Name = "selectDriveButtonDriveSearch";
            selectDriveButtonDriveSearch.Size = new Size(111, 29);
            selectDriveButtonDriveSearch.TabIndex = 1;
            selectDriveButtonDriveSearch.Text = "Select Drive";
            selectDriveButtonDriveSearch.UseVisualStyleBackColor = true;
            selectDriveButtonDriveSearch.Click += selectDriveButtonDriveSearch_Click;
            // 
            // infoLabelDriveSearch
            // 
            infoLabelDriveSearch.AutoSize = true;
            infoLabelDriveSearch.Location = new Point(6, 26);
            infoLabelDriveSearch.Name = "infoLabelDriveSearch";
            infoLabelDriveSearch.Size = new Size(209, 20);
            infoLabelDriveSearch.TabIndex = 4;
            infoLabelDriveSearch.Text = "Please select a drive to search:";
            // 
            // openFileButtonDriveSearch
            // 
            openFileButtonDriveSearch.Location = new Point(6, 132);
            openFileButtonDriveSearch.Name = "openFileButtonDriveSearch";
            openFileButtonDriveSearch.Size = new Size(111, 29);
            openFileButtonDriveSearch.TabIndex = 4;
            openFileButtonDriveSearch.Text = "Open File(s)";
            openFileButtonDriveSearch.UseVisualStyleBackColor = true;
            openFileButtonDriveSearch.Click += openFileButtonDriveSearch_Click;
            // 
            // driveSearchGB
            // 
            driveSearchGB.Controls.Add(searchButtonDriveSearch);
            driveSearchGB.Controls.Add(drivePathLabelDriveSearh);
            driveSearchGB.Controls.Add(selectDriveButtonDriveSearch);
            driveSearchGB.Controls.Add(infoLabelDriveSearch);
            driveSearchGB.Location = new Point(0, 0);
            driveSearchGB.Name = "driveSearchGB";
            driveSearchGB.Size = new Size(380, 121);
            driveSearchGB.TabIndex = 11;
            driveSearchGB.TabStop = false;
            driveSearchGB.Text = "Drive Search";
            // 
            // removeAllButton
            // 
            removeAllButton.Location = new Point(449, 132);
            removeAllButton.Name = "removeAllButton";
            removeAllButton.Size = new Size(94, 29);
            removeAllButton.TabIndex = 12;
            removeAllButton.Text = "Remove All";
            removeAllButton.UseVisualStyleBackColor = true;
            removeAllButton.Click += removeAllButton_Click;
            // 
            // openTogetherButtonDriveSearch
            // 
            openTogetherButtonDriveSearch.Location = new Point(134, 132);
            openTogetherButtonDriveSearch.Name = "openTogetherButtonDriveSearch";
            openTogetherButtonDriveSearch.Size = new Size(140, 29);
            openTogetherButtonDriveSearch.TabIndex = 11;
            openTogetherButtonDriveSearch.Text = "Open Together";
            openTogetherButtonDriveSearch.UseVisualStyleBackColor = true;
            openTogetherButtonDriveSearch.Click += openTogetherButtonDriveSearch_Click;
            // 
            // foundFilesCLB
            // 
            foundFilesCLB.FormattingEnabled = true;
            foundFilesCLB.Location = new Point(6, 53);
            foundFilesCLB.Name = "foundFilesCLB";
            foundFilesCLB.Size = new Size(750, 70);
            foundFilesCLB.TabIndex = 10;
            foundFilesCLB.ItemCheck += foundFilesCLB_ItemCheck;
            foundFilesCLB.SelectedIndexChanged += foundFilesCLB_SelectedIndexChanged;
            // 
            // foundFilesLabel
            // 
            foundFilesLabel.AutoSize = true;
            foundFilesLabel.Location = new Point(6, 24);
            foundFilesLabel.Name = "foundFilesLabel";
            foundFilesLabel.Size = new Size(155, 20);
            foundFilesLabel.TabIndex = 9;
            foundFilesLabel.Text = "Files of interest found:";
            // 
            // manualOpenGB
            // 
            manualOpenGB.Controls.Add(openFileButtonManual);
            manualOpenGB.Location = new Point(386, 0);
            manualOpenGB.Name = "manualOpenGB";
            manualOpenGB.Size = new Size(377, 121);
            manualOpenGB.TabIndex = 12;
            manualOpenGB.TabStop = false;
            manualOpenGB.Text = "Open Manually";
            // 
            // openFileButtonManual
            // 
            openFileButtonManual.Location = new Point(12, 49);
            openFileButtonManual.Name = "openFileButtonManual";
            openFileButtonManual.Size = new Size(167, 29);
            openFileButtonManual.TabIndex = 5;
            openFileButtonManual.Text = "Manually Select File";
            openFileButtonManual.UseVisualStyleBackColor = true;
            openFileButtonManual.Click += openFileButtonManual_Click;
            // 
            // helpButton
            // 
            helpButton.Location = new Point(662, 132);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(94, 29);
            helpButton.TabIndex = 6;
            helpButton.Text = "Help";
            helpButton.UseVisualStyleBackColor = true;
            helpButton.Click += helpButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(removeSelectedButton);
            groupBox1.Controls.Add(removeAllButton);
            groupBox1.Controls.Add(foundFilesLabel);
            groupBox1.Controls.Add(helpButton);
            groupBox1.Controls.Add(openFileButtonDriveSearch);
            groupBox1.Controls.Add(openTogetherButtonDriveSearch);
            groupBox1.Controls.Add(foundFilesCLB);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(0, 122);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(763, 169);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // removeSelectedButton
            // 
            removeSelectedButton.Location = new Point(291, 132);
            removeSelectedButton.Name = "removeSelectedButton";
            removeSelectedButton.Size = new Size(141, 29);
            removeSelectedButton.TabIndex = 13;
            removeSelectedButton.Text = "Remove Selected";
            removeSelectedButton.UseVisualStyleBackColor = true;
            removeSelectedButton.Click += removeSelectedButton_Click;
            // 
            // StartupPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 291);
            Controls.Add(groupBox1);
            Controls.Add(manualOpenGB);
            Controls.Add(driveSearchGB);
            Name = "StartupPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ELST - Startup";
            driveSearchGB.ResumeLayout(false);
            driveSearchGB.PerformLayout();
            manualOpenGB.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button searchButtonDriveSearch;
        private Label drivePathLabelDriveSearh;
        private Button selectDriveButtonDriveSearch;
        private Label infoLabelDriveSearch;
        private Button openFileButtonDriveSearch;
        private GroupBox driveSearchGB;
        private GroupBox manualOpenGB;
        private Button openFileButtonManual;
        private Label foundFilesLabel;
        private CheckedListBox foundFilesCLB;
        private Button openTogetherButtonDriveSearch;
        private Button helpButton;
        private Button removeAllButton;
        private GroupBox groupBox1;
        private Button removeSelectedButton;
    }
}