namespace RadiatorSprings.Application.Users.GetUsers;

public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, object>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<object> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var data = await _userRepository.GetUsersAsync();
        var dto = data.Select(i => new UserDto(i.Id, i.Name, i.Username));

        return dto;
    }
}
