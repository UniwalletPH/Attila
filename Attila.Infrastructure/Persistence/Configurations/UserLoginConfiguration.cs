using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{

    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.Property(a => a.Username)
               .HasMaxLength(120)
               .IsRequired();

            builder.HasIndex(a => a.Username)
                .IsUnique();

            builder.Property(p => p.Salt)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(500)
                .IsRequired();


            byte[] _salt = Encoding.ASCII.GetBytes("ADMIN-SALT-1234!@#$");
            string _passb64 = "AEFETUlOLVNBTFQtMTIzNCGYnC9z/LG17TGsW3lRvMRkLZ2pfNGwTVfABFD1h7Afew==";
            string _pass = "admin";

            builder.HasData(new UserLogin
            {
                ID = -1,
                Salt = _salt,
                Password = Convert.FromBase64String(_passb64),
                Username = "admin",
                IsTemporaryPassword = true,
                TemporaryPassword = _pass
            });

            builder.HasData(new UserLogin
            {
                ID = -2,
                Salt = _salt,
                Password = Convert.FromBase64String(_passb64),
                Username = "test-coordinator",
                IsTemporaryPassword = true,
                TemporaryPassword = _pass
            });

            builder.HasData(new UserLogin
            {
                ID = -3,
                Salt = _salt,
                Password = Convert.FromBase64String(_passb64),
                Username = "test-inventory-manager",
                IsTemporaryPassword = true,
                TemporaryPassword = _pass
            });

            builder.HasData(new UserLogin
            {
                ID = -4,
                Salt = _salt,
                Password = Convert.FromBase64String(_passb64),
                Username = "test-chef",
                IsTemporaryPassword = true,
                TemporaryPassword = _pass
            });
        }
    }
}