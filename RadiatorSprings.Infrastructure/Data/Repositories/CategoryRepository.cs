namespace RadiatorSprings.Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddCategory(Category category) =>
        _context.Categories.Add(category);

    public async Task<IReadOnlyList<Category>> GetCategoriesAsync() =>
        await _context.Categories.AsNoTracking().ToListAsync();

    public async Task<Category?> GetCategoryByIdAsync(int id) =>
        await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);

    public void UpdateCategory(Category category) =>
        _context.Categories.Update(category);
}
