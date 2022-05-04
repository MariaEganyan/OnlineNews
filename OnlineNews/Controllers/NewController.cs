using Microsoft.AspNetCore.Mvc;
using OnlineNews.Interfaces;
using OnlineNews.Models;

namespace OnlineNews.Controllers
{
    [ApiController]
    [Route("controller")]
    public class NewController : Controller
    {
        private INewService _newservice;
        private ILogger<NewController> _logger;
        public NewController(INewService newService, ILogger<NewController> logger)
        {
            _logger = logger;
            _newservice = newService;
        }
        [HttpGet("byCategory")]
        public async Task<IActionResult> GetbyCategoryAsync(string category)
        {
            try
            {
               var n=await _newservice.GetByCategoryAsync(category);
                return Ok(n);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("byDate")]
        public async Task<IActionResult> GetByDatetime(DateTime first, DateTime last)
        {
            try
            {
                var n= await _newservice.GetByDatetimeAsync(first, last);
                return Ok(n);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByContent")]
        public async Task<IActionResult> GetByContent(string content)
        {
            try
            {
                var n = await _newservice.GetByContentAsync(content);
                return Ok(n);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("news")]
        public async Task<IActionResult> AddNewAsync(NewDto newDto)
        {
            try
            {
                await  _newservice.AddNewAsync(newDto);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
