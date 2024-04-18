using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CarRentalDbContext: DbContext
    {
        private static readonly string sqlserverCon = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={AppDomain.CurrentDomain.BaseDirectory}\Data\Rental.mdf;Integrated Security=True";
        public CarRentalDbContext() : base(sqlserverCon)
        {
            // Set Database Initialization
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarRentalDbContext>());
        }

        public DbSet<PaymentInfo> Payments { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
