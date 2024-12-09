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
using System.Drawing.Printing;
using System.IO;
using PdfText = iTextSharp.text;
using PdfTextPdf = iTextSharp.text.pdf;
using IOFile = System.IO;
using System.Diagnostics;







namespace DarsBBQ
{
    public partial class adminPOS : UserControl
    {
        private Form _mainForm; // Store a reference to the main form
        private string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
        // Default constructor required by the designer
        private decimal change = 0;
        public adminPOS()
        {
            InitializeComponent();
        }

        // Constructor with a parameter for runtime usage
        public adminPOS(Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm; // Assign the passed mainForm reference
        }

        private void adminPOS_Load(object sender, EventArgs e)
        {
            // Call the method to add product panels on load
            AddProductPanels();

        }

        // Method to add product panels dynamically
        public void AddProductPanels(string searchTerm = "")
        {
            flowLayoutPanel1.Controls.Clear();  // Clear existing panels
            List<Panel> productPanels = new List<Panel>();  // Store the panels for reordering

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // If searchTerm is provided, filter products
                    string query = string.IsNullOrEmpty(searchTerm)
                        ? "SELECT * FROM products"  // Load all products if no search term
                        : "SELECT * FROM products WHERE name LIKE @searchTerm";  // Filter by name

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

                    // Add search term parameter to avoid SQL injection
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Loop through the filtered or full list of products
                    foreach (DataRow row in dt.Rows)
                    {
                        // Fetch product status
                        string productStatus = row["status"].ToString(); // Assume "Available" or "Out of Stock"

                        // Create the outer panel
                        Panel productPanel = new Panel
                        {
                            Size = new Size(213, 255),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.LightGray,
                            Enabled = productStatus == "Available" // Disable if "Out of Stock"
                        };

                        // Attach the click event handler only if the panel is enabled
                        if (productPanel.Enabled)
                        {
                            productPanel.Click += ProductPanel_Click;
                        }

                        // Create the inner panel
                        Panel innerPanel = new Panel
                        {
                            Size = new Size(193, 140),
                            Location = new Point(5, 5),
                            BackColor = Color.CadetBlue
                        };

                        // Add PictureBox to inner panel
                        PictureBox productPictureBox = new PictureBox
                        {
                            Size = new Size(193, 140),
                            Location = new Point(0, 0),
                            BackColor = Color.White,
                            SizeMode = PictureBoxSizeMode.Zoom
                        };

                        // Load the image from the database
                        if (row["image"] != DBNull.Value)
                        {
                            byte[] imageData = (byte[])row["image"];
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                productPictureBox.Image = Image.FromStream(ms);
                            }
                        }

                        innerPanel.Controls.Add(productPictureBox);
                        productPanel.Controls.Add(innerPanel);

                        // Add the product name label
                        Label lblProductName = new Label
                        {
                            Text = row["name"].ToString(),
                            Location = new Point(5, 200),
                            AutoSize = true,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleLeft
                        };

                        // Add the product price label
                        Label lblProductPrice = new Label
                        {
                            Text = $"₱{row["price"]}",
                            Location = new Point(110, 200),
                            Size = new Size(80, 20),
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            ForeColor = Color.DarkGreen,
                            TextAlign = ContentAlignment.MiddleRight
                        };

                        // Add the availability label
                        Label lblProductAvailability = new Label
                        {
                            Text = $"Availability: {productStatus}",
                            Location = new Point(5, 220),
                            AutoSize = true,
                            Font = new Font("Arial", 9, FontStyle.Regular),
                            ForeColor = productStatus == "Available" ? Color.Green : Color.Red,
                            TextAlign = ContentAlignment.MiddleLeft
                        };

                        productPanel.Controls.Add(lblProductAvailability);
                        productPanel.Controls.Add(lblProductName);
                        productPanel.Controls.Add(lblProductPrice);

                        // Add the product panel to the list (not directly to the FlowLayoutPanel)
                        productPanels.Add(productPanel);
                    }

                    // After all panels are created, apply sorting based on the search term
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        // Order panels: Place matching products at the top
                        var searchResults = productPanels
                            .Where(panel => panel.Controls.OfType<Label>()
                            .Any(lbl => lbl.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                            .ToList();

                        var nonSearchResults = productPanels
                            .Except(searchResults)
                            .ToList();

                        // First add the search results, then the non-search results
                        productPanels = searchResults.Concat(nonSearchResults).ToList();
                    }

                    // Add all panels to the FlowLayoutPanel in the sorted order
                    foreach (var panel in productPanels)
                    {
                        flowLayoutPanel1.Controls.Add(panel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        // Event handler for the Click event of the product panel
        private void ProductPanel_Click(object sender, EventArgs e)
        {
            // Get the clicked product panel
            if (sender is not Panel clickedPanel) return;

            // Optionally, provide visual feedback for the clicked panel
            clickedPanel.BackColor = Color.LightBlue;

            // Reset other panels' background color if necessary
            foreach (Control control in clickedPanel.Parent.Controls)
            {
                if (control is Panel panel && panel != clickedPanel)
                {
                    panel.BackColor = SystemColors.Control; // Default color
                }
            }

            // Find the product name and price labels inside the clicked panel
            Label lblProductName = clickedPanel.Controls
                .OfType<Label>()
                .FirstOrDefault(label => label.Font.Bold);

            Label lblProductPrice = clickedPanel.Controls
                .OfType<Label>()
                .FirstOrDefault(label => label.ForeColor == Color.DarkGreen);

            if (lblProductName != null && lblProductPrice != null)
            {
                // Get product name and price
                string productName = lblProductName.Text;
                string productPrice = lblProductPrice.Text;

                // Default quantity (can be updated later using edit button)
                int quantity = 1;

                // Check if the product already exists in the DataGridView
                foreach (DataGridViewRow row in dgvOrderList.Rows)
                {
                    if (row.Cells["Column1"].Value?.ToString() == productName) // Use "Column1" for ProductName
                    {
                        // Update quantity if product exists
                        int currentQuantity = Convert.ToInt32(row.Cells["Column2"].Value); // Use "Column2" for Quantity
                        row.Cells["Column2"].Value = currentQuantity + quantity;
                        MessageBox.Show($"Updated quantity for {productName}.", "Product Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateTotalPrice();
                        return;
                    }
                }

                // Add a new row to the DataGridView
                dgvOrderList.Rows.Add(
                    productName,  // Column1
                    quantity,     // Column2
                    productPrice, // Column3
                    "Edit",       // Column4
                    "Delete"      // Column5
                );

                MessageBox.Show($"Added {productName} to the order.", "Product Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateTotalPrice();
            }
            else
            {
                MessageBox.Show(
                    "Unable to find product details in the clicked panel.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }






        private void btnBack_Click(object sender, EventArgs e)
        {
            // Logic for the back button (if needed)
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //}

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Paint event left intentionally blank for better performance
        }

        private void dgvOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked a valid cell
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Check if the clicked column is the "Delete" button (assuming "Column5" is the delete button column)
            if (dgvOrderList.Columns[e.ColumnIndex].Name == "Column5") // Replace "Column5" with your actual delete button column name
            {
                // Confirm deletion with the user
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this order?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Remove the selected row from the DataGridView
                    dgvOrderList.Rows.RemoveAt(e.RowIndex);

                    if (dgvOrderList.Rows.Count == 0)
                    {
                        lblTotalPrice.Text = "0.00"; // Reset total price
                        lblChange.Text = "0.00"; // Reset change
                        txtCash.Clear();
                        cmbPaymentMethod.SelectedIndex = 0;
                    }
                    else
                    {
                        UpdateTotalPrice(); // Update total price for remaining rows
                        //UpdateChange(); // Update change based on updated total
                    }

                    MessageBox.Show("Order deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            // Check if the clicked column is the "Edit" button (assuming "Column4" is the edit button column)
            else if (dgvOrderList.Columns[e.ColumnIndex].Name == "Column4") // Replace "Column4" with your actual edit button column name
            {
                // Get the current quantity value from the DataGridView row
                int currentQuantity = Convert.ToInt32(dgvOrderList.Rows[e.RowIndex].Cells["column2"].Value); // Assuming "column2" is the quantity column

                // Show the QuantityActionForm dialog
                using (QuantityActionForm actionForm = new QuantityActionForm())
                {
                    // Show the dialog and get the result
                    DialogResult actionResult = actionForm.ShowDialog();

                    // Determine the user's action
                    if (actionResult == DialogResult.Yes) // "Yes" means Add
                    {
                        string quantityInput = Microsoft.VisualBasic.Interaction.InputBox(
                            "Enter the quantity to add (current: " + currentQuantity + "):",
                            "Add Quantity",
                            "0" // Default value
                        );

                        if (int.TryParse(quantityInput, out int quantityChange) && quantityChange >= 0)
                        {
                            dgvOrderList.Rows[e.RowIndex].Cells["column2"].Value = currentQuantity + quantityChange;
                            UpdateTotalPrice();
                            MessageBox.Show("Quantity updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (actionResult == DialogResult.No) // "No" means Subtract
                    {
                        string quantityInput = Microsoft.VisualBasic.Interaction.InputBox(
                            "Enter the quantity to subtract (current: " + currentQuantity + "):",
                            "Subtract Quantity",
                            "0" // Default value
                        );

                        if (int.TryParse(quantityInput, out int quantityChange) && quantityChange >= 0)
                        {
                            int newQuantity = currentQuantity - quantityChange;

                            if (newQuantity >= 0)
                            {
                                dgvOrderList.Rows[e.RowIndex].Cells["column2"].Value = newQuantity;
                                UpdateTotalPrice();
                                MessageBox.Show("Quantity updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Subtraction would result in a negative quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }






        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvOrderList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dgvOrderList.Rows)
            {
                // Assuming the price is in the third column (index 2) and the quantity is in the second column (index 1)
                if (row.Cells["column3"].Value != null && row.Cells["column2"].Value != null)
                {
                    string priceString = row.Cells["column3"].Value.ToString().Replace("₱", "").Trim();  // Remove currency symbol
                    if (decimal.TryParse(priceString, out decimal price))  // Try parsing the price
                    {
                        int quantity = Convert.ToInt32(row.Cells["column2"].Value);
                        totalPrice += price * quantity;
                    }
                    else
                    {
                        // Handle invalid price format if needed
                        MessageBox.Show("Invalid price format in row " + row.Index);
                    }
                }
            }

            lblTotalPrice.Text = totalPrice.ToString("0.00");
            //PrintReceiptAsPdf(invoiceNumber, cmbPaymentMethod.SelectedItem.ToString());
        }

        private void btnPay_Click(object sender, EventArgs e)

        {
            decimal change = Convert.ToDecimal(lblChange.Text.Trim());

            if (dgvOrderList.Rows.Count == 0)
            {
                MessageBox.Show("No items in the order list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();
            decimal totalAmount = Convert.ToDecimal(lblTotalPrice.Text);
            string invoiceNumber = "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            DateTime currentDate = DateTime.Now;

            // Retrieve values for Cash and ReferenceId
            decimal cash = 0;
            if (!decimal.TryParse(txtCash.Text.Trim(), out cash))
            {
                MessageBox.Show("Invalid cash amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the ReferenceId from the TextBox (if the payment method is GCash)
            string referenceId = paymentMethod == "Gcash" ? txtReferenceId.Text.Trim() : "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Check stock availability for the entire order first
                        bool isStockAvailable = true;
                        var stockDeductionRules = new Dictionary<string, Dictionary<string, int>>()
                {
                    { "Chiken Rice", new Dictionary<string, int> { { "Chiken", 1 }, { "Rice", 1 }, { "Spoon", 1 }, { "Cups", 1 } } },
                    { "Pork Rice", new Dictionary<string, int> { { "Pork", 1 }, { "Rice", 1 }, { "Spoon", 1 }, { "Cups", 1 } } },
                    { "Rice Only", new Dictionary<string, int> { { "Rice", 1 }, { "Spoon", 1 }, { "Cups", 1 } } },
                    { "Pork Only", new Dictionary<string, int> { { "Pork", 1 }, { "Spoon", 1 }, { "Cups", 1 } } },
                    { "Chiken Only", new Dictionary<string, int> { { "Chiken", 1 }, { "Spoon", 1 }, { "Cups", 1 } } },
                    { "Pork Refill", new Dictionary<string, int> { { "Pork", 1 } } },
                    { "Chiken Refill", new Dictionary<string, int> { { "Chiken", 1 } } },
                    { "Rice Refill", new Dictionary<string, int> { { "Rice", 1 } } }
                };


                        // Loop through each order row to check stock levels and deduct stock
                        foreach (DataGridViewRow row in dgvOrderList.Rows)
                        {
                            if (row.Cells["Column1"].Value != null && row.Cells["Column2"].Value != null && row.Cells["Column3"].Value != null)
                            {
                                string productName = row.Cells["Column1"].Value.ToString();
                                int quantity = Convert.ToInt32(row.Cells["Column2"].Value);

                                if (stockDeductionRules.ContainsKey(productName))
                                {
                                    foreach (var component in stockDeductionRules[productName])
                                    {
                                        // Check current stock before deducting
                                        string checkStockQuery = "SELECT quantity FROM stock_in WHERE name = @StockName";
                                        using (MySqlCommand cmdCheckStock = new MySqlCommand(checkStockQuery, conn))
                                        {
                                            cmdCheckStock.Parameters.AddWithValue("@StockName", component.Key);
                                            var currentStock = cmdCheckStock.ExecuteScalar();
                                            int currentQuantity = Convert.ToInt32(currentStock);

                                            // If stock is less than required quantity, set isStockAvailable to false and break out of the loop
                                            if (currentQuantity < quantity * component.Value)
                                            {
                                                isStockAvailable = false;
                                                MessageBox.Show($"Insufficient stock for {component.Key}.", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (!isStockAvailable)
                                {
                                    break; // Stop processing if stock is not sufficient
                                }
                            }
                        }

                        if (!isStockAvailable)
                        {
                            return; // If not enough stock, stop the transaction process
                        }


                        // Insert into TransactionDetails

                        string transactionItemsQuery = @"
        INSERT INTO transactionitems (InvoiceNumber, ProductName, Quantity, TotalPrice)
        VALUES (@InvoiceNumber, @ProductName, @Quantity, @TotalPrice);";

                        string updateStockQuery = @"
        UPDATE stock_in 
        SET quantity = quantity - @Deduction, 
            date_modified = @CurrentDate
        WHERE name = @StockName;";

                        foreach (DataGridViewRow row in dgvOrderList.Rows)
                        {
                            if (row.Cells["Column1"].Value != null && row.Cells["Column2"].Value != null && row.Cells["Column3"].Value != null)
                            {
                                string productName = row.Cells["Column1"].Value.ToString();
                                int quantity = Convert.ToInt32(row.Cells["Column2"].Value);
                                string priceString = row.Cells["Column3"].Value.ToString().Replace("₱", "").Trim();

                                if (decimal.TryParse(priceString, out decimal price))
                                {
                                    decimal itemTotalPrice = price * quantity;

                                    // Insert transaction item
                                    using (MySqlCommand cmdItems = new MySqlCommand(transactionItemsQuery, conn, transaction))
                                    {
                                        cmdItems.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber);
                                        cmdItems.Parameters.AddWithValue("@ProductName", productName);
                                        cmdItems.Parameters.AddWithValue("@Quantity", quantity);
                                        cmdItems.Parameters.AddWithValue("@TotalPrice", itemTotalPrice);
                                        cmdItems.ExecuteNonQuery();
                                    }

                                    // Update stock levels based on product ingredients
                                    if (stockDeductionRules.ContainsKey(productName))
                                    {
                                        foreach (var component in stockDeductionRules[productName])
                                        {
                                            using (MySqlCommand cmdStock = new MySqlCommand(updateStockQuery, conn, transaction))
                                            {
                                                cmdStock.Parameters.AddWithValue("@StockName", component.Key);
                                                cmdStock.Parameters.AddWithValue("@Deduction", quantity * component.Value);
                                                cmdStock.Parameters.AddWithValue("@CurrentDate", currentDate);
                                                cmdStock.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // Retrieve the latest itemID for transaction details
                        int latestItemID = 0;
                        string query = "SELECT itemID FROM transactionitems ORDER BY itemID DESC LIMIT 1;";
                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                latestItemID = Convert.ToInt32(result);
                            }
                            else
                            {
                                Console.WriteLine("No itemID found in the transactionitems table.");
                            }
                        }

                        // Insert transaction details
                        string transactionDetailsQuery = @"
        INSERT INTO transactiondetails (itemID, InvoiceNumber, TransactionDateTime, PaymentMethod, TotalAmount, cash, ReferenceId)
        VALUES (@itemID, @InvoiceNumber, @TransactionDateTime, @PaymentMethod, @TotalAmount, @Cash, @ReferenceId);";

                        using (MySqlCommand cmdDetails = new MySqlCommand(transactionDetailsQuery, conn, transaction))
                        {
                            cmdDetails.Parameters.AddWithValue("@itemID", latestItemID);
                            cmdDetails.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber);
                            cmdDetails.Parameters.AddWithValue("@TransactionDateTime", currentDate);
                            cmdDetails.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                            cmdDetails.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            cmdDetails.Parameters.AddWithValue("@cash", cash);
                            cmdDetails.Parameters.AddWithValue("@ReferenceId", referenceId);
                            cmdDetails.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        // Save the receipt to a file and display it
                        PrintReceiptAsPdf(invoiceNumber, paymentMethod, totalAmount, cash, change);

                        MessageBox.Show("Transaction saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbPaymentMethod.SelectedIndex = -1;
                        lblTotalPrice.Text = "0.00";
                        lblChange.Text = "0.00";
                        txtReferenceId.Clear();
                        dgvOrderList.Rows.Clear();
                        txtCash.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }






        //naa diri
        private void PrintReceiptAsPdf(string invoiceNumber, string paymentMethod, decimal totalAmount, decimal cash, decimal change)
        {

            try
            {
                // Define the directory for saving receipts
                string receiptsDirectory = @"C:\Users\User\source\Copy\DarsBBQ\Receipts";

                // Ensure the directory exists; create it if it doesn't
                if (!System.IO.Directory.Exists(receiptsDirectory))
                {
                    System.IO.Directory.CreateDirectory(receiptsDirectory);
                }

                // Define the file path for the PDF receipt
                string filePath = System.IO.Path.Combine(receiptsDirectory, $"Receipt_{invoiceNumber}.pdf");

                // Create a new PDF document with custom page size (3 inches x 7 inches for a receipt)
                var pageSize = new iTextSharp.text.Rectangle(216f, 504f); // 216 points x 504 points (3 inches x 7 inches)
                var pdfDocument = new iTextSharp.text.Document(pageSize, 10, 10, 10, 10); // Slightly adjusted margins

                // Create a PDF writer instance
                iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDocument, new System.IO.FileStream(filePath, System.IO.FileMode.Create));

                // Open the PDF document
                pdfDocument.Open();

                // Define fonts
                var headerFont = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                var regularFont = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);
                var boldFont = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD);

                // Header Section
                pdfDocument.Add(new iTextSharp.text.Paragraph("DARS BBQ", headerFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                pdfDocument.Add(new iTextSharp.text.Paragraph("Purok Talisay, Coog Mandug", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                pdfDocument.Add(new iTextSharp.text.Paragraph("Davao City, 8000", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                pdfDocument.Add(new iTextSharp.text.Paragraph("Contact: 109203853517", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });

                pdfDocument.Add(new iTextSharp.text.Paragraph("\n")); // Space

                // Receipt Details
                pdfDocument.Add(new iTextSharp.text.Paragraph($"Invoice #: {invoiceNumber}", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                pdfDocument.Add(new iTextSharp.text.Paragraph($"Date: {DateTime.Now:MM/dd/yyyy HH:mm:ss}", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });

                pdfDocument.Add(new iTextSharp.text.Paragraph("\n")); // Space

                // Product Table Header
                var table = new iTextSharp.text.pdf.PdfPTable(4) // 4 columns
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10f,
                    SpacingAfter = 10f
                };

                // Set the column widths
                table.SetWidths(new float[] { 40f, 20f, 20f, 20f });

                // Add headers to the table
                table.AddCell(new iTextSharp.text.Phrase("Product Name", boldFont));
                table.AddCell(new iTextSharp.text.Phrase("Qty", boldFont));
                table.AddCell(new iTextSharp.text.Phrase("Price", boldFont));
                table.AddCell(new iTextSharp.text.Phrase("Total", boldFont));

                decimal subtotal = 0;

                // Add product details to the table
                foreach (DataGridViewRow row in dgvOrderList.Rows)
                {
                    // Skip if any required cell (Product Name, Quantity, Price) is null or empty
                    if (row.Cells["column1"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["column1"].Value.ToString()) &&
                        row.Cells["column2"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["column2"].Value.ToString()) &&
                        row.Cells["column3"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["column3"].Value.ToString()))
                    {
                        string productName = row.Cells["column1"].Value.ToString();
                        string quantityString = row.Cells["column2"].Value.ToString();
                        string priceString = row.Cells["column3"].Value.ToString().Replace("₱", "").Trim();

                        // Attempt to parse quantity and price
                        if (int.TryParse(quantityString, out int quantity) && decimal.TryParse(priceString, out decimal price))
                        {
                            decimal itemTotalPrice = price * quantity;

                            // Add a row to the table
                            table.AddCell(new iTextSharp.text.Phrase(productName, regularFont));
                            table.AddCell(new iTextSharp.text.Phrase(quantity.ToString(), regularFont));
                            table.AddCell(new iTextSharp.text.Phrase($"₱{price:F2}", regularFont));
                            table.AddCell(new iTextSharp.text.Phrase($"₱{itemTotalPrice:F2}", regularFont));

                            subtotal += itemTotalPrice;
                        }
                        else
                        {
                            // Debugging and error message for invalid data
                            Debug.WriteLine($"Parsing Error: Product={productName}, Quantity={quantityString}, Price={priceString}");
                            MessageBox.Show($"Error parsing quantity or price for product: {productName}. Please check the values.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Add the table to the PDF
                pdfDocument.Add(table);

                // Add the totals
                pdfDocument.Add(new iTextSharp.text.Paragraph($"Subtotal:       ₱{subtotal:F2}", boldFont) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT });
                pdfDocument.Add(new iTextSharp.text.Paragraph($"Payment Method: {paymentMethod}", regularFont));
                pdfDocument.Add(new iTextSharp.text.Paragraph($"Total:          ₱{totalAmount:F2}", boldFont) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT });

                // Add Cash and Change
                pdfDocument.Add(new iTextSharp.text.Paragraph($"Cash:           ₱{cash:F2}", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT });
                pdfDocument.Add(new iTextSharp.text.Paragraph($"Change:         ₱{change:F2}", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT });

                // Footer
                pdfDocument.Add(new iTextSharp.text.Paragraph("\n")); // Space
                pdfDocument.Add(new iTextSharp.text.Paragraph("Thank you for eating with us!", boldFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                pdfDocument.Add(new iTextSharp.text.Paragraph("Please come again!", regularFont) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });

                // Close the PDF document
                pdfDocument.Close();

                // Notify the user and open the PDF
                System.Windows.Forms.MessageBox.Show($"Receipt saved at {filePath}", "Receipt Generated", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                OpenPdfFile(filePath);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error generating receipt: " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }






        private void OpenPdfFile(string filePath)
        {
            try
            {
                var processStartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath, // Path to the PDF
                    UseShellExecute = true // Opens the file with the default PDF viewer
                };
                System.Diagnostics.Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error opening receipt: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void lblTotalPrice_Click(object sender, EventArgs e)
        {

        }

        private void txtRefID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected payment method is GCash
            if (cmbPaymentMethod.SelectedItem != null && cmbPaymentMethod.SelectedItem.ToString() == "Gcash")
            {
                txtReferenceId.Enabled = true; // Enable the TextBox for input
            }
            else
            {
                txtReferenceId.Enabled = false; // Disable the TextBox
            }
        }



        private void lblChange_Click(object sender, EventArgs e)
        {

        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            // Ensure that both total amount and cash values are valid
            decimal totalAmount = Convert.ToDecimal(lblTotalPrice.Text); // lblTotalPrice holds the total amount
            decimal cash = 0;

            // Try parsing the cash value entered in the txtCash TextBox
            if (decimal.TryParse(txtCash.Text.Trim(), out cash))
            {
                // Calculate the change
                decimal change = cash - totalAmount;

                // Display the change in lblChange
                if (change < 0)
                {
                    lblChange.Text = "0.00";
                }
                else
                {
                    lblChange.Text = change.ToString("0.00");
                }
            }
            else
            {
                // If the cash entered is not valid
                lblChange.Text = "0.00";
            }
        }

        private void lblPesoSign_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text.Trim(); // Get the search term from the text box
            AddProductPanels(searchTerm); // Call the method with the search term
        }

    }
}


