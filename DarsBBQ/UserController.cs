using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarsBBQ
{
    public partial class UserController : UserControl
    {
        public UserController()
        {
            InitializeComponent();
        }

        private void UserController_Load(object sender, EventArgs e)
        {
            LoadUsers();

        }
        private void LoadUsers()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            string query = "SELECT user_id, username, role, fullname, email, contact FROM users";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvUsers.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the clicked cell is not a header
            {
                // Get the current row based on the clicked cell
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                // Populate the text boxes with the values from the row
                txtUsername.Text = row.Cells["username"].Value.ToString();
                cmbRole.Text = row.Cells["role"].Value.ToString();
                txtFullname.Text = row.Cells["fullname"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtContact.Text = row.Cells["contact"].Value.ToString();

                // Retrieve the password securely from the database
                string userId = row.Cells["user_id"].Value.ToString();
                PopulatePassword(userId);
            }
        }


        private string selectedUserId = string.Empty;
        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a valid row was clicked
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                // Populate text boxes with the row data
                txtUsername.Text = row.Cells["username"].Value.ToString();
                cmbRole.Text = row.Cells["role"].Value.ToString();
                txtFullname.Text = row.Cells["fullname"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtContact.Text = row.Cells["contact"].Value.ToString();

                // Retrieve user_id and populate password
                string userId = row.Cells["user_id"].Value.ToString();
                PopulatePassword(selectedUserId);
                btnEditUser_Click(sender, e);// A function to get and display the password securely
            }
        }


        private void PopulatePassword(string userId)
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            string query = "SELECT password FROM users WHERE user_id = @user_id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtPassword.Text = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Password not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contact = txtContact.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            string query = "INSERT INTO users (username, password, role, fullname, email, contact) VALUES (@username, @password, @role, @fullname, @email, @contact)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contact", contact);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers(); // Refresh user list
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            // Using the selectedUserId to perform the update
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contact = txtContact.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            string query = "UPDATE users SET username = @username, password = @password, role = @role, fullname = @fullname, email = @email, contact = @contact WHERE username = @username";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        //cmd.Parameters.AddWithValue("@user_id", selectedUserId); // Use the selected user_id

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers(); // Refresh the user list after edit
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0) // Ensure a row is selected
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];

                // Extract the user_id from the row
                string userId = selectedRow.Cells["user_id"].Value.ToString();
                string userName = selectedRow.Cells["username"].Value.ToString();

                // Confirm deletion
                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete user {userName}?",
                                                       "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
                    string query = "DELETE FROM users WHERE user_id = @user_id";

                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@user_id", userId);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUsers(); // Refresh the DataGridView
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchUser.Text.Trim();
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            string query = "SELECT * FROM users WHERE username LIKE @search OR fullname LIKE @search OR email LIKE @search OR role LIKE @search";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchText}%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Assuming you have a DataGridView named dgvUsers to display the user list
                            dgvUsers.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
