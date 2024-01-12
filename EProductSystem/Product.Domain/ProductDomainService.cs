using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain
{
    public class ProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
