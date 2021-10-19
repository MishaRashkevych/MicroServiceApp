using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepo<Order> _service;
        public OrderController(IRepo<Order> service)
        {
            _service = service;
        }

        [HttpGet("All/{email}")]
        public async Task<IEnumerable<Order>> Get(string email)
        {
            return await _service.GetAll(email);
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        [Route("Post")]
        public async Task<Order> Post([FromBody] Order pizza)
        {
            return await _service.Create(pizza);
        }

        [HttpPut]
        public async Task Put([FromBody] Order pizza)
        {
            await _service.Edit(pizza);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(await _service.Get(id));
        }
    }
}
