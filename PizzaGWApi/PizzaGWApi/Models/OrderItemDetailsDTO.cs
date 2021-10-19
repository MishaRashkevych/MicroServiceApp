using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGWApi.Models
{
    public class OrderItemDetailsDTO
    {
        public int OrderDetailsId { get; set; }
        public int ToppingId { get; set; }
    }
}
