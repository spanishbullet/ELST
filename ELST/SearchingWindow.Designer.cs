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
            directoriesLB = new Label();
            numDirectoriesLB = new Label();
            SuspendLayout();
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(129, 30);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(208, 20);
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Searching for files of interest...";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(186, 108);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // directoriesLB
            // 
            directoriesLB.AutoSize = true;
            directoriesLB.Location = new Point(129, 67);
            directoriesLB.Name = "directoriesLB";
            directoriesLB.Size = new Size(154, 20);
            directoriesLB.TabIndex = 4;
            directoriesLB.Text = "Directories Processed:";
            // 
            // numDirectoriesLB
            // 
            numDirectoriesLB.AutoSize = true;
            numDirectoriesLB.Location = new Point(289, 67);
            numDirectoriesLB.Name = "numDirectoriesLB";
            numDirectoriesLB.Size = new Size(17, 20);
            numDirectoriesLB.TabIndex = 5;
            numDirectoriesLB.Text = "0";
            // 
            // SearchingWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(485, 162);
            Controls.Add(numDirectoriesLB);
            Controls.Add(directoriesLB);
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
        private Label directoriesLB;
        private Label numDirectoriesLB;
    }
}