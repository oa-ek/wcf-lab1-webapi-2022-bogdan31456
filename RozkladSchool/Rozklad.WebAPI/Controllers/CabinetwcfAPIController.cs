using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Core;
using Rozklad.Repository.Dto.CabinetDto;
using Rozklad.Repository.Repositories;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinetwcfAPIController : ControllerBase
    {

        private readonly ILogger<CabinetwcfAPIController> _logger;
        private readonly CabinetAPIRepository cabinetApiRepository;
        public CabinetwcfAPIController(CabinetAPIRepository cabinetApiRepository)
        {

            this.cabinetApiRepository = cabinetApiRepository;
        }
        [HttpGet("cabinet/{id}")]
        public Cabinet GetCabinet(int id)
        {
            return cabinetApiRepository.GetCabinet(id);
        }
        [HttpGet]

        public async Task<IEnumerable<CabinetReadDto>> GetListAsync()
        {
            return await cabinetApiRepository.GetListAsync();
        }

        [HttpPost]
        public async Task<Cabinet> Create(CabinetCreateDto cabDto)
        {
            var createdCabinet = await cabinetApiRepository.AddCabinet(cabDto);
            return createdCabinet;
        }



        [HttpPut]
        public async Task Edit(CabinetCreateDto cab)
        {
            await cabinetApiRepository.UpdateCabinetAsync(cab);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await cabinetApiRepository.DeleteCabinetAsync(id);
        }
        /* private readonly CabinetAPIRepository cabinetApiRepository;
         private readonly ILogger<CabinetwcfAPIController> _logger;
         public CabinetwcfAPIController(ILogger<CabinetwcfAPIController> logger, CabinetAPIRepository cabinetApiRepository)
         {
             _logger = logger;
             this.cabinetApiRepository = cabinetApiRepository;
         }
         [HttpGet]
         public CabinetAPIRepository GetCabinetRepository()
         {
             return cabinetApiRepository;
         }


         [HttpGet("GetCabinetListAsync")]
         public async Task<IEnumerable<CabinetReadDto>> GetListAsync()
         {
             return await cabinetApiRepository.GetListAsync();
         }

         [HttpPost]
         public async Task<Cabinet> Create(CabinetCreateDto cabDto)
         {
             var createdCabinet = await cabinetApiRepository.AddCabinetByDtoAsync(cabDto);
             return createdCabinet;
         }

         [HttpPut]
         public async Task Edit(CabinetCreateDto cab)
         {
             await cabinetApiRepository.UpdateCabinetAsync(cab);
         }

         [HttpDelete("{id}")]
         public async Task Delete(int id)
         {
             await cabinetApiRepository.DeleteCabinetAsync(id);
         }*/

    }
}
