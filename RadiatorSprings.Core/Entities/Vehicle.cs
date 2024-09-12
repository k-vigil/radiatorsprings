using RadiatorSprings.Core.Common;

namespace RadiatorSprings.Core.Entities;

public class Vehicle : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public string? UrlImage { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    private Vehicle()
    {
        
    }

    public Vehicle(string description, string? urlImage, decimal price, int categoryId)
    {
        Description = description;
        UrlImage = urlImage;
        Price = price;
        Active = true;
        CategoryId = categoryId;
    }
}
