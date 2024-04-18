using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Reflection;
using DAL.Entitys;

namespace management_system
{
    public partial class car_management : Form
    {
        // Instance of CarmanageDB class for database operation
        public car_management()
        {
            InitializeComponent();
        }

        // Event handler for Add Car button click
        private void button1_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string model = carmodel.Text;
            string brand = carbrand.Text;
            string year = caryear.Text;
            string price = carprice.Text;
            string status = carstatus.Text;
            string carid = id.Text;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(year, out int yearValue) || !double.TryParse(price, out double priceValue) || !int.TryParse(carid, out int idvalue))
            {
                MessageBox.Show("Year and price must be numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex modelregex = new Regex("^[\\w ]*$");
            Regex brandregex = new Regex("^[\\w ,.]*$");
            Regex statusregex = new Regex("^[\\w ,.]*$");
            Regex yearregex = new Regex("^[0-9-]*$");
            Regex priceregex = new Regex("^[0-9.]*$");
            Regex idregex = new Regex("^[0-9]*$");

            foreach (var item in carListbox.Items)
            {
                string existingId = item.ToString().Split('-').Last().Trim();
                if (existingId == carid)
                {
                    MessageBox.Show("Car ID already exists. Please use a unique Car ID or update the existing car.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!modelregex.IsMatch(model))
            {
                MessageBox.Show("Model name contains invalid characters. Please use only letters, digits, spaces, and underscores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!brandregex.IsMatch(brand))
            {
                MessageBox.Show("Brand name contains invalid characters. Please use only letters, digits, spaces, commas, and periods.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!statusregex.IsMatch(status))
            {
                MessageBox.Show("Status contains invalid characters. Please use only letters, digits, spaces, commas, and periods.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!yearregex.IsMatch(year))
            {
                MessageBox.Show("Year must be a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!priceregex.IsMatch(price))
            {
                MessageBox.Show("Price must be a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!idregex.IsMatch(carid))
            {
                MessageBox.Show("carid must be a numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Add car to database
            string errorMessage;
            bool result = CarmanageDB.AddCar(model, brand, year, price, status, carid, out errorMessage);
            if (result)
            {
                MessageBox.Show("Car added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCarListBox();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        // Method to clear textboxes
        private void ClearTextBoxes()
        {
            carmodel.Text = "";
            carbrand.Text = "";
            caryear.Text = "";
            carprice.Text = "";
            carstatus.Text = "";
            id.Text = "";
        }
        // Method to refresh car listbox
        private void RefreshCarListBox()
        {
            carListbox.Items.Clear();
            List<Car> cars = CarmanageDB.GetCars();
            foreach (Car car in cars)
            {
                carListbox.Items.Add($"{car.Model} - {car.Brand} - {car.Year} - {car.Price} - {car.Status} - {car.CarID}");
            }
        }

        // Event handler for Update Car button click
        private void button2_Click(object sender, EventArgs e)
        {
            if (carListbox.SelectedIndex != -1)
            {
                int selectedIndex = carListbox.SelectedIndex;
                Car selectedCar = CarmanageDB.GetCars()[selectedIndex];
                // Get the new values from the textboxes
                string model = carmodel.Text;
                string brand = carbrand.Text;
                string year = caryear.Text;
                string price = carprice.Text;
                string status = carstatus.Text;
                string carid = id.Text;

                // Check if any field is entered
                if (string.IsNullOrWhiteSpace(model) && string.IsNullOrWhiteSpace(brand) &&
                    string.IsNullOrWhiteSpace(year) && string.IsNullOrWhiteSpace(price) &&
                    string.IsNullOrWhiteSpace(status) && string.IsNullOrWhiteSpace(carid))
                {
                    MessageBox.Show("Please enter at least one field to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop further execution
                }

                // Check which fields have been modified
                if (!string.IsNullOrWhiteSpace(model))
                    selectedCar.Model = model;
                if (!string.IsNullOrWhiteSpace(brand))
                    selectedCar.Brand = brand;
                if (!string.IsNullOrWhiteSpace(year))
                    selectedCar.Year = year;
                if (!string.IsNullOrWhiteSpace(price))
                    selectedCar.Price = price;
                if (!string.IsNullOrWhiteSpace(status))
                    selectedCar.Status = status;
                if (!string.IsNullOrWhiteSpace(carid))
                    selectedCar.CarID = carid;

                // Update the car in the database
                string errorMessage;
                if (CarmanageDB.UpdateCar(selectedIndex, selectedCar.Model, selectedCar.Brand, selectedCar.Year, selectedCar.Price, selectedCar.Status, selectedCar.CarID, out errorMessage))
                {
                    MessageBox.Show("Car updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCarListBox();
                    ClearTextBoxes();
                    carListbox.Items[selectedIndex] = $"{selectedCar.Model} - {selectedCar.Brand} - {selectedCar.Year} - {selectedCar.Price} - {selectedCar.Status} - {selectedCar.CarID}"; ;
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a car to update.");
            }
        }




        // Event handler for Remove Car button click
        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = carListbox.SelectedIndex;
            if (carListbox.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Remove this car?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                    string errorMessage;
                    if (CarmanageDB.RemoveCar(selectedIndex, out errorMessage))
                    {
                        MessageBox.Show("Car Removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshCarListBox();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            else
                {
                    button3.BackColor = Color.Transparent;
                }
            }
            else
            {
                MessageBox.Show("Please select a car to delete.");
            }

        }

        // Event handler for View Car button click

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedIndex = carListbox.SelectedIndex;
            if (carListbox.SelectedIndex != -1)
            {
                Car car;
                string errorMessage;
                if (CarmanageDB.ViewCar(selectedIndex, out car, out errorMessage))
                {
                    MessageBox.Show($"Model: {car.Model}\nBrand: {car.Brand}\nYear: {car.Year}\nPrice: {car.Price}\nStatus: {car.Status}\nCarID: {car.CarID}", "Car Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a car to view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Event handler for Form load
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.PaleGoldenrod;

            RefreshCarListBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Close the application
            //Application.Exit();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void carid_TextChanged(object sender, EventArgs e)
        {

        }

        private void carListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = carListbox.SelectedIndex;
            if (index != -1)
            {
                List<Car> cars = CarmanageDB.GetCars();
                Car car = cars[index];
                carmodel.Text = car.Model;
                carbrand.Text = car.Brand;
                caryear.Text = car.Year;
                carprice.Text = car.Price;
                carstatus.Text = car.Status;
                id.Text = car.CarID;
            }
        }
    }
}
