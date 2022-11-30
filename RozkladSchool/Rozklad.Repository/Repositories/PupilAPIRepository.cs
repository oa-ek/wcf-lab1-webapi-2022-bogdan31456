using AutoMapper;
using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repository.Repositories
{
   public class PupilAPIRepository
    {

        private readonly RozkladContext _ctx;
        private readonly IMapper _mapper;

        public PupilAPIRepository(RozkladContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LessonReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<LessonReadDto>>(await _ctx.Lessons.Include(x => x.Discipline).Include(x => x.Teacher).Include(x => x.Pupil).ToListAsync());
        }
    }
}
