using Microsoft.EntityFrameworkCore;
using CrudSimple.Data;
using CrudSimple.Models;

namespace CrudSimple.Services;
public class CustomerService: ICustomerService
{
    private CrudSimpleDatabaseContext _context;

    public CustomerService(CrudSimpleDatabaseContext context)
    {
        _context = context;
    }
    // pagination
    public async Task<List<Customer>> FindAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> FindById(long Id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == Id);
    }

    public async Task<Customer> Save(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> Update(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<bool> Delete(long Id)
    {
        var customer = await _context.Customers.FindAsync();
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }
}