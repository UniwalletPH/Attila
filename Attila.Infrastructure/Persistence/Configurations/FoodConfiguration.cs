using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData( new Food
            { 
                ID = 1,
                Code = "BVN-001",
                Name = "Nestle All Purpose Cream",
                Specification = "250 ml",
                FoodType = FoodType.NonPerishable,
                Unit = UnitType.Piece
            });

            builder.HasData(new Food
            {
                ID = 2,
                Code = "XCM-002",
                Name = "Golden Fiesta Palm Oil",
                Specification = "950 ml",
                FoodType = FoodType.NonPerishable,
                Unit = UnitType.Piece
            });

            builder.HasData(new Food
            { 
                ID = 3,
                Code = "MNX-003",
                Name = "Red Apples",
                Specification = "N/A",
                FoodType = FoodType.Perishable,
                Unit = UnitType.Box
            });
        }
    }
}
