using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace management_system
{
    public static class CarmanageDB
    {

        // Method to retrieve car details from the text file
        public static List<Car> GetCars()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Cars.ToList();
            }
        }


        // Method to add a new car to the database
        public static bool AddCar(string model, string brand, string year, string price, string status, string carid, out string errorMessage)
        {
            errorMessage = null;

            // Validate input
            if (!IsValidInput(model, brand, year, price, status, carid))
            {
                errorMessage = "Invalid car information.";
                return false;
            }

            try
            {
                // Create a new Car object and add it to the list
                List<Car> cars = GetCars();
                Car newCar = new Car(model, brand, year, price, status, carid);
                cars.Add(newCar);
                using (var dbContext = new CarRentalDbContext())
                {
                    dbContext.Cars.Add(newCar);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while adding the car: " + ex.Message;
                return false;
            }
        }

        // Method to update an existing car in the database
        public static bool UpdateCar(int index, string model, string brand, string year, string price, string status, string carid, out string errorMessage)
        {
            errorMessage = null;

            // Check if the index is valid
            if (index < 0 || index >= GetCars().Count)
            {
                errorMessage = "Index is out of range.";
                return false;
            }

            // Validate input
            if (!IsValidInput(model, brand, year, price, status, carid))
            {
                errorMessage = "Invalid car information.";
                return false;
            }

            // Update the car at the specified index
            //cars[index] = new Car(model, brand, year, price, status, carid);

            using (var dbContext = new CarRentalDbContext())
            {
                Car updateCars = dbContext.Cars.FirstOrDefault(c => c.CarID == carid);
                // Update customer's information
                updateCars.Model = model;
                updateCars.Brand = brand;
                updateCars.Year = year;
                updateCars.Price = price;
                updateCars.Status = status;
                dbContext.SaveChanges();
            }
            return true;
        }

        // Method to remove a car from the database
        public static bool RemoveCar(int index, out string errorMessage)
        {
            errorMessage = null;

            // Check if the index is valid
            if (index < 0 || index >= GetCars().Count)
            {
                errorMessage = "Index is out of range.";
                return false;
            }
            string carID = GetCars()[index].CarID;


            // Remove the car at the specified index
            using (var dbContext = new CarRentalDbContext())
            {
                Car deleteCar = dbContext.Cars.FirstOrDefault(m => m.CarID == carID);
                dbContext.Cars.Remove(deleteCar);
                dbContext.SaveChanges();
            }
            return true;
        }

        // Method to view details of a car
        public static bool ViewCar(int index, out Car car, out string errorMessage)
        {
            errorMessage = null;
            car = null;

            // Check if the index is valid
            if (index < 0 || index >= GetCars().Count)
            {
                errorMessage = "Index is out of range.";
                return false;
            }

            // Retrieve the car at the specified index
            car = GetCars()[index];
            return true;
        }

        // Method to validate input fields
        private static bool IsValidInput(string model, string brand, string year, string price, string status, string carid)
        {
            // Check for null or empty values and validate numeric fields
            if (string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(status) || !int.TryParse(year, out _) || !double.TryParse(price, out _) || !int.TryParse(carid, out _))
                return false;

            // Regular expressions to validate model, brand, and status
            Regex modelRegex = new Regex("^[\\w .,-]*$");
            Regex brandRegex = new Regex("^[\\w .,-]*$");
            Regex statusRegex = new Regex("^[\\w .,-]*$");
            Regex yearRegex = new Regex("^[0-9-]*$");
            Regex priceRegex = new Regex("^[0-9.]*$");
            Regex idRegex = new Regex("^[0-9]*$");

            // Check if model, brand, and status match the regex patterns
            if (!modelRegex.IsMatch(model) || !brandRegex.IsMatch(brand) || !statusRegex.IsMatch(status))
                return false;

            // Check if year and price match the regex patterns
            return yearRegex.IsMatch(year) && priceRegex.IsMatch(price) && idRegex.IsMatch(carid);
        }
    }
}
