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

        //public async Task<IEnumerable<CabinetReadDto>> GetItemAsync(string name)
        //{
        // return _ctx.Cabinets.FirstOrDefault(x => x.CabinetName == name);
        //}
    }
}
