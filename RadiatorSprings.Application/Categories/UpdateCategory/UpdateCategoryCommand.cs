namespace RadiatorSprings.Application.Categories.UpdateCategory;

public record UpdateCategoryCommand(string Name, string Description, int Id) : IRequest<object>;
