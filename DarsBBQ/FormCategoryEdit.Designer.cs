namespace DarsBBQ
{
    partial class FormCategoryEdit
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
            btnCategoryEditClose = new Button();
            btnCategoryEditSave = new Button();
            txtCategoryEdit = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCategoryEditClose
            // 
            btnCategoryEditClose.ForeColor = Color.Black;
            btnCategoryEditClose.Location = new Point(339, 250);
            btnCategoryEditClose.Name = "btnCategoryEditClose";
            btnCategoryEditClose.Size = new Size(94, 29);
            btnCategoryEditClose.TabIndex = 8;
            btnCategoryEditClose.Text = "CLOSE";
            btnCategoryEditClose.UseVisualStyleBackColor = true;
            btnCategoryEditClose.Click += btnCategoryEditClose_Click;
            // 
            // btnCategoryEditSave
            // 
            btnCategoryEditSave.ForeColor = Color.Black;
            btnCategoryEditSave.Location = new Point(212, 250);
            btnCategoryEditSave.Name = "btnCategoryEditSave";
            btnCategoryEditSave.Size = new Size(94, 29);
            btnCategoryEditSave.TabIndex = 7;
            btnCategoryEditSave.Text = "SAVE";
            btnCategoryEditSave.UseVisualStyleBackColor = true;
            btnCategoryEditSave.Click += btnCategoryEditSave_Click;
            // 
            // txtCategoryEdit
            // 
            txtCategoryEdit.Location = new Point(94, 172);
            txtCategoryEdit.Multiline = true;
            txtCategoryEdit.Name = "txtCategoryEdit";
            txtCategoryEdit.Size = new Size(447, 54);
            txtCategoryEdit.TabIndex = 6;
            txtCategoryEdit.TextChanged += txtCategoryEdit_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(305, 140);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 5;
            label2.Text = "Name";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(86, 0, 0);
            panel1.Controls.Add(label1);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(2, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(659, 73);
            panel1.TabIndex = 9;
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
            // FormCategoryEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(658, 298);
            Controls.Add(panel1);
            Controls.Add(btnCategoryEditClose);
            Controls.Add(btnCategoryEditSave);
            Controls.Add(txtCategoryEdit);
            Controls.Add(label2);
            MaximizeBox = false;
            Name = "FormCategoryEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCategoryEdit";
            Load += FormCategoryEdit_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCategoryEditClose;
        private Button btnCategoryEditSave;
        private TextBox txtCategoryEdit;
        private Label label2;
        private Panel panel1;
        private Label label1;
    }
}