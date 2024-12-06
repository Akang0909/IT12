using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient; // Use MySql.Data.MySqlClient for MySQL
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace DarsBBQ
{
    public partial class dashboardControl : UserControl
    {
        public dashboardControl()
        {
            InitializeComponent();
        }


        private void dashboardControl_Load(object sender, EventArgs e)
        {
            //UpdateDashboardCounts();
            //LoadTotalSales();
        }

        //public void UpdateDashboardCounts()
        //{

        //    string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";

        //    using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();

        //            // Get total categories
        //            string queryCategory = "SELECT COUNT(*) FROM category";
        //            using (MySql.Data.MySqlClient.MySqlCommand cmdCategory = new MySql.Data.MySqlClient.MySqlCommand(queryCategory, conn))
        //            {
        //                int totalCategories = Convert.ToInt32(cmdCategory.ExecuteScalar());
        //                lblTotalCategories.Text = $"Total Categories: {totalCategories}";
        //            }

        //            // Get total products
        //            string queryProduct = "SELECT COUNT(*) FROM products";
        //            using (MySql.Data.MySqlClient.MySqlCommand cmdProduct = new MySql.Data.MySqlClient.MySqlCommand(queryProduct, conn))
        //            {
        //                int totalProducts = Convert.ToInt32(cmdProduct.ExecuteScalar());
        //                lblTotalProduct.Text = $"Total Products: {totalProducts}";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error: {ex.Message}");
        //        }
        //    }
        //}

        //private void lblTotalCategory_Click(object sender, EventArgs e)
        //{
        //    // Optionally add functionality here if needed
        //}

        private void lblTotalProduct_Click(object sender, EventArgs e)
        {
            // Optionally add functionality here if needed
        }

        private void dashboardControl_Load_1(object sender, EventArgs e)
        {

            // panel
            LoadTotalSales();
            LoadTodaySales();
            LoadTotalProductsCount();
            CountCategories();


            //graphs
            LoadSalesData();
            LoadChart();

        }

        private void lbl_total_sales_Click(object sender, EventArgs e)
        {

        }

        private void LoadChart()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            string query = @"
        SELECT 
            ProductName, 
            SUM(Quantity) AS TotalQuantity
        FROM 
            transactionitems
        GROUP BY 
            ProductName
        ORDER BY 
            TotalQuantity DESC
        LIMIT 5;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear existing chart data
                            chartTrends.Series.Clear();
                            chartTrends.Titles.Clear();

                            // Create a new series for the chart
                            Series series = new Series("Most Purchased Products")
                            {
                                ChartType = SeriesChartType.Pie
                            };

                            // Populate the chart with data
                            while (reader.Read())
                            {
                                string productName = reader["ProductName"].ToString();
                                int totalQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                                series.Points.AddXY(productName, totalQuantity);
                            }

                            // Add series to the chart
                            chartTrends.Series.Add(series);

                            // Add a title to the chart
                            chartTrends.Titles.Add("Top 5 Most Purchased Products");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTotalSales()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();  // Open the connection

                // Example query to get total sales from the database
                string query = "SELECT SUM(TotalPrice) FROM transactionitems"; // Adjust the query based on your table/column names
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();  // Executes the query and returns the result

                if (result != DBNull.Value)
                {
                    decimal totalSales = Convert.ToDecimal(result);
                    lbl_total_sales.Text = "₱" + totalSales.ToString("N2");  // Format as peso and show two decimal places
                    lbl_total_sales.Invalidate();  // Force the label to refresh
                }
                else
                {
                    lbl_total_sales.Text = "₱0.00";  // If no data found, set default value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching total sales: " + ex.Message);
            }
            finally
            {
                conn.Close();  // Ensure the connection is closed after use
            }
        }













        private void LoadTotalProductsCount()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();

                // Query to count the total number of products
                string query = "SELECT COUNT(*) FROM products";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();  // Executes the query and returns the result

                if (result != DBNull.Value)
                {
                    int totalProducts = Convert.ToInt32(result);  // Convert result to integer
                    lblTotalProduct.Text = $"{totalProducts}";  // Update the label with the count
                }
                else
                {
                    lblTotalProduct.Text = "0";  // If no data found, set default value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching total products: " + ex.Message);
            }
            finally
            {
                conn.Close();  // Ensure the connection is closed after use
            }
        }


        private void LoadTodaySales()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();  // Open the connection

                // Query to get total sales for today
                string query = "SELECT SUM(TotalAmount) FROM transactiondetails WHERE DATE(TransactionDateTime) = CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();  // Executes the query and returns the result

                if (result != DBNull.Value)
                {
                    decimal todaySales = Convert.ToDecimal(result);
                    lblTodaySales.Text = "₱" + todaySales.ToString("N2");  // Format as peso and show two decimal places
                    lblTodaySales.Invalidate();  // Force the label to refresh
                }
                else
                {
                    lblTodaySales.Text = "₱0.00";  // If no data found, set default value
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching today's sales: " + ex.Message);
            }
            finally
            {
                conn.Close();  // Ensure the connection is closed after use
            }
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTodaySales_Click(object sender, EventArgs e)
        {

        }

        private void total_categories_Click(object sender, EventArgs e)
        {

        }
        // Method to count categories
        private void CountCategories()
        {
            // Define the query to count all categories
            string query = "SELECT COUNT(*) FROM category";
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                // Create a MySqlConnection object
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a MySqlCommand object with the query
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        int categoryCount = Convert.ToInt32(command.ExecuteScalar());

                        // Display the result in a label or any control of your choice
                        total_categories.Text = "" + categoryCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Call this method in the form's Load event
        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Call the CountCategories method to display the category count
            CountCategories();
        }

        private void salesChart_Click(object sender, EventArgs e)
        {

        }

        //    private void LoadSalesData()
        //    {
        //        // Dummy data (simulating the output of your query)
        //        var salesData = new List<Tuple<DateTime, decimal>>()
        //{
        //    new Tuple<DateTime, decimal>(new DateTime(2024, 1, 1), 1000),
        //    new Tuple<DateTime, decimal>(new DateTime(2024, 1, 2), 1500),
        //    new Tuple<DateTime, decimal>(new DateTime(2024, 1, 3), 1200),
        //    new Tuple<DateTime, decimal>(new DateTime(2024, 1, 4), 1800),
        //    new Tuple<DateTime, decimal>(new DateTime(2024, 1, 5), 2000),
        //    new Tuple<DateTime, decimal>(new DateTime(2024, 1, 6), 2500),
        //    new Tuple<DateTime, decimal>(new DateTime(2024, 1, 7), 3000)
        //};

        //        try
        //        {
        //            // Clear existing data in the chart
        //            salesChart.Series.Clear();
        //            salesChart.ChartAreas.Clear();
        //            salesChart.Titles.Clear();

        //            // Create a new chart area
        //            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("SalesArea");
        //            chartArea.AxisX.Title = "Date (Months)";
        //            chartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
        //            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10);
        //            chartArea.AxisX.LabelStyle.Format = "MMM yyyy"; // Format dates as Month-Year
        //            chartArea.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
        //            chartArea.AxisX.IsLabelAutoFit = true;
        //            chartArea.AxisX.LabelStyle.Angle = -45;

        //            // Set the Y-axis to start from 0
        //            chartArea.AxisY.Minimum = 0;
        //            chartArea.AxisY.Title = "Sales";
        //            chartArea.AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
        //            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 10);
        //            chartArea.AxisY.IsLabelAutoFit = true;

        //            salesChart.ChartAreas.Add(chartArea);

        //            // Set the main title of the chart
        //            var title = new System.Windows.Forms.DataVisualization.Charting.Title
        //            {
        //                Text = "Dynamic Daily Sales Report",
        //                Font = new Font("Arial", 16, FontStyle.Bold),
        //                Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top,
        //                ForeColor = Color.Black,
        //            };
        //            salesChart.Titles.Add(title);

        //            // Create a new series for the sales chart
        //            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Sales");
        //            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //            series.BorderWidth = 2;
        //            salesChart.Series.Add(series);

        //            // Loop through the dummy data and add points to the chart
        //            foreach (var data in salesData)
        //            {
        //                DateTime saleDate = data.Item1;
        //                decimal totalSales = data.Item2;

        //                // Add the data point to the chart
        //                series.Points.AddXY(saleDate, totalSales);
        //            }

        //            // Call RecalculateAxesScale only after adding data points
        //            chartArea.RecalculateAxesScale();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //    }




        private void LoadSalesData(bool useDummyData = false)
        {
            // Dummy data (simulating the output of your query)
            var dummySalesData = new List<Tuple<DateTime, decimal>>()
    {
        new Tuple<DateTime, decimal>(new DateTime(2024, 1, 1), 1000),
        new Tuple<DateTime, decimal>(new DateTime(2024, 1, 2), 1500),
        new Tuple<DateTime, decimal>(new DateTime(2024, 1, 3), 1200),
        new Tuple<DateTime, decimal>(new DateTime(2024, 1, 4), 1800),
        new Tuple<DateTime, decimal>(new DateTime(2024, 1, 5), 2000),
        new Tuple<DateTime, decimal>(new DateTime(2024, 1, 6), 2500),
        new Tuple<DateTime, decimal>(new DateTime(2024, 1, 7), 3000)
    };

            try
            {
                // Clear existing data in the chart
                salesChart.Series.Clear();
                salesChart.ChartAreas.Clear();
                salesChart.Titles.Clear();

                // Create a new chart area
                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("SalesArea");
                chartArea.AxisX.Title = "Date (Days)";
                chartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
                chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10);
                chartArea.AxisX.LabelStyle.Format = "dd MMM yyyy"; // Format dates as Day-Month-Year
                chartArea.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
                chartArea.AxisX.IsLabelAutoFit = true;
                chartArea.AxisX.LabelStyle.Angle = -45;

                // Set the Y-axis to start from 0
                chartArea.AxisY.Minimum = 0;
                chartArea.AxisY.Title = "Sales";
                chartArea.AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
                chartArea.AxisY.LabelStyle.Font = new Font("Arial", 10);
                chartArea.AxisY.IsLabelAutoFit = true;

                salesChart.ChartAreas.Add(chartArea);

                // Set the main title of the chart
                var title = new System.Windows.Forms.DataVisualization.Charting.Title
                {
                    Text = "Dynamic Daily Sales Report",
                    Font = new Font("Arial", 16, FontStyle.Bold),
                    Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top,
                    ForeColor = Color.Black,
                };
                salesChart.Titles.Add(title);

                // Create a new series for the sales chart
                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Sales");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series.BorderWidth = 2;
                salesChart.Series.Add(series);

                if (useDummyData)
                {
                    // Use dummy data for testing
                    foreach (var data in dummySalesData)
                    {
                        series.Points.AddXY(data.Item1, data.Item2);
                    }
                }
                else
                {
                    // SQL query to fetch sales data
                    string query = @"SELECT 
                SUM(transactionitems.TotalPrice) AS total_sales, 
                DATE(transactiondetails.TransactionDateTime) AS sale_date
            FROM 
                transactionitems
            JOIN 
                transactiondetails 
            ON 
                transactionitems.itemID = transactiondetails.itemID
            GROUP BY 
                DATE(transactiondetails.TransactionDateTime)
            ORDER BY 
                sale_date ASC";

                    string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            bool hasData = false;
                            while (reader.Read())
                            {
                                DateTime saleDate = reader.GetDateTime("sale_date");
                                decimal totalSales = reader.GetDecimal("total_sales");

                                // Add the data point to the chart
                                series.Points.AddXY(saleDate, totalSales);
                                hasData = true;
                            }

                            if (!hasData)
                            {
                                MessageBox.Show("No sales data found.");
                            }
                        }
                    }
                }

                // Recalculate axes scale
                chartArea.RecalculateAxesScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        private void SalesTrendChart_Click(object sender, EventArgs e)
        {

        }

        private void chartTrends_Click(object sender, EventArgs e)
        {

        }





        //private void chart1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
