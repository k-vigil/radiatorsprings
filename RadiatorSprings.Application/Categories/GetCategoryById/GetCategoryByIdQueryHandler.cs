namespace RadiatorSprings.Application.Categories.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, object>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<object> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _categoryRepository.GetCategoryByIdAsync(request.Id);

        if (data is null) return Task.CompletedTask;

        var dto = new CategoryDto(data.Id, data.Name, data.Description);

        return dto;
    }
}
