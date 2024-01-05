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
            // ʵ�巺�� ��ͼ����
            //var roleService = new BaseService<Role, RoleView>(_mapper);
            //var roleList = await roleService.Query();

            var roleList = await _roleService.Query();
            // ��ȡappsettings.json ������õ�Enable����������
            var redisEnable = AppSettings.app(new string[] { "Redis", "Enable" });

            // ��ȡappsettings.json ������õ� ConnectionString ����������
            var redisConnectionString = AppSettings.GetValue("Redis:ConnectionString");
            Console.WriteLine($"Enable:{redisEnable},ConnectionString:{redisConnectionString}");

            return roleList;

        }
    }
}
