using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repository.Dto.ClassDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repository.Repositories
{
    public class ClassRoomAPIRepository
    {
        private readonly RozkladContext _ctx;
        private readonly IMapper _mapper;

        public ClassRoomAPIRepository(RozkladContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassRoomReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<ClassRoomReadDto>>(await _ctx.ClassRooms.ToListAsync());

        }
        public async Task<ClassRoom> AddClassRoom(ClassCreateDto classDto)
        {
            var cls = new ClassRoom();
            cls.ClassRoomId = classDto.ClassRoomId;
            cls.ClassRoomName= classDto.Name;
            _ctx.ClassRooms.Add(cls);
            await _ctx.SaveChangesAsync();
            return _ctx.ClassRooms.FirstOrDefault(x => x.ClassRoomName == cls.ClassRoomName);
        }


        public async Task UpdateClass(ClassCreateDto updatedClass)
        {
            var classRoom = _ctx.ClassRooms.FirstOrDefault(x => x.ClassRoomId== updatedClass.ClassRoomId);
            classRoom.ClassRoomName = updatedClass.ClassRoomName;
            //cabinet.Name = updatedCabinet.Name;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteClass(int id)
        {
            _ctx.Remove(GetClass(id));
            await _ctx.SaveChangesAsync();
        }

        public List<ClassRoom> GetClass()
        {
            var classroomList = _ctx.ClassRooms.ToList();
            return classroomList;
        }

        public ClassRoom GetClass(int id)
        {
            return _ctx.ClassRooms.FirstOrDefault(x => x.ClassRoomId == id);
        }

        public ClassRoom GetClassname(string name)
        {
            return _ctx.ClassRooms.FirstOrDefault(x => x.ClassRoomName == name);
        }
        //public async Task<IEnumerable<CabinetReadDto>> GetItemAsync(string name)
        //{
        // return _ctx.Cabinets.FirstOrDefault(x => x.CabinetName == name);
        //}
    }
}
