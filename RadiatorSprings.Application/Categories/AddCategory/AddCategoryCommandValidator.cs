using FluentValidation;

namespace RadiatorSprings.Application.Categories.AddCategory;

public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator()
    {
        RuleFor(e => e.Name)
            .MinimumLength(5)
            .NotEmpty();
    }
}
