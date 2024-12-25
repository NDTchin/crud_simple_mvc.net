using System.ComponentModel.DataAnnotations;
namespace crudSimple.Models;

public class Customer
{
    public long Id { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string Name { get; set; }
}