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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CabinetName"></param>
        /// <returns></returns>
        //[HttpGet("{CabinetName}")]
        //public async Task<IEnumerable<CabinetReadDto>> GetItemAsync(string CabinetName)
        //{
        //return await cabinetApiRepository.GetItemAsync(CabinetName);
        // }

        //[HttpPost]
        //public async Task<int> Create(CabinetReadDto obj)
        //{
        // return obj.CabinetId * 3;
        //}

    }
}
