using PizzaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaMVC.Service
{
    public class OrderItemDetailsService
    {
        public async Task<IEnumerable<OrderItemDetailsDTO>> GetAll(string token)
        {
            IEnumerable<OrderItemDetailsDTO> oid = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("OrderItemDetails");
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<IEnumerable<OrderItemDetailsDTO>>();
                    data.Wait();
                    oid = data.Result;
                }
            }
            return oid;
        }

        public async Task<IEnumerable<OrderItemDetailsDTO>> Get(int id, string token)
        {
            IEnumerable<OrderItemDetailsDTO> oid = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("OrderItemDetails/" + id);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<IEnumerable<OrderItemDetailsDTO>>();
                    data.Wait();
                    oid = data.Result;
                }
            }
            return oid;
        }

        public async Task<OrderItemDetailsDTO> Create(OrderItemDetailsDTO oid, string token)
        {
            OrderItemDetailsDTO oidNew = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PostAsJsonAsync("OrderItemDetails", oid);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDetailsDTO>();
                    data.Wait();
                    oidNew = data.Result;
                }
            }
            return oidNew;
        }

        public async Task Edit(OrderItemDetailsDTO oid, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PutAsJsonAsync("OrderItemDetails", oid);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDetailsDTO>();
                    data.Wait();
                }
            }
        }

        public async Task Delete(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.DeleteAsync("OrderItemDetails/" + id);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<OrderItemDetailsDTO>();
                    data.Wait();
                }
            }
        }
    }
}
