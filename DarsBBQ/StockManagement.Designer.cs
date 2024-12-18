namespace DarsBBQ
{
    partial class StockManagement
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
            components = new System.ComponentModel.Container();
            label6 = new Label();
            dtpStockAdded = new DateTimePicker();
            label3 = new Label();
            txtQuantity = new TextBox();
            cmbStockCategory = new ComboBox();
            txtStockInName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dtpStockModified = new DateTimePicker();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            txtSearchStock = new TextBox();
            btnNewStock = new Button();
            btnDeleteStock = new Button();
            btnEditStock = new Button();
            btnSaveStock = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(50, 140);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 30;
            label6.Text = "Quantity";
            // 
            // dtpStockAdded
            // 
            dtpStockAdded.Location = new Point(550, 47);
            dtpStockAdded.Name = "dtpStockAdded";
            dtpStockAdded.Size = new Size(199, 27);
            dtpStockAdded.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 90);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 27;
            label3.Text = "Category";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(138, 133);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(199, 27);
            txtQuantity.TabIndex = 25;
            // 
            // cmbStockCategory
            // 
            cmbStockCategory.FormattingEnabled = true;
            cmbStockCategory.Location = new Point(138, 87);
            cmbStockCategory.Name = "cmbStockCategory";
            cmbStockCategory.Size = new Size(199, 28);
            cmbStockCategory.TabIndex = 24;
            // 
            // txtStockInName
            // 
            txtStockInName.Location = new Point(138, 38);
            txtStockInName.Name = "txtStockInName";
            txtStockInName.Size = new Size(199, 27);
            txtStockInName.TabIndex = 22;
            txtStockInName.TextChanged += txtStockInName_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(442, 52);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 31;
            label1.Text = "Date Added";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(426, 99);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 33;
            label2.Text = "Date Modified";
            // 
            // dtpStockModified
            // 
            dtpStockModified.Location = new Point(550, 94);
            dtpStockModified.Name = "dtpStockModified";
            dtpStockModified.Size = new Size(199, 27);
            dtpStockModified.TabIndex = 32;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 320);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(800, 406);
            dataGridView1.TabIndex = 34;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 38);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 35;
            label4.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(343, 136);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 40;
            label5.Text = "pcs";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(392, 281);
            label7.Name = "label7";
            label7.Size = new Size(53, 20);
            label7.TabIndex = 44;
            label7.Text = "Search";
            // 
            // txtSearchStock
            // 
            txtSearchStock.Location = new Point(461, 278);
            txtSearchStock.Name = "txtSearchStock";
            txtSearchStock.Size = new Size(317, 27);
            txtSearchStock.TabIndex = 45;
            txtSearchStock.TextChanged += txtSearchStock_TextChanged;
            // 
            // btnNewStock
            // 
            btnNewStock.Location = new Point(677, 171);
            btnNewStock.Name = "btnNewStock";
            btnNewStock.Size = new Size(72, 29);
            btnNewStock.TabIndex = 49;
            btnNewStock.Text = "Clear";
            btnNewStock.UseVisualStyleBackColor = true;
            btnNewStock.Click += btnNewStock_Click;
            // 
            // btnDeleteStock
            // 
            btnDeleteStock.Location = new Point(599, 171);
            btnDeleteStock.Name = "btnDeleteStock";
            btnDeleteStock.Size = new Size(72, 29);
            btnDeleteStock.TabIndex = 48;
            btnDeleteStock.Text = "Delete";
            btnDeleteStock.UseVisualStyleBackColor = true;
            btnDeleteStock.Click += btnDeleteStock_Click;
            // 
            // btnEditStock
            // 
            btnEditStock.Location = new Point(521, 216);
            btnEditStock.Name = "btnEditStock";
            btnEditStock.Size = new Size(228, 29);
            btnEditStock.TabIndex = 47;
            btnEditStock.Text = "Add Quantity";
            btnEditStock.UseVisualStyleBackColor = true;
            btnEditStock.Click += btnEditStock_Click;
            // 
            // btnSaveStock
            // 
            btnSaveStock.Location = new Point(521, 171);
            btnSaveStock.Name = "btnSaveStock";
            btnSaveStock.Size = new Size(72, 29);
            btnSaveStock.TabIndex = 46;
            btnSaveStock.Text = "Save";
            btnSaveStock.UseVisualStyleBackColor = true;
            btnSaveStock.Click += btnSaveStock_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // StockManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            Controls.Add(btnNewStock);
            Controls.Add(btnDeleteStock);
            Controls.Add(btnEditStock);
            Controls.Add(btnSaveStock);
            Controls.Add(txtSearchStock);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(dtpStockModified);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(dtpStockAdded);
            Controls.Add(label3);
            Controls.Add(txtQuantity);
            Controls.Add(cmbStockCategory);
            Controls.Add(txtStockInName);
            Location = new Point(209, 0);
            Name = "StockManagement";
            Size = new Size(800, 726);
            Load += StockManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private DateTimePicker dtpStockAdded;
        private Label label3;
        private TextBox txtQuantity;
        private ComboBox cmbStockCategory;
        private TextBox txtStockInName;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpStockModified;
        private DataGridView dataGridView1;
        private Label label4;
        private Label label5;
        private Label label7;
        private TextBox txtSearchStock;
        private Button btnNewStock;
        private Button btnDeleteStock;
        private Button btnEditStock;
        private Button btnSaveStock;
        private System.Windows.Forms.Timer timer1;
    }
}
