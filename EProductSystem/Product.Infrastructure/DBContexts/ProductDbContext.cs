using Microsoft.EntityFrameworkCore;
using Product.Domain.Entity;

namespace Product.Infrastructure.DBContexts
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Domain.Entity.Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Category> Categories { get; set; }


        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
