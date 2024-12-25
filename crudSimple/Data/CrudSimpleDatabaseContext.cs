using CrudSimple.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSimple.Data;

public class CrudSimpleDatabaseContext: DbContext
{
    public CrudSimpleDatabaseContext(
        DbContextOptions<CrudSimpleDatabaseContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlite("SqliteConnection");
    }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; }
}