namespace RadiatorSprings.Application.Customers.GetCustomerById;

public record GetCustomerByIdQuery(int Id) : IRequest<object>;
