using Joker.Net.IBaseRepository;
using Joker.Net.IBaseService;
using Joker.Net.Model;


namespace Joker.Net.BaseService
{
    public  class UserService:BaseService <User>,IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            base._repository = userRepository;
            _userRepository = userRepository;
        }


    }
}
