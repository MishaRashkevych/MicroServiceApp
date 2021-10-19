using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaGWApi.Models;
using PizzaGWApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaGWApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService orderService)
        {
            _service = orderService;
        }

        [HttpGet("All/{email}")]
        public async Task<IEnumerable<OrderDTO>> Get(string email, string token)
        {
            return await _service.GetAll(email, token);
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(int id, string token)
        {
            return await _service.Get(id, token);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<OrderDTO> Post([FromBody] OrderDTO order)
        {
            return await _service.Create(order);
        }

        [HttpPut]
        public async Task Put([FromBody] OrderDTO order)
        {
            await _service.Edit(order);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, string token)
        {
            await _service.Delete(id, token);
        }
    }
}
