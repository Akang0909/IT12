namespace DarsBBQ
{
    partial class AddRecipe
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
            label1 = new Label();
            txtEngredients = new TextBox();
            label2 = new Label();
            txtEngredientsQty = new TextBox();
            btnSave = new Button();
            lblEngName = new Label();
            btnDone = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 422);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "Recipe Name";
            // 
            // txtEngredients
            // 
            txtEngredients.Location = new Point(225, 419);
            txtEngredients.Name = "txtEngredients";
            txtEngredients.Size = new Size(210, 27);
            txtEngredients.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(154, 470);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 2;
            label2.Text = "QTY";
            // 
            // txtEngredientsQty
            // 
            txtEngredientsQty.Location = new Point(225, 467);
            txtEngredientsQty.Name = "txtEngredientsQty";
            txtEngredientsQty.Size = new Size(210, 27);
            txtEngredientsQty.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(212, 542);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 43);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // lblEngName
            // 
            lblEngName.BackColor = Color.White;
            lblEngName.Font = new Font("Segoe UI", 10F);
            lblEngName.Location = new Point(-3, -1);
            lblEngName.Name = "lblEngName";
            lblEngName.Size = new Size(658, 264);
            lblEngName.TabIndex = 5;
            lblEngName.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(325, 542);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(110, 43);
            btnDone.TabIndex = 6;
            btnDone.Text = "Done";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click_1;
            // 
            // AddRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 660);
            Controls.Add(btnDone);
            Controls.Add(lblEngName);
            Controls.Add(btnSave);
            Controls.Add(txtEngredientsQty);
            Controls.Add(label2);
            Controls.Add(txtEngredients);
            Controls.Add(label1);
            Name = "AddRecipe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddRecipe";
            Load += AddRecipe_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtEngredients;
        private Label label2;
        private TextBox txtEngredientsQty;
        private Button btnSave;
        private Label lblEngName;
        private Button btnDone;
    }
}