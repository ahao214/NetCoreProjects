using AutoMapper;
using JOKER.NetE.IService;
using JOKER.NetE.Repository.Base;

namespace JOKER.NetE.Service
{
    public class BaseService<TEntity, TView> : IBaseService<TEntity, TView> where TEntity : class, new()
    {
        private readonly IMapper _mapper;
        public BaseService(IMapper mapper)
        {
                _mapper = mapper;
        }


        public async Task<List<TView>> Query()
        {
            var baseRepo = new BaseRepository<TEntity>();
            var entities = await baseRepo.Query();
            var result = _mapper.Map<List<TView>>(entities);
            return result;
        }

       
    }
}
