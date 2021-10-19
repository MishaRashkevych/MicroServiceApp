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
    public class PizzaService
    {
        public async Task<IEnumerable<PizzaDTO>> GetAll(string token)
        {
            IEnumerable<PizzaDTO> pizzas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20534/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("Pizza");
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<IEnumerable<PizzaDTO>>();
                    data.Wait();
                    pizzas = data.Result;
                }
            }
            return pizzas;
        }

        public async Task<PizzaDTO> Get(int id, string token)
        {
            PizzaDTO pizza = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20534/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.GetAsync("Pizza/"+ id);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<PizzaDTO>();
                    data.Wait();
                    pizza = data.Result;
                }
            }
            return pizza;
        }

        public async Task Create(PizzaDTO pizza, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20534/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PostAsJsonAsync("Pizza", pizza);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<PizzaDTO>();
                    data.Wait();
                }
            }
        }

        public async Task Edit(PizzaDTO pizza, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20534/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PutAsJsonAsync("Pizza", pizza);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<PizzaDTO>();
                    data.Wait();
                }
            }
        }

        public async Task Delete(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20534/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.DeleteAsync("Pizza/" + id);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<PizzaDTO>();
                    data.Wait();
                }
            }
        }
    }
}
