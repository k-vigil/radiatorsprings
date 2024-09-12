namespace RadiatorSprings.Application.Customers.AddCustomer;

public record AddCustomerCommand(
    string FirstName,
    string LastName,
    string DocumentType,
    string DocumentNumber,
    string PhoneNumber,
    string Email) : IRequest<object>;
