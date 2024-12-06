namespace DarsBBQ
{
    partial class reportControl
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
            dgvSalesReport = new DataGridView();
            dtpFrom = new DateTimePicker();
            label6 = new Label();
            label7 = new Label();
            dtpTo = new DateTimePicker();
            btnPrint = new Button();
            txtSearchSales = new TextBox();
            label12 = new Label();
            cmbPaymentMethod = new ComboBox();
            label1 = new Label();
            btnFilterSales = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            SuspendLayout();
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesReport.Location = new Point(0, 230);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.RowHeadersWidth = 51;
            dgvSalesReport.Size = new Size(800, 496);
            dgvSalesReport.TabIndex = 0;
            dgvSalesReport.CellContentClick += dgvSalesReport_CellContentClick;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(70, 26);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(260, 27);
            dtpFrom.TabIndex = 11;
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 31);
            label6.Name = "label6";
            label6.Size = new Size(43, 20);
            label6.TabIndex = 12;
            label6.Text = "From";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 79);
            label7.Name = "label7";
            label7.Size = new Size(25, 20);
            label7.TabIndex = 14;
            label7.Text = "To";
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(70, 74);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(260, 27);
            dtpTo.TabIndex = 13;
            dtpTo.ValueChanged += dtpTo_ValueChanged;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(699, 21);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(86, 41);
            btnPrint.TabIndex = 19;
            btnPrint.Text = "print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // txtSearchSales
            // 
            txtSearchSales.Location = new Point(640, 183);
            txtSearchSales.Name = "txtSearchSales";
            txtSearchSales.Size = new Size(157, 27);
            txtSearchSales.TabIndex = 23;
            txtSearchSales.TextChanged += txtSearchSales_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(572, 190);
            label12.Name = "label12";
            label12.Size = new Size(51, 20);
            label12.TabIndex = 24;
            label12.Text = "search";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Gcash" });
            cmbPaymentMethod.Location = new Point(70, 125);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(151, 28);
            cmbPaymentMethod.TabIndex = 25;
            cmbPaymentMethod.SelectedIndexChanged += cmbPaymentMethod_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 133);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 26;
            label1.Text = "Payment";
            // 
            // btnFilterSales
            // 
            btnFilterSales.Location = new Point(70, 181);
            btnFilterSales.Name = "btnFilterSales";
            btnFilterSales.Size = new Size(94, 29);
            btnFilterSales.TabIndex = 27;
            btnFilterSales.Text = "FILTER";
            btnFilterSales.UseVisualStyleBackColor = true;
            btnFilterSales.Click += btnFilterSales_Click;
            // 
            // reportControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnFilterSales);
            Controls.Add(label1);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(label12);
            Controls.Add(txtSearchSales);
            Controls.Add(btnPrint);
            Controls.Add(label7);
            Controls.Add(dtpTo);
            Controls.Add(label6);
            Controls.Add(dtpFrom);
            Controls.Add(dgvSalesReport);
            Name = "reportControl";
            Size = new Size(800, 726);
            Load += reportControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSalesReport;
        private DateTimePicker dtpFrom;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpTo;
        private Button btnPrint;
        private TextBox txtSearchSales;
        private Label label12;
        private ComboBox cmbPaymentMethod;
        private Label label1;
        private Button btnFilterSales;
    }
}
