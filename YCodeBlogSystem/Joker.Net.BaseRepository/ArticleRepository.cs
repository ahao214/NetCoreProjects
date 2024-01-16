using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Joker.Net.BaseRepository
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly SqlDbContext _dbContext;

        public ArticleRepository(SqlDbContext dbContext)
        {
            base._db = dbContext;
            _dbContext = dbContext;
        }

        public override async Task<List<Article>> FindAllAsync()
        {
            return await _dbContext.articles.Include(x => x.User).Include(x => x.Type).ToListAsync();
        }

        public override async Task<List<Article>> FindAllAsync(Expression<Func<Article, bool>> del)
        {
            return await _dbContext.articles.Where(del).Include(x => x.User).Include(x => x.Type).ToListAsync();
        }

        public override async Task<Article> FindOneAsync(Guid id)
        {
            return await _dbContext.articles.Include(x => x.User).Include(x => x.Type).SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<Article> FindOneAsync(Expression<Func<Article, bool>> del)
        {
            return await _dbContext.articles.Include(x => x.User).Include(x => x.Type).SingleOrDefaultAsync(del);
        }

    }
}
