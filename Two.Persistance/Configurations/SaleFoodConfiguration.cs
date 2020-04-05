using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class SaleFoodConfiguration : IEntityTypeConfiguration<SaleFood>
    {
        public void Configure(EntityTypeBuilder<SaleFood> builder)
        {
            builder.HasOne(d => d.Food)
                    .WithMany(p => p.SaleFood)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SaleFood_FoodId_fkey");

            builder.HasOne(d => d.Sale)
                .WithMany(p => p.SaleFood)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SaleFood_SaleId_fkey");
        }
    }
}
