using AutoMapper;
using JOKER.NetE.Common;
using JOKER.NetE.Common.Caches;
using JOKER.NetE.Common.Core;
using JOKER.NetE.Common.Option;
using JOKER.NetE.IService;
using JOKER.NetE.Model;
using JOKER.NetE.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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
        private readonly IOptions<RedisOptions> _options;
        private readonly ICaching _caching;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBaseService<Role, RoleView> roleService, IOptions<RedisOptions> options, ICaching caching)
        {
            _logger = logger;
            _roleService = roleService;
            _options = options;
            _caching = caching;
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

            var redisOptions = _options.Value;
            Console.WriteLine(JsonConvert.SerializeObject(redisOptions));

            var roleServiceObjNew = App.GetService<IBaseService<Role, RoleView>>(false);
            var roleList2 = await roleServiceObjNew.Query();
            var redisOptions2 = App.GetOptions<RedisOptions>();

            return roleList;

        }
    }
}
