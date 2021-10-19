using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaOrderDetails.Models
{
    public class OrderItemdetail
    {
        public int OrderDetailsId { get; set; }
        public int ToppingId { get; set; }
    }
}