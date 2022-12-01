using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository.Dto.DisciplineDto;
using Rozklad.Repository.Repositories;
using Rozklad.Core;

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

        [HttpPost]
        public async Task<Discipline> Create(DisciplineCreateDto disDto)
        {
            var createdDiscipline = await disciplineApiRepository.AddDiscipline(disDto);
            return createdDiscipline;
        }
        [HttpPut]
        public async Task Edit(DisciplineCreateDto dis)
        {
            await disciplineApiRepository.UpdateDiscipline(dis);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await disciplineApiRepository.DeleteDiscipline(id);
        }
    }
}

