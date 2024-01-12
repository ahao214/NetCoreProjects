using Product.Domain;
using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public class ProductTypeRepository : IProductTypeRepository
    {
        public Task<List<ProductType>> FindAllProductTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductType>> GetProductTypeByProductIdAsync(Guid ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
