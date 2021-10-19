using PizzaAPIProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaAPIProject.Services
{
    public class PizzaService : IRepo<Pizza>
    {
        private readonly PizzaContext _pizzaContext;

        public PizzaService(PizzaContext pizzaContext)
        {
            _pizzaContext = pizzaContext;
        }

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            try
            {
                return await _pizzaContext.Pizzas.ToListAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<Pizza> Get(int id)
        {
            try
            {
                return await _pizzaContext.Pizzas.Where(p=>p.Id == id).FirstOrDefaultAsync();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task Edit(Pizza pizza)
        {
            try
            {
                _pizzaContext.Entry(pizza).State = EntityState.Modified;
                await _pizzaContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task Delete(Pizza pizza)
        {
            try
            {
                _pizzaContext.Remove(pizza);
                await _pizzaContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<Pizza> Create(Pizza pizza)
        {
            try
            {
                var entry = await _pizzaContext.AddAsync(pizza);
                await _pizzaContext.SaveChangesAsync();
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
