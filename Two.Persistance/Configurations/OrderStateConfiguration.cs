using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class OrderStateConfiguration : IEntityTypeConfiguration<OrderState>
    {
        public void Configure(EntityTypeBuilder<OrderState> builder)
        {
            builder.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}
