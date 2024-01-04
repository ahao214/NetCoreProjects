using JOKER.NetE.Model;

namespace JOKER.NetE.IService
{
   public interface IUserService
    {
        Task<List<UserView>> Query();

    }
}
