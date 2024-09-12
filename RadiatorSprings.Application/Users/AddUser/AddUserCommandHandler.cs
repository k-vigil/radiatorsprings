namespace RadiatorSprings.Application.Users.AddUser;

public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, object>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserPermissionRepository _userPermissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserCommandHandler(IUserRepository userRepository, IUserPermissionRepository userPermissionRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _userPermissionRepository = userPermissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Username);
        _userRepository.AddUser(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // permisos
        foreach (var permissionId in request.PermissionsId)
        {
            var userPermission = new UserPermission(user.Id, permissionId);
            _userPermissionRepository.AddUserPermission(userPermission);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
