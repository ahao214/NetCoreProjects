using JOKER.NetE.Model;
using Newtonsoft.Json;

namespace JOKER.NetE.Repository
{

    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\":19,\"Name\":\"joker\"}]";
            return JsonConvert.DeserializeObject<List<User>>(data) ?? new List<User>();
        }
    }
}
