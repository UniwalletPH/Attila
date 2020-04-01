using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(a => a.UID)
                .IsUnique();

            builder.Property(a => a.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(a => a.Email)
                .IsUnique();

            builder.HasData(new User
            {
                ID = -1,
                UID = Guid.Empty,
                Name = "Admin",
                Role = AccessRole.Admin,
                Email = "admin@acs.com"
            });
        }
    }
}
