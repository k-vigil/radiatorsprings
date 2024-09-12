namespace RadiatorSprings.Application.Permissions.GetPermissions;

public sealed class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, object>
{
    private readonly IPermissionRepository _permissionRepository;

    public GetPermissionsQueryHandler(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
    }

    public async Task<object> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        var data = await _permissionRepository.GetPermissionsAsync();
        var dto = data.Select(i => new PermissionDto(i.Id, i.Description!));

        return dto;
    }
}
