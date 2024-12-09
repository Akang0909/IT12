using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DarsBBQ
{
    public partial class ProductControl : UserControl

    {
        private FormCategoryAdd formCategoryAdd;
        private string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
        private int selectedProductId = 0;  // This will hold the ID of the selected product
        private adminPOS _adminPOS;
        private mainForm _mainForm;
        //private AddRecipe AddRecipe;



        //builder or constructor
        public ProductControl(adminPOS adminPOS)
        {
            InitializeComponent();
            _adminPOS = adminPOS;
            _mainForm = mainForm;
            //AddRecipe = new AddRecipe();


        }

        private void ProductControl_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategoriesIntoComboBox();// Load products into DataGridView on load
        }

        private void LoadProducts()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT product_id, name, sr_no, price, status, image FROM products"; // Query includes image
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a column to convert and display images
                    if (!dt.Columns.Contains("DisplayImage"))
                        dt.Columns.Add("DisplayImage", typeof(Image));

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["image"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])row["image"];
                            try
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    row["DisplayImage"] = Image.FromStream(ms); // Load image into column
                                }
                            }
                            catch
                            {
                                row["DisplayImage"] = null; // Fallback for invalid images
                            }
                        }
                        else
                        {
                            row["DisplayImage"] = null; // Handle missing images
                        }
                    }

                    // Bind the modified DataTable to the DataGridView
                    dtgProduct.DataSource = dt;

                    // Configure DataGridView columns
                    if (!dtgProduct.Columns.Contains("DisplayImageColumn"))
                    {
                        // Add image display column
                        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                        {
                            Name = "DisplayImageColumn",
                            HeaderText = "Image",
                            ImageLayout = DataGridViewImageCellLayout.Zoom,
                            DataPropertyName = "DisplayImage" // Bind to "DisplayImage" column
                        };
                        dtgProduct.Columns.Add(imgColumn);
                    }

                    // Hide unnecessary columns, including raw image data
                    dtgProduct.Columns["image"].Visible = false;
                    dtgProduct.Columns["DisplayImage"].Visible = false; // Optional: Hide temporary column if not needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd;
            MemoryStream ms;

            try
            {
                // Validation: Ensure all required fields are filled
                if (string.IsNullOrEmpty(txtProductName.Text) ||
                    cmbCategory.SelectedValue == null ||
                    string.IsNullOrEmpty(txtPrice.Text) ||
                    cmbStatus.SelectedItem == null ||
                    productPicture.Image == null) // Ensure an image is loaded
                {
                    MessageBox.Show("Incomplete data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validation: Ensure Product Name contains only letters
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtProductName.Text.Trim(), @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Product Name must contain only letters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation: Ensure Price is a valid positive decimal number
                if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
                {
                    MessageBox.Show("Price must be a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convert the image from the PictureBox to a JPEG byte array
                ms = new MemoryStream();
                productPicture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Save as JPEG
                byte[] imageData = ms.ToArray();

                // Prepare the SQL query to insert the product
                string query = "INSERT INTO products (name, sr_no, price, status, image) " +
                               "VALUES (@name, @category, @price, @status, @image)";

                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100);
                cmd.Parameters.Add("@category", MySqlDbType.Int32);
                cmd.Parameters.Add("@price", MySqlDbType.Decimal);
                cmd.Parameters.Add("@status", MySqlDbType.VarChar, 50);
                cmd.Parameters.Add("@image", MySqlDbType.Blob);

                cmd.Parameters["@name"].Value = txtProductName.Text.Trim();
                cmd.Parameters["@category"].Value = cmbCategory.SelectedValue; // sr_no from ComboBox
                cmd.Parameters["@price"].Value = price; // Validated price
                cmd.Parameters["@status"].Value = cmbStatus.SelectedItem.ToString();
                cmd.Parameters["@image"].Value = imageData; // Save the image as a BLOB

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts(); // Refresh DataGridView
                    _adminPOS.AddProductPanels();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }









        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd;

            try
            {
                // Ensure a row is selected in the DataGridView
                if (dtgProduct.SelectedRows.Count > 0)
                {
                    // Ensure all required fields are filled
                    if (!string.IsNullOrEmpty(txtProductName.Text) &&
                        cmbCategory.SelectedValue != null &&
                        !string.IsNullOrEmpty(txtPrice.Text) &&
                        cmbStatus.SelectedItem != null)
                    {
                        // Get the selected product ID
                        int selectedProductId = Convert.ToInt32(dtgProduct.SelectedRows[0].Cells[0].Value); // Assuming product_id is the first column

                        // Prepare the SQL query to update the product without touching the image field
                        string query = "UPDATE products SET name=@name, sr_no=@category, price=@price, status=@status WHERE product_id=@product_id";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100);
                        cmd.Parameters.Add("@category", MySqlDbType.Int32);
                        cmd.Parameters.Add("@price", MySqlDbType.Decimal);
                        cmd.Parameters.Add("@status", MySqlDbType.VarChar, 50);
                        cmd.Parameters.Add("@product_id", MySqlDbType.Int32);

                        cmd.Parameters["@name"].Value = txtProductName.Text.Trim();
                        cmd.Parameters["@category"].Value = cmbCategory.SelectedValue; // sr_no from ComboBox
                        cmd.Parameters["@price"].Value = Convert.ToDecimal(txtPrice.Text.Trim());
                        cmd.Parameters["@status"].Value = cmbStatus.SelectedItem.ToString();
                        cmd.Parameters["@product_id"].Value = selectedProductId;

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProducts(); // Refresh DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incomplete data! Please ensure all required fields are filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }



        // Helper method to retrieve the existing image if no new image is provided











        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgProduct.SelectedRows.Count > 0)
                {
                    int id = Convert.ToInt32(dtgProduct.SelectedRows[0].Cells["product_id"].Value);

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM products WHERE product_id=@product_id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@product_id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadProducts(); // Refresh DataGridView
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT product_id, name, sr_no AS category, price, status, image 
                             FROM products 
                             WHERE product_id LIKE @search
                                OR name LIKE @search 
                                OR CAST(sr_no AS CHAR) LIKE @search 
                                OR CAST(price AS CHAR) LIKE @search 
                                OR status LIKE @search";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", $"%{txtSearchProduct.Text.Trim()}%");
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Prepare a DataTable to bind to DataGridView
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Product ID", typeof(int));
                    dt.Columns.Add("Name", typeof(string));
                    dt.Columns.Add("Category", typeof(string));
                    dt.Columns.Add("Price", typeof(decimal));
                    dt.Columns.Add("Status", typeof(string));
                    dt.Columns.Add("Image", typeof(Image));

                    while (reader.Read())
                    {
                        byte[] imageBytes = reader["image"] as byte[];
                        Image image = null;

                        if (imageBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                image = Image.FromStream(ms);
                            }
                        }

                        dt.Rows.Add(
                            Convert.ToInt32(reader["product_id"]),
                            reader["name"].ToString(),
                            reader["category"].ToString(),
                            Convert.ToDecimal(reader["price"]),
                            reader["status"].ToString(),
                            image);
                    }

                    // Bind DataTable to DataGridView
                    dtgProduct.DataSource = dt;

                    // Ensure columns are set correctly
                    if (!dtgProduct.Columns.Contains("ImageColumn"))
                    {
                        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                        {
                            Name = "ImageColumn",
                            HeaderText = "Image",
                            DataPropertyName = "Image",
                            ImageLayout = DataGridViewImageCellLayout.Zoom
                        };
                        dtgProduct.Columns.Add(imageColumn);
                    }

                    // Set DataGridView column properties
                    dtgProduct.Columns["Product ID"].HeaderText = "Product ID";
                    dtgProduct.Columns["Name"].HeaderText = "Product Name";
                    dtgProduct.Columns["Category"].HeaderText = "Category";
                    dtgProduct.Columns["Price"].HeaderText = "Price";
                    dtgProduct.Columns["Status"].HeaderText = "Status";
                    dtgProduct.Columns["Image"].Visible = false; // Hide the raw image data column (optional)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void dtgProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can use this to get the selected category name
            string selectedCategory = cmbCategory.SelectedItem.ToString();
            //MessageBox.Show($"You selected: {selectedCategory}");
        }


        private void LoadCategoriesIntoComboBox()
        {
            string connectionString = "server=localhost;database=darsbbq;uid=root;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sr_no, name FROM category"; // Select both sr_no and name columns
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Bind the ComboBox with the sr_no as the ValueMember and name as the DisplayMember
                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "name"; // Display the category name
                    cmbCategory.ValueMember = "sr_no"; // Use the sr_no as the value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is not on the header row
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgProduct.Rows[e.RowIndex];

                // Populate text fields
                txtProductName.Text = selectedRow.Cells["name"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["price"].Value.ToString();

                // Populate ComboBoxes
                cmbCategory.SelectedValue = selectedRow.Cells["sr_no"].Value;
                cmbStatus.SelectedItem = selectedRow.Cells["status"].Value.ToString();

                // Load the image into the PictureBox
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT image FROM products WHERE product_id = @product_id";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(selectedRow.Cells["product_id"].Value));
                            object imageData = cmd.ExecuteScalar();

                            if (imageData != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])imageData;
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    productPicture.Image = Image.FromStream(ms);
                                    productPicture.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio
                                }
                            }
                            else
                            {
                                productPicture.Image = null; // Clear the PictureBox if no image is found
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }








        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }


        //mao ni ang pag pick ug image sulod sa local folder 
        private void btnImageProduct_Click(object sender, EventArgs e)
        {
            // Create and configure the OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // Allow only image files
            openFileDialog.Title = "Select Product Image";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the Image in productPicture control
                productPicture.Image = Image.FromFile(openFileDialog.FileName);

                // Set the SizeMode of the picture to zoom (maintain aspect ratio and fill the area)
                productPicture.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }


        private void productPicture_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        //private void btnAddRecipe_Click(object sender, EventArgs e)
        //{
        //    AddRecipe addRecipe = new AddRecipe();
        //    addRecipe.Show();
        //}

        //private void btnAddRecipe_Click(object sender, EventArgs e)
        //{
        //    AddRecipe.Show();
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
