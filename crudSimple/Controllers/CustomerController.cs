using CrudSimple.Models;
using CrudSimple.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudSimple.Controllers;

public class CustomerController : Controller
{
    private ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    public IActionResult Create()
    {
        return View(new Customer());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessCreate(
        [Bind("Id, Name")] Customer customer)
    {
        if (!ModelState.IsValid)
        {
            // tra ve form show loi
            return View("Create", customer);
        }
        await _customerService.Save(customer);
        return RedirectToAction("Index");
    }

    [Route("Customer/Detail/{id}")]
    public async Task<IActionResult> GetDetail(long id)
    {
        var existingObject = await _customerService.FindById(id);
        if (existingObject == null)
        {
            return NotFound();
        }

        return View("Detail", existingObject);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long Id)
    {
        var existingObject = await _customerService.FindById(Id);
        if (existingObject == null)
        {
            return NotFound();
        }

        return View("Edit", existingObject);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessEdit(
        [Bind("Id, Name")] Customer obj)
    {
        if (!ModelState.IsValid)
        {
            // tra ve form show loi
            return View("Edit", obj);
        }
        await _customerService.Update(obj);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _customerService.Delete(id);
        if (result)
        {
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}