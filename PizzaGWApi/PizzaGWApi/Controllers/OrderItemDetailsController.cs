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
    public class OrderItemDetailsController : ControllerBase
    {
        private readonly OrderItemDetailsService _service;

        public OrderItemDetailsController(OrderItemDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItemDetailsDTO>> Get(string token)
        {
            return await _service.GetAll(token);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderItemDetailsDTO>> Get(int id, string token)
        {
            return await _service.Get(id, token);
        }

        [HttpPost]
        public async Task<OrderItemDetailsDTO> Post([FromBody] OrderItemDetailsDTO order, string token)
        {
            return await _service.Create(order, token);
        }

        [HttpPut("{id}")]
        public async Task Put([FromBody] OrderItemDetailsDTO order, string token)
        {
            await _service.Edit(order, token);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, string token)
        {
            await _service.Delete(id, token);
        }
    }
}
