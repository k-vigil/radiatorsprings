using RadiatorSprings.Core.Common;

namespace RadiatorSprings.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    private Category()
    {

    }

    public Category(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
