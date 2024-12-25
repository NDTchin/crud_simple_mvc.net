using System.ComponentModel.DataAnnotations;

namespace CrudSimple.Models;

public class Product
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }
}