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
    public class OrderItemServise
    {
        public async Task<IEnumerable<OrderItemDTO>> GetAll(string token)
        {
            IEnumerable<OrderItemDTO> oid = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37421/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("OrderItem");
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<IEnumerable<OrderItemDTO>>();
                    data.Wait();
                    oid = data.Result;
                }
            }
            return oid;
        }

        public async Task<OrderItemDTO> GetById(int id)
        {
            OrderItemDTO oids = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37421/api/");
                var postTask = await client.GetAsync("OrderItem/GetById/" + id);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDTO>();
                    data.Wait();
                    oids = data.Result;
                }
            }
            return oids;
        }

        public async Task<IEnumerable<OrderItemDTO>> GetByOrderId(int id)
        {
            IEnumerable<OrderItemDTO> oids = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37421/api/");
                var postTask = await client.GetAsync("OrderItem/GetByOrderId/" + id);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<IEnumerable<OrderItemDTO>>();
                    data.Wait();
                    oids = data.Result;
                }
            }
            return oids;
        }

        public async Task<OrderItemDTO> Create(OrderItemDTO oid)
        {
            OrderItemDTO orderItem = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37421/api/");
                var postTask = await client.PostAsJsonAsync("OrderItem", oid);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDTO>();
                    data.Wait();
                    orderItem = data.Result;
                }
            }
            return orderItem;
        }

        public async Task Edit(OrderItemDTO oid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37421/api/");
                var postTask = await client.PutAsJsonAsync("OrderItem", oid);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDTO>();
                    data.Wait();
                }
            }
        }

        public async Task Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:37421/api/");
                var getTask = await client.DeleteAsync("OrderItem/" + id);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<OrderItemDTO>();
                    data.Wait();
                }
            }
        }
    }
}
