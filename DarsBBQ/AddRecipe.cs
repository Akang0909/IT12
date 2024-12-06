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
    public partial class AddRecipe : Form
    {
        private ProductControl productControl;
        private adminPOS adminPOS;
        List<Tuple<string, int>> ingredientsList = new List<Tuple<string, int>>();

        public AddRecipe()
        {
            InitializeComponent();
            adminPOS = new adminPOS(); // Ensure adminPOS is properly initialized
            productControl = new ProductControl(adminPOS); // Initialize ProductControl once
        }

        private void AddRecipe_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string txtEngredients1 = txtEngredients.Text;
            int txtEngredientsQty1 = int.Parse(txtEngredientsQty.Text);

            if (txtEngredients.Text.Trim() != "" && txtEngredientsQty.Text.Trim() != "")
            {
                lblEngName.Text += txtEngredients.Text + " " + txtEngredientsQty.Text + "\n";
                txtEngredients.Text = "";
                txtEngredientsQty.Text = "";
                ingredientsList.Add(new Tuple<string, int>(txtEngredients1, txtEngredientsQty1));
            }
        }

        private void lblEngName_Click(object sender, EventArgs e)
        {
            // Possibly add logic for label click here if needed
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked!"); // Debugging statement
            this.Close();
            productControl.Show();
            // Show the existing ProductControl form
        }
    }
}
