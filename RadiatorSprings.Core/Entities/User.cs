using RadiatorSprings.Core.Common;

namespace RadiatorSprings.Core.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;

    private User()
    {

    }

    public User(string name, string username)
    {
        Name = name;
        Username = username;
    }
}
