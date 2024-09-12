namespace RadiatorSprings.Application.Customers.GetCustomers;

public sealed class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, object>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<object> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var data = await _customerRepository.GetCustomersAsync();
        var dto = data.Select(i => new CustomerDto(
            i.Id,
            i.FirstName,
            i.LastName,
            i.Document.DocumentType,
            i.Document.DocumentNumber,
            i.PhoneNumber,
            i.Email));

        return dto;
    }
}
