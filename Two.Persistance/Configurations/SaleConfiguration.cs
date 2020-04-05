using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(e => e.Id).HasDefaultValueSql("nextval('\"Sales_Id_seq\"'::regclass)");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
