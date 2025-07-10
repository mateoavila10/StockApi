using Microsoft.EntityFrameworkCore;
using StockApi.Models;

namespace StockApi.Data
{
    public class StockDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }
    }
}
