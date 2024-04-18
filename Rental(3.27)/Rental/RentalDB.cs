using DAL;
using DAL.Entitys;
using management_system;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Rental
{
    public static class RentalDB
    {

        public static List<string> ValidateRentalData(string customerID, string carID, DateTime startDate, DateTime endDate, ListBox lbxCarList)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(customerID))
            {
                errors.Add("Please enter Customer ID.");
            }

            if (string.IsNullOrWhiteSpace(carID))
            {
                errors.Add("Please enter Vehicle ID.");
            }

            if (startDate == DateTime.MinValue)
            {
                errors.Add("Please select Start Date.");
            }

            if (endDate == DateTime.MinValue)
            {
                errors.Add("Please select End Date.");
            }

            string pattern = @"^[A-Za-z0-9]+$";
            if (!Regex.IsMatch(customerID, pattern))
            {
                errors.Add("Customer ID format is incorrect. Please check and re-enter.");
            }

            if (!Regex.IsMatch(carID, pattern))
            {
                errors.Add("Vehicle ID format is incorrect. Please check and re-enter.");
            }

            if (startDate >= endDate)
            {
                errors.Add("End Date must be later than Start Date.");
            }

            return errors;
        }

        public static int RentCar(string customerID, string carID, DateTime startDate, DateTime endDate)
        {
            using (var dbContext = new CarRentalDbContext())
            {
                var car = dbContext.Cars.FirstOrDefault(c => c.CarID == carID && c.Status.ToLower() == "available");
                {
                    car.Status = "unavailable";
                    DAL.Entitys.Rental rental = new DAL.Entitys.Rental(carID, startDate, endDate);

                    dbContext.Rentals.Add(rental);
                    dbContext.SaveChanges();

                    return rental.RentalID;
                }
                return -1;
            }
        }


        public static List<DAL.Entitys.Rental> GetAllRentals()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Rentals.ToList();
            }
        }

        public static List<Car> GetAllAvailableCars()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Cars.Where(car => car.Status.ToLower() == "available").ToList();
            }
        }

        public static bool IsCarAvailable(string carId)
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Cars.Any(c => c.CarID == carId && c.Status.ToLower() == "available");
            }
        }

        public static bool ReturnCar(string carID, string customerID)
        {
            using (var dbContext = new CarRentalDbContext())
            {
                var rental = dbContext.Rentals.FirstOrDefault(r => r.CarID == carID && !r.IsReturned);
                if (rental == null)
                {
                    return false;
                }

                rental.IsReturned = true;
                var car = dbContext.Cars.FirstOrDefault(c => c.CarID == carID);
                if (car != null)
                {
                    car.Status = "available";
                }

                dbContext.SaveChanges();
            }

            return true;
        }

        public static List<Car> GetCars()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Cars.ToList();
            }
        }

        public static Car GetCar(string carID)
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Cars.FirstOrDefault(m=>m.CarID == carID);
            }
        }

        public static List<Customer> GetCustomers()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Customers.ToList();
            }
        }
    }
}
