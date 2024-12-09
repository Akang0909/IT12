namespace DarsBBQ
{
    partial class UserController
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
            dgvUsers = new DataGridView();
            btnAddUser = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            label1 = new Label();
            txtSearchUser = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtFullname = new TextBox();
            txtEmail = new TextBox();
            txtContact = new TextBox();
            cmbRole = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(0, 225);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(800, 501);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(87, 189);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(94, 29);
            btnAddUser.TabIndex = 1;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(187, 189);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(94, 29);
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "Edit";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(287, 189);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(94, 29);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(426, 190);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 4;
            label1.Text = "Search";
            // 
            // txtSearchUser
            // 
            txtSearchUser.Location = new Point(503, 191);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.Size = new Size(248, 27);
            txtSearchUser.TabIndex = 5;
            txtSearchUser.TextChanged += txtSearchUser_TextChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(133, 29);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(248, 27);
            txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(133, 77);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(248, 27);
            txtPassword.TabIndex = 7;
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(133, 117);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(248, 27);
            txtFullname.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(503, 29);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(248, 27);
            txtEmail.TabIndex = 9;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(503, 73);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(248, 27);
            txtContact.TabIndex = 10;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "admin", "cashier" });
            cmbRole.Location = new Point(503, 117);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(248, 28);
            cmbRole.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(30, 33);
            label2.Name = "label2";
            label2.Size = new Size(87, 23);
            label2.TabIndex = 12;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(28, 77);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 13;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(28, 121);
            label4.Name = "label4";
            label4.Size = new Size(79, 23);
            label4.TabIndex = 14;
            label4.Text = "Fullname";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(426, 34);
            label5.Name = "label5";
            label5.Size = new Size(51, 23);
            label5.TabIndex = 15;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(412, 77);
            label6.Name = "label6";
            label6.Size = new Size(70, 23);
            label6.TabIndex = 16;
            label6.Text = "Contact";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(433, 121);
            label7.Name = "label7";
            label7.Size = new Size(43, 23);
            label7.TabIndex = 17;
            label7.Text = "Role";
            // 
            // UserController
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbRole);
            Controls.Add(txtContact);
            Controls.Add(txtEmail);
            Controls.Add(txtFullname);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtSearchUser);
            Controls.Add(label1);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnEditUser);
            Controls.Add(btnAddUser);
            Controls.Add(dgvUsers);
            Location = new Point(209, 0);
            Name = "UserController";
            Size = new Size(800, 726);
            Load += UserController_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsers;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Label label1;
        private TextBox txtSearchUser;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtFullname;
        private TextBox txtEmail;
        private TextBox txtContact;
        private ComboBox cmbRole;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
