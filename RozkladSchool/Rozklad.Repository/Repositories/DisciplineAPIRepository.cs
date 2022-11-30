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

        //public async Task<IEnumerable<CabinetReadDto>> GetItemAsync(string name)
        //{
        // return _ctx.Cabinets.FirstOrDefault(x => x.CabinetName == name);
        //}
    }
}
