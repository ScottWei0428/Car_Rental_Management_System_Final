using CustomerManagementApp;
using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerManagementProject
{
    public static class CustomerDB
    {
        private static readonly string FilePath = "customer.txt";
        private const string Delimiter = "|";

        // Method to retrieve customer details from the text file
        public static List<Customer> GetCustomers()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Customers.ToList();
            }
        }

        public static Customer GetCustomer(int id)
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Customers.FirstOrDefault(c => c.Id == id);
            }
        }


        // Method to add a new customer to the database
        public static bool AddCustomer(string name, string address, string phoneNumber, string email, out string errorMessage)
        {
            errorMessage = null;

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(email))
            {
                errorMessage = "Please fill all the fields.";
                return false;
            }


            // Validate Name
            if (!IsValidName(name))
            {
                errorMessage = "Invalid name format. Name should contain only characters.";
                return false;
            }

            // Validate Phone Number
            if (!IsValidPhoneNumber(phoneNumber))
            {
                errorMessage = "Invalid phone number format. Phone number should contain only numbers.";
                return false;
            }

            // Validate Email
            if (!IsValidEmail(email))
            {
                errorMessage = "Invalid email format.";
                return false;
            }

            try
            {
                Customer customer = new Customer(name, address, phoneNumber, email);
                using (var dbContext = new CarRentalDbContext())
                {
                    dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while adding the customer: " + ex.Message;
                return false;
            }
        }

        // Method to update an existing customer in the database
        public static bool UpdateCustomer(int customerId, string name, string address, string phoneNumber, string email, out string errorMessage)
        {
            errorMessage = "";

            // Find the customer with the given ID
            Customer customerToUpdate = GetCustomer(customerId);

            if (customerToUpdate != null)
            {
                // Check if the details are the same as the existing customer details
                if (customerToUpdate.Name == name &&
                    customerToUpdate.Address == address &&
                    customerToUpdate.PhoneNumber == phoneNumber &&
                    customerToUpdate.Email == email)
                {
                    // If there are no changes, display a message box and return false
                    MessageBox.Show("There are no changes to update.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // Validate Name
                if (string.IsNullOrWhiteSpace(name) || !IsValidName(name))
                {
                    errorMessage = "Invalid name format. Name should contain only characters.";
                    return false;
                }

                // Validate Phone Number
                if (string.IsNullOrWhiteSpace(phoneNumber) || !IsValidPhoneNumber(phoneNumber))
                {
                    errorMessage = "Invalid phone number format. Phone number should contain only numbers.";
                    return false;
                }

                // Validate Email
                if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
                {
                    errorMessage = "Invalid email format.";
                    return false;
                }

               
                // Save the updated list of customers
                using (var dbContext = new CarRentalDbContext())
                {
                    Customer update = dbContext.Customers.FirstOrDefault(c => c.Id == customerId);
                    // Update customer's information
                    update.Name = name;
                    update.Address = address;
                    update.PhoneNumber = phoneNumber;
                    update.Email = email;
                    dbContext.SaveChanges();
                }
                return true;
            }

            errorMessage = "Customer not found.";
            return false;
        }

       
        // Method to remove a customer from the database
        public static bool DeleteCustomer(int id, out string errorMessage)
        {
            errorMessage = null;

            string message = "Are you sure you want to delete this customer?";
            string caption = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {

                // Find the customer with the given ID
                using (var dbContext = new CarRentalDbContext())
                {
                    Customer customerToDelete = dbContext.Customers.FirstOrDefault(c => c.Id == id);

                    if (customerToDelete != null)
                    {
                        dbContext.Customers.Remove(customerToDelete);
                        dbContext.SaveChanges();
                        
                        return true; // Deletion successful
                    }
                    else
                    {
                        errorMessage = "Customer not found.";
                        return false; // Customer not found
                    }
                }
            }
            else
            {
                errorMessage = "Customer deletion canceled.";
                return false; // User canceled deletion
            }
        }


        // Method to view details of a customer
        public static bool ViewCustomer(int id, out Customer customer, out string errorMessage)
        {
            errorMessage = null;
            customer = GetCustomer(id);
            if (customer == null)
            {
                errorMessage = "Customer not found.";
                return false;
            }
            return true;
        }

        // Method to check if details already exist for another customer
        private static bool IsDuplicate(int customerId, string name, string address, string phoneNumber, string email)
        {
            List<Customer> customers = GetCustomers();

            foreach (Customer customer in customers)
            {
                if (customer.Id != customerId &&
                    (customer.Name.Equals(name) || customer.Address.Equals(address) ||
                     customer.PhoneNumber.Equals(phoneNumber) || customer.Email.Equals(email)))
                {
                    return true;
                }
            }
            return false;
        }
       
       
        private static bool IsValidEmail(string email)
        {
            // Regular expression pattern for basic email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Method to validate phone number using regular expression
        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regular expression pattern for basic phone number validation
            string pattern = @"^[0-9]+$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        // Method to validate name - allow only alphabets and spaces
        private static bool IsValidName(string name)
        {
            // Regular expression pattern to allow only alphabets and spaces
            string pattern = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(name, pattern);
        }

        // Method to check if a given ID already exists in the database
        private static bool IsDuplicateId(int id)
        {
            List<Customer> customers = GetCustomers();
            return customers.Any(c => c.Id == id);
        }
        // Method to convert Customer object to a string to be written to file
        private static string customerToFileString(Customer customer)
        {
            return $"{customer.Id}{Delimiter}{customer.Name}{Delimiter}{customer.Address}" +
                $"{Delimiter}{customer.PhoneNumber}{Delimiter}{customer.Email}";
        }

    }
}

