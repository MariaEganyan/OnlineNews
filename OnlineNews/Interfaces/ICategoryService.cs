using OnlineNews.Models;

namespace OnlineNews.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryDto categoryDto);
        Task RemoveCategoryAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<Category> GetById(int? id);
        Task UpdateAsync(Category category);
    }
}
