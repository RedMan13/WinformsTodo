﻿namespace WinformsTodo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnAdd = new Button();
            txtDate = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtTitle = new TextBox();
            groupBox2 = new GroupBox();
            flpTodos = new FlowLayoutPanel();
            btnClearTasks = new Button();
            btnEdit = new Button();
            btnRemove = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(txtDate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTitle);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(203, 104);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create Todo";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(103, 75);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(44, 23);
            btnClear.TabIndex = 5;
            btnClear.Text = "clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(153, 75);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(44, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "save";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(58, 43);
            txtDate.Name = "txtDate";
            txtDate.PlaceholderText = "2024-04-12";
            txtDate.Size = new Size(139, 23);
            txtDate.TabIndex = 3;
            txtDate.KeyPress += txtDate_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 2;
            label2.Text = "due by:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 19);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 1;
            label1.Text = "todo:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(58, 16);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(139, 23);
            txtTitle.TabIndex = 0;
            txtTitle.KeyPress += txtTitle_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flpTodos);
            groupBox2.Controls.Add(btnClearTasks);
            groupBox2.Controls.Add(btnEdit);
            groupBox2.Controls.Add(btnRemove);
            groupBox2.Location = new Point(12, 122);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(203, 364);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Todos";
            // 
            // flpTodos
            // 
            flpTodos.AutoScroll = true;
            flpTodos.Location = new Point(6, 51);
            flpTodos.Name = "flpTodos";
            flpTodos.Size = new Size(191, 307);
            flpTodos.TabIndex = 5;
            // 
            // btnClearTasks
            // 
            btnClearTasks.Location = new Point(32, 22);
            btnClearTasks.Name = "btnClearTasks";
            btnClearTasks.Size = new Size(60, 23);
            btnClearTasks.TabIndex = 4;
            btnClearTasks.Text = "clear all";
            btnClearTasks.UseVisualStyleBackColor = true;
            btnClearTasks.Click += btnClearTasks_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(95, 22);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(39, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(140, 22);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(57, 23);
            btnRemove.TabIndex = 1;
            btnRemove.Text = "remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(227, 498);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Todo List";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox txtTitle;
        private Button btnAdd;
        private TextBox txtDate;
        private Button btnClear;
        private GroupBox groupBox2;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnClearTasks;
        private FlowLayoutPanel flpTodos;
    }
}
