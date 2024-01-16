using Microsoft.AspNetCore.Identity;

namespace Joker.Net.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : IdentityUser<Guid>
    {
        public long JwtVersion { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
        public bool IsDeleted { get; set; }
    }
}
