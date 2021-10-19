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
    public class ToppingController : ControllerBase
    {
        private readonly ToppingService _service;

        public ToppingController(ToppingService toppingService)
        {
            _service = toppingService;
        }

        [HttpGet]
        public async Task<IEnumerable<ToppingDTO>> Get(string token)
        {
            return await _service.GetAll(token);
        }

        [HttpGet("{id}")]
        public async Task<ToppingDTO> Get(int id, string token)
        {
            return await _service.Get(id, token);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ToppingDTO> GetByName(string name, string token)
        {
            return await _service.GetByName(name, token);
        }

        [HttpPost]
        public async Task<ToppingDTO> Post([FromBody] ToppingDTO topping, string token)
        {
            return await _service.Create(topping, token);
        }

        [HttpPut("{id}")]
        public async Task Put([FromBody] ToppingDTO topping, string token)
        {
            await _service.Edit(topping, token);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, string token)
        {
            await _service.Delete(id, token);
        }
    }
}
