using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Car
    {
        [Key] // 指定主键属性
        public string CarID { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Year { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }

        public Car()
        {

        }

        public Car(string model, string brand, string year, string price, string status, string carid)
        {
            Model = model; Brand = brand; Year = year; Price = price; Status = status; CarID = carid;
        }
    }
}
