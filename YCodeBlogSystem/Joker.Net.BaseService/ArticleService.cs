using Joker.Net.IBaseRepository;
using Joker.Net.IBaseService;
using Joker.Net.Model;


namespace Joker.Net.BaseService
{
    public class ArticleService : BaseService<Article>, IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            base._repository = articleRepository;
            this.articleRepository = articleRepository;
        }
    }
}
