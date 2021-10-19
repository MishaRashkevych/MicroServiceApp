﻿using PizzaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaMVC.Service
{
    public class ToppingService
    {
        public async Task<IEnumerable<ToppingDTO>> GetAll(string token)
        {
            IEnumerable<ToppingDTO> toppings = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getTask = await client.GetAsync("Topping");
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<IEnumerable<ToppingDTO>>();
                    data.Wait();
                    toppings = data.Result;
                }
            }
            return toppings;
        }

        public async Task<ToppingDTO> Get(int id, string token)
        {
            ToppingDTO topping = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.GetAsync("Topping/" + id);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<ToppingDTO>();
                    data.Wait();
                    topping = data.Result;
                }
            }
            return topping;
        }

        public async Task Create(ToppingDTO topping, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PostAsJsonAsync("Topping", topping);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<ToppingDTO>();
                    data.Wait();
                }
            }
        }

        internal async Task<ToppingDTO> GetByName(string value, string token)
        {
            ToppingDTO topping = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.GetAsync("Topping/GetByName/" + value);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<ToppingDTO>();
                    data.Wait();
                    topping = data.Result;
                }
            }
            return topping;
        }

        public async Task Edit(ToppingDTO pizza, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8253/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var postTask = await client.PutAsJsonAsync("Topping", pizza);
                if (postTask.IsSuccessStatusCode)
                {
                    var data = postTask.Content.ReadFromJsonAsync<ToppingDTO>();
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
                var getTask = await client.DeleteAsync("Topping/" + id);
                if (getTask.IsSuccessStatusCode)
                {
                    var data = getTask.Content.ReadFromJsonAsync<ToppingDTO>();
                    data.Wait();
                }
            }
        }
    }
}
