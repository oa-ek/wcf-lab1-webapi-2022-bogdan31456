using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repository.Dto.TeacherDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repository.Repositories
{
   public class TeacherAPIRepository
    {

        private readonly RozkladContext _ctx;
        private readonly IMapper _mapper;

        public TeacherAPIRepository(RozkladContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<TeacherReadDto>>(await _ctx.Teachers.ToListAsync());

        }

        public async Task<Teacher> AddTeacher(TeacherCreateDto teachDto)
        {
            var teach= new Teacher();
            teach.TeacherId= teachDto.TeacherId;
            teach.TeacherName = teachDto.TeacherName;
            _ctx.Teachers.Add(teach);
            await _ctx.SaveChangesAsync();
            return _ctx.Teachers.FirstOrDefault(x => x.TeacherName == teach.TeacherName);
        }

        public async Task UpdateTeacher(TeacherCreateDto updatedTeacher)
        {
            var teacher = _ctx.Teachers.FirstOrDefault(x => x.TeacherId == updatedTeacher.TeacherId);
            teacher.TeacherName= updatedTeacher.TeacherName;
            //cabinet.CabinetName = updatedCabinet.Name;
            await _ctx.SaveChangesAsync();
        }


        public async Task DeleteTeacher(int id)
        {
            _ctx.Remove(GetTeacher(id));
            await _ctx.SaveChangesAsync();
        }

        public List<Teacher> GetTeacher()
        {
            var cabinetList = _ctx.Teachers.ToList();
            return cabinetList;
        }

        public Teacher GetTeacher(int id)
        {
            return _ctx.Teachers.FirstOrDefault(x => x.TeacherId == id);
        }

        public Teacher GetTeacherByName(string name)
        {
            return _ctx.Teachers.FirstOrDefault(x => x.TeacherName == name);
        }
    }
}
