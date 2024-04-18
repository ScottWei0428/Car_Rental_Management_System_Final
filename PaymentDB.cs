using DAL;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Car_Rental_System
{
    internal class PaymentDB
    {

        public void AddPayment(PaymentInfo payment)
        {
            if (!CheckRentalIDExists(payment.RentalID))
            {
                using (var dbContext = new CarRentalDbContext())
                {
                    dbContext.Payments.Add(payment);
                    dbContext.SaveChanges();
                }
            }
        }

        public bool CheckRentalIDExists(string rentalID)
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Payments.Any(p => p.RentalID == rentalID);
            }
        }

        public void DeletePaymentByRentalID(string rentalID)
        {
            using (var dbContext = new CarRentalDbContext())
            {
                var paymentToRemove = dbContext.Payments.FirstOrDefault(p => p.RentalID == rentalID);
                if (paymentToRemove != null)
                {
                    dbContext.Payments.Remove(paymentToRemove);
                    dbContext.SaveChanges();
                }
            }
        }

        public List<PaymentInfo> GetPayments()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Payments.ToList();
            }
        }

        public List<DAL.Entitys.Rental> GetRentas()
        {
            using (var dbContext = new CarRentalDbContext())
            {
                return dbContext.Rentals.ToList();
            }
        }

    }
}
