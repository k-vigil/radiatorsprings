using RadiatorSprings.Core.Common;

namespace RadiatorSprings.Core.Entities;

public class UserPermission : BaseEntity
{
    public int UserId { get; set; }
    public int PermissionId { get; set; }
    public Permission Permission { get; set; } = null!;
    public User User { get; set; } = null!;

    private UserPermission()
    {
        
    }

    public UserPermission(int userId, int permissionId)
    {
        UserId = userId;
        PermissionId = permissionId;
    }
}
