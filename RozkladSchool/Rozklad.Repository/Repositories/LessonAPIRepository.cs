using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repository.Dto.LessonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rozklad.Core;

namespace Rozklad.Repository.Repositories
{
    public class LessonAPIRepository
    {
        private readonly RozkladContext _ctx;
        private readonly IMapper _mapper;

        public LessonAPIRepository(RozkladContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LessonReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<LessonReadDto>>(await _ctx.Lessons.Include(x=>x.Discipline).Include(x => x.Teacher).Include(x => x.Pupil).ToListAsync());
        }

        public async Task<Lesson> AddLesson(LessonCreateDto lessonDto)
        {
            var lesoon = new Lesson();
            lesoon.LessonId= lessonDto.LessonId;
            lesoon.LessonName = lessonDto.LessonName;
            _ctx.Lessons.Add(lesoon);
            await _ctx.SaveChangesAsync();
            return _ctx.Lessons.FirstOrDefault(x => x.LessonName == lesoon.LessonName);
        }

        public async Task UpdateLesson(LessonCreateDto updatedLesson)
        {
            var cabinet = _ctx.Lessons.FirstOrDefault(x => x.LessonId == updatedLesson.LessonId);
            cabinet.LessonName = updatedLesson.LessonName;
           // cabinet.CabinetName = updatedCabinet.Name;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteLesson(int id)
        {
            _ctx.Remove(GetLesson(id));
            await _ctx.SaveChangesAsync();
        }

        public List<Lesson> GetLessons()
        {
            var lessonList = _ctx.Lessons.ToList();
            return lessonList;
        }

        public Lesson GetLesson(int id)
        {
            return _ctx.Lessons.FirstOrDefault(x => x.LessonId == id);
        }

        public Lesson GetLessonByName(string name)
        {
            return _ctx.Lessons.FirstOrDefault(x => x.LessonName == name);
        }

    }
}
