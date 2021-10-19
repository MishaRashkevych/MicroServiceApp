using Microsoft.EntityFrameworkCore;
using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Service
{
    public class OrderService : IRepo<Order>
    {
        private readonly OrderContext _context;

        public OrderService(OrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll(string email)
        {
            try
            {
                return await _context.Orders.Where(o=>o.UEmail == email).ToListAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<Order> Get(int id)
        {
            try
            {
                return await _context.Orders.Where(o=>o.Id == id).FirstOrDefaultAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task Edit(Order order)
        {
            try
            {
                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task Delete(Order order)
        {
            try
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<Order> Create(Order order)
        {
            try
            {
                var entry = await _context.AddAsync(order);
                await _context.SaveChangesAsync();
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