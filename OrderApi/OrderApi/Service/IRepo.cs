using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Service
{
    public interface IRepo<T>
    {
        public Task<IEnumerable<T>> GetAll(string email);
        public Task<T> Get(int id);
        public Task<T> Create(T t);
        public Task Edit(T t);
        public Task Delete(T t);
    }
}
