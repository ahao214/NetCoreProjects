using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Joker.Net.BaseRepository
{
    public class ArticleTypeRepository:BaseRepository<ArticleType>,IArticleTypeRepository
    {
        private readonly SqlDbContext _dbContext;

        public ArticleTypeRepository( SqlDbContext dbContext)
        {
            base._db = dbContext;
            _dbContext = dbContext; 
        }

        public override async Task<List<ArticleType>> FindAllAsync()
        {
            return await _dbContext.articleTypes.Include(x => x.Articles).ToListAsync();
        }

        public async override Task<List<ArticleType>> FindAllAsync(Expression<Func<ArticleType, bool>> del)
        {
            return await _dbContext.articleTypes.Where(del).Include(x => x.Articles).ToListAsync();
        }

        public override async Task<ArticleType> FindOneAsync(Guid id)
        {
            return await _dbContext.articleTypes.Include(x => x.Articles).SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<ArticleType> FindOneAsync(Expression<Func<ArticleType, bool>> del)
        {
            return await _dbContext.articleTypes.Include(x => x.Articles).SingleOrDefaultAsync(del);
        }

    }
}
