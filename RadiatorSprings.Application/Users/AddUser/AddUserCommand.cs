namespace RadiatorSprings.Application.Users.AddUser;

public record AddUserCommand(
    string Name,
    string Username,
    int[] PermissionsId) : IRequest<object>;
