namespace RadiatorSprings.Infrastructure.Auth;

public class PermissionAuthorizationRequirement : IAuthorizationRequirement
{
    public string Permission { get; set; }

    public PermissionAuthorizationRequirement(string permission)
    {
        Permission = permission;
    }
}
