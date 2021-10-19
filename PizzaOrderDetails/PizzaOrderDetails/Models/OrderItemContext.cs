using Microsoft.EntityFrameworkCore;

namespace PizzaOrderDetails.Models
{
    public class OrderItemContext : DbContext
    {
        public DbSet<OrderItemdetail> OrderItemdetails { get; set; }
        public OrderItemContext(DbContextOptions<OrderItemContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemdetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderDetailsId, e.ToppingId });
            });
        }
    }
}
