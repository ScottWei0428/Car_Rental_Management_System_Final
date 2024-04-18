using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class PaymentInfo
    {
        [Key]
        public int Id { get; set; }
        // Properties to store payment information
        public string RentalID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
    }
}
