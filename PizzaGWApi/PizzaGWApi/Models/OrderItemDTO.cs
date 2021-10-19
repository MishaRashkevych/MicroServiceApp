using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGWApi.Models
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? PizzaId { get; set; }
    }
}
