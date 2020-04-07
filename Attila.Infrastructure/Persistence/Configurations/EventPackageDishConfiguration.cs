using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class EventPackageDishConfiguration : IEntityTypeConfiguration<EventPackageDish>
    {
        public void Configure(EntityTypeBuilder<EventPackageDish> builder)
        {
            //Sample
            // Package 1. yung 400 per head yata to

            builder.HasData( new EventPackageDish{ 
                ID = 1,
                EventPackageID = 1,
                DishID = 1
            });
        }
    }
}
