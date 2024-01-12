using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Configs
{
    public class ProductTypeConfig:IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder <ProductType > builder)
        {
            builder.ToTable($"T_{nameof(ProductType)}");
        }

    }
}
