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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Check the result
            if (result == DialogResult.Yes)
            {
                // If the user confirms, close the current form and show Form1
                this.Close(); // Close the main form
                Form1 form1 = new Form1();
                form1.Show(); // Show the login form
            }
            else
            {
                // If the user cancels, do nothing and return to the current form
                // No additional action needed as the form remains open
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CashierDashboard dashboard = new CashierDashboard();
            cashierPOS cashierPOS = new cashierPOS();
            dashboard.Show();
            adminpos1.Hide();
        }

        private void cashierDashboard1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //cashierpos1.Show();
            cashierPOS cashierPOS = new cashierPOS();
            CashierDashboard dashboard = new CashierDashboard();
            adminpos1.Enabled = true;
            dashboard.Hide();
            adminpos1.Show();

        }

        private void cashierpos1_Load(object sender, EventArgs e)
        {

        }

        private void adminpos1_Load(object sender, EventArgs e)
        {

        }

        private void adminpos1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
