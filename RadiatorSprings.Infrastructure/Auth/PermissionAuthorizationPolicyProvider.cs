namespace RadiatorSprings.Infrastructure.Auth;

public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        : base(options)
    {

    }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy is not null) return policy;

        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionAuthorizationRequirement(policyName))
            .Build();
    }
}
