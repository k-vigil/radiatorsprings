namespace RadiatorSprings.Application.Users.GetUserById;

public record GetUserByIdQuery(int Id) : IRequest<object>;
