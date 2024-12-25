using CrudSimple.Data;
using CrudSimple.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudSimple.Controllers;

public class SeedController : Controller
{
    private CrudSimpleDatabaseContext _crudSimpleDatabaseContext;
    
    public SeedController(CrudSimpleDatabaseContext crudSimpleDatabaseContext)
    {
        _crudSimpleDatabaseContext = crudSimpleDatabaseContext;
    }
    
    public IActionResult GenerateSeed(string name)
    {
        var cate = 
            _crudSimpleDatabaseContext.Categories.FirstOrDefault(c => c.Id == 1);
        
        Product p = new Product()
        {
            Name = name,
            Category = cate
        };
        _crudSimpleDatabaseContext.Products.Add(p);
        _crudSimpleDatabaseContext.SaveChangesAsync();
        return Ok();
    }

    public IActionResult LazyLoad(long id)
    {
        var p = _crudSimpleDatabaseContext.Products
            .FirstOrDefault(p => p.Id == id);
        Console.WriteLine("---------------" + p.CategoryId);
        return Json(p.Category.Name);
    }

    public IActionResult EagerLoad(long id)
    {
        var p = _crudSimpleDatabaseContext.Products
            .Include(p => p.Category)
            .FirstOrDefault(p => p.Id == id);
        return Json(p); 
    }
}