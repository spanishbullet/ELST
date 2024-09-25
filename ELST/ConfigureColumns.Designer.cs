namespace ELST
{
    partial class ConfigureColumns
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
            cancelButton = new Button();
            columnsCLB = new CheckedListBox();
            moveUpButton = new Button();
            moveDownButton = new Button();
            applyButton = new Button();
            checkAllButton = new Button();
            uncheckAllButton = new Button();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(206, 254);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(108, 29);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Close";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // columnsCLB
            // 
            columnsCLB.FormattingEnabled = true;
            columnsCLB.Location = new Point(12, 12);
            columnsCLB.Name = "columnsCLB";
            columnsCLB.Size = new Size(178, 422);
            columnsCLB.TabIndex = 5;
            // 
            // moveUpButton
            // 
            moveUpButton.Location = new Point(206, 14);
            moveUpButton.Name = "moveUpButton";
            moveUpButton.Size = new Size(108, 29);
            moveUpButton.TabIndex = 6;
            moveUpButton.Text = "Move Up";
            moveUpButton.UseVisualStyleBackColor = true;
            moveUpButton.Click += moveUpButton_Click;
            // 
            // moveDownButton
            // 
            moveDownButton.Location = new Point(206, 62);
            moveDownButton.Name = "moveDownButton";
            moveDownButton.Size = new Size(108, 29);
            moveDownButton.TabIndex = 7;
            moveDownButton.Text = "Move Down";
            moveDownButton.UseVisualStyleBackColor = true;
            moveDownButton.Click += moveDownButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(206, 206);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(108, 29);
            applyButton.TabIndex = 8;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // checkAllButton
            // 
            checkAllButton.Location = new Point(206, 110);
            checkAllButton.Name = "checkAllButton";
            checkAllButton.Size = new Size(108, 29);
            checkAllButton.TabIndex = 9;
            checkAllButton.Text = "Check All";
            checkAllButton.UseVisualStyleBackColor = true;
            checkAllButton.Click += checkAllButton_Click;
            // 
            // uncheckAllButton
            // 
            uncheckAllButton.Location = new Point(206, 158);
            uncheckAllButton.Name = "uncheckAllButton";
            uncheckAllButton.Size = new Size(108, 29);
            uncheckAllButton.TabIndex = 10;
            uncheckAllButton.Text = "Uncheck All";
            uncheckAllButton.UseVisualStyleBackColor = true;
            uncheckAllButton.Click += uncheckAllButton_Click;
            // 
            // ConfigureColumns
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 447);
            Controls.Add(uncheckAllButton);
            Controls.Add(checkAllButton);
            Controls.Add(applyButton);
            Controls.Add(moveDownButton);
            Controls.Add(moveUpButton);
            Controls.Add(columnsCLB);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ConfigureColumns";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configure Columns";
            ResumeLayout(false);
        }

        #endregion
        private Button cancelButton;
        private CheckedListBox columnsCLB;
        private Button moveUpButton;
        private Button moveDownButton;
        private Button applyButton;
        private Button checkAllButton;
        private Button uncheckAllButton;
    }
}