using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToppingsApi.Models
{
    public class Toppings
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
    }
}

