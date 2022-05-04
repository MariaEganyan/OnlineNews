using OnlineNews.Interfaces;
using OnlineNews.Models;

namespace OnlineNews.Services
{
    public class CategoryService : ICategoryService
    {
        private OnlineNewsPRContext _context;
        public CategoryService()
        {
            _context = new OnlineNewsPRContext();
        }
        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category()
            {
                Categoryid = categoryDto.Categoryid,
                Description = categoryDto.Description,
            };
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = from c in _context.Categories
                             select new CategoryDto()
                             {
                                 Categoryid = c.Categoryid,
                                 Description = c.Description,
                             };
            return await Task.FromResult(categories);
        }

        public async Task RemoveCategoryAsync(int id)
        {
            var n = _context.Categories.FirstOrDefault(c => c.Categoryid == id);
            if(n != null)
            {
                _context.Categories.Remove(n);
                _context.SaveChanges();
                await Task.CompletedTask;
            }
            else
            {
                throw new Exception("that category id is not found");
            }
        }
        public async Task<Category> GetById(int? id)
        {
            var c= _context.Categories.FirstOrDefault(c => c.Categoryid == id);
            if (c == null)
            {
                throw new Exception("that categoryid is not found");
            }
            return await Task.FromResult(c);
        }
        
    }
}
