using Common.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using User.Domain;

namespace User.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDomainService _userDomainService;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IOptionsSnapshot<JwtSetting> _options;

        public LoginController(UserDomainService userDomainService,ITokenService tokenService,IUserRepository userRepository,IOptionsSnapshot<JwtSetting> options)
        {
            _userDomainService = userDomainService;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _options = options;
        }



    }
}
