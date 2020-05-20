using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(new Client
            {
                ID = 1,
                Name = "Vincent Dagpin",
                Email = "vincentdagpin@uniwallet.ph",
                Contact = "090909090909",
                Address = "Cavite, Philippines",
                CreatedOn = DateTime.Parse("01/01/2020")
            });

            builder.HasData(new Client 
            {
                ID = 2,
                Name = "Cheryl Chan",
                Email = "cherylchan@gmail.com",
                Contact = "+65877327373",
                Address = "Manila, Philippines",
                CreatedOn = DateTime.Parse("01/01/2020")
            });

            builder.HasData(new Client
            { 
                ID = 3,
                Name =  "Pei Shi",
                Email = "peishi@gmail.com",
                Contact = "+6523423523",
                Address = "Manila, Philippines",
                CreatedOn = DateTime.Parse("01/01/2020")
            });

            builder.HasData( new Client
            { 
                ID = 4,
                Name = "Ren Yi Xiang",
                Email = "ryx@gmail.com",
                Contact = "+65342642345",
                Address = "Singapore",
                CreatedOn = DateTime.Parse("01/01/2020")
            });
        }
    }
}
