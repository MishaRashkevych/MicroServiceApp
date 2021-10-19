using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Models
{
    public class CartItem
    {
        public int OrderDetailsId { get; set; }
        public PizzaDTO Pizza { get; set; }
        public IEnumerable<ToppingDTO> Toppings { get; set; }

        public IList<SelectListItem> SelectedToppings { get; set; } = new List<SelectListItem>();
    }
}
