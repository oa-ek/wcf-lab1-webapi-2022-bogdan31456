using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.ClassDto;
using Rozklad.Repository.Repositories;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomwcfAPIController : ControllerBase
    {
        private readonly ClassRoomAPIRepository classroomApiRepository;
        public ClassRoomwcfAPIController(ClassRoomAPIRepository classroomApiRepository)
        {

            this.classroomApiRepository = classroomApiRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<ClassRoomReadDto>> GetListAsync()
        {
            return await classroomApiRepository.GetListAsync();
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
