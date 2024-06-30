using Microsoft.EntityFrameworkCore;
using Task2.Contract;

namespace Task2.Application;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}
