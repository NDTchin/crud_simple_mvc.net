using Microsoft.AspNetCore.Mvc;

namespace crudSimple.Controllers;

public class SeedController: Controller
{
    public IActionResult GenerateSeed()
    {
        return View();
    }
}