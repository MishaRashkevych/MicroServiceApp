using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPIProject.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
        }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { Id = 1, Name = "Margherita", Price = 20, Speciality = "Plain", Crust = "Meat", IsVeg = false, Picture = "/images/11.jfif" },
                new Pizza() { Id = 2, Name = "Cheese N Corn", Price = 25, Speciality = "Cheezy", Crust = "Standart", IsVeg = true, Picture = "/images/22.jfif" },
                new Pizza() { Id = 3, Name = "Chicken Pepperoni", Price = 20, Speciality = "Spicy", Crust = "Cheezy", IsVeg = false, Picture = "/images/33.jfif" }
                );
        }
    }
}
