namespace ELST
{
    partial class EventPropertiesPage
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
            xmlViewCB = new CheckBox();
            friendlyViewCB = new CheckBox();
            panel1 = new Panel();
            detailsLabel = new Label();
            closeButton = new Button();
            previousButton = new Button();
            nextButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // xmlViewCB
            // 
            xmlViewCB.AutoSize = true;
            xmlViewCB.Location = new Point(155, 12);
            xmlViewCB.Name = "xmlViewCB";
            xmlViewCB.Size = new Size(96, 24);
            xmlViewCB.TabIndex = 3;
            xmlViewCB.Text = "XML View";
            xmlViewCB.UseVisualStyleBackColor = true;
            xmlViewCB.CheckedChanged += xmlViewCB_CheckedChanged;
            // 
            // friendlyViewCB
            // 
            friendlyViewCB.AutoSize = true;
            friendlyViewCB.Location = new Point(12, 12);
            friendlyViewCB.Name = "friendlyViewCB";
            friendlyViewCB.Size = new Size(119, 24);
            friendlyViewCB.TabIndex = 2;
            friendlyViewCB.Text = "Friendly View";
            friendlyViewCB.UseVisualStyleBackColor = true;
            friendlyViewCB.CheckedChanged += friendlyViewCB_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(detailsLabel);
            panel1.Location = new Point(12, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(717, 480);
            panel1.TabIndex = 1;
            // 
            // detailsLabel
            // 
            detailsLabel.AutoSize = true;
            detailsLabel.BackColor = SystemColors.ButtonHighlight;
            detailsLabel.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            detailsLabel.Location = new Point(0, 0);
            detailsLabel.Name = "detailsLabel";
            detailsLabel.Size = new Size(56, 18);
            detailsLabel.TabIndex = 0;
            detailsLabel.Text = "label1";
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.Location = new Point(724, 540);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 4;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // previousButton
            // 
            previousButton.Anchor = AnchorStyles.Right;
            previousButton.Location = new Point(744, 192);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(74, 68);
            previousButton.TabIndex = 5;
            previousButton.Text = "Previous Event";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // nextButton
            // 
            nextButton.Anchor = AnchorStyles.Right;
            nextButton.Location = new Point(744, 278);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(74, 68);
            nextButton.TabIndex = 6;
            nextButton.Text = "Next Event";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // EventPropertiesPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 581);
            Controls.Add(nextButton);
            Controls.Add(previousButton);
            Controls.Add(closeButton);
            Controls.Add(xmlViewCB);
            Controls.Add(friendlyViewCB);
            Controls.Add(panel1);
            Name = "EventPropertiesPage";
            Text = "EventPropertiesPage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label detailsLabel;
        private Panel panel1;
        private CheckBox xmlViewCB;
        private CheckBox friendlyViewCB;
        private Button closeButton;
        private Button previousButton;
        private Button nextButton;
    }
}