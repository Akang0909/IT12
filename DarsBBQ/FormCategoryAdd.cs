using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DarsBBQ
{
    public partial class FormCategoryAdd : Form
    {
        private categoryControl1 _mainForm;
        public FormCategoryAdd(categoryControl1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void btnCategoryAddClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=darsbbq;uid=root;";
            string categoryName = txtCategoryAdd.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO category (name) VALUES (@CategoryName)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCategoryAdd.Clear(); // Clear the text box after saving

                            // Reload categories in the main form (categoryControl)
                            _mainForm.LoadCategories();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void FormCategoryAdd_Load(object sender, EventArgs e)
        {


        }

        private void txtCategoryAdd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
