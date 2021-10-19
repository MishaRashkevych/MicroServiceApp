using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Models
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Crust { get; set; }
        public string Speciality { get; set; }
        public bool IsVeg { get; set; }
        public string Picture { get; set; }
        public string Details { get; set; }
    }
}
