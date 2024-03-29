﻿using Joker.Net.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joker.Net.EFCoreEnvironment.Configs
{
    public class ArticleTypeConfig : IEntityTypeConfiguration<ArticleType>
    {
        public void Configure(EntityTypeBuilder<ArticleType> builder)
        {
            //配置表名
            builder.ToTable($"T_{nameof(ArticleType)}");

            //配置全局筛选器
            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
