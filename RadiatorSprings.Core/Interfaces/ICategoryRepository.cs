using RadiatorSprings.Core.Entities;

namespace RadiatorSprings.Core.Interfaces;

public interface ICategoryRepository
{
    Task<IReadOnlyList<Category>> GetCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    void AddCategory(Category category);
    void UpdateCategory(Category category);
}
