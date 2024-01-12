using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain
{
    /// <summary>
    /// 类别接口
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// 查询所有类别
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> FindAllCategoriesAsync();
    }
}
