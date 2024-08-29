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
            panel1.AutoScroll = true;
            panel1.Controls.Add(detailsLabel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 539);
            panel1.TabIndex = 1;
            // 
            // detailsLabel
            // 
            detailsLabel.AutoSize = true;
            detailsLabel.Location = new Point(0, 0);
            detailsLabel.Name = "detailsLabel";
            detailsLabel.Size = new Size(50, 20);
            detailsLabel.TabIndex = 0;
            detailsLabel.Text = "label1";
            // 
            // EventPropertiesPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 581);
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
    }
}