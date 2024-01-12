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
    /// 商品类别
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        public Task<List<Category>> FindAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
