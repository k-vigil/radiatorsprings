namespace RadiatorSprings.Infrastructure.Auth;

public class PermissionRequiredAttribute : AuthorizeAttribute
{
    public PermissionRequiredAttribute(string permission)
        : base(policy: permission)
    {

    }
}
