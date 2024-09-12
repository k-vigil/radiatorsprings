namespace RadiatorSprings.Infrastructure.Data.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly ApplicationDbContext _context;

    public PermissionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Permission>> GetPermissionsAsync() =>
        await _context.Permissions.AsNoTracking().ToListAsync();
}
