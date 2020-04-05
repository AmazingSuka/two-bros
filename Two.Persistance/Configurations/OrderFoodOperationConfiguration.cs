using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class OrderFoodOperationConfiguration : IEntityTypeConfiguration<OrderFoodOperation>
    {
        public void Configure(EntityTypeBuilder<OrderFoodOperation> builder)
        {
            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderFoodOperations)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("order_orderFoodOperation_fk");

            builder.HasOne(d => d.Food)
                .WithMany(p => p.OrderFoodOperations)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("food_orderFoodOperation_fk");
        }
    }
}
