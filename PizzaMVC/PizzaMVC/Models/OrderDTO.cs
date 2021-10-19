using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UEmail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? Total { get; set; } = 0;
        public double? DeliveryCharge { get; set; } = 0;
        public string Status { get; set; }
    }
}
