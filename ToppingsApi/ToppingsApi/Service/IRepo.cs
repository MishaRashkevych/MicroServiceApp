using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToppingsApi.Models;

namespace ToppingsApi.Service
{
        public interface IRepo<T>
        {
            public Task<IEnumerable<T>> GetAll();
            public Task<T> Get(int id);
            public Task<T> Create(T t);
            public Task Edit(T t);
            public Task Delete(T t);
            public Task<T> GetByName(string name);
    }
}


