using CustomerManagementApp;
using CustomerManagementProject;
using DAL.Entitys;
using System;
using System.Windows.Forms;

namespace CustomerManagementApp
{
    public partial class CustomerInformation : Form
    {
        public CustomerInformation()
        {
            InitializeComponent();
            RefreshCustomerListBox();
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {

            string name = customerName.Text;
            string address = customerAddress.Text;
            string phoneNumber = customerPhnNum.Text;
            string email = customerEmail.Text;
            string errorMessage;

            if (CustomerDB.AddCustomer(name, address, phoneNumber, email, out errorMessage))
            {
                MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCustomerListBox();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCustomerBtn_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId != -1)
            {
                string name = customerName.Text;
                string address = customerAddress.Text;
                string phoneNumber = customerPhnNum.Text;
                string email = customerEmail.Text;
                string errorMessage;

                if (CustomerDB.UpdateCustomer(customerId, name, address, phoneNumber, email, out errorMessage))
                {
                    MessageBox.Show("Customer updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCustomerListBox();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void ViewCustomerBtn_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId != -1)
            {
                Customer customer;
                string errorMessage;

                if (CustomerDB.ViewCustomer(customerId, out customer, out errorMessage))
                {
                    MessageBox.Show($"Customer ID: {customer.Id}\nName: {customer.Name}\nAddress: {customer.Address}\nPhone Number: {customer.PhoneNumber}\nEmail: {customer.Email}", "Customer Details");
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error");
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to view.");
            }
        }

        private void DeleteCustomerBtn_Click(object sender, EventArgs e)
        {
            
               int customerId = GetSelectedCustomerId();
                if (customerId != -1)
                {
                    string errorMessage; // Declare errorMessage variable
                    if (CustomerDB.DeleteCustomer(customerId, out errorMessage)) // Provide errorMessage as out parameter
                    {
                        MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshCustomerListBox();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.");
                }
            }

        

        private void RefreshCustomerListBox()
        {
            customerListbox.Items.Clear();
            foreach (Customer customer in CustomerDB.GetCustomers())
            {
                customerListbox.Items.Add(customer);
            }
        }

        private void ClearTextBoxes()
        {
            customerName.Text = "";
            customerAddress.Text = "";
            customerPhnNum.Text = "";
            customerEmail.Text = "";
        }

        private int GetSelectedCustomerId()
        {
            if (customerListbox.SelectedIndex != -1)
            {
                string[] customerDetails = customerListbox.SelectedItem.ToString().Split(',');
                string[] separatingStrings = { ": " };
                string[] customerIdInfo = customerDetails[0].Split(separatingStrings, StringSplitOptions.None);
                if (customerDetails.Length > 0 && int.TryParse(customerIdInfo[1], out int customerId))
                {
                    return customerId;
                }
            }
            return -1;
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customerListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId();
            if (customerId != -1)
            {
                Customer customer;
                string errorMessage;
                if (CustomerDB.ViewCustomer(customerId, out customer, out errorMessage))
                {
                    customerName.Text = customer.Name;
                    customerAddress.Text = customer.Address;
                    customerPhnNum.Text = customer.PhoneNumber;
                    customerEmail.Text = customer.Email;
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error");
                }
            }
        }

        private void CustomerInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
