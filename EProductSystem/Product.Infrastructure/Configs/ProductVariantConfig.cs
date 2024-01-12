using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Configs
{
    public class ProductVariantConfig : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable($"T_{nameof(ProductVariant)}");

            builder.HasKey(x => new { x.ProductId, x.ProductTypeId });

            builder.Property(x=>x.Price ).HasColumnType("decimal(18,2)");
            builder.Property(x => x.OriginalPrice).HasColumnType("decimal(18,2)");
        }
    }

}
