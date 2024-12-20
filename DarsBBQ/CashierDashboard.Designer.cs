﻿namespace DarsBBQ
{
    partial class CashierDashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            lblTotalSales = new Label();
            label2 = new Label();
            panel2 = new Panel();
            lblTotalSalesCashier = new Label();
            label3 = new Label();
            panel3 = new Panel();
            lblTotalTransactions = new Label();
            label4 = new Label();
            chartCashierTrends = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel4 = new Panel();
            lblTopSellingProduct = new Label();
            label5 = new Label();
            label1 = new Label();
            dgvCashierStocks = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCashierTrends).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCashierStocks).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 128);
            panel1.Controls.Add(lblTotalSales);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(43, 142);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 97);
            panel1.TabIndex = 1;
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Location = new Point(93, 57);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(17, 20);
            lblTotalSales.TabIndex = 1;
            lblTotalSales.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 15);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 0;
            label2.Text = "TOTAL SALES";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 255, 255);
            panel2.Controls.Add(lblTotalSalesCashier);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(293, 142);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 97);
            panel2.TabIndex = 2;
            // 
            // lblTotalSalesCashier
            // 
            lblTotalSalesCashier.AutoSize = true;
            lblTotalSalesCashier.Location = new Point(104, 57);
            lblTotalSalesCashier.Name = "lblTotalSalesCashier";
            lblTotalSalesCashier.Size = new Size(17, 20);
            lblTotalSalesCashier.TabIndex = 2;
            lblTotalSalesCashier.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 15);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 0;
            label3.Text = "TODAY SALES";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 255, 128);
            panel3.Controls.Add(lblTotalTransactions);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(537, 142);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 97);
            panel3.TabIndex = 2;
            // 
            // lblTotalTransactions
            // 
            lblTotalTransactions.AutoSize = true;
            lblTotalTransactions.Location = new Point(101, 57);
            lblTotalTransactions.Name = "lblTotalTransactions";
            lblTotalTransactions.Size = new Size(17, 20);
            lblTotalTransactions.TabIndex = 3;
            lblTotalTransactions.Text = "0";
            lblTotalTransactions.Click += lblTotalTransactions_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 15);
            label4.Name = "label4";
            label4.Size = new Size(166, 20);
            label4.TabIndex = 1;
            label4.Text = "TODAY TRANSACTIONS";
            // 
            // chartCashierTrends
            // 
            chartArea1.Name = "ChartArea1";
            chartCashierTrends.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartCashierTrends.Legends.Add(legend1);
            chartCashierTrends.Location = new Point(43, 335);
            chartCashierTrends.Name = "chartCashierTrends";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartCashierTrends.Series.Add(series1);
            chartCashierTrends.Size = new Size(470, 369);
            chartCashierTrends.TabIndex = 3;
            chartCashierTrends.Text = "chart1";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 192, 255);
            panel4.Controls.Add(lblTopSellingProduct);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(788, 142);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 97);
            panel4.TabIndex = 3;
            // 
            // lblTopSellingProduct
            // 
            lblTopSellingProduct.AutoSize = true;
            lblTopSellingProduct.Location = new Point(24, 57);
            lblTopSellingProduct.Name = "lblTopSellingProduct";
            lblTopSellingProduct.Size = new Size(61, 20);
            lblTopSellingProduct.TabIndex = 4;
            lblTopSellingProduct.Text = "product";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 15);
            label5.Name = "label5";
            label5.Size = new Size(164, 20);
            label5.TabIndex = 2;
            label5.Text = "TOP SELLING PRODUCT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 58);
            label1.Name = "label1";
            label1.Size = new Size(144, 27);
            label1.TabIndex = 5;
            label1.Text = "Dashboard";
            // 
            // dgvCashierStocks
            // 
            dgvCashierStocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCashierStocks.Location = new Point(559, 335);
            dgvCashierStocks.Name = "dgvCashierStocks";
            dgvCashierStocks.RowHeadersWidth = 51;
            dgvCashierStocks.Size = new Size(504, 369);
            dgvCashierStocks.TabIndex = 6;
            dgvCashierStocks.CellContentClick += dgvCashierStocks_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(559, 303);
            label6.Name = "label6";
            label6.Size = new Size(148, 20);
            label6.TabIndex = 7;
            label6.Text = "Inventory Overview";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(43, 303);
            label7.Name = "label7";
            label7.Size = new Size(115, 20);
            label7.TabIndex = 8;
            label7.Text = "Product Trends\n";
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dgvCashierStocks);
            Controls.Add(label1);
            Controls.Add(panel4);
            Controls.Add(chartCashierTrends);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CashierDashboard";
            Size = new Size(1069, 726);
            Load += CashierDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartCashierTrends).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCashierStocks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCashierTrends;
        private Panel panel4;
        private Label label2;
        private Label label3;
        private Label lblTotalSales;
        private Label lblTotalSalesCashier;
        private Label label4;
        private Label label5;
        private Label lblTotalTransactions;
        private Label lblTopSellingProduct;
        private Label label1;
        private DataGridView dgvCashierStocks;
        private Label label6;
        private Label label7;
    }
}
