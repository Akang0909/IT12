using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DarsBBQ
{
    public partial class StockManagement : UserControl
    {
        private string connectionString = "Server=localhost;Database=darsbbq;User Id=root;Password=;";


        public StockManagement()
        {
            InitializeComponent();
            timer1.Interval = 30000; // Refresh every 30 seconds
            timer1.Tick += timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DisplayData(); // Refresh DataGridView
        }

        // Display data in DataGridView
        private void DisplayData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT stock_in_id, name, category, quantity, date_added, date_modified FROM stock_in";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    if (row["date_added"] == DBNull.Value)
                    {
                        row["date_added"] = DateTime.Now;
                    }

                    if (row["date_modified"] == DBNull.Value)
                    {
                        row["date_modified"] = DateTime.Now;
                    }

                    // Check if the stock quantity is below the low stock threshold (e.g., 5)
                    //int quantity = Convert.ToInt32(row["quantity"]);
                    //if (quantity < 5)
                    //{
                    //    // Add a "Low Stock" tag or trigger a color change
                    //    row["quantity"] = $"{quantity} (Low Stock)";  // Optionally append text
                    //}
                }

                dataGridView1.DataSource = dt;

                // Modify header text
                dataGridView1.Columns["stock_in_id"].HeaderText = "Stock ID";
                dataGridView1.Columns["name"].HeaderText = "Product Name";
                dataGridView1.Columns["category"].HeaderText = "Category";
                dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                dataGridView1.Columns["date_added"].HeaderText = "Date Added";
                dataGridView1.Columns["date_modified"].HeaderText = "Date Modified";

                timer1.Start();

                // Optional: Highlight rows with low stock
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int quantity = Convert.ToInt32(row.Cells["quantity"].Value.ToString().Split(' ')[0]);
                    if (quantity <= 5)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;  // Highlight row in red
                        row.DefaultCellStyle.ForeColor = Color.White;  // Change text color for visibility
                    }
                }
            }
        }






        // Fetch categories and bind them to the ComboBox
        private void LoadCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT sr_no, name FROM category"; // Adjust table and column names as necessary
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                // Bind the DataTable to the ComboBox
                cmbStockCategory.DisplayMember = "name";  // Display the category name in the ComboBox
                cmbStockCategory.ValueMember = "sr_no";  // Store the category ID as the value
                cmbStockCategory.DataSource = dt;
            }
        }

        // Save Stock method (uses category ID from ComboBox)
        private void btnSaveStock_Click(object sender, EventArgs e)
        {
            string stockName = txtStockInName.Text;
            string productCategory = cmbStockCategory.Text; // Get category name directly from ComboBox
            int quantity;

            // Validate quantity input
            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return; // Exit if quantity is not valid
            }

            DateTime currentDate = DateTime.Now; // Get the current date

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO stock_in (name, category, quantity, date_added, date_modified) " +
                               "VALUES (@stockName, @productCategory, @quantity, @dateAdded, @dateModified)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@stockName", stockName);
                cmd.Parameters.AddWithValue("@productCategory", productCategory); // Save the category name
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@dateAdded", currentDate); // Set current date as date_added
                cmd.Parameters.AddWithValue("@dateModified", currentDate); // Set current date as date_modified

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock added successfully.");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

            // Refresh the DataGridView to show the updated data
            DisplayData();
        }

        // Edit Stock method (uses category ID from ComboBox)
        private void btnEditStock_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Get the stock_in_id from the selected row (assuming the column name is 'stock_in_id')
                int stockInId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["stock_in_id"].Value);

                // Validate quantity input
                int quantity;
                if (!int.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return; // Exit if quantity is not valid
                }

                DateTime currentDate = DateTime.Now; // Get the current date

                // Update query to modify only the quantity and date_modified based on stock_in_id
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "UPDATE stock_in SET quantity = quantity+@quantity, date_modified = @dateModified WHERE stock_in_id = @stockInId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@dateModified", currentDate); // Set current date as date_modified
                    cmd.Parameters.AddWithValue("@stockInId", stockInId); // Use stock_in_id to identify the record to update

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Quantity updated successfully.");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }

                // Refresh the DataGridView to show the updated data
                DisplayData();
            }
            else
            {
                MessageBox.Show("Please select a stock to edit.");
            }
        }





        private void btnDeleteStock_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int stockInId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["stock_in_id"].Value);

                // Prompt for confirmation
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this stock?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM stock_in WHERE stock_in_id = @stockInId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@stockInId", stockInId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    DisplayData(); // Refresh the DataGridView
                }
            }
            else
            {
                MessageBox.Show("Please select a stock to delete.");
            }
        }

        private void btnNewStock_Click(object sender, EventArgs e)
        {
            // Clear all fields
            txtStockInName.Clear();
            cmbStockCategory.SelectedIndex = -1; // Reset to no selection
            txtQuantity.Clear();
            dtpStockAdded.Value = DateTime.Now;
            dtpStockModified.Value = DateTime.Now;

            // Make all fields editable
            txtStockInName.ReadOnly = false;
            cmbStockCategory.Enabled = true;
            dtpStockAdded.Enabled = true;
            dtpStockModified.Enabled = true;
            txtQuantity.ReadOnly = false; // Allow quantity to be editable
            btnSaveStock.Visible = true;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            if (selectedRowIndex >= 0) // Ensure a valid row is clicked
            {
                try
                {
                    // Populate fields when a row is clicked
                    txtStockInName.Text = dataGridView1.Rows[selectedRowIndex].Cells["name"].Value.ToString();
                    string categoryName = dataGridView1.Rows[selectedRowIndex].Cells["category"].Value.ToString();
                    txtQuantity.Text = dataGridView1.Rows[selectedRowIndex].Cells["quantity"].Value.ToString();
                    dtpStockAdded.Value = Convert.ToDateTime(dataGridView1.Rows[selectedRowIndex].Cells["date_added"].Value);
                    dtpStockModified.Value = Convert.ToDateTime(dataGridView1.Rows[selectedRowIndex].Cells["date_modified"].Value);

                    // Make fields read-only
                    txtStockInName.ReadOnly = true;
                    cmbStockCategory.Enabled = false;
                    dtpStockAdded.Enabled = false;
                    dtpStockModified.Enabled = false;

                    // Find the corresponding sr_no for the category name
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "SELECT sr_no FROM category WHERE name = @categoryName";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@categoryName", categoryName);
                        conn.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int categorySrNo = Convert.ToInt32(result);
                            cmbStockCategory.SelectedValue = categorySrNo; // Set selected category by sr_no
                        }
                        else
                        {
                            cmbStockCategory.SelectedIndex = -1; // If category not found, reset combo box
                        }
                    }

                    // Allow only quantity to be editable
                    txtQuantity.ReadOnly = false;

                    // Hide the btnSaveStock button
                    btnSaveStock.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while populating data: " + ex.Message);
                }
            }
        }




        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Optionally handle cell content clicks if needed
        //}

        // Call DisplayData and LoadCategories when the user control is loaded
        private void StockManagement_Load(object sender, EventArgs e)
        {
            DisplayData(); // Refresh the data on load
            LoadCategories(); // Load categories into ComboBox
            timer1.Start();
        }

        private void txtSearchStock_TextChanged(object sender, EventArgs e)
        {
            // Get the search term entered by the user
            string searchTerm = txtSearchStock.Text.Trim();

            // If the search term is not empty, perform the search
            if (!string.IsNullOrEmpty(searchTerm))
            {
                SearchStock(searchTerm);
            }
            else
            {
                // If the search box is empty, display all data
                DisplayData();
            }
        }

        private void SearchStock(string searchTerm)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // SQL query to search stock by name or category using LIKE for partial matching
                string query = "SELECT stock_in_id, name, category, quantity, date_added, date_modified " +
                               "FROM stock_in WHERE name LIKE @searchTerm OR category LIKE @searchTerm";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                try
                {
                    conn.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    // Modify any date fields to handle DBNull
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["date_added"] == DBNull.Value)
                        {
                            row["date_added"] = DateTime.Now;
                        }

                        if (row["date_modified"] == DBNull.Value)
                        {
                            row["date_modified"] = DateTime.Now;
                        }
                    }

                    // Bind filtered data to DataGridView
                    dataGridView1.DataSource = dt;

                    // Modify header text
                    dataGridView1.Columns["stock_in_id"].HeaderText = "Stock ID";
                    dataGridView1.Columns["name"].HeaderText = "Product Name";
                    dataGridView1.Columns["category"].HeaderText = "Category";
                    dataGridView1.Columns["quantity"].HeaderText = "Quantity";
                    dataGridView1.Columns["date_added"].HeaderText = "Date Added";
                    dataGridView1.Columns["date_modified"].HeaderText = "Date Modified";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txtStockInName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}

