using JOKER.NetE.Model;
using Newtonsoft.Json;

namespace JOKER.NetE.Repository.Base
{

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        public async Task<List<TEntity>> Query()
        {
            await Task.CompletedTask;
            var data = "[{\"Id\":19,\"Name\":\"castle\"}]";
            return JsonConvert.DeserializeObject<List<TEntity>>(data) ?? new List<TEntity>();

        }
    }
}
