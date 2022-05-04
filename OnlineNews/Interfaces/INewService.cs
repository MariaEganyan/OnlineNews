using OnlineNews.Models;

namespace OnlineNews.Interfaces
{
    public interface INewService
    {
        Task AddNewAsync(NewDto newDto);
        Task DeleteAsync(int id);
        Task<NewDto> GetByCategoryAsync(string category);
        Task<IEnumerable<NewDto>> GetByContentAsync(string content);
        Task<IEnumerable<NewDto>> GetByDatetimeAsync(DateTime firstdate, DateTime lastdate);
    }
}
