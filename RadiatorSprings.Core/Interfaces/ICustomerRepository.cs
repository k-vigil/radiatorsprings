using RadiatorSprings.Core.Entities;

namespace RadiatorSprings.Core.Interfaces;

public interface ICustomerRepository
{
    Task<IReadOnlyList<Customer>> GetCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int id);
    void AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
}
