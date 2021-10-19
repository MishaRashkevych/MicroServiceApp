using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToppingsApi.Models;
using static ToppingsApi.Models.ToppingsContext;


namespace ToppingsApi.Service

    {
        public class ToppingsService : IRepo<Toppings>
        {
            private readonly ToppingsContext _toppingsContext;

            public ToppingsService(ToppingsContext toppingsContext)
            {
                _toppingsContext = toppingsContext;
            }

            public async Task<IEnumerable<Toppings>> GetAll()
            {
                try
                {
                    return await _toppingsContext.Topping.ToListAsync();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }

            public async Task<Toppings> Get(int id)
            {
                try
                {
                return await _toppingsContext.Topping.Where(t=>t.Id == id).FirstOrDefaultAsync();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }

            public async Task Edit(Toppings toppings)
            {
                try
                {
                    _toppingsContext.Entry(toppings).State = EntityState.Modified;
                    await _toppingsContext.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public async Task Delete(Toppings toppings)
            {
                try
                {
                    _toppingsContext.Remove(toppings);
                    await _toppingsContext.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public async Task<Toppings> Create(Toppings toppings)
            {
                try
                {
                    var entry = await _toppingsContext.AddAsync(toppings);
                    await _toppingsContext.SaveChangesAsync();
                    return entry.Entity;
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }

        public async Task<Toppings> GetByName(string name)
        {
            try
            {
                return await _toppingsContext.Topping.Where(t => t.Name == name).FirstOrDefaultAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}



