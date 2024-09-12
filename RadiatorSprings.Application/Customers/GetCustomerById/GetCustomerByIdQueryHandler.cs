namespace RadiatorSprings.Application.Customers.GetCustomerById;

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, object>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<object> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _customerRepository.GetCustomerByIdAsync(request.Id);

        if (data is null) return Task.CompletedTask;

        var dto = new CustomerDto(
            data.Id,
            data.FirstName,
            data.LastName,
            data.Document.DocumentType,
            data.Document.DocumentNumber,
            data.PhoneNumber,
            data.Email);

        return dto;
    }
}
