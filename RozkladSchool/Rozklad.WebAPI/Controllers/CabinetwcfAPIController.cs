using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.CabinetDto;
using Rozklad.Repository.Repositories;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinetwcfAPIController : ControllerBase
    {

        private readonly CabinetAPIRepository cabinetApiRepository;
        public CabinetwcfAPIController(CabinetAPIRepository cabinetApiRepository)
        {

            this.cabinetApiRepository = cabinetApiRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<CabinetReadDto>> GetListAsync()
        {
            return await cabinetApiRepository.GetListAsync();
        }

        
    }
}
