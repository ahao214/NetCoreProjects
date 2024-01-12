using Microsoft.EntityFrameworkCore;
using Product.Domain;
using Product.Infrastructure.DBContexts;
using System.Xml.XPath;

namespace Product.Infrastructure
{
    /// <summary>
    /// 商品
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entity.Product>> FindAllProductAsync()
        {
            var result = await _dbContext.Products.Include(p => p.Variants.Where(x => x.Deleted == false && x.Visible == true)).Where(x => x.Deleted == false && x.Visible == true).ToListAsync();

            return result;
        }

        public async Task<List<Domain.Entity.Product>> FindProductByCategoryAsync(string categoryUrl)
        {
            var result = await _dbContext.Products.Where(x => x.Deleted == false && x.Visible == true && x.Category.Url.ToLower().Equals(categoryUrl.ToLower())).Include(v => v.Variants.Where(x => x.Deleted == false && x.Visible == true)).ToListAsync();

            return result;
        }

        public async Task<Domain.Entity.Product> FindProductByIdAsync(Guid productId)
        {
            var result = await _dbContext.Products.Include(x => x.Variants.Where(x => x.Deleted == false && x.Visible == true)).ThenInclude(x => x.ProductType).SingleOrDefaultAsync(x => x.Id == productId && x.Deleted == false && x.Visible == true);

            return result;
        }



        public async Task<List<Domain.Entity.Product>> FindProductsByFeatureAsync()
        {
            var result = await _dbContext.Products.Where(x => x.Deleted == false && x.Visible == true && x.Featured == true).Include(x => x.Variants.Where(x => x.Deleted == false && x.Visible == true)).ToListAsync();

            return result;

        }

        public async Task<List<Domain.Entity.Product>> FindProductBySearchAsync(string searchText)
        {
            var result = await _dbContext.Products.Where(x => x.Deleted == false && x.Visible == true && x.Title.ToLower().Contains(searchText.ToLower()) || x.Description.ToLower().Contains(searchText.ToLower())).Include(v => v.Variants.Where(x => x.Deleted == false && v.Visible == true)).ToListAsync();

            return result;
        }

        public async Task<List<string>> GetProductSearchSuggestionsAsync(string searchText)
        {
            var products = await FindProductBySearchAsync(searchText);
            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.ToLower().Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if(product.Description !=null )
                {
                    var punctuation = product.Description.Where(char.IsPunctuation).Distinct().ToArray();
                    var words = product.Description.Split().Select(s => s.Trim(punctuation));
                    foreach (var word in words) { 
                        if(word.Contains (searchText,StringComparison.OrdinalIgnoreCase) && !result.Contains(word ))
                        {
                            result.Add(word);
                        }
                    }
                }
            }
            return result;
        }
    }
}
