using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.Model;

namespace Joker.Net.BaseRepository
{
    public class ArticleRepository : BaseRepository<Article>,IArticleRepository
    {
        private readonly SqlDbContext _dbContext;

        public ArticleRepository(SqlDbContext dbContext)
        {
            base._db = dbContext;
            _dbContext = dbContext;
        }


    }
}
