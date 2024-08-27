namespace ELST
{
    partial class FilterWindow
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
            eventTypeGB = new GroupBox();
            eventTypesCLB = new CheckedListBox();
            sourceLabel = new Label();
            categoryLabel = new Label();
            userLabel = new Label();
            computerLabel = new Label();
            eventIDLabel = new Label();
            eventIDInstructionsLabel = new Label();
            eventIDTB = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            clearButton = new Button();
            okButton = new Button();
            testTB = new TextBox();
            testLabel = new Label();
            eventTypeGB.SuspendLayout();
            SuspendLayout();
            // 
            // eventTypeGB
            // 
            eventTypeGB.Controls.Add(eventTypesCLB);
            eventTypeGB.Location = new Point(12, 12);
            eventTypeGB.Name = "eventTypeGB";
            eventTypeGB.Size = new Size(223, 187);
            eventTypeGB.TabIndex = 0;
            eventTypeGB.TabStop = false;
            eventTypeGB.Text = "Event Types";
            // 
            // eventTypesCLB
            // 
            eventTypesCLB.Dock = DockStyle.Fill;
            eventTypesCLB.FormattingEnabled = true;
            eventTypesCLB.Items.AddRange(new object[] { "Information", "Warning", "Error", "Critical", "Verbose", "Audit Success", "Audit Failure" });
            eventTypesCLB.Location = new Point(3, 23);
            eventTypesCLB.Name = "eventTypesCLB";
            eventTypesCLB.Size = new Size(217, 161);
            eventTypesCLB.TabIndex = 0;
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.Location = new Point(241, 24);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new Size(57, 20);
            sourceLabel.TabIndex = 1;
            sourceLabel.Text = "Source:";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(241, 62);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(72, 20);
            categoryLabel.TabIndex = 2;
            categoryLabel.Text = "Category:";
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new Point(241, 100);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(41, 20);
            userLabel.TabIndex = 3;
            userLabel.Text = "User:";
            // 
            // computerLabel
            // 
            computerLabel.AutoSize = true;
            computerLabel.Location = new Point(241, 138);
            computerLabel.Name = "computerLabel";
            computerLabel.Size = new Size(78, 20);
            computerLabel.TabIndex = 4;
            computerLabel.Text = "Computer:";
            // 
            // eventIDLabel
            // 
            eventIDLabel.AutoSize = true;
            eventIDLabel.Location = new Point(15, 202);
            eventIDLabel.Name = "eventIDLabel";
            eventIDLabel.Size = new Size(83, 20);
            eventIDLabel.TabIndex = 5;
            eventIDLabel.Text = "Event ID(s):";
            // 
            // eventIDInstructionsLabel
            // 
            eventIDInstructionsLabel.AutoSize = true;
            eventIDInstructionsLabel.Location = new Point(15, 249);
            eventIDInstructionsLabel.Name = "eventIDInstructionsLabel";
            eventIDInstructionsLabel.Size = new Size(103, 20);
            eventIDInstructionsLabel.TabIndex = 6;
            eventIDInstructionsLabel.Text = "ID Instructions";
            // 
            // eventIDTB
            // 
            eventIDTB.Location = new Point(15, 222);
            eventIDTB.Name = "eventIDTB";
            eventIDTB.Size = new Size(670, 27);
            eventIDTB.TabIndex = 8;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(329, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(355, 27);
            textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(330, 135);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(355, 27);
            textBox2.TabIndex = 17;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(329, 97);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(355, 27);
            textBox3.TabIndex = 18;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(330, 59);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(355, 27);
            textBox4.TabIndex = 19;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(590, 369);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(94, 29);
            clearButton.TabIndex = 21;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // okButton
            // 
            okButton.Location = new Point(694, 369);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 22;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // testTB
            // 
            testTB.Location = new Point(91, 315);
            testTB.Name = "testTB";
            testTB.Size = new Size(125, 27);
            testTB.TabIndex = 23;
            testTB.Text = "test";
            // 
            // testLabel
            // 
            testLabel.AutoSize = true;
            testLabel.Location = new Point(26, 316);
            testLabel.Name = "testLabel";
            testLabel.Size = new Size(33, 20);
            testLabel.TabIndex = 24;
            testLabel.Text = "test";
            // 
            // FilterWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 410);
            Controls.Add(testLabel);
            Controls.Add(testTB);
            Controls.Add(okButton);
            Controls.Add(clearButton);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(eventIDTB);
            Controls.Add(eventIDInstructionsLabel);
            Controls.Add(eventIDLabel);
            Controls.Add(computerLabel);
            Controls.Add(userLabel);
            Controls.Add(categoryLabel);
            Controls.Add(sourceLabel);
            Controls.Add(eventTypeGB);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FilterWindow";
            Text = "FilterWindow";
            eventTypeGB.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox eventTypeGB;
        private CheckedListBox eventTypesCLB;
        private Label sourceLabel;
        private Label categoryLabel;
        private Label userLabel;
        private Label computerLabel;
        private Label eventIDLabel;
        private Label eventIDInstructionsLabel;
        private TextBox eventIDTB;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button clearButton;
        private Button okButton;
        private TextBox testTB;
        private Label testLabel;
    }
}