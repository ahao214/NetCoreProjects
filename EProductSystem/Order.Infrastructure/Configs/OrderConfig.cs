﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Entity;


namespace Order.Infrastructure.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Order.Domain.Entity.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Order> builder)
        {
            builder.ToTable($"T_{nameof(Order.Domain.Entity.Order)}");

            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
        }
    }
}
