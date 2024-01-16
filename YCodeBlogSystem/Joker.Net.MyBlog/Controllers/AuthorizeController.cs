using Joker.Net.IBaseService;
using Joker.Net.Model;
using Joker.Net.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Joker.Net.MyBlog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IOptionsSnapshot<JwtSetting> _settings;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public AuthorizeController(IOptionsSnapshot<JwtSetting> settings, IUserService userService, UserManager<User> userManager)
        {
            _settings = settings;
            _userService = userService;
            _userManager = userManager;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ApiResult>> Login(CheckRequestInfo info)
        {
            var isExist = await _userService.FindOneAsync(x => x.UserName == info.userName);
            if (isExist is null)
            {
                return ApiResultHelper.Error("用户或者密码输入错误");
            }

            // 判断是否被冻结
            if (await _userManager.IsLockedOutAsync(isExist))
            {
                return ApiResultHelper.Error($"用户{isExist.UserName} 已经被冻结，距离解冻还需{isExist.LockoutEnd}分");
            }

            // 执行登录操作
            var result = await _userManager.CheckPasswordAsync(isExist, info.userPwd);
            if (result)
            {
                // 重置登录次数
                await _userManager.ResetAccessFailedCountAsync(isExist);

                //颁发令牌
                //1. 声明payload
                List<Claim> claims = new List<Claim>() {
                    new (ClaimTypes.NameIdentifier,isExist.Id.ToString()),
                    new (ClaimTypes.Name,isExist.UserName),
                    new ("JwtVersion",isExist.JwtVersion.ToString())
                };
                var roles = await _userManager.GetRolesAsync(isExist);
                foreach (var role in roles)
                {
                    claims.Add(new(ClaimTypes.Role, role));
                }

                //2. 生成jwt
                string? key = _settings.Value.SecKey;
                DateTime expire = DateTime.Now.AddSeconds(_settings.Value.ExpireSeconds);

                byte[] secBytes = Encoding.UTF8.GetBytes(key);
                var secKey = new SymmetricSecurityKey(secBytes);
                var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new JwtSecurityToken(
                    claims: claims,
                    issuer: _settings.Value.Issuer,
                    audience: _settings.Value.Audience,
                    expires: expire,
                    signingCredentials: credentials
                    );

                string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

                //3. 返回jwt
                return ApiResultHelper.Success(jwt);
            }
            else
            {
                // 记录登录次数
                await _userManager.AccessFailedAsync(isExist);
                return ApiResultHelper.Error($"用户名或者密码输入错误");
            }
        }



    }
}
