using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Type)
                .WithMany(p => p.Food)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("food_foodtype_fk");
        }
    }
}
