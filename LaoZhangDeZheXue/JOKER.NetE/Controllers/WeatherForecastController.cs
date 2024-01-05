using AutoMapper;
using JOKER.NetE.Common;
using JOKER.NetE.IService;
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
        private readonly IBaseService<Role, RoleView> _roleService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseService<Role, RoleView> roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        [HttpGet(Name = "GetList")]
        public async Task<object> Get()
        {
            //var userService = new UserService();
            //var userList = await userService.Query();
            //return userList;
            // 实体泛型 视图泛型
            //var roleService = new BaseService<Role, RoleView>(_mapper);
            //var roleList = await roleService.Query();

            var roleList = await _roleService.Query();
            // 获取appsettings.json 里面的拿到Enable参数的内容
            var redisEnable = AppSettings.app(new string[] { "Redis", "Enable" });

            // 获取appsettings.json 里面的拿到 ConnectionString 参数的内容
            var redisConnectionString = AppSettings.GetValue("Redis:ConnectionString");
            Console.WriteLine($"Enable:{redisEnable},ConnectionString:{redisConnectionString}");

            return roleList;

        }
    }
}
