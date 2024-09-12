namespace RadiatorSprings.Application.Categories.GetCategories;

public sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, object>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<object> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var data = await _categoryRepository.GetCategoriesAsync();
        var dto = data.Select(i => new CategoryDto(i.Id, i.Name, i.Description));

        return dto;
    }
}
