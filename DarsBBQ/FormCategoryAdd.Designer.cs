namespace DarsBBQ
{
    partial class FormCategoryAdd
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            txtCategoryAdd = new TextBox();
            btnCategorySave = new Button();
            btnCategoryAddClose = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(86, 0, 0);
            panel1.Controls.Add(label1);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(659, 73);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(294, 25);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 0;
            label1.Text = "CATEGORY";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(314, 131);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // txtCategoryAdd
            // 
            txtCategoryAdd.Location = new Point(103, 163);
            txtCategoryAdd.Multiline = true;
            txtCategoryAdd.Name = "txtCategoryAdd";
            txtCategoryAdd.Size = new Size(447, 54);
            txtCategoryAdd.TabIndex = 2;
            txtCategoryAdd.TextChanged += txtCategoryAdd_TextChanged;
            // 
            // btnCategorySave
            // 
            btnCategorySave.ForeColor = Color.Black;
            btnCategorySave.Location = new Point(221, 241);
            btnCategorySave.Name = "btnCategorySave";
            btnCategorySave.Size = new Size(94, 29);
            btnCategorySave.TabIndex = 3;
            btnCategorySave.Text = "SAVE";
            btnCategorySave.UseVisualStyleBackColor = true;
            btnCategorySave.Click += btnCategorySave_Click;
            // 
            // btnCategoryAddClose
            // 
            btnCategoryAddClose.ForeColor = Color.Black;
            btnCategoryAddClose.Location = new Point(348, 241);
            btnCategoryAddClose.Name = "btnCategoryAddClose";
            btnCategoryAddClose.Size = new Size(94, 29);
            btnCategoryAddClose.TabIndex = 4;
            btnCategoryAddClose.Text = "CLOSE";
            btnCategoryAddClose.UseVisualStyleBackColor = true;
            btnCategoryAddClose.Click += btnCategoryAddClose_Click;
            // 
            // FormCategoryAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(658, 298);
            Controls.Add(btnCategoryAddClose);
            Controls.Add(btnCategorySave);
            Controls.Add(txtCategoryAdd);
            Controls.Add(label2);
            Controls.Add(panel1);
            ForeColor = SystemColors.Control;
            MaximizeBox = false;
            Name = "FormCategoryAdd";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCategory";
            Load += FormCategoryAdd_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox txtCategoryAdd;
        private Button btnCategorySave;
        private Button btnCategoryAddClose;
    }
}