using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
  
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
    }
}
