namespace DarsBBQ
{
    partial class Form2
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
            button10 = new Button();
            btnLogOut = new Button();
            btnCashierDashboard = new Button();
            cashierDashboard1 = new CashierDashboard();
            adminpos1 = new adminPOS();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(86, 0, 0);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(btnLogOut);
            panel1.Controls.Add(btnCashierDashboard);
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(134, 726);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // button10
            // 
            button10.Location = new Point(0, 160);
            button10.Name = "button10";
            button10.Size = new Size(130, 43);
            button10.TabIndex = 9;
            button10.Text = "POS";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(0, 658);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(130, 43);
            btnLogOut.TabIndex = 8;
            btnLogOut.Text = "LOG OUT";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnCashierDashboard
            // 
            btnCashierDashboard.Location = new Point(0, 111);
            btnCashierDashboard.Name = "btnCashierDashboard";
            btnCashierDashboard.Size = new Size(130, 43);
            btnCashierDashboard.TabIndex = 4;
            btnCashierDashboard.Text = "DASHBOARD";
            btnCashierDashboard.UseVisualStyleBackColor = true;
            btnCashierDashboard.Click += button5_Click;
            // 
            // cashierDashboard1
            // 
            cashierDashboard1.BackColor = Color.White;
            cashierDashboard1.Location = new Point(142, 1);
            cashierDashboard1.Name = "cashierDashboard1";
            cashierDashboard1.Size = new Size(1064, 726);
            cashierDashboard1.TabIndex = 2;
            cashierDashboard1.Load += cashierDashboard1_Load;
            // 
            // adminpos1
            // 
            adminpos1.BackColor = Color.Beige;
            adminpos1.Location = new Point(135, 1);
            adminpos1.Name = "adminpos1";
            adminpos1.Size = new Size(1071, 726);
            adminpos1.TabIndex = 3;
            adminpos1.Visible = false;
            adminpos1.Load += adminpos1_Load_1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1205, 726);
            Controls.Add(adminpos1);
            Controls.Add(cashierDashboard1);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DARSBBQ";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button button10;
        private Button btnLogOut;
        private Button btnCashierDashboard;
        private CashierDashboard cashierDashboard1;
        private adminPOS adminpos1;
    }
}