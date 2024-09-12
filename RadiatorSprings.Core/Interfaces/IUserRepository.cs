using RadiatorSprings.Core.Entities;

namespace RadiatorSprings.Core.Interfaces;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByUsernameAsync(string username);
    void AddUser(User user);
}
