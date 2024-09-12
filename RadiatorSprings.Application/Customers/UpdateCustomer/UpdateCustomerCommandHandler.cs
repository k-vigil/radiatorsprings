using RadiatorSprings.Core.ValueObjects;

namespace RadiatorSprings.Application.Customers.UpdateCustomer;

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, object>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);

        if (customer is null) return Task.CompletedTask;

        var customerDocument = Document.Create(request.DocumentType, request.DocumentNumber);

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Document = customerDocument;
        customer.PhoneNumber = request.PhoneNumber;
        customer.Email = request.Email;

        _customerRepository.UpdateCustomer(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Task.CompletedTask;
    }
}
