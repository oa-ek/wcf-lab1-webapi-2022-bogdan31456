using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repository.Dto.DisciplineDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repository.Repositories
{
    public class DisciplineAPIRepository
    {

        private readonly RozkladContext _ctx;
        private readonly IMapper _mapper;

        public DisciplineAPIRepository(RozkladContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DisciplineReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<DisciplineReadDto>>(await _ctx.Disciplines.ToListAsync());

        }

        public async Task<Discipline> AddDiscipline(DisciplineCreateDto disDto)
        {
            var dis = new Discipline();
            dis.DisciplineId = disDto.DisciplineId;
            dis.DisciplineName = disDto.DisciplineName;
            _ctx.Disciplines.Add(dis);
            await _ctx.SaveChangesAsync();
            return _ctx.Disciplines.FirstOrDefault(x => x.DisciplineName == dis.DisciplineName);
        }
        public async Task UpdateDiscipline(DisciplineCreateDto updateDiscipline)
        {
            var discipline = _ctx.Disciplines.FirstOrDefault(x => x.DisciplineId == updateDiscipline.DisciplineId);
            discipline.DisciplineName = updateDiscipline.DisciplineName;
            //cabinet.CabinetName = updatedCabinet.Name;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteDiscipline(int id)
        {
            _ctx.Remove(GetDiscipline(id));
            await _ctx.SaveChangesAsync();
        }

        public List<Discipline> GetDiscipline()
        {
            var cabinetList = _ctx.Disciplines.ToList();
            return cabinetList;
        }

        public Discipline GetDiscipline(int id)
        {
            return _ctx.Disciplines.FirstOrDefault(x => x.DisciplineId == id);
        }

        public Discipline GetDisciplineByName(string name)
        {
            return _ctx.Disciplines.FirstOrDefault(x => x.DisciplineName == name);
        }
        //public async Task<IEnumerable<CabinetReadDto>> GetItemAsync(string name)
        //{
        // return _ctx.Cabinets.FirstOrDefault(x => x.CabinetName == name);
        //}
    }
}
