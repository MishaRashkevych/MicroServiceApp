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
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemServise _service;

        public OrderItemController(OrderItemServise service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItemDTO>> Get(string token)
        {
            return await _service.GetAll(token);
        }

        [HttpGet("GetById/{id}")]
        public async Task<OrderItemDTO> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpGet("GetByOrderId/{id}")]
        public async Task<IEnumerable<OrderItemDTO>> GetByOrderId(int id)
        {
            return await _service.GetByOrderId(id);
        }

        [HttpPost]
        public async Task<OrderItemDTO> Post([FromBody] OrderItemDTO order)
        {
            return await _service.Create(order);
        }

        [HttpPut("{id}")]
        public async Task Put([FromBody] OrderItemDTO order)
        {
            await _service.Edit(order);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
