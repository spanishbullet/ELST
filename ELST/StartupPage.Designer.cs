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
            foundFilesTV = new TreeView();
            driveSearchGB = new GroupBox();
            manualOpenGB = new GroupBox();
            openFileButtonManual = new Button();
            foundFilesLabelDriveSearch = new Label();
            driveSearchGB.SuspendLayout();
            manualOpenGB.SuspendLayout();
            SuspendLayout();
            // 
            // searchButtonDriveSearch
            // 
            searchButtonDriveSearch.Location = new Point(6, 84);
            searchButtonDriveSearch.Name = "searchButtonDriveSearch";
            searchButtonDriveSearch.Size = new Size(111, 29);
            searchButtonDriveSearch.TabIndex = 10;
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
            selectDriveButtonDriveSearch.TabIndex = 6;
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
            openFileButtonDriveSearch.Location = new Point(6, 229);
            openFileButtonDriveSearch.Name = "openFileButtonDriveSearch";
            openFileButtonDriveSearch.Size = new Size(94, 29);
            openFileButtonDriveSearch.TabIndex = 9;
            openFileButtonDriveSearch.Text = "Open File";
            openFileButtonDriveSearch.UseVisualStyleBackColor = true;
            openFileButtonDriveSearch.Click += openFileButtonDriveSearch_Click;
            // 
            // foundFilesTV
            // 
            foundFilesTV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            foundFilesTV.Location = new Point(6, 146);
            foundFilesTV.Name = "foundFilesTV";
            foundFilesTV.Size = new Size(749, 77);
            foundFilesTV.TabIndex = 7;
            // 
            // driveSearchGB
            // 
            driveSearchGB.Controls.Add(searchButtonDriveSearch);
            driveSearchGB.Controls.Add(foundFilesLabelDriveSearch);
            driveSearchGB.Controls.Add(drivePathLabelDriveSearh);
            driveSearchGB.Controls.Add(foundFilesTV);
            driveSearchGB.Controls.Add(selectDriveButtonDriveSearch);
            driveSearchGB.Controls.Add(openFileButtonDriveSearch);
            driveSearchGB.Controls.Add(infoLabelDriveSearch);
            driveSearchGB.Dock = DockStyle.Top;
            driveSearchGB.Location = new Point(0, 0);
            driveSearchGB.Name = "driveSearchGB";
            driveSearchGB.Size = new Size(762, 299);
            driveSearchGB.TabIndex = 11;
            driveSearchGB.TabStop = false;
            driveSearchGB.Text = "Drive Search";
            // 
            // foundFilesLabelDriveSearch
            // 
            foundFilesLabelDriveSearch.AutoSize = true;
            foundFilesLabelDriveSearch.Location = new Point(6, 123);
            foundFilesLabelDriveSearch.Name = "foundFilesLabelDriveSearch";
            foundFilesLabelDriveSearch.Size = new Size(155, 20);
            foundFilesLabelDriveSearch.TabIndex = 5;
            foundFilesLabelDriveSearch.Text = "FIles of interest found:";
            // 
            // manualOpenGB
            // 
            manualOpenGB.Controls.Add(openFileButtonManual);
            manualOpenGB.Dock = DockStyle.Fill;
            manualOpenGB.Location = new Point(0, 299);
            manualOpenGB.Name = "manualOpenGB";
            manualOpenGB.Size = new Size(762, 64);
            manualOpenGB.TabIndex = 12;
            manualOpenGB.TabStop = false;
            manualOpenGB.Text = "Open Manually";
            // 
            // openFileButtonManual
            // 
            openFileButtonManual.Location = new Point(6, 26);
            openFileButtonManual.Name = "openFileButtonManual";
            openFileButtonManual.Size = new Size(94, 29);
            openFileButtonManual.TabIndex = 10;
            openFileButtonManual.Text = "Open File";
            openFileButtonManual.UseVisualStyleBackColor = true;
            openFileButtonManual.Click += openFileButtonManual_Click;
            // 
            // StartupPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 363);
            Controls.Add(manualOpenGB);
            Controls.Add(driveSearchGB);
            Name = "StartupPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ELST - Startup";
            driveSearchGB.ResumeLayout(false);
            driveSearchGB.PerformLayout();
            manualOpenGB.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button searchButtonDriveSearch;
        private Label drivePathLabelDriveSearh;
        private Button selectDriveButtonDriveSearch;
        private Label infoLabelDriveSearch;
        private Button openFileButtonDriveSearch;
        private TreeView foundFilesTV;
        private Label foundFilesLabelDriveSearch;
        private GroupBox driveSearchGB;
        private GroupBox manualOpenGB;
        private Button openFileButtonManual;
    }
}