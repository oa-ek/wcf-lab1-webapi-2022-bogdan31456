using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.DisciplineDto;
using Rozklad.Repository.Repositories;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinewcfAPIController : ControllerBase
    {
        private readonly DisciplineAPIRepository disciplineApiRepository;
        public DisciplinewcfAPIController(DisciplineAPIRepository disciplineApiRepository)
        {

            this.disciplineApiRepository = disciplineApiRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<DisciplineReadDto>> GetListAsync()
        {
            return await disciplineApiRepository.GetListAsync();
        }

        

    }
}
