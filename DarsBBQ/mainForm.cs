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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DarsBBQ
{
    public partial class mainForm : Form
    {
        private string _username;
        private categoryControl1 _categoryControl1;
        //private ProductControl productControl2;

        // Declare as a field

        public mainForm(string username)
        {
            InitializeComponent();
            _username = username;
            productControl2 = new ProductControl(adminPOS);
            //categoryControl1 = new categoryControl(adminPOS);
            productControl2.Location = new Point(209, 0);
            //categoryControl1.Location = new Point(209, 0);
            adminPOS.Controls.Add(productControl2);
            this.Controls.Add(productControl2);
            this.categoryControl1 = new categoryControl1();
            this.Controls.Add(this.categoryControl1);


        }

        private void mainForm_Load(object sender, EventArgs e)
        {


            dashboardControl1.Show();
            MessageBox.Show($"Welcome, admin {_username}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            categoryControl1.Hide();
            userController1.Hide();
            reportControl1.Hide();




        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //sidepanel
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboardControl1.Show();
            categoryControl1.Hide();
            productControl2.Hide();
            stockManagement1.Hide();
            userController1.Hide();
            reportControl1.Hide();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            productControl2.Hide();
            dashboardControl1.Hide();
            stockManagement1.Hide();
            categoryControl1.Show();
            userController1.Hide();
            reportControl1.Hide();


        }

        private void categoryControl1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
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

        private void btnProducts_Click(object sender, EventArgs e)
        {
            //productControl2.Enabled= true;
            dashboardControl1.Hide();
            categoryControl1.Hide();
            productControl2.Show();
            stockManagement1.Hide();
            userController1.Hide();// diria ang error (Object reference not set to an instance of an object )
            reportControl1.Hide();

        }

        private void productControl2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void adminpos1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboardControl1_Load(object sender, EventArgs e)
        {
        }

        private void dashboardControl1_Load_1(object sender, EventArgs e)
        {


        }

        private void categoryControl11_Load(object sender, EventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            stockManagement1.Show();
            dashboardControl1.Hide();
            categoryControl1.Hide();
            productControl2.Hide();
            userController1.Hide();
        }

        private void stockManagement1_Load(object sender, EventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            stockManagement1.Hide();
            dashboardControl1.Hide();
            categoryControl1.Hide();
            productControl2.Hide();
            userController1.Show();
            reportControl1.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            stockManagement1.Hide();
            dashboardControl1.Hide();
            categoryControl1.Hide();
            productControl2.Hide();
            userController1.Hide();
            reportControl1.Show();


        }

        private void btnDashboard_MouseEnter(object sender, EventArgs e)
        {
            //// Change to the desired hover color
            //btnDashboard.BackColor = Color.FromArgb(218, 212, 181);
        }

        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            // Revert to the original color
            //btnDashboard.BackColor = SystemColors.Control;  // Replace 'Blue' with your button's default color
        }


        private void btnDashboard_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnCategories_MouseEnter(object sender, EventArgs e)
        {
            //btnCategories.BackColor = Color.FromArgb(218, 212, 181);
        }

        private void btnCategories_MouseLeave(object sender, EventArgs e)
        {
            //btnDashboard.BackColor = SystemColors.Control;
        }
    }
}
