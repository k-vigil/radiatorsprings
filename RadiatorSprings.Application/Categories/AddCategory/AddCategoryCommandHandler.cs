namespace RadiatorSprings.Application.Categories.AddCategory;

public sealed class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, object>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<object> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name, request.Description);
        _categoryRepository.AddCategory(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
