using RadiatorSprings.Core.ValueObjects;

namespace RadiatorSprings.Application.Customers.AddCustomer;

public sealed class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, object>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerDocument = Document.Create(request.DocumentType, request.DocumentNumber);
        var customer = new Customer(
            request.FirstName,
            request.LastName,
            customerDocument,
            request.PhoneNumber,
            request.Email);

        _customerRepository.AddCustomer(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
