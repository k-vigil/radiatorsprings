namespace RadiatorSprings.Application.Customers.UpdateCustomer;

public record UpdateCustomerCommand(
    int Id,
    string FirstName,
    string LastName,
    string DocumentType,
    string DocumentNumber,
    string PhoneNumber,
    string Email) : IRequest<object>;
