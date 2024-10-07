namespace ELST
{
    partial class HelpWindow
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
            closeButton = new Button();
            helpRTB = new RichTextBox();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.Location = new Point(883, 409);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // helpRTB
            // 
            helpRTB.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            helpRTB.Location = new Point(0, 0);
            helpRTB.Name = "helpRTB";
            helpRTB.Size = new Size(989, 403);
            helpRTB.TabIndex = 1;
            helpRTB.Text = "";
            // 
            // HelpWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 450);
            Controls.Add(helpRTB);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "HelpWindow";
            Text = "HelpWindow";
            ResumeLayout(false);
        }

        #endregion

        private Button closeButton;
        private RichTextBox helpRTB;
    }
}