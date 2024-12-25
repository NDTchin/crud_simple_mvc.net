using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudSimple.Models;
using CrudSimple.Services;

namespace CrudSimple.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ICustomerService _service;

    public HomeController(ILogger<HomeController> logger, ICustomerService service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index(Customer updateData)
    {
        _service.FindAll();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}