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
    public class OrderItemService
    {
        public async Task<IEnumerable<OrderItemDTO>> GetAll(string token)
        {
            IEnumerable<OrderItemDTO> pizzas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("OrderItem");
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<IEnumerable<OrderItemDTO>>();
                    data.Wait();
                    pizzas = data.Result;
                }
            }
            return pizzas;
        }

        public async Task<OrderItemDTO> GetById(int id, string token)
        {
            OrderItemDTO orderItems = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.GetAsync("OrderItem/GetById/" + id);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDTO>();
                    data.Wait();
                    orderItems = data.Result;
                }
            }
            return orderItems;
        }

        public async Task<IEnumerable<OrderItemDTO>> GetByOrderId(int id, string token)
        {
            IEnumerable<OrderItemDTO> orderItems = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.GetAsync("OrderItem/GetByOrderId/" + id);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<IEnumerable<OrderItemDTO>>();
                    data.Wait();
                    orderItems = data.Result;
                }
            }
            return orderItems;
        }

        public async Task<OrderItemDTO> Create(OrderItemDTO orderItem, string token)
        {
            OrderItemDTO order = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PostAsJsonAsync("OrderItem", orderItem);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDTO>();
                    data.Wait();
                    order = data.Result;
                }
            }
            return order;
        }

        public async Task Edit(OrderItemDTO pizza, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PutAsJsonAsync("OrderItem", pizza);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<OrderItemDTO>();
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
