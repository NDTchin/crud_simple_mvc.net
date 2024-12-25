using Microsoft.EntityFrameworkCore;
using crudSimple.Models;
using crudSimple.Data;
namespace crudSimple.Service;

public class CustomerService: ICustomerService 
{
    private MyDbContext _context;

    public CustomerService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> FindAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> FindById(long Id)
    {
        return await _context.Customers.FirstOrDefaultAsync(x => x.Id == Id);
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
        var customer = await _context.Customers.FindAsync(Id);
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