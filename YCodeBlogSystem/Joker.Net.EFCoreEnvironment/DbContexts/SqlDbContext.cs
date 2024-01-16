using Joker.Net.Model;
using Microsoft.EntityFrameworkCore;

namespace Joker.Net.EFCoreEnvironment.DbContexts
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Article> articles { get; set; }

        public DbSet<ArticleType> articleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 把当前程序集中把当前程序集中实现了IEntityTypeConfiguration接口的实现类加载进来
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
