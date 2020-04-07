using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class EventPackageConfiguration : IEntityTypeConfiguration<EventPackage>
    {
        public void Configure(EntityTypeBuilder<EventPackage> builder)
        {
            builder.HasData( new EventPackage {                
                ID = 1,
                Name = "400/HEAD",
                RatePerHead = 400,
                Description = "",
            });

            builder.HasData(new EventPackage
            {
                ID = 2,
                Name = "450/HEAD",
                RatePerHead = 450,
                Description = "",
            });

            builder.HasData(new EventPackage
            {
                ID = 3,
                Name = "500/HEAD",
                RatePerHead = 500,
                Description = "",
            });

            builder.HasData(new EventPackage
            {
                ID = 4,
                Name = "600/HEAD",
                RatePerHead = 600,
                Description = "",
            });

            builder.HasData(new EventPackage
            {
                ID = 5,
                Name = "700/HEAD ",
                RatePerHead = 700,
                Description = "",
            });

            builder.HasData(new EventPackage
            {
                ID = 6,
                Name = "800/HEAD ",
                RatePerHead = 800,
                Description = "",
            });

            builder.HasData(new EventPackage
            {
                ID = 7,
                Name = "900/HEAD ",
                RatePerHead = 900,
                Description = "",
            });

            builder.HasData(new EventPackage
            {
                ID = 8,
                Name = "1000/HEAD ",
                RatePerHead = 1000,
                Description = "",
            });

        }
    }
}
