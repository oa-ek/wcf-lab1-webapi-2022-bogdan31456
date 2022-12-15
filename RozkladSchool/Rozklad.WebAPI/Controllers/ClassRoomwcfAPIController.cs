using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.ClassDto;
using Rozklad.Repository.Repositories;
using Rozklad.Core;

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
        [HttpGet("classroom/{id}")]
        public ClassRoom GetClass(int id)
        {
            return classroomApiRepository.GetClass(id);
        }
        [HttpGet]

        public async Task<IEnumerable<ClassRoomReadDto>> GetListAsync()
        {
            return await classroomApiRepository.GetListAsync();
        }

        [HttpPost]
        public async Task<ClassRoom> Create(ClassCreateDto classDto)
        {
            var createdclass = await classroomApiRepository.AddClassRoom(classDto);
            return createdclass;
        }

        [HttpPut]
        public async Task Edit(ClassCreateDto cab)
        {
            await classroomApiRepository.UpdateClass(cab);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await classroomApiRepository.DeleteClass(id);
        }
    }
}
