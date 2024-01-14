using System.Security.Claims;

namespace Common.Jwt
{
    public interface ITokenService
    {
        string BuildToken(IEnumerable<Claim> claims, JwtSetting setting);
    }
}
