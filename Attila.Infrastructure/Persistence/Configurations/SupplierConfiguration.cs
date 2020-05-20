using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData( new Supplier
            { 
                ID = 1,
                Name = "CSI",
                Address = "Quezon City",
                ContactNumber = "+639439435435",
                ContactPersonName = "Paul Parks",
                CreatedOn = DateTime.Now
            });

            builder.HasData(new Supplier
            {
                ID = 2,
                Name = "UVWoods",
                Address = "Quezon City",
                ContactNumber = "+6392674564564",
                ContactPersonName = "Cris Cruz",
                CreatedOn = DateTime.Now
            });

            builder.HasData(new Supplier
            {
                ID = 3,
                Name = "ABC",
                Address = "Pasig City",
                ContactNumber = "+639465634453",
                ContactPersonName = "Angel Tan",
                CreatedOn = DateTime.Now
            });
        }
    }
}
