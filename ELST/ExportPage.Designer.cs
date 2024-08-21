namespace ELST
{
    partial class ExportPage
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
            typeGB = new GroupBox();
            typeCLB = new CheckedListBox();
            scopeGB = new GroupBox();
            scopeCLB = new CheckedListBox();
            closeCB = new CheckBox();
            fieldsCLB = new CheckedListBox();
            fieldsLabel = new Label();
            exportButton = new Button();
            closeButton = new Button();
            typeGB.SuspendLayout();
            scopeGB.SuspendLayout();
            SuspendLayout();
            // 
            // typeGB
            // 
            typeGB.Controls.Add(typeCLB);
            typeGB.Location = new Point(12, 7);
            typeGB.Name = "typeGB";
            typeGB.Size = new Size(250, 119);
            typeGB.TabIndex = 0;
            typeGB.TabStop = false;
            typeGB.Text = "Export to";
            // 
            // typeCLB
            // 
            typeCLB.Dock = DockStyle.Fill;
            typeCLB.FormattingEnabled = true;
            typeCLB.Items.AddRange(new object[] { "Excel Document", "Excel Document 2007", "HTML Document", "Text File (tab seperated)" });
            typeCLB.Location = new Point(3, 23);
            typeCLB.Name = "typeCLB";
            typeCLB.Size = new Size(244, 93);
            typeCLB.TabIndex = 0;
            typeCLB.MouseDown += typeCLB_MouseDown;
            // 
            // scopeGB
            // 
            scopeGB.Controls.Add(scopeCLB);
            scopeGB.Location = new Point(12, 124);
            scopeGB.Name = "scopeGB";
            scopeGB.Size = new Size(250, 74);
            scopeGB.TabIndex = 1;
            scopeGB.TabStop = false;
            scopeGB.Text = "Scope";
            // 
            // scopeCLB
            // 
            scopeCLB.Dock = DockStyle.Fill;
            scopeCLB.FormattingEnabled = true;
            scopeCLB.Items.AddRange(new object[] { "All Events", "Selected Events" });
            scopeCLB.Location = new Point(3, 23);
            scopeCLB.Name = "scopeCLB";
            scopeCLB.Size = new Size(244, 48);
            scopeCLB.TabIndex = 0;
            scopeCLB.MouseDown += scopeCLB_MouseDown;
            // 
            // closeCB
            // 
            closeCB.AutoSize = true;
            closeCB.Location = new Point(15, 204);
            closeCB.Name = "closeCB";
            closeCB.Size = new Size(209, 24);
            closeCB.TabIndex = 2;
            closeCB.Text = "Close dialog when finished";
            closeCB.UseVisualStyleBackColor = true;
            closeCB.CheckedChanged += closeCB_CheckedChanged;
            // 
            // fieldsCLB
            // 
            fieldsCLB.FormattingEnabled = true;
            fieldsCLB.Location = new Point(276, 44);
            fieldsCLB.Name = "fieldsCLB";
            fieldsCLB.Size = new Size(232, 224);
            fieldsCLB.TabIndex = 3;
            fieldsCLB.MouseDown += fieldsCLB_MouseDown;
            // 
            // fieldsLabel
            // 
            fieldsLabel.AutoSize = true;
            fieldsLabel.Location = new Point(272, 21);
            fieldsLabel.Name = "fieldsLabel";
            fieldsLabel.Size = new Size(97, 20);
            fieldsLabel.TabIndex = 4;
            fieldsLabel.Text = "Export Fields:";
            // 
            // exportButton
            // 
            exportButton.Location = new Point(31, 239);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(94, 29);
            exportButton.TabIndex = 5;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(148, 239);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(94, 29);
            closeButton.TabIndex = 6;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // ExportPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 281);
            Controls.Add(closeButton);
            Controls.Add(exportButton);
            Controls.Add(fieldsLabel);
            Controls.Add(fieldsCLB);
            Controls.Add(closeCB);
            Controls.Add(scopeGB);
            Controls.Add(typeGB);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ExportPage";
            Text = "Export Log";
            typeGB.ResumeLayout(false);
            scopeGB.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox typeGB;
        private GroupBox scopeGB;
        private CheckBox closeCB;
        private CheckedListBox fieldsCLB;
        private Label fieldsLabel;
        private Button exportButton;
        private Button closeButton;
        private CheckedListBox typeCLB;
        private CheckedListBox scopeCLB;
    }
}