using crudSimple.Models;
using Microsoft.EntityFrameworkCore;

namespace crudSimple.Data;

public class CrudSimpleDatabaseContext: DbContext
{
    public CrudSimpleDatabaseContext(DbContextOptions<CrudSimpleDatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students{get;set;}
}