using RadiatorSprings.Application.Common.Interfaces;

namespace RadiatorSprings.Application.Auth;

public sealed class SignInCommandHandler : IRequestHandler<SignInCommand, object>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserRepository _userRepository;

    public SignInCommandHandler(IJwtProvider jwtProvider, IUserRepository userRepository)
    {
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
    }

    public async Task<object> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernameAsync(request.Username);

        if (user is null) return Task.CompletedTask;

        var token = _jwtProvider.GenerateToken(user.Id);

        return token;
    }
}
