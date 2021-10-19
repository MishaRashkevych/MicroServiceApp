using Microsoft.EntityFrameworkCore;
using PizzaGWApi.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGWApi.Services
{
    public class UserService
    {
        private readonly UserContext _context;
        private readonly ITokenService _tokenService;

        public UserService(DbContextOptions<UserContext> options, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = new UserContext(options);
        }

        public async Task<UserDTO> RegisterAsync(UserDTO userDTO)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var user = new User()
                {
                    Email = userDTO.Email,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                    PasswordSalt = hmac.Key,
                    Address = userDTO.Address,
                    Name = userDTO.Name,
                    Phone = userDTO.Phone
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                userDTO.JwtToken = _tokenService.CreateToken(userDTO);
                userDTO.Password = "";
                return userDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<UserDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                var myUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDTO.Email);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                    for (int i = 0; i < userPass.Length; i++)
                    {
                        if (userPass[i] != myUser.PasswordHash[i])
                        {
                            return null;
                        }
                    }
                    UserDTO userDTO = new() {Email = myUser.Email, Address = myUser.Address, Name = myUser.Name, Password = "", Phone = myUser.Phone };
                    userDTO.JwtToken = _tokenService.CreateToken(userDTO);
                    return userDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<UserDTO> Get(string email)
        {
            try
            {
                UserDTO userDTO = new UserDTO();
                var user = await _context.Users.FindAsync(email);
                if (user != null)
                {
                    userDTO.Email = user.Email;
                    userDTO.Name = user.Name;
                    userDTO.Phone = user.Phone;
                    userDTO.Address = user.Address;
                    return userDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
