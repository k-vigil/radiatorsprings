namespace RadiatorSprings.Infrastructure.Data.Repositories;

public class UserPermissionRepository : IUserPermissionRepository
{
    private readonly ApplicationDbContext _context;

    public UserPermissionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddUserPermission(UserPermission userPermission) =>
        _context.UserPermissions.Add(userPermission);

    public async Task<IReadOnlyList<UserPermission>> GetUserPermissionsByUserIdAsync(int userId) =>
        await _context.UserPermissions
            .AsNoTracking()
            .Include(up => up.Permission)
            .Where(up => up.UserId == userId)
            .ToListAsync();
}
