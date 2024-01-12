using Product.Domain;

namespace Product.Infrastructure
{
    /// <summary>
    /// 商品
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        public Task<List<Domain.Entity.Product>> FindAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entity.Product>> FindProductByCategoryAsync(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entity.Product> FindProductByIdAsync(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entity.Product> FindProductBySearchAsync(string searchText)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entity.Product>> FindProductsByFeatureAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entity.Product>> GetProductSearchSuggestionsAsync(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
