using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.LessonDto;
using Rozklad.Repository.Repositories;
using Rozklad.Core;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonwcfAPIController : ControllerBase
    {

        private readonly LessonAPIRepository lessonApiRepository;
        public LessonwcfAPIController(LessonAPIRepository lessonApiRepository)
        {

            this.lessonApiRepository = lessonApiRepository;
        }
        [HttpGet("lesson/{id}")]
        public Lesson GetLesson(int id)
        {
            return lessonApiRepository.GetLesson(id);
        }
        [HttpGet]

        public async Task<IEnumerable<LessonReadDto>> GetListAsync()
        {
            return await lessonApiRepository.GetListAsync();
        }


        [HttpPost]
        public async Task<Lesson> Create(LessonCreateDto lessonDto)
        {
            var createdLesson = await lessonApiRepository.AddLesson(lessonDto);
            return createdLesson;
        }

        [HttpPut]
        public async Task Edit(LessonCreateDto cab)
        {
            await lessonApiRepository.UpdateLesson(cab);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await lessonApiRepository.DeleteLesson(id);
        }
    }
}
