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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserList")]
        public async Task<List<UserView>> Get()
        {
            var userService = new UserService();
            var userList = await userService.Query();
            return userList;
        }
    }
}
