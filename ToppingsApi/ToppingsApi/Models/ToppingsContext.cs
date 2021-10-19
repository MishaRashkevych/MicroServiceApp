using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToppingsApi.Models
{
    public class ToppingsContext : DbContext
    {
        public ToppingsContext(DbContextOptions<ToppingsContext> options) : base(options)
        {

        }
        public DbSet<Toppings> Topping{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toppings>().HasData(
                new Toppings() { Id = 1, Name = "Onion", Price = 2 },
                new Toppings() { Id = 2, Name = "Meat", Price = 4 },
                new Toppings() { Id = 3, Name = "Cheese", Price = 3 }
                );
        }
    }
}


    

        