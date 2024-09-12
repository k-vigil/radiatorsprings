namespace RadiatorSprings.Application.Categories.AddCategory;

public record AddCategoryCommand(string Name, string? Description) : IRequest<object>;
