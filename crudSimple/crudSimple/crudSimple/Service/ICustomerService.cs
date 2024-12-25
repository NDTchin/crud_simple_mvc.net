using crudSimple.Models;
namespace crudSimple.Service;

public interface ICustomerService
{
    Task<List<Customer>> FindAll();
    
    Task<Customer> FindById(long Id);

    Task<Customer> Save(Customer customer);

    Task<Customer> Update(Customer customer);
    
    Task<bool> Delete(long Id);
}