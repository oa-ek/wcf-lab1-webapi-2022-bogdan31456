using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rozklad.Repository;
using Rozklad.Repository.Dto;
using Rozklad.Repository.Repositories;

namespace Rozklad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserwcfAPIController : ControllerBase
    {
        private readonly UsersAPIRepository userAPIRepository;
        private readonly ILogger<UserwcfAPIController> _logger;
        public UserwcfAPIController(ILogger<UserwcfAPIController> logger, UsersRepository userApiRepository)
        {
            _logger = logger;
            this.userAPIRepository = userAPIRepository;
        }
        [HttpGet]
        public UsersAPIRepository GetPupilRepository()
        {
            return userAPIRepository;
        }

       
        [HttpGet("GetPupilListAsync")]
        public async Task<IEnumerable<UserReadDto>> GetListAsync()
        {
            return await userAPIRepository.GetListAsync();
        }
    }
}
