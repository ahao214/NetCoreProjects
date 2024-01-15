using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entity;

namespace User.Infrastructure.DbContexts
{
    public class UserDbContext : DbContext
    {
        public DbSet<Domain.Entity.User> Users { get; set; }
        public DbSet<UserLoginHistory> UserLoginHistories { get; set; }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
