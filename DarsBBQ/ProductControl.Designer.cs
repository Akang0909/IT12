namespace DarsBBQ
{
    partial class ProductControl
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
            dtgProduct = new DataGridView();
            btnAddProduct = new Button();
            btnUpdateProduct = new Button();
            btnDeleteProduct = new Button();
            label1 = new Label();
            txtSearchProduct = new TextBox();
            txtProductName = new TextBox();
            txtPrice = new TextBox();
            cmbCategory = new ComboBox();
            cmbStatus = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label7 = new Label();
            productPicture = new PictureBox();
            btnImageProduct = new Button();
            btnAddRecipe = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productPicture).BeginInit();
            SuspendLayout();
            // 
            // dtgProduct
            // 
            dtgProduct.AllowUserToAddRows = false;
            dtgProduct.AllowUserToDeleteRows = false;
            dtgProduct.ColumnHeadersHeight = 29;
            dtgProduct.Location = new Point(0, 320);
            dtgProduct.Name = "dtgProduct";
            dtgProduct.ReadOnly = true;
            dtgProduct.RowHeadersWidth = 51;
            dtgProduct.Size = new Size(800, 406);
            dtgProduct.TabIndex = 0;
            dtgProduct.CellClick += dtgProduct_CellClick;
            dtgProduct.CellContentClick += dtgProduct_CellContentClick;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(26, 279);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(105, 29);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.Location = new Point(149, 279);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(147, 29);
            btnUpdateProduct.TabIndex = 2;
            btnUpdateProduct.Text = "Update Product";
            btnUpdateProduct.UseVisualStyleBackColor = true;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(311, 279);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(136, 29);
            btnDeleteProduct.TabIndex = 4;
            btnDeleteProduct.Text = "Delete Product:";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(554, 288);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 5;
            label1.Text = "Search";
            // 
            // txtSearchProduct
            // 
            txtSearchProduct.Location = new Point(625, 285);
            txtSearchProduct.Name = "txtSearchProduct";
            txtSearchProduct.Size = new Size(160, 27);
            txtSearchProduct.TabIndex = 6;
            txtSearchProduct.TextChanged += txtSearchProduct_TextChanged;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(292, 44);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(199, 27);
            txtProductName.TabIndex = 7;
            txtProductName.TextChanged += txtProductName_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(554, 126);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(199, 27);
            txtPrice.TabIndex = 9;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(292, 125);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(199, 28);
            cmbCategory.TabIndex = 10;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Available", "Out of Stock" });
            cmbStatus.Location = new Point(554, 45);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(199, 28);
            cmbStatus.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(292, 19);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 15;
            label2.Text = "Product Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(292, 93);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 16;
            label3.Text = "Category";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(554, 103);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 17;
            label4.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(554, 19);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 21;
            label7.Text = "Status";
            // 
            // productPicture
            // 
            productPicture.BorderStyle = BorderStyle.FixedSingle;
            productPicture.Location = new Point(41, 42);
            productPicture.Name = "productPicture";
            productPicture.Size = new Size(150, 150);
            productPicture.SizeMode = PictureBoxSizeMode.Zoom;
            productPicture.TabIndex = 22;
            productPicture.TabStop = false;
            productPicture.Click += productPicture_Click;
            // 
            // btnImageProduct
            // 
            btnImageProduct.Location = new Point(56, 199);
            btnImageProduct.Name = "btnImageProduct";
            btnImageProduct.Size = new Size(121, 29);
            btnImageProduct.TabIndex = 23;
            btnImageProduct.Text = "Choose Image";
            btnImageProduct.UseVisualStyleBackColor = true;
            btnImageProduct.Click += btnImageProduct_Click;
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Location = new Point(292, 190);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(199, 29);
            btnAddRecipe.TabIndex = 25;
            btnAddRecipe.Text = "Add Recipe";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += btnAddRecipe_Click;
            // 
            // ProductControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddRecipe);
            Controls.Add(btnImageProduct);
            Controls.Add(productPicture);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbStatus);
            Controls.Add(cmbCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtProductName);
            Controls.Add(txtSearchProduct);
            Controls.Add(label1);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnUpdateProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(dtgProduct);
            Name = "ProductControl";
            Size = new Size(800, 726);
            Load += ProductControl_Load;
            ((System.ComponentModel.ISupportInitialize)dtgProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)productPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgProduct;
        private Button btnAddProduct;
        private Button btnUpdateProduct;
        private Button btnDeleteProduct;
        private Label label1;
        private TextBox txtSearchProduct;
        private TextBox txtProductName;
        private TextBox txtPrice;
        private ComboBox cmbCategory;
        private ComboBox cmbStatus;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label7;
        private PictureBox productPicture;
        private Button btnImageProduct;
        private mainForm mainForm;
        private Button btnAddRecipe;
    }
}
