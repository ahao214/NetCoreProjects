using Microsoft.EntityFrameworkCore;
using Product.Domain;
using Product.Domain.Entity;
using Product.Infrastructure.DBContexts;
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
        private readonly ProductDbContext _dbContext;

        public CategoryRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Category>> FindAllCategoriesAsync()
        {
            //var result = await _dbContext.Categories.Where(x => x.Deleted == false && x.Visible == true).ToListAsync();
            var result = await _dbContext.Categories.ToListAsync();

            return result;
        }
    }
}
