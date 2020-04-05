using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxters.Persistance.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(e => e.IsSuperUser).HasColumnName("isSuperUser");

            builder.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Password).IsRequired();
        }
    }
}
