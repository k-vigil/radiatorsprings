namespace RadiatorSprings.Application.Categories.GetCategoryById;

public record GetCategoryByIdQuery(int Id) : IRequest<object>;
