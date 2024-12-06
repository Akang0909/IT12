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
using System.Windows.Forms.DataVisualization.Charting;

namespace DarsBBQ
{
    public partial class CashierDashboard : UserControl
    {
        public CashierDashboard()
        {
            InitializeComponent();
        }

        private void CashierDashboard_Load(object sender, EventArgs e)
        {
            LoadTotalSales();
            LoadTodaySales();
            LoadTopSellingProduct();
            LoadTodayTransactions();
            LoadChart();
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
                            chartCashierTrends.Series.Clear();
                            chartCashierTrends.Titles.Clear();

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
                            chartCashierTrends.Series.Add(series);

                            // Add a title to the chart
                            chartCashierTrends.Titles.Add("Top 5 Most Purchased Products");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTodaySales()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT SUM(TotalAmount) FROM transactiondetails WHERE DATE(TransactionDateTime) = CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    decimal todaySales = Convert.ToDecimal(result);
                    lblTotalSalesCashier.Text = "₱" + todaySales.ToString("N2");
                    lblTotalSalesCashier.Invalidate();
                }
                else
                {
                    lblTotalSalesCashier.Text = "₱0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching today's sales: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadTotalSales()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT SUM(TotalPrice) FROM transactionitems";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    decimal totalSales = Convert.ToDecimal(result);
                    lblTotalSales.Text = "₱" + totalSales.ToString("N2");
                    lblTotalSales.Invalidate();
                }
                else
                {
                    lblTotalSales.Text = "₱0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching total sales: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Load Top Selling Product
        private void LoadTopSellingProduct()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                // Assuming transactionitems has a ProductID and Quantity columns
                string query = @"
                    SELECT ProductName, SUM(Quantity) AS TotalQuantity
                    FROM transactionitems
                    GROUP BY ProductName
                    ORDER BY TotalQuantity DESC
                    LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string topSellingProduct = reader["ProductName"].ToString();
                    int totalQuantity = Convert.ToInt32(reader["TotalQuantity"]);
                    lblTopSellingProduct.Text = topSellingProduct + " (" + totalQuantity.ToString() + " sold)";
                }
                else
                {
                    lblTopSellingProduct.Text = "No sales data available.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching top selling product: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Load Today's Transactions Count
        private void LoadTodayTransactions()
        {
            string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM transactiondetails WHERE DATE(TransactionDateTime) = CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    int transactionCount = Convert.ToInt32(result);
                    lblTotalTransactions.Text = transactionCount.ToString() + "";
                }
                else
                {
                    lblTotalTransactions.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching today's transactions: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lblTotalTransactions_Click(object sender, EventArgs e)
        {

        }
    }
}
