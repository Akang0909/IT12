namespace DarsBBQ
{
    partial class adminPOS
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
            splitter1 = new Splitter();
            panel1 = new Panel();
            dgvOrderList = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewButtonColumn();
            Column5 = new DataGridViewButtonColumn();
            textBox1 = new TextBox();
            label1 = new Label();
            label26 = new Label();
            cmbPaymentMethod = new ComboBox();
            btnPay = new Button();
            label27 = new Label();
            lblPesoSign = new Label();
            comboBox2 = new ComboBox();
            label29 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblTotalPrice = new Label();
            printDialog1 = new PrintDialog();
            txtCash = new TextBox();
            label2 = new Label();
            lblChange = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtReferenceId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvOrderList).BeginInit();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 726);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1069, 73);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // dgvOrderList
            // 
            dgvOrderList.AllowUserToAddRows = false;
            dgvOrderList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderList.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvOrderList.Location = new Point(458, 71);
            dgvOrderList.Name = "dgvOrderList";
            dgvOrderList.RowHeadersVisible = false;
            dgvOrderList.RowHeadersWidth = 55;
            dgvOrderList.Size = new Size(608, 458);
            dgvOrderList.TabIndex = 4;
            dgvOrderList.CellContentClick += dgvOrderList_CellContentClick;
            dgvOrderList.RowsAdded += dgvOrderList_RowsAdded;
            // 
            // Column1
            // 
            Column1.HeaderText = "ProductName";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "QTY";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "PRICE";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "EDIT";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "DELETE";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(78, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 88);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 2;
            label1.Text = "Search";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(474, 548);
            label26.Name = "label26";
            label26.Size = new Size(115, 20);
            label26.TabIndex = 7;
            label26.Text = "Payment Option";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Gcash" });
            cmbPaymentMethod.Location = new Point(625, 545);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(151, 28);
            cmbPaymentMethod.TabIndex = 8;
            cmbPaymentMethod.SelectedIndexChanged += cmbPaymentMethod_SelectedIndexChanged;
            // 
            // btnPay
            // 
            btnPay.Location = new Point(858, 676);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(172, 38);
            btnPay.TabIndex = 9;
            btnPay.Text = "Pay";
            btnPay.UseVisualStyleBackColor = true;
            btnPay.Click += btnPay_Click;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(793, 553);
            label27.Name = "label27";
            label27.Size = new Size(45, 20);
            label27.TabIndex = 11;
            label27.Text = "Total:";
            // 
            // lblPesoSign
            // 
            lblPesoSign.AutoSize = true;
            lblPesoSign.Font = new Font("Segoe UI", 20F);
            lblPesoSign.Location = new Point(858, 545);
            lblPesoSign.Name = "lblPesoSign";
            lblPesoSign.Size = new Size(40, 46);
            lblPesoSign.TabIndex = 12;
            lblPesoSign.Text = "₱";
            lblPesoSign.Click += lblPesoSign_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Food", "Drinks" });
            comboBox2.Location = new Point(314, 87);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(138, 28);
            comboBox2.TabIndex = 13;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(270, 88);
            label29.Name = "label29";
            label29.Size = new Size(42, 20);
            label29.TabIndex = 14;
            label29.Text = "Filter";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(2, 121);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(450, 605);
            flowLayoutPanel1.TabIndex = 5;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 20F);
            lblTotalPrice.Location = new Point(904, 548);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(81, 46);
            lblTotalPrice.TabIndex = 15;
            lblTotalPrice.Text = "0.00";
            lblTotalPrice.Click += lblTotalPrice_Click;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // txtCash
            // 
            txtCash.Location = new Point(625, 586);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(151, 27);
            txtCash.TabIndex = 16;
            txtCash.TextChanged += txtCash_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(512, 593);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 17;
            label2.Text = "Cash";
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 20F);
            lblChange.Location = new Point(904, 615);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(81, 46);
            lblChange.TabIndex = 18;
            lblChange.Text = "0.00";
            lblChange.Click += lblChange_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(793, 635);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 19;
            label4.Text = "Change";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(858, 609);
            label5.Name = "label5";
            label5.Size = new Size(40, 46);
            label5.TabIndex = 20;
            label5.Text = "₱";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(502, 641);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 21;
            label6.Text = "Ref. ID";
            // 
            // txtReferenceId
            // 
            txtReferenceId.Enabled = false;
            txtReferenceId.Location = new Point(625, 638);
            txtReferenceId.Name = "txtReferenceId";
            txtReferenceId.Size = new Size(151, 27);
            txtReferenceId.TabIndex = 22;
            txtReferenceId.TextChanged += txtRefID_TextChanged;
            // 
            // adminPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            Controls.Add(txtReferenceId);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblChange);
            Controls.Add(label2);
            Controls.Add(txtCash);
            Controls.Add(lblTotalPrice);
            Controls.Add(label29);
            Controls.Add(comboBox2);
            Controls.Add(lblPesoSign);
            Controls.Add(label27);
            Controls.Add(btnPay);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(label26);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(textBox1);
            Controls.Add(dgvOrderList);
            Controls.Add(panel1);
            Controls.Add(splitter1);
            Name = "adminPOS";
            Size = new Size(1069, 726);
            Load += adminPOS_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrderList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Splitter splitter1;
        private Panel panel1;
        private DataGridView dgvOrderList;
        private TextBox textBox1;
        private Label label1;
        private Label label26;
        private ComboBox cmbPaymentMethod;
        private Button btnPay;
        private Label label27;
        private Label lblPesoSign;
        private ComboBox comboBox2;
        private Label label29;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewButtonColumn Column4;
        private DataGridViewButtonColumn Column5;
        private Label lblTotalPrice;
        private PrintDialog printDialog1;
        private TextBox txtCash;
        private Label label2;
        private Label lblChange;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtReferenceId;
    }
}
