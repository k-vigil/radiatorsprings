using RadiatorSprings.Core.Common;

namespace RadiatorSprings.Core.Entities;

public class Permission : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }

    private Permission()
    {
        
    }

    public Permission(string code, string? description)
    {
        Code = code;
        Description = description;
    }
}
