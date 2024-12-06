using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DarsBBQ
{
    public partial class FormCategoryEdit : Form
    {
        private string _srNo; // Unique identifier for the category
        private categoryControl1 _mainForm; // Reference to the main form
        private string srNo;

        public FormCategoryEdit(string srNo, string categoryName, categoryControl1 mainForm)
        {
            InitializeComponent();
            _srNo = srNo;
            txtCategoryEdit.Text = categoryName; // Populate with the current category name
            _mainForm = mainForm; // Save reference to main form for reloading
        }

        public FormCategoryEdit(string srNo)
        {
            this.srNo = srNo;
        }

        private void btnCategoryEditSave_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;database=darsbbq;uid=root;";
            string newCategoryName = txtCategoryEdit.Text.Trim();

            if (string.IsNullOrEmpty(newCategoryName))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Update the category name in the database
                    string query = "UPDATE category SET name = @CategoryName WHERE sr_no = @SrNo";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", newCategoryName);
                        cmd.Parameters.AddWithValue("@SrNo", _srNo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload categories in the main form
                            _mainForm.LoadCategories();

                            // Close the edit form
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCategoryEditClose_Click(object sender, EventArgs e)
        {
            // Close the form without saving changes
            this.Close();
        }

        private void txtCategoryEdit_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCategoryEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
