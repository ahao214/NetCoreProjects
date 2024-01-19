using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain
{
    /// <summary>
    /// 商品类型接口
    /// </summary>
    public interface IProductTypeRepository
    {
        /// <summary>
        /// 查询所有商品类型
        /// </summary>
        /// <returns></returns>
        Task<List<ProductType>> FindAllProductTypeAsync();
        /// <summary>
        /// 根据商品ID获取商品类型
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        Task<List<ProductType>> GetProductTypeByProductIdAsync(Guid ProductId);

        Task<string> GetTypeNameByProductTypeId(Guid productTypeId);
    }
}
