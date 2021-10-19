using PizzaAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaAPIProject.Services;

namespace PizzaAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IRepo<Pizza> _service;

        public PizzaController(IRepo<Pizza> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Pizza>> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Pizza> Get(int id)
        {
            return await _service.Get(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Pizza pizza)
        {
            await _service.Create(pizza);
        }

        [HttpPut]
        public async Task Put([FromBody] Pizza pizza)
        {
            await _service.Edit(pizza);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete((await _service.Get(id)));
        }
    }
}
