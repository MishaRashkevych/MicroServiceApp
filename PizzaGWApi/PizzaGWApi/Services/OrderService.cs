using PizzaGWApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaGWApi.Services
{
    public class OrderService
    {
        public async Task<IEnumerable<OrderDTO>> GetAll(string email, string token)
        {
            IEnumerable<OrderDTO> pizzas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54989/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("Order/All/" + email);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
                    data.Wait();
                    pizzas = data.Result;
                }
            }
            return pizzas;
        }

        public async Task<OrderDTO> Get(int id, string token)
        {
            OrderDTO pizzas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54989/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.GetAsync("Order/"+ id);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderDTO>();
                    data.Wait();
                    pizzas = data.Result;
                }
            }
            return pizzas;
        }

        public async Task<OrderDTO> Create(OrderDTO pizza)
        {
            OrderDTO orderDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54989/api/");
                var postTask = await client.PostAsJsonAsync("Order/Post", pizza);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderDTO>();
                    data.Wait();
                    orderDTO = data.Result;

                }
            }
            return orderDTO;
        }

        public async Task Edit(OrderDTO pizza)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54989/api/");
                var postTask = await client.PutAsJsonAsync("Order", pizza);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderDTO>();
                    data.Wait();
                }
            }
        }

        public async Task Delete(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54989/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.DeleteAsync("Order/" + id);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<OrderDTO>();
                    data.Wait();
                }
            }
        }
    }
}