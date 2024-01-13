using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain
{
    /// <summary>
    /// 商品接口
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// 查询全部商品
        /// </summary>
        /// <returns></returns>
        Task<List<Domain.Entity.Product>> FindAllProductAsync();
        /// <summary>
        /// 根据商品ID查询
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        Task<Entity.Product> FindProductByIdAsync(Guid productId);
        /// <summary>
        /// 根据类别查询商品
        /// </summary>
        /// <param name="categoryUrl"></param>
        /// <returns></returns>
        Task<List<Entity.Product>> FindProductByCategoryAsync(string categoryUrl);
        
        /// <summary>
        /// 根据内容查询商品
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        Task<List<Entity.Product>> FindProductBySearchAsync(string searchText);

        Task<(List<Entity.Product>, double)> FindProductBySearchAsync(string searchText, int page);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        Task<List<string>> GetProductSearchSuggestionsAsync(string searchText);
        /// <summary>
        /// 根据商品种类查询商品
        /// </summary>
        /// <returns></returns>
        Task<List<Entity.Product>> FindProductsByFeatureAsync();
    }
}
