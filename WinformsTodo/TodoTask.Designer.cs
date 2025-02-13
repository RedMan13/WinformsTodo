namespace WinformsTodo
{
    partial class TodoTask
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chkCompleted = new CheckBox();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // chkCompleted
            // 
            chkCompleted.AutoSize = true;
            chkCompleted.Location = new Point(3, 1);
            chkCompleted.Name = "chkCompleted";
            chkCompleted.Size = new Size(15, 14);
            chkCompleted.TabIndex = 0;
            chkCompleted.UseVisualStyleBackColor = true;
            chkCompleted.CheckedChanged += chkCompleted_CheckedChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(24, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(75, 15);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "--/--/-- Fatal";
            lblTitle.Click += lblTitle_Click;
            // 
            // TodoTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(lblTitle);
            Controls.Add(chkCompleted);
            Name = "TodoTask";
            Size = new Size(191, 15);
            Click += TodoTask_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkCompleted;
        private Label lblTitle;
    }
}
