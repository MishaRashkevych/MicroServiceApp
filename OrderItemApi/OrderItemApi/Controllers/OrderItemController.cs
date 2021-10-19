using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderItemApi.Models;
using OrderItemApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IRepo<OrderItem> _service;
        public OrderItemController(IRepo<OrderItem> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItem>> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public async Task<OrderItem> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpGet("GetByOrderId/{id}")]
        public async Task<IEnumerable<OrderItem>> GetByOrderId(int id)
        {
            return await _service.GetByOrderId(id);
        }

        [HttpPost]
        public async Task<OrderItem> Post([FromBody] OrderItem pizza)
        {
            return await _service.Create(pizza);
        }

        [HttpPut]
        public async Task Put([FromBody] OrderItem pizza)
        {
            await _service.Edit(pizza);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(await _service.GetById(id));
        }
    }
}
