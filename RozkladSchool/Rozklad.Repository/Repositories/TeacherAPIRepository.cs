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
    }
}
