using AutoMapper;
using JOKER.NetE.IService;
using JOKER.NetE.Repository.Base;

namespace JOKER.NetE.Service
{
    public class BaseService<TEntity, TView> : IBaseService<TEntity, TView> where TEntity : class, new()
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IMapper mapper, IBaseRepository<TEntity> baseRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }


        public async Task<List<TView>> Query()
        {
            var entities = await _baseRepository.Query();
            var result = _mapper.Map<List<TView>>(entities);
            return result;
        }


    }
}
