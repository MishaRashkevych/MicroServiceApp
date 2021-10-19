using PizzaOrderDetails.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaOrderDetails.Services
{
    public interface IRepo<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> Get(int id);
        public Task<T> Create(T t);
        public Task Edit(T t);
        public Task Delete(int id);
    }
}