using Joker.Net.IBaseRepository;
using Joker.Net.IBaseService;
using Joker.Net.Model;


namespace Joker.Net.BaseService
{
    public class ArticleTypeService : BaseService<ArticleType>, IArticleTypeService
    {
        private readonly IArticleTypeRepository _articleTypeRepository;

        public ArticleTypeService(IArticleTypeRepository articleTypeRepository)
        {
            base._repository = articleTypeRepository;
            _articleTypeRepository = articleTypeRepository;
        }
    }
}
