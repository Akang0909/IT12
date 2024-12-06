using iTextSharp.text.pdf;
using iTextSharp.text;
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
    public partial class reportControl : UserControl
    {
        private string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
        public reportControl()
        {
            InitializeComponent();
        }

        private void reportControl_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            LoadSalesReport();

        }
        private void LoadSalesReport()
        {
            string query = @"SELECT 
                        td.TransactionDateTime,
                        td.InvoiceNumber,
                        td.PaymentMethod,
                        td.cash,
                        td.ReferenceId,
                        ti.ProductName,
                        ti.Quantity,
                        ti.TotalPrice,
                        td.TotalAmount
                     FROM 
                        transactiondetails td
                     JOIN 
                        transactionitems ti
                     ON 
                        td.InvoiceNumber = ti.InvoiceNumber
                     ORDER BY 
                        td.TransactionDateTime";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvSalesReport.DataSource = table;
                    }
                }
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }



        private void btnFilterSales_Click(object sender, EventArgs e)
        {
            string paymentMethod = cmbPaymentMethod.SelectedItem?.ToString(); // Get selected payment method
            DateTime startDate = dtpFrom.Value.Date; // Get start date from dtpFrom
            DateTime endDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1); // Get end date from dtpTo (end of the day)

            FilterSalesReport(startDate, endDate, paymentMethod);
        }

        private void FilterSalesReport(DateTime startDate, DateTime endDate, string paymentMethod)
        {
            string query = @"SELECT 
                        td.TransactionDateTime,
                        td.InvoiceNumber,
                        td.PaymentMethod,
                        ti.ProductName,
                        ti.Quantity,
                        ti.TotalPrice,
                        td.TotalAmount,
                        td.ReferenceId
                     FROM 
                        transactiondetails td
                     JOIN 
                        transactionitems ti
                     ON 
                        td.InvoiceNumber = ti.InvoiceNumber
                     WHERE 
                        td.TransactionDateTime BETWEEN @StartDate AND @EndDate";

            // If a payment method is selected, add it to the query filter
            if (!string.IsNullOrEmpty(paymentMethod))
            {
                query += " AND td.PaymentMethod = @PaymentMethod";
            }

            query += " ORDER BY td.TransactionDateTime";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Add parameters for date range and payment method
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    if (!string.IsNullOrEmpty(paymentMethod))
                    {
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvSalesReport.DataSource = table;
                    }
                }
            }
        }

        private void txtSearchSales_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchSales.Text.Trim();
            SearchSalesReport(searchText);
        }
        private void SearchSalesReport(string searchText)
        {
            string query = @"SELECT 
                        td.TransactionDateTime,
                        td.InvoiceNumber,
                        td.PaymentMethod,
                        td.ReferenceId,
                        ti.ProductName,
                        ti.Quantity,
                        ti.TotalPrice,
                        td.TotalAmount
                     FROM 
                        transactiondetails td
                     JOIN 
                        transactionitems ti
                     ON 
                        td.InvoiceNumber = ti.InvoiceNumber";

            // If there's a search text, add a WHERE clause
            if (!string.IsNullOrEmpty(searchText))
            {
                query += @" WHERE 
                        td.InvoiceNumber LIKE @SearchText OR
                        td.PaymentMethod LIKE @SearchText OR
                        td.ReferenceId LIKE @SearchText OR
                        ti.ProductName LIKE @SearchText";
            }

            query += " ORDER BY td.TransactionDateTime";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Add the parameter for search text
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvSalesReport.DataSource = table;
                    }
                }
            }
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Define the folder and file path for the PDF report
            string folderPath = @"C:\Users\User\source\Copy\DarsBBQ\SalesReport";

            // Ensure the directory exists, create it if necessary
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Define the full path for the PDF file
            string filePath = Path.Combine(folderPath, "SalesReport.pdf");

            // Create the PDF file
            CreateSalesReportPdf(filePath);

            // Check if the PDF was created successfully and then open it
            if (File.Exists(filePath))
            {
                OpenSalesReportPdf(filePath); // Open the PDF after creation
            }
            else
            {
                MessageBox.Show("Failed to create the Sales Report PDF.");
            }
        }

        private void OpenSalesReportPdf(string filePath)
        {
            try
            {
                // Set up the process to open the PDF with the default PDF viewer
                var processStartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath, // Path to the PDF
                    UseShellExecute = true // Use the default system viewer to open the file
                };

                // Start the process to open the file
                System.Diagnostics.Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                // Show error message if there's an issue opening the file
                MessageBox.Show($"Error opening sales report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateSalesReportPdf(string filePath)
        {
            Document doc = new Document();

            try
            {
                // Initialize the PDF writer to save the document to the specified path
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                // Open the document to start adding content
                doc.Open();

                // Add a title to the PDF
                doc.Add(new Paragraph("Sales Report"));

                // Create a table in the PDF with the same number of columns as your DataGridView
                PdfPTable pdfTable = new PdfPTable(dgvSalesReport.ColumnCount);

                // Add column headers to the table
                foreach (DataGridViewColumn column in dgvSalesReport.Columns)
                {
                    pdfTable.AddCell(new Phrase(column.HeaderText));
                }

                // Add data rows from the DataGridView to the table
                foreach (DataGridViewRow row in dgvSalesReport.Rows)
                {
                    if (row.IsNewRow) continue; // Skip the empty new row
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty); // Handle null values
                    }
                }

                // Add the table to the PDF document
                doc.Add(pdfTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating the Sales Report PDF: " + ex.Message);
            }
            finally
            {
                doc.Close();
            }
        }

        private void dgvSalesReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
