﻿using Microsoft.EntityFrameworkCore;
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
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductVariantRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductVariant> GetVariantByProductAsync(Guid productId, Guid productTypeId)
        {
            var result = await _dbContext.ProductVariants.Where(x => x.ProductId == productId && x.ProductTypeId == productTypeId).Include(x => x.ProductType).FirstOrDefaultAsync();

            return result;

        }
    }
}
