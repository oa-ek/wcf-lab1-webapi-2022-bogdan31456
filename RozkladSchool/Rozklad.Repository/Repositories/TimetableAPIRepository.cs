using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repository.Dto.TimetableDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repository.Repositories
{
    public class TimetableAPIRepository
    {
        private readonly RozkladContext _ctx;
        private readonly IMapper _mapper;

        public TimetableAPIRepository(RozkladContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TimetableReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<TimetableReadDto>>(await _ctx.Timetables.Include(x => x.Cabinet).Include(x => x.Lesson).ToListAsync());

        }


        public List<Timetable> GetTimetable()
        {
            var timetable = _ctx.Timetables.Include(x => x.Lesson).ThenInclude(x => x.Teacher).Include(x => x.Lesson).ThenInclude(x => x.Discipline).Include(x => x.Lesson).ThenInclude(x => x.Pupil).
               Include(x => x.Cabinet).
               Include(x => x.Week).ToList();
            return timetable;
        }

        public async Task<TimetableReadDto> GetAsync(int id)
        {
            return _mapper.Map<TimetableReadDto>(await _ctx.Timetables.Include(x => x.Cabinet).Include(x => x.Lesson)/*ThenInclude(x => x.Discipline)/*Include(x => x.Lesson.Teacher).Include(x => x.Lesson.Pupil).ThenInclude(x => x.ClassRoom)/*.Include(x => x.Week).Include(x => x.User)*/.FirstAsync());
        }

        public Timetable GetTimetable(int id)
        {
            return _ctx.Timetables.Include(x => x.Lesson).ThenInclude(x => x.Teacher).
               Include(x => x.Lesson).
               ThenInclude(x => x.Discipline).
               Include(x => x.Lesson).
               ThenInclude(x => x.Pupil).
               Include(x => x.Cabinet).
               Include(x => x.Week).
               Include(x => x.Lesson).
               ThenInclude(x => x.Pupil).
               ThenInclude(x => x.ClassRoom).
               Include(x => x.User).

               FirstOrDefault();
        }
        public async Task DeleteTimetableAsync(int id)
        {
            _ctx.Remove(GetTimetable(id));
            await _ctx.SaveChangesAsync();
        }

        public List<TimetableCreateDto> SearchTimetable(string searchText)
        {
            return GetTimetablesDto().
                Where(x => x.LessonNumber.ToString().Contains(searchText.ToLower()) || x.TimeStart.ToLower().Contains(searchText.ToLower()) || x.TimeEnd.ToString().Contains(searchText.ToLower())).ToList();
        }

        public List<TimetableCreateDto> GetTimetablesDto()
        {
            var timetableList = _ctx.Timetables.Include(x => x.Cabinet).Include(x => x.Week).Include(x => x.User).ToList();
            var timetableListDto = new List<TimetableCreateDto>();
            foreach (var timetable in timetableList)
            {
                timetableListDto.Add(new TimetableCreateDto
                {
                    TimetableId = timetable.TimetableId,
                    LessonNumber = timetable.LessonNumber,
                    TimeStart = timetable.TimeStart,
                    CabinetName = timetable.Cabinet.CabinetName,
                    WeekName = timetable.Week.WeekName,

                });
            }
            return timetableListDto;
        }
    }
}
