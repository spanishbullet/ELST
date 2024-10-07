namespace ELST
{
    partial class LogPropertiesWindow
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
            logFileNameLB = new Label();
            sizeLB = new Label();
            createdLB = new Label();
            modifiedLB = new Label();
            accessedLB = new Label();
            closeButton = new Button();
            logFileName = new Label();
            fileCreated = new Label();
            fileModified = new Label();
            fileAccessed = new Label();
            fileSize = new Label();
            SuspendLayout();
            // 
            // logFileNameLB
            // 
            logFileNameLB.AutoSize = true;
            logFileNameLB.Location = new Point(39, 38);
            logFileNameLB.Name = "logFileNameLB";
            logFileNameLB.Size = new Size(108, 20);
            logFileNameLB.TabIndex = 0;
            logFileNameLB.Text = "Log File Name:";
            // 
            // sizeLB
            // 
            sizeLB.AutoSize = true;
            sizeLB.Location = new Point(39, 78);
            sizeLB.Name = "sizeLB";
            sizeLB.Size = new Size(66, 20);
            sizeLB.TabIndex = 1;
            sizeLB.Text = "File Size:";
            // 
            // createdLB
            // 
            createdLB.AutoSize = true;
            createdLB.Location = new Point(39, 118);
            createdLB.Name = "createdLB";
            createdLB.Size = new Size(91, 20);
            createdLB.TabIndex = 2;
            createdLB.Text = "File Created:";
            // 
            // modifiedLB
            // 
            modifiedLB.AutoSize = true;
            modifiedLB.Location = new Point(39, 158);
            modifiedLB.Name = "modifiedLB";
            modifiedLB.Size = new Size(100, 20);
            modifiedLB.TabIndex = 3;
            modifiedLB.Text = "File Modified:";
            // 
            // accessedLB
            // 
            accessedLB.AutoSize = true;
            accessedLB.Location = new Point(39, 198);
            accessedLB.Name = "accessedLB";
            accessedLB.Size = new Size(100, 20);
            accessedLB.TabIndex = 4;
            accessedLB.Text = "File Accessed:";
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            closeButton.Location = new Point(759, 246);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 11;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // logFileName
            // 
            logFileName.AutoSize = true;
            logFileName.Location = new Point(159, 38);
            logFileName.Name = "logFileName";
            logFileName.Size = new Size(121, 20);
            logFileName.TabIndex = 9;
            logFileName.Text = "logFileNameText";
            // 
            // fileCreated
            // 
            fileCreated.AutoSize = true;
            fileCreated.Location = new Point(159, 116);
            fileCreated.Name = "fileCreated";
            fileCreated.Size = new Size(82, 20);
            fileCreated.TabIndex = 6;
            fileCreated.Text = "fileCreated";
            // 
            // fileModified
            // 
            fileModified.AutoSize = true;
            fileModified.Location = new Point(159, 156);
            fileModified.Name = "fileModified";
            fileModified.Size = new Size(91, 20);
            fileModified.TabIndex = 7;
            fileModified.Text = "fileModified";
            // 
            // fileAccessed
            // 
            fileAccessed.AutoSize = true;
            fileAccessed.Location = new Point(159, 196);
            fileAccessed.Name = "fileAccessed";
            fileAccessed.Size = new Size(91, 20);
            fileAccessed.TabIndex = 8;
            fileAccessed.Text = "fileAccessed";
            // 
            // fileSize
            // 
            fileSize.AutoSize = true;
            fileSize.Location = new Point(159, 78);
            fileSize.Name = "fileSize";
            fileSize.Size = new Size(57, 20);
            fileSize.TabIndex = 5;
            fileSize.Text = "fileSize";
            // 
            // LogPropertiesWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 287);
            Controls.Add(closeButton);
            Controls.Add(logFileName);
            Controls.Add(fileAccessed);
            Controls.Add(fileModified);
            Controls.Add(fileCreated);
            Controls.Add(fileSize);
            Controls.Add(accessedLB);
            Controls.Add(modifiedLB);
            Controls.Add(createdLB);
            Controls.Add(sizeLB);
            Controls.Add(logFileNameLB);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LogPropertiesWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogPropertiesWindow";
            Deactivate += LogPropertiesWindow_Deactivate;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label logFileNameLB;
        private Label sizeLB;
        private Label createdLB;
        private Label modifiedLB;
        private Label accessedLB;
        private Button button1;
        private Button closeButton;
        private Label logFileName;
        private Label fileCreated;
        private Label fileModified;
        private Label fileAccessed;
        private Label fileSize;
    }
}