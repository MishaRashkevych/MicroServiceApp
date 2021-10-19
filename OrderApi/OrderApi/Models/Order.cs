using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UEmail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? Total { get; set; } = 0;
        public double? DeliveryCharge { get; set; } = 0;
        public string Status { get; set; }
    }
}
