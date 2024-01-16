using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
