using OrderItemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItemApi.Service
{
    public interface IRepo<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<IEnumerable<T>> GetByOrderId(int id);
        public Task<T> Create(T t);
        public Task Edit(T t);
        public Task Delete(T t);
        public Task<T> GetById(int id);
    }
}
