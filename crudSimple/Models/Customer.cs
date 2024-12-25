using System.ComponentModel.DataAnnotations;

namespace CrudSimple.Models;

public class Customer
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Please enter name.")]
    public string Name { get; set; }
}