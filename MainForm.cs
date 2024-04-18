// Importing necessary namespaces for the form
using CustomerManagementApp;
using management_system;
using Rental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Payments;

// Namespace for the Car Rental System
namespace Car_Rental_System
{
    // Definition for MainForm which is a type of Form
    public partial class MainForm : Form
    {
        // Constructor for MainForm
        public MainForm()
        {
            // Initialize the form components (auto-generated code)
            InitializeComponent();
        }

        // Event handler for the Customer button click
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            // Creating an instance of CustomerInfo form
            CustomerInformation customerForm = new CustomerInformation();
            // Subscribing to the FormClosed event with the ChildForm_FormClosed event handler
            customerForm.FormClosed += new FormClosedEventHandler(ChildForm_FormClosed);
            // Hiding the MainForm
            this.Hide();
            // Displaying the CustomerInfo form
            customerForm.Show();
        }

        // Event handler for the Car button click
        private void btnCar_Click(object sender, EventArgs e)
        {
            // Creating an instance of car_management form
            car_management carForm = new car_management();
            // Subscribing to the FormClosed event with the ChildForm_FormClosed event handler
            carForm.FormClosed += new FormClosedEventHandler(ChildForm_FormClosed);
            // Hiding the MainForm
            this.Hide();
            // Displaying the car_management form
            carForm.Show();
        }

        // Event handler for the Rental button click
        private void BtnRental_Click(object sender, EventArgs e)
        {
            // Creating an instance of CarRentalSystem form
            CarRentalSystem rentalForm = new CarRentalSystem();
            // Subscribing to the FormClosed event with the ChildForm_FormClosed event handler
            rentalForm.FormClosed += new FormClosedEventHandler(ChildForm_FormClosed);
            // Hiding the MainForm
            this.Hide();
            // Displaying the CarRentalSystem form
            rentalForm.Show();
        }

        // Event handler for the Payment button click
        private void btnPayment_Click(object sender, EventArgs e)
        {
            // Creating an instance of Payment_Management form
            Payment_Management paymentForm = new Payment_Management();
            // Subscribing to the FormClosed event with the ChildForm_FormClosed event handler
            paymentForm.FormClosed += new FormClosedEventHandler(ChildForm_FormClosed);
            // Hiding the MainForm
            this.Hide();
            // Displaying the Payment_Management form
            paymentForm.Show();
        }

        // Event handler for when a child form is closed
        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Showing the MainForm again when the child form is closed
            this.Show();
        }

        // Event handler for the MainForm load event
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        // Event handler for a button click intended to close the MainForm
        private void button1_Click(object sender, EventArgs e)
        {
            // Closes the MainForm
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
