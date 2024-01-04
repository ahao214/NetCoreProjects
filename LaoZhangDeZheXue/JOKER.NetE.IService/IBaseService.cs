using JOKER.NetE.Model;

namespace JOKER.NetE.IService
{
    public interface IBaseService<TEntity,TView> where TEntity : class 
    {
        Task<List<TEntity>> Query();

    }
}
