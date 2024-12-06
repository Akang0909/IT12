using MySql.Data.MySqlClient;

namespace DarsBBQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Any initialization logic if needed
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            string username = txtUsername.Text.Trim(); // Remove leading and trailing spaces
            string password = txtPassword.Text.Trim(); // Remove leading and trailing spaces

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields(); // Clear the textboxes
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to get the user role based on the provided username and password
                    string query = "SELECT role FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        // Get the role from the database (assuming it exists)
                        string role = Convert.ToString(cmd.ExecuteScalar());

                        if (!string.IsNullOrEmpty(role))
                        {
                            // Check the role and navigate to the appropriate form
                            if (role.Equals("Cashier", StringComparison.OrdinalIgnoreCase))
                            {
                                Form2 form2 = new Form2(); // Navigate to Form2
                                form2.Show();
                            }
                            else if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                mainForm mainForm = new mainForm(username); // Pass username to the MainForm
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Role not recognized.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearFields(); // Clear the textboxes
                            }

                            this.Hide(); // Hide the current form
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ClearFields(); // Clear the textboxes
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields(); // Clear the textboxes in case of an exception
            }
        }

        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus(); // Optionally, set focus back to the username field
        }






        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            // Change to the hover color
            btnLogin.BackColor = Color.FromArgb(120, 30, 30); // Adjusted lighter shade
        }

        private void btnLogin_MouseLeave1(object sender, EventArgs e)
        {
            // Revert to white when mouse leaves
            btnLogin.BackColor = Color.White; // Original color
        }


    }
}
