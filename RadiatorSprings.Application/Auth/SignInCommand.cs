namespace RadiatorSprings.Application.Auth;

public record SignInCommand(string Username) : IRequest<object>;
