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
    public partial class categoryControl1 : UserControl
    {
        private categoryControl1 _categoryControl; // Rename the field

        public categoryControl1()
        {
            InitializeComponent();

        }

        private void categoryControl_Load(object sender, EventArgs e)
        {
            LoadCategories();

        }




        public void LoadCategories()
        {
            string connectionString = "server=localhost;database=darsbbq;uid=root;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM category";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dtgCategory.AutoGenerateColumns = false;
                    dtgCategory.Columns.Clear();

                    DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn
                    {
                        Name = "SrNo",
                        HeaderText = "Sr#",
                        DataPropertyName = "sr_no",
                        Width = 100
                    };
                    dtgCategory.Columns.Add(column1);

                    DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn
                    {
                        Name = "CategoryName",
                        HeaderText = "Name",
                        DataPropertyName = "name",
                        Width = 200,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    };
                    dtgCategory.Columns.Add(column2);

                    DataGridViewButtonColumn column3 = new DataGridViewButtonColumn
                    {
                        Name = "EditButton",
                        HeaderText = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };
                    dtgCategory.Columns.Add(column3);

                    DataGridViewButtonColumn column4 = new DataGridViewButtonColumn
                    {
                        Name = "DeleteButton",
                        HeaderText = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dtgCategory.Columns.Add(column4);

                    dtgCategory.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            // Create an instance of the FormCategoryAdd
            FormCategoryAdd categoryAddForm = new FormCategoryAdd(this);


            // Show the FormCategoryAdd
            categoryAddForm.ShowDialog(); // Use ShowDialog() if you want the form to be modal
        }


        private void dtgCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Debugging: Log the clicked cell
            Console.WriteLine($"Cell clicked: RowIndex = {e.RowIndex}, ColumnIndex = {e.ColumnIndex}");

            // Ensure the user clicked a valid cell
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                Console.WriteLine("Invalid cell click: Either header or out of bounds.");
                return;
            }

            // Debugging: Log the clicked column name
            string clickedColumnName = dtgCategory.Columns[e.ColumnIndex].Name;
            Console.WriteLine($"Clicked column: {clickedColumnName}");

            // Check if the clicked column is the "Delete" button
            if (clickedColumnName == "DeleteButton") // Ensure the column name matches your setup
            {
                Console.WriteLine("Delete button clicked!");

                // Debugging: Check if the unique identifier is present
                var cellValue = dtgCategory.Rows[e.RowIndex].Cells["SrNo"].Value;
                if (cellValue == null)
                {
                    Console.WriteLine("No SrNo value found in the selected row.");
                    MessageBox.Show("Unable to find the category identifier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string srNo = cellValue.ToString();
                Console.WriteLine($"SrNo of the category to delete: {srNo}");

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this category?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Console.WriteLine("User confirmed deletion.");

                    // Delete the category from the database
                    DeleteCategoryFromDatabase(srNo);

                    // Refresh the DataGridView
                    LoadCategories();

                    MessageBox.Show("Category deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Console.WriteLine("User canceled deletion.");
                }
            }
            else
            {
                Console.WriteLine("Clicked column is not the delete button.");
            }
        }


        private void DeleteCategoryFromDatabase(string srNo)
        {
            try
            {
                // Replace with your actual connection string
                string connectionString = "server=localhost;database=darsbbq;uid=root;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Prepare the DELETE query
                    string query = "DELETE FROM category WHERE sr_no = @SrNo"; // Adjust table and column name as needed
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SrNo", srNo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No category found with the specified SrNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}




