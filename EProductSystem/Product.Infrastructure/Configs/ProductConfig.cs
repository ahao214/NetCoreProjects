using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Infrastructure.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product.Domain.Entity.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Product> builder)
        {
            builder.ToTable($"T_{nameof(Domain.Entity.Product)}");
            builder.HasMany(x => x.Variants).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        }

    }
}
