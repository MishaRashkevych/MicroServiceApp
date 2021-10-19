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
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> Get(string id)
        {
            return await _userService.Get(id);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserDTO user)
        {
            var userDTO = await _userService.RegisterAsync(user);
            if (userDTO != null)
            {
                return userDTO;
            }
            else return BadRequest("Not able to reg");
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login([FromBody] LoginDTO user)
        {
            var userDTO = await _userService.LoginAsync(user);
            if (userDTO != null)
            {
                return Ok(userDTO);
            }
            else return BadRequest("Not able to reg");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
