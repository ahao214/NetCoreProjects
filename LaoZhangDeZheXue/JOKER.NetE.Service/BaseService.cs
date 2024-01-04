using JOKER.NetE.IService;
using JOKER.NetE.Repository.Base;

namespace JOKER.NetE.Service
{
    public class BaseService<TEntity, TView> : IBaseService<TEntity, TView> where TEntity : class, new()
    {
        public async Task<List<TEntity>> Query()
        {
            var baseRepo = new BaseRepository<TEntity>();
            return await baseRepo.Query();
        }
    }
}
