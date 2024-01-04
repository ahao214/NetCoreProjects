using JOKER.NetE.IService;
using JOKER.NetE.Model;
using JOKER.NetE.Repository;

namespace JOKER.NetE.Service
{
    public class UserService : IUserService
    {
        public async Task<List<UserView>> Query()
        {
            var userRepo = new UserRepository();
            var users = await userRepo.Query();
            return users.Select(d => new UserView() { UserName = d.Name }).ToList();
        }
    }
}
