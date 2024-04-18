using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Rental
    {
        [Key]
        public int RentalID { get; set; }
        public string CarID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsReturned { get; set; } = false;

        public Rental()
        {

        }

        public Rental(string carID, DateTime startDate, DateTime endDate)
        {
            CarID = carID;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
