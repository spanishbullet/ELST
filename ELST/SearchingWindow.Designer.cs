namespace ELST
{
    partial class SearchingWindow
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
            searchLabel = new Label();
            cancelButton = new Button();
            searchPB = new ProgressBar();
            progressLabel = new Label();
            SuspendLayout();
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(129, 29);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(208, 20);
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Searching for files of interest...";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(186, 168);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // searchPB
            // 
            searchPB.Location = new Point(129, 118);
            searchPB.Name = "searchPB";
            searchPB.Size = new Size(208, 29);
            searchPB.TabIndex = 2;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new Point(190, 77);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(86, 20);
            progressLabel.TabIndex = 3;
            progressLabel.Text = "Progres: 0%";
            // 
            // SearchingWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 244);
            Controls.Add(progressLabel);
            Controls.Add(searchPB);
            Controls.Add(cancelButton);
            Controls.Add(searchLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SearchingWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Searching";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label searchLabel;
        private Button cancelButton;
        private ProgressBar searchPB;
        private Label progressLabel;
    }
}