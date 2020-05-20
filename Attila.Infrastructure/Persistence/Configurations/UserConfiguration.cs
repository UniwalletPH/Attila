using Attila.Application.Common.Extensions;
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
                UID = Guid.Empty.Increment(1),
                Name = "Admin",
                Role = AccessRole.Admin,
                Email = "admin@acs.com"
            });

            builder.HasData(new User
            {
                ID = -2,
                UID = Guid.Empty.Increment(2),
                Name = "Test-Coordinator",
                Role = AccessRole.Coordinator,
                Email = "coordinator@acs.com"
            });

            builder.HasData(new User
            {
                ID = -3,
                UID = Guid.Empty.Increment(3),
                Name = "Test-Inventory-Manager",
                Role = AccessRole.InventoryManager,
                Email = "inventory-mgr@acs.com"
            });

            builder.HasData(new User
            {
                ID = -4,
                UID = Guid.Empty.Increment(4),
                Name = "Test-Chef",
                Role = AccessRole.Chef,
                Email = "chef@acs.com"
            });
        }
    }
}
