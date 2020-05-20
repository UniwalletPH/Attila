using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasData(new Delivery
            {
                ID = 1,
                SupplierID = 1,
                DeliveryDate = DateTime.Parse("01/01/2020"),
                DeliveryPrice = 50000
            });

            builder.HasData(new Delivery
            { 
                ID = 2,
                SupplierID = 2,
                DeliveryDate = DateTime.Parse("01/01/2020"),
                DeliveryPrice = 100000
            });
        }
    }
}
