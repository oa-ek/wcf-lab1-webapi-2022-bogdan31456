using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.TeacherDto;
using Rozklad.Repository.Repositories;
using Rozklad.Core;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherwcfAPIController : ControllerBase
    {


        private readonly TeacherAPIRepository teacherAPIRepository;
        public TeacherwcfAPIController(TeacherAPIRepository teacherAPIRepository)
        {

            this.teacherAPIRepository = teacherAPIRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<TeacherReadDto>> GetListAsync()
        {
            return await teacherAPIRepository.GetListAsync();
        }

        [HttpPost]
        public async Task<Teacher> Create(TeacherCreateDto cabDto)
        {
            var createdCabinet = await teacherAPIRepository.AddTeacher(cabDto);
            return createdCabinet;
        }


        [HttpPut]
        public async Task Edit(TeacherCreateDto teach)
        {
            await teacherAPIRepository.UpdateTeacher(teach);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await teacherAPIRepository.DeleteTeacher(id);
        }
    }
}
