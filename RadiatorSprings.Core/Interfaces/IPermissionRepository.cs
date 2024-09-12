using RadiatorSprings.Core.Entities;

namespace RadiatorSprings.Core.Interfaces;

public interface IPermissionRepository
{
    Task<IReadOnlyList<Permission>> GetPermissionsAsync();
}
