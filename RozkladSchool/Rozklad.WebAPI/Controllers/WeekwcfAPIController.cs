using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.WeekDto;
using Rozklad.Repository.Repositories;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekwcfAPIController : ControllerBase
    {
        private readonly ILogger<WeekwcfAPIController> _logger;
        private readonly WeekAPIRepository weekApiRepository;
        public WeekwcfAPIController(WeekAPIRepository weekApiRepository)
        {

            this.weekApiRepository = weekApiRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<WeekReadDto>> GetListAsync()
        {
            return await weekApiRepository.GetListAsync();
        }
    }
}
