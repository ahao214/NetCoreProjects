using AutoMapper;
using Joker.Net.Model;
using Joker.Net.Model.DTO;


namespace Joker.Net.Utility.Mappers
{
    public class DTOMapper : Profile
    {
        public DTOMapper()
        {
            //Article
            base.CreateMap<Article, ArticleDTO>().ForMember(x => x.TypeName, opt =>
            {
                opt.MapFrom(src => src.Type.TypeName);
            });

            //ArticleType
            base.CreateMap<ArticleType, ArticleTypeDTO>().ForMember(x => x.ArticleNames, opt =>
            {
                opt.MapFrom(src => src.Articles.Select(x => x.Title));
            });
        }

    }
}
