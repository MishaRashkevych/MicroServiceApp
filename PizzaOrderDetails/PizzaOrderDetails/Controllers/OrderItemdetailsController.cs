using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaOrderDetails.Models;
using PizzaOrderDetails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemdetailsController : Controller
    {
        private readonly IRepo<OrderItemdetail> _service;
        public OrderItemdetailsController(IRepo<OrderItemdetail> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<OrderItemdetail>> Get()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderItemdetail>> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        public async Task<OrderItemdetail> Post([FromBody] OrderItemdetail oid)
        {
            return await _service.Create(oid);
        }

        [HttpPut]
        public async Task Put([FromBody] OrderItemdetail oid)
        {
            await _service.Edit(oid);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
