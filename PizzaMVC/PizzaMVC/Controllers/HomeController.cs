using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PizzaMVC.Models;
using PizzaMVC.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public PizzaService _pizzaService;

        public HomeController(ILogger<HomeController> logger, PizzaService pizzaService)
        {
            _logger = logger;
            _pizzaService = pizzaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pizzaService.GetAll(HttpContext.Session.GetString("Token")));
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login", "Login");

            var orderDetail = await new OrderItemService().Create(new OrderItemDTO() { OrderId = HttpContext.Session.GetInt32("OrderId"), PizzaId = id }, HttpContext.Session.GetString("Token"));
            TempData["OrderDetailId"] = orderDetail.Id;
            var pizza = (await new PizzaService().Get(id, HttpContext.Session.GetString("Token")));
            var cartItem = new CartItem() { Pizza = pizza, Toppings = await new ToppingService().GetAll(HttpContext.Session.GetString("Token"))};
            if (cartItem != null)
            {
                HttpContext.Session.SetString("IsCartEmpty", "false");
            }
            foreach (var item in cartItem.Toppings)
            {
                cartItem.SelectedToppings.Add(new SelectListItem { Text = item.Name + " " + item.Price + "$", Value = item.Name, Selected = false });
            }
            return View(cartItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CartItem cItem, string button)
        {
            foreach (var item in cItem.SelectedToppings)
            {
                if (item.Selected)
                {
                    var topping = await new ToppingService().GetByName(item.Value, HttpContext.Session.GetString("Token"));
                    await new OrderItemDetailsService().Create(new OrderItemDetailsDTO() { OrderDetailsId = int.Parse(TempData.Peek("OrderDetailId").ToString()), ToppingId = topping.Id }, HttpContext.Session.GetString("Token"));
                }
            }
            if (button == "Add more pizza")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Order");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
