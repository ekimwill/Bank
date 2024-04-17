using Microsoft.EntityFrameworkCore;

namespace Bank;

internal class ProductContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source= Bank.db");
}
