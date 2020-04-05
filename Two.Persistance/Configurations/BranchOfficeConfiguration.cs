using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class BranchOfficeConfiguration : IEntityTypeConfiguration<BranchOffice>
    {
        public void Configure(EntityTypeBuilder<BranchOffice> builder)
        {
            builder.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Schedule)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
