using Microsoft.EntityFrameworkCore;

namespace OrderItemApi.Models
{
    public class OrderItemContext : DbContext
    {
        public OrderItemContext(DbContextOptions<OrderItemContext> options) : base(options)
        {

        }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
