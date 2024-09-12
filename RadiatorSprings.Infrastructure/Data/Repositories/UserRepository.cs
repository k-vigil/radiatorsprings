namespace RadiatorSprings.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddUser(User user) =>
        _context.Users.Add(user);

    public async Task<User?> GetUserByIdAsync(int id) =>
        await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

    public async Task<User?> GetUserByUsernameAsync(string username) =>
        await _context.Users.SingleOrDefaultAsync(u => u.Username == username);

    public async Task<IReadOnlyList<User>> GetUsersAsync() =>
        await _context.Users.AsNoTracking().ToListAsync();
}
