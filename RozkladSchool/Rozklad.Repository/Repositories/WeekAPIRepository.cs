using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repository.Dto.WeekDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repository.Repositories
{
   public class WeekAPIRepository
    {

        private readonly RozkladContext _ctx;
        private readonly IMapper _mapper;

        public WeekAPIRepository(RozkladContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WeekReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<WeekReadDto>>(await _ctx.Weeks.ToListAsync());

        }
    }
}
