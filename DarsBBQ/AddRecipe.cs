using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DarsBBQ
{
    public partial class AddRecipe : Form
    {
        private ProductControl productControl;
        private adminPOS adminPOS;
        List<Tuple<string, int>> ingredientsList = new List<Tuple<string, int>>();

        // Connection string to connect to your MySQL database
        private string connectionString = "Server=localhost;Database=darsbbq;Uid=root;Pwd=;"; // Replace with your actual connection string

        public AddRecipe()
        {
            InitializeComponent();
            adminPOS = new adminPOS(); // Ensure adminPOS is properly initialized
            productControl = new ProductControl(adminPOS); // Initialize ProductControl once
        }

        private void AddRecipe_Load(object sender, EventArgs e)
        {
            // You can load any required data on form load, if needed
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Get ingredient name and quantity from textboxes
            string ingredientName = txtEngredients.Text;
            int ingredientQty = int.Parse(txtEngredientsQty.Text);

            // Check if both ingredient name and quantity are provided
            if (txtEngredients.Text.Trim() != "" && txtEngredientsQty.Text.Trim() != "")
            {
                // Display the added ingredient on the label for confirmation
                lblEngName.Text += ingredientName + " " + ingredientQty.ToString() + "\n";
                // Clear the textboxes after adding the ingredient
                txtEngredients.Text = "";
                txtEngredientsQty.Text = "";

                // Add the ingredient and quantity to the list for further processing
                ingredientsList.Add(new Tuple<string, int>(ingredientName, ingredientQty));
            }
        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Call the method to save the recipe and deduct the ingredients
                SaveRecipe();
                DeductIngredients();

                // Show a message to indicate success
                MessageBox.Show("Recipe added and ingredients deducted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the current form and show the product control form
                this.Close();
                productControl.Show();
            }
            catch (Exception ex)
            {
                // Show an error message if anything goes wrong
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to save the recipe to the 'recipe' table in the database
        private void SaveRecipe()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // Open a connection to the database

                    // Insert the recipe into the 'recipe' table
                    string insertRecipeQuery = "INSERT INTO recipe (name, ingredients) VALUES (@name, @ingredients)";
                    MySqlCommand cmd = new MySqlCommand(insertRecipeQuery, conn);
                    cmd.Parameters.AddWithValue("@name", "New Recipe"); // Use dynamic recipe name if needed
                    cmd.Parameters.AddWithValue("@ingredients", string.Join(",", ingredientsList.Select(i => i.Item1))); // Combine ingredient names

                    // Execute the query to insert the recipe into the database
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Throw an error if saving the recipe fails
                throw new Exception("Error saving recipe: " + ex.Message);
            }
        }

        // Method to deduct the quantities of ingredients used in the recipe from the 'ingredients' table
        private void DeductIngredients()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // Open a connection to the database

                    // Loop through each ingredient in the list
                    foreach (var ingredient in ingredientsList)
                    {
                        string ingredientName = ingredient.Item1; // Ingredient name
                        int ingredientQty = ingredient.Item2; // Ingredient quantity to deduct

                        // Check if the ingredient exists in the 'ingredients' table and fetch the current stock quantity
                        string checkIngredientQuery = "SELECT stock_quantity FROM ingredients WHERE name = @name";
                        MySqlCommand checkCmd = new MySqlCommand(checkIngredientQuery, conn);
                        checkCmd.Parameters.AddWithValue("@name", ingredientName);

                        MySqlDataReader reader = checkCmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read(); // Read the current stock quantity of the ingredient
                            int currentStock = reader.GetInt32("stock_quantity");

                            // Check if there’s enough stock to deduct the specified quantity
                            if (currentStock >= ingredientQty)
                            {
                                reader.Close(); // Close the reader after checking the stock

                                // Deduct the stock quantity from the 'ingredients' table
                                string updateStockQuery = "UPDATE ingredients SET stock_quantity = stock_quantity - @qty WHERE name = @name";
                                MySqlCommand updateCmd = new MySqlCommand(updateStockQuery, conn);
                                updateCmd.Parameters.AddWithValue("@qty", ingredientQty);
                                updateCmd.Parameters.AddWithValue("@name", ingredientName);

                                // Execute the query to update the ingredient's stock quantity
                                updateCmd.ExecuteNonQuery();
                            }
                            else
                            {
                                reader.Close(); // Close the reader if there’s insufficient stock
                                throw new Exception($"Not enough stock for ingredient: {ingredientName}"); // Throw an error if stock is insufficient
                            }
                        }
                        else
                        {
                            reader.Close(); // Close the reader if ingredient not found
                            throw new Exception($"Ingredient '{ingredientName}' not found in database."); // Throw an error if ingredient doesn't exist
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Throw an error if there’s an issue with deducting ingredients
                throw new Exception("Error deducting ingredients: " + ex.Message);
            }
        }
    }
}
