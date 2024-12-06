namespace DarsBBQ
{
    partial class dashboardControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            lbl_total_sales = new Label();
            label1 = new Label();
            panel2 = new Panel();
            lblTodaySales = new Label();
            label2 = new Label();
            panel3 = new Panel();
            total_categories = new Label();
            label4 = new Label();
            panel4 = new Panel();
            lblTotalProduct = new Label();
            label3 = new Label();
            salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label9 = new Label();
            chartTrends = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)salesChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTrends).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Goldenrod;
            panel1.Controls.Add(lbl_total_sales);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(7, 117);
            panel1.Name = "panel1";
            panel1.Size = new Size(199, 90);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lbl_total_sales
            // 
            lbl_total_sales.AutoSize = true;
            lbl_total_sales.Location = new Point(85, 51);
            lbl_total_sales.Name = "lbl_total_sales";
            lbl_total_sales.Size = new Size(33, 20);
            lbl_total_sales.TabIndex = 10;
            lbl_total_sales.Text = "500";
            lbl_total_sales.TextChanged += dashboardControl_Load;
            lbl_total_sales.Click += lbl_total_sales_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 6;
            label1.Text = "TOTAL SALES";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 102, 102);
            panel2.Controls.Add(lblTodaySales);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(222, 117);
            panel2.Name = "panel2";
            panel2.Size = new Size(179, 90);
            panel2.TabIndex = 1;
            // 
            // lblTodaySales
            // 
            lblTodaySales.AutoSize = true;
            lblTodaySales.Location = new Point(72, 51);
            lblTodaySales.Name = "lblTodaySales";
            lblTodaySales.Size = new Size(17, 20);
            lblTodaySales.TabIndex = 11;
            lblTodaySales.Text = "0";
            lblTodaySales.Click += lblTodaySales_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 9);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 7;
            label2.Text = "Today Sales";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 128, 128);
            panel3.Controls.Add(total_categories);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(609, 117);
            panel3.Name = "panel3";
            panel3.Size = new Size(179, 90);
            panel3.TabIndex = 3;
            // 
            // total_categories
            // 
            total_categories.AutoSize = true;
            total_categories.Location = new Point(74, 51);
            total_categories.Name = "total_categories";
            total_categories.Size = new Size(33, 20);
            total_categories.TabIndex = 13;
            total_categories.Text = "400";
            total_categories.Click += total_categories_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 9;
            label4.Text = "CATEGORIES";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(240, 234, 214);
            panel4.Controls.Add(lblTotalProduct);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(416, 117);
            panel4.Name = "panel4";
            panel4.Size = new Size(179, 90);
            panel4.TabIndex = 2;
            // 
            // lblTotalProduct
            // 
            lblTotalProduct.AutoSize = true;
            lblTotalProduct.Location = new Point(83, 51);
            lblTotalProduct.Name = "lblTotalProduct";
            lblTotalProduct.Size = new Size(17, 20);
            lblTotalProduct.TabIndex = 12;
            lblTotalProduct.Text = "0";
            lblTotalProduct.Click += lblTotalProduct_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 8;
            label3.Text = "Products";
            // 
            // salesChart
            // 
            chartArea1.Name = "ChartArea1";
            salesChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            salesChart.Legends.Add(legend1);
            salesChart.Location = new Point(0, 223);
            salesChart.Name = "salesChart";
            salesChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            salesChart.Series.Add(series1);
            salesChart.Size = new Size(800, 231);
            salesChart.TabIndex = 4;
            salesChart.Text = "chart1";
            salesChart.Click += salesChart_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 52);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 11;
            label9.Text = "DASHBOARD";
            // 
            // chartTrends
            // 
            chartArea2.Name = "ChartArea1";
            chartTrends.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartTrends.Legends.Add(legend2);
            chartTrends.Location = new Point(3, 476);
            chartTrends.Name = "chartTrends";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartTrends.Series.Add(series2);
            chartTrends.Size = new Size(797, 250);
            chartTrends.TabIndex = 12;
            chartTrends.Text = "chart1";
            chartTrends.Click += chartTrends_Click;
            // 
            // dashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Beige;
            Controls.Add(chartTrends);
            Controls.Add(label9);
            Controls.Add(salesChart);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "dashboardControl";
            Size = new Size(800, 726);
            Load += dashboardControl_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)salesChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTrends).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label9;
        private Label lbl_total_sales;
        private Label label1;
        private Panel panel2;
        private Label lblTodaySales;
        private Label label2;
        private Panel panel3;
        private Label total_categories;
        private Label label4;
        private Panel panel4;
        private Label lblTotalProduct;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrends;
    }
}
