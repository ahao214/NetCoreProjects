using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entity;

namespace User.Infrastructure.Configs
{
    public class UserAccessFailConfig : IEntityTypeConfiguration<UserAccessFail>
    {
        public void Configure(EntityTypeBuilder<UserAccessFail> builder)
        {
            builder.ToTable($"T_{nameof(UserAccessFail)}");

            builder.Property("isLockOut");
        }
    }
}
