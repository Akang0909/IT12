namespace DarsBBQ
{
    partial class categoryControl1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(categoryControl1));
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            btnCategoryAdd = new Button();
            dtgCategory = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewImageColumn();
            Column4 = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dtgCategory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 52);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Categories";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(465, 140);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 1;
            label2.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(524, 133);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(257, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnCategoryAdd
            // 
            btnCategoryAdd.Location = new Point(21, 136);
            btnCategoryAdd.Name = "btnCategoryAdd";
            btnCategoryAdd.Size = new Size(94, 29);
            btnCategoryAdd.TabIndex = 3;
            btnCategoryAdd.Text = "Add";
            btnCategoryAdd.UseVisualStyleBackColor = true;
            btnCategoryAdd.Click += btnCategoryAdd_Click;
            // 
            // dtgCategory
            // 
            dtgCategory.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(239, 231, 243);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dtgCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtgCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCategory.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dtgCategory.Location = new Point(21, 185);
            dtgCategory.Name = "dtgCategory";
            dtgCategory.RowHeadersVisible = false;
            dtgCategory.RowHeadersWidth = 51;
            dtgCategory.Size = new Size(761, 521);
            dtgCategory.TabIndex = 4;
            dtgCategory.CellClick += dtgCategory_CellClick;
            dtgCategory.CellContentClick += dtgCategory_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "SR#";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Name";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "";
            Column3.Image = (Image)resources.GetObject("Column3.Image");
            Column3.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "";
            Column4.Image = (Image)resources.GetObject("Column4.Image");
            Column4.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // categoryControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dtgCategory);
            Controls.Add(btnCategoryAdd);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Location = new Point(209, 0);
            Name = "categoryControl1";
            Size = new Size(800, 726);
            Load += categoryControl_Load;
            ((System.ComponentModel.ISupportInitialize)dtgCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSearch;
        private Button btnCategoryAdd;
        private DataGridView dtgCategory;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewImageColumn Column3;
        private DataGridViewImageColumn Column4;
        private mainForm mainForm;
        private categoryControl1 categoryControl;
    }
}
