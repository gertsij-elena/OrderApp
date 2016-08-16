using System.Data.Entity;

namespace OrderApp.Models
{
    public class DataContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}