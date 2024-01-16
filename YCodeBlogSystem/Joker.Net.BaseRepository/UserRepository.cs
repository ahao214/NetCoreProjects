using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.Model;

namespace Joker.Net.BaseRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SqlDbContext _dbContext;

        public UserRepository(SqlDbContext dbContext)
        {
            base._db = dbContext;
            _dbContext = dbContext;
        }



    }
}
