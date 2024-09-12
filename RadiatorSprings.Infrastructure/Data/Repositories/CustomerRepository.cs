namespace RadiatorSprings.Infrastructure.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddCustomer(Customer customer) =>
        _context.Customers.Add(customer);

    public async Task<Customer?> GetCustomerByIdAsync(int id) =>
        await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

    public async Task<IReadOnlyList<Customer>> GetCustomersAsync() =>
        await _context.Customers.AsNoTracking().ToListAsync();

    public void UpdateCustomer(Customer customer) =>
        _context.Customers.Update(customer);
}
