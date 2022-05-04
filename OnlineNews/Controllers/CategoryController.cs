using Microsoft.AspNetCore.Mvc;
using OnlineNews.Interfaces;
using OnlineNews.Models;

namespace OnlineNews.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryservice;
        private ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryservice = categoryService;
            _logger = logger;
        }
        [HttpGet("AllCategory")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var c = await _categoryservice.GetAllCategoriesAsync();
                return Ok(c);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryDto categoryDto)
        {
            try
            {
                await _categoryservice.AddCategoryAsync(categoryDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                await _categoryservice.RemoveCategoryAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
