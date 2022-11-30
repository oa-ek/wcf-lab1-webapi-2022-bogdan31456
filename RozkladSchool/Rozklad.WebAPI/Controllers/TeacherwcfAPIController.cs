using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.TeacherDto;
using Rozklad.Repository.Repositories;

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
    }
}
