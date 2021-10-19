using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrderService _orderService;

        public HistoryController(ILogger<HomeController> logger, OrderService pizzaService)
        {
            _logger = logger;
            _orderService = pizzaService;
        }

        public async Task<IActionResult> Index()
        {
            var odrers = await _orderService.GetAll(HttpContext.Session.GetString("UserEmail"), HttpContext.Session.GetString("Token"));
            return View(odrers);
        }
    }
}
