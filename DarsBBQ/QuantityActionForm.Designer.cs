namespace DarsBBQ
{
    partial class QuantityActionForm
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
            btnAddQuantity = new Button();
            btnSubQuantity = new Button();
            SuspendLayout();
            // 
            // btnAddQuantity
            // 
            btnAddQuantity.DialogResult = DialogResult.Yes;
            btnAddQuantity.Location = new Point(23, 36);
            btnAddQuantity.Name = "btnAddQuantity";
            btnAddQuantity.Size = new Size(170, 82);
            btnAddQuantity.TabIndex = 0;
            btnAddQuantity.Text = "Add";
            btnAddQuantity.UseVisualStyleBackColor = true;
            // 
            // btnSubQuantity
            // 
            btnSubQuantity.DialogResult = DialogResult.No;
            btnSubQuantity.Location = new Point(221, 36);
            btnSubQuantity.Name = "btnSubQuantity";
            btnSubQuantity.Size = new Size(159, 82);
            btnSubQuantity.TabIndex = 1;
            btnSubQuantity.Text = "Remove";
            btnSubQuantity.UseVisualStyleBackColor = true;
            // 
            // QuantityActionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            ClientSize = new Size(411, 152);
            Controls.Add(btnSubQuantity);
            Controls.Add(btnAddQuantity);
            MaximizeBox = false;
            Name = "QuantityActionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuantityActionForm";
            Load += QuantityActionForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddQuantity;
        private Button btnSubQuantity;
    }
}