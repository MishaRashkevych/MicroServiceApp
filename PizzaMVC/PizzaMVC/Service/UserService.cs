using PizzaMVC.Models;
using PizzaMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaMVC.Service
{
    public class UserService
    {
        public async Task<UserDTO> Register(UserRegister userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                var postTask = await client.PostAsJsonAsync<UserRegister>("User/Register", userDto);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = await postTask.Content.ReadFromJsonAsync<UserDTO>();
                    userDTO = data;
                }
            }
            return userDTO;
        }
        public UserDTO Login(UserLogin userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                var postTask = client.PostAsJsonAsync<UserLogin>("User/Login", userDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO = data.Result;
                }
            }
            return userDTO;
        }
        public async Task<UserDTO> Get(string id)
        {
            UserDTO user = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                var getTask = await client.GetAsync("User/" + id);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    user = data.Result;
                }
            }
            return user;
        }
    }
}
