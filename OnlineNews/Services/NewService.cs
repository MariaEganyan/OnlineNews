using OnlineNews.Interfaces;
using OnlineNews.Models;

namespace OnlineNews.Services
{
    public class NewService : INewService
    {
        private OnlineNewsPRContext _context;
        private ICategoryService _categoryService;
        public NewService(ICategoryService categoryService)
        {
            _context = new OnlineNewsPRContext();
            _categoryService = categoryService;
        }
        public async Task AddNewAsync(NewDto newDto)
        {
            var n = new New()
            {
                Newsid = newDto.Newsid,
                Categoryid = newDto.Categoryid,
                Title = newDto.Title,
                Content = newDto.Content,
            };
            //var c= _categoryService.GetById(newDto.Categoryid).Result;
            //var cat = new Category()
            //{
            //    Categoryid = c.Categoryid,
            //    Description = c.Description
            //};
            Check(n.Newsid);
            Check(n.Categoryid);
            Check(n.Title);
            Check(n.Content);
            
            await _context.News.AddAsync(n);
           // cat.News.Add(n);
           //await _categoryService.UpdateAsync(cat);
            _context.SaveChanges();
        }

        private void Check<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
        }
        public async Task DeleteAsync(int id)
        {
            var n = _context.News.FirstOrDefault(c => c.Newsid == id);
            if (n != null)
            {
                _context.News.Remove(n);
                _context.SaveChanges();
                await Task.CompletedTask;
            }
            else
            {
                throw new Exception("that newid is not found");
            }
        }

        public async Task<NewDto> GetByCategoryAsync(string category)
        {
            var n = _context.News.FirstOrDefault(c => c.Category.Description == category);
            if (n != null)
            {
                var ndto = new NewDto()
                {
                    Newsid = n.Newsid,
                    Title = n.Title,
                    Categoryid = n.Categoryid,
                    Content = n.Content,
                    Datetime = n.Datetime,
                };
                return await Task.FromResult(ndto);
            }
            else
            {
                throw new Exception("News with that category is not found");
            }
        }

        public async Task<IEnumerable<NewDto>> GetByContentAsync(string content)
        {
            var n = from nw in _context.News.Where(c => c.Content.Contains(content) || c.Title.Contains(content))
                    select new NewDto()
                    {
                        Newsid = nw.Newsid,
                        Content = nw.Content,
                        Categoryid = nw.Categoryid,
                        Title = nw.Title,
                    };
            if (n != null)
            {
                return await Task.FromResult(n);
            }
            else
            {
                throw new Exception("News with that content is not found");
            }
        }

        public async Task<IEnumerable<NewDto>> GetByDatetimeAsync(DateTime firstdate, DateTime lastdate)
        {
            var n = from nw in _context.News.Where(c => c.Datetime >= firstdate && c.Datetime <= lastdate)
                    select new NewDto()
                    {
                        Newsid = nw.Newsid,
                        Categoryid = nw.Categoryid,
                        Title = nw.Title,
                        Content = nw.Content,
                    };
            if (n != null)
            {
                return await Task.FromResult(n);
            }
            else
            {
                throw new Exception("That news is not found");
            }
        }
    }
}
