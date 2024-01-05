using AutoMapper;
using JOKER.NetE.Model;
using JOKER.NetE.Service;
using Microsoft.AspNetCore.Mvc;

namespace JOKER.NetE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetList")]
        public async Task<object> Get()
        {
            //var userService = new UserService();
            //var userList = await userService.Query();
            //return userList;
            // 实体泛型 视图泛型
            var roleService = new BaseService<Role, RoleView>(_mapper);
            var roleList = await roleService.Query();
            return roleList;

        }
    }
}
