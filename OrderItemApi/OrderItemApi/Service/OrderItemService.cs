using Microsoft.EntityFrameworkCore;
using OrderItemApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItemApi.Service
{
    public class OrderItemService : IRepo<OrderItem>
    {
        private readonly OrderItemContext _context;

        public OrderItemService(OrderItemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            try
            {
                return await _context.OrderItems.ToListAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderId(int id)
        {
            try
            {
                return await _context.OrderItems.Where(o=>o.OrderId == id).ToListAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<OrderItem> GetById(int id)
        {
            try
            {
                return await _context.OrderItems.Where(o => o.Id == id).FirstOrDefaultAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task Edit(OrderItem pizza)
        {
            try
            {
                _context.Entry(pizza).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task Delete(OrderItem pizza)
        {
            try
            {
                _context.Remove(pizza);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<OrderItem> Create(OrderItem pizza)
        {
            try
            {
                var entry = await _context.AddAsync(pizza);
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
