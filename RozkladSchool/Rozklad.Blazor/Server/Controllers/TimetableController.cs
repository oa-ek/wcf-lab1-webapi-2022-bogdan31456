﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Core;
using Rozklad.Repository.Dto.TimetableDto;
using Rozklad.Repository.Repositories;

namespace Rozklad.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetableController : ControllerBase
    {//private readonly ClassRoomRepository classRoomRepository;
        private readonly CabinetAPIRepository cabinetRepository;
        private readonly ClassRoomAPIRepository classRoomRepository;
        private readonly DisciplineAPIRepository disciplineRepository;
        private readonly TeacherAPIRepository teacherRepository;
        private readonly WeekAPIRepository weekRepository;
        private readonly PupilAPIRepository pupilRepository;
        private readonly LessonAPIRepository lessonRepository;
        //private readonly UsersRepository usersRepository;
        //private readonly UserManager<User> userManager;
        // private readonly SignInManager<User> signInManager;
        private readonly ILogger<TimetableController> _logger;
        // private readonly TimetableRepository ctx;
        private readonly TimetableAPIRepository timetableRepository;
        //private readonly CabinetRepository cabinetsRepository;
        public TimetableController(TimetableAPIRepository timetableRepository, ClassRoomAPIRepository classRoomRepository, CabinetAPIRepository cabinetRepository, DisciplineAPIRepository disciplineRepository, TeacherAPIRepository teacherRepository, WeekAPIRepository weekRepository, PupilAPIRepository pupilRepository, LessonAPIRepository lessonRepository, ILogger<TimetableController> logger)
        {
            this.timetableRepository = timetableRepository;

            _logger = logger;

            this.classRoomRepository = classRoomRepository;
            this.cabinetRepository = cabinetRepository;
            this.weekRepository = weekRepository;
            this.disciplineRepository = disciplineRepository;
            this.teacherRepository = teacherRepository;
            this.pupilRepository = pupilRepository;
            this.lessonRepository = lessonRepository;
            //this.usersRepository = usersRepository;
            // this.userManager = userManager;
            //this.signInManager = signInManager;

        }



        [HttpGet("/timetable")]
        public async Task<IActionResult> GetListAsync()
        {
            return Ok(await timetableRepository.GetListAsync());
        }

        [HttpGet("{id}")]
        public async Task<TimetableReadDto> GetById(int id)
        {
            return await timetableRepository.GetAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await timetableRepository.DeleteTimetableAsync(id);
        }

        [HttpGet("search/{searchText}")]
        public ActionResult<List<TimetableCreateDto>> SearchTimetables(string searchText)
        {
            return Ok(timetableRepository.SearchTimetable(searchText));
        }
        /*
        [HttpPost("/timetable")]
        //public async Task<int> CreateAsync(TimetableCreateDto timetable)
        //{
        //return await timetableRepository.CreateAsync(timetable);
        //}
        public async Task<TimetableCreateDto> CreateTimetable(TimetableCreateDto timetableCreateDto)
        {
            var cabinet = cabinetRepository.GetCabinetByName(timetableCreateDto.CabinetName);
            if (cabinet == null)
            {
                cabinet = new Cabinet() { CabinetName = timetableCreateDto.CabinetName };
                cabinet = await cabinetRepository.AddCabinetAsync(cabinet);
            }

            var lesson = lessonRepository.GetLessonByName(timetableCreateDto.LessonName);
            if (lesson == null)
            {
                lesson = new Lesson() { LessonName = timetableCreateDto.LessonName };
                lesson = await lessonRepository.AddLessonAsync(lesson);
            }

            var week = weekRepository.GetWeekByName(timetableCreateDto.WeekName);
            if (week == null)
            {
                week = new Week() { WeekName = timetableCreateDto.WeekName };
                week = await weekRepository.AddWeekAsync(week);
            }

            var discipline = disciplineRepository.GetDisciplineByName(timetableCreateDto.DisciplineName);
            if (discipline == null)
            {
                discipline = new Discipline() { DisciplineName = timetableCreateDto.DisciplineName };
                discipline = await disciplineRepository.AddDisciplineAsync(discipline);
            }

            var pupil = pupilRepository.GetPupilByName(timetableCreateDto.PupilName);
            if (pupil == null)
            {
                pupil = new Pupil() { PupilName = timetableCreateDto.PupilName };
                pupil = await pupilRepository.AddPupilAsync(pupil);
            }

            var teacher = teacherRepository.GetTeacherByName(timetableCreateDto.TeacherName);
            if (teacher == null)
            {
                teacher = new Teacher() { TeacherName = timetableCreateDto.TeacherName };
                teacher = await teacherRepository.AddTeacherAsync(teacher);
            }

            var timetable = await timetableRepository.AddTimetableAsync(new Timetable()
            {
                LessonNumber = timetableCreateDto.LessonNumber,
                Day = timetableCreateDto.Day,
                TimeStart = timetableCreateDto.TimeStart,
                TimeEnd = timetableCreateDto.TimeEnd,
                Cabinet = cabinet,
                Lesson = lesson,

                Week = week,


                //Discipline = discipline,
            });
            return timetable;
        }*/
    }
}
