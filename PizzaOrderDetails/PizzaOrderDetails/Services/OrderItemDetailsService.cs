using Microsoft.EntityFrameworkCore;
using PizzaOrderDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderDetails.Services
{
    public class OrderItemDetailsService : IRepo<OrderItemdetail>
    {
        private readonly OrderItemContext _itemContext;

        public OrderItemDetailsService(OrderItemContext itemContext)
        {
            _itemContext = itemContext;
        }
        public async Task<IEnumerable<OrderItemdetail>> GetAll()
        {
            try
            {
                return await _itemContext.OrderItemdetails.ToListAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public async Task<IEnumerable<OrderItemdetail>> Get(int id)
        {
            try
            {
                return await _itemContext.OrderItemdetails.Where(o=>o.OrderDetailsId == id).ToListAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public async Task Edit(OrderItemdetail oid)
        {
            try
            {
                _itemContext.Entry(oid).State = EntityState.Modified;
                await _itemContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task Delete(int oid)
        {
            try
            {
                _itemContext.RemoveRange(await _itemContext.OrderItemdetails.Where(o => o.OrderDetailsId == oid).ToListAsync());
                await _itemContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task<OrderItemdetail> Create(OrderItemdetail oid)
        {
            try
            {
                var entry = await _itemContext.AddAsync(oid);
                await _itemContext.SaveChangesAsync();
                return entry.Entity;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
