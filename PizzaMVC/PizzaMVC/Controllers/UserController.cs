using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaMVC.Models;
using PizzaMVC.Service;
using PizzaMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _service;

        public UserController(UserService userService)
        {
            _service = userService;
        }
        public IActionResult Login()
        {
            HttpContext.Session.SetString("IsCartEmpty", "true");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin loginModel)
        {
            try
            {
                var user = await _service.Get(loginModel.Email);
                if (user != null)
                {
                    user = _service.Login(loginModel);
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserName", user.Name);
                    HttpContext.Session.SetString("Token", user.JwtToken);
                    var order = new OrderDTO() { UEmail = loginModel.Email, Phone = user.Phone, Address = user.Address };
                    var newOrder = await new OrderService().Create(order, user.JwtToken);
                    HttpContext.Session.SetInt32("OrderId", newOrder.Id);
                    return RedirectToAction("Index", "Home", new { id = newOrder.Id });
                }
                else
                {
                    ModelState.AddModelError(nameof(user.Email), "Incorrect input!");
                    ModelState.AddModelError(nameof(user.Password), "Incorrect input!");
                }
                return View(loginModel);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegister user)
        {
            if (_service.Get(user.Email) != null)
            {
                ModelState.AddModelError(nameof(user.Email), "User already exist!");
                return View(user);
            }
            await _service.Register(user);
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}