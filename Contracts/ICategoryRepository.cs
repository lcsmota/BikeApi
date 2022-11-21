using BikeApi.Model;

namespace BikeApi.Contracts;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<Category> CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(int id, Category category);
    Task DeleteCategoryAsync(int id);
}
