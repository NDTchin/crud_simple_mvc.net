using System.ComponentModel.DataAnnotations;

namespace CrudSimple.Models;

public class Category
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public virtual List<Product> Products { get; set; }
}