using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Models
{
    public class ToppingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
    }
}
