using Microsoft.AspNetCore.Authorization;
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
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _service;

        public PizzaController(PizzaService pizzaService)
        {
            _service = pizzaService;
        }

        [HttpGet]
        public async Task<IEnumerable<PizzaDTO>> Get(string token)
        {
            return await _service.GetAll(token);
        }

        [HttpGet("{id}")]
        public async Task<PizzaDTO> Get(int id, string token)
        {
            return await _service.Get(id, token);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
