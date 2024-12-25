using crudSimple.Models;
using Microsoft.EntityFrameworkCore;

namespace crudSimple.Data;

public class MyDbContext: DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Customer> Customers{get;set;}
}