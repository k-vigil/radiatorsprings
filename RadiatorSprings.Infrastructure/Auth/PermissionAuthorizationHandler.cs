using Microsoft.Extensions.DependencyInjection;

namespace RadiatorSprings.Infrastructure.Auth;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
{
    private readonly IServiceProvider _serviceProvider;

    public PermissionAuthorizationHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
    {
        using var scope = _serviceProvider.CreateScope();
        var userPermissionRepository = scope.ServiceProvider.GetRequiredService<IUserPermissionRepository>();

        var userId = context.User.Claims.FirstOrDefault(c => c.Type == "sujeto")?.Value;

        if (userId is null) return;

        var userPermissions = await userPermissionRepository.GetUserPermissionsByUserIdAsync(int.Parse(userId));

        HashSet<string> permissions = userPermissions
            .Select(up => up.Permission.Code)
            .ToHashSet();

        if (!permissions.Contains(requirement.Permission)) return;

        context.Succeed(requirement);
    }
}
