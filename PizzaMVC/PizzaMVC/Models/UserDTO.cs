using System.Collections.Generic;

namespace PizzaMVC.Models
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string JwtToken { get; set; }
        public List<int> OrderIds { get; set; }
    }
}
