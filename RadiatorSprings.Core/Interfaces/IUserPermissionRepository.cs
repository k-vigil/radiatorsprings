using RadiatorSprings.Core.Entities;

namespace RadiatorSprings.Core.Interfaces;

public interface IUserPermissionRepository
{
    Task<IReadOnlyList<UserPermission>> GetUserPermissionsByUserIdAsync(int userId);
    void AddUserPermission(UserPermission userPermission);
}
