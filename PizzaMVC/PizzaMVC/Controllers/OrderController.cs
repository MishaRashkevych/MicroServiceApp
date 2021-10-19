using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaMVC.Models;
using PizzaMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly CartItemServise _service;

        public OrderController(CartItemServise cartItemService)
        {
            _service = cartItemService;
        }
        public async Task<ActionResult> Index()
        {
            var items = await _service.Get(HttpContext.Session.GetInt32("OrderId"), HttpContext.Session.GetString("Token"));
            await _service.GetTotalSum((int)HttpContext.Session.GetInt32("OrderId"), HttpContext.Session.GetString("Token"));
            return View(items);
        }

        [HttpPost]
        public ActionResult OrderDelete()
        {
            //_service.DeleteOrder();
            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> ItemDelete(int id)
        {
            await new CartItemServise().DeleteItem(id, HttpContext.Session.GetString("Token"));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Confirm()
        {
            var order = await new OrderService().Get((int)HttpContext.Session.GetInt32("OrderId"), HttpContext.Session.GetString("Token"));
            return View(order);
        }

        [HttpPost]
        public ActionResult Confirm(bool confirm)
        {
            if (!confirm)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("EndMessage");
        }

        public async Task<ActionResult> EndMessage()
        {
            var order = await new OrderService().Get((int)HttpContext.Session.GetInt32("OrderId"), HttpContext.Session.GetString("Token"));
            return View(order);
        }

        [HttpPost]
        public async Task<ActionResult> EndMessage(bool confirm)
        {
            var order = await new OrderService().Get((int)HttpContext.Session.GetInt32("OrderId"), HttpContext.Session.GetString("Token"));
            if (confirm)
            {
                order.Status = "Confirmed";
            }
            else
            {
                order.Status = "Not Confirmed";
            }
            await new OrderService().Edit(order, HttpContext.Session.GetString("Token"));

            HttpContext.Session.SetString("IsCartEmpty", "true");
            var user = await new UserService().Get(HttpContext.Session.GetString("UserEmail"));
            OrderDTO order1 = new OrderDTO() { Address = user.Address, Phone = user.Phone, UEmail = user.Email };
            var newOrder = await new OrderService().Create(order1, HttpContext.Session.GetString("Token"));
            HttpContext.Session.SetInt32("OrderId", newOrder.Id);
            return RedirectToAction("Index", "Home");
        }
    }
}
