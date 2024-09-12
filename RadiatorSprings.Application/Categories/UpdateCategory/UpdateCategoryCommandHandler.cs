namespace RadiatorSprings.Application.Categories.UpdateCategory;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, object>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(request.Id);

        if (category is null) return Task.CompletedTask;

        category.Name = request.Name;
        category.Description = request.Description;

        _categoryRepository.UpdateCategory(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Task.CompletedTask;
    }
}
