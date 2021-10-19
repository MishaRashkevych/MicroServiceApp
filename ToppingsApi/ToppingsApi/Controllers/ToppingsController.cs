using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToppingsApi.Models;
using ToppingsApi.Service;


namespace ToppingsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly IRepo<Toppings> _service;

        public ToppingsController(IRepo<Toppings> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Toppings>> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Toppings> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<Toppings> GetByName(string name)
        {
            return await _service.GetByName(name);
        }

        [HttpPost]
        public async Task Post([FromBody] Toppings toppings)
        {
            await _service.Create(toppings);
        }

        [HttpPut]
        public async Task Put([FromBody] Toppings toppings)
        {
            await _service.Edit(toppings);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(await _service.Get(id));
        }
    }
}