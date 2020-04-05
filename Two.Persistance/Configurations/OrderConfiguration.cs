using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300);

            builder.Property(e => e.ClientName)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Emoloyee)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.EmoloyeeId)
                .HasConstraintName("Order_EmoloyeeId_fkey");

            builder.HasOne(d => d.OrderState)
                .WithMany(p => p.Order)
                .HasForeignKey(d => d.OrderStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_StateId_fkey");
        }
    }
}
