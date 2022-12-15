using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.TimetableDto;
using Rozklad.Repository.Repositories;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetablewcfAPIController : ControllerBase
    {
        private readonly TimetableAPIRepository timetableApiRepository;
        public TimetablewcfAPIController(TimetableAPIRepository timetableApiRepository)
        {

            this.timetableApiRepository = timetableApiRepository;
        }
       /* [HttpGet("timetable/{id}")]
        public Timetable GetTeacher(int id)
        {
            return teacherAPIRepository.GetTeacher(id);
        }*/
        [HttpGet]

        public async Task<IEnumerable<TimetableReadDto>> GetListAsync()
        {
            return await timetableApiRepository.GetListAsync();
        }
    }
}
