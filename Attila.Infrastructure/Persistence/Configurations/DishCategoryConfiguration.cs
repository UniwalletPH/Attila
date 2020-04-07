using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class DishCategoryConfiguration : IEntityTypeConfiguration<DishCategory>
    {
        public void Configure(EntityTypeBuilder<DishCategory> builder)
        {
            builder.HasData( new DishCategory { 
                ID = 1,
                Category = "Pork"
            });

            builder.HasData(new DishCategory
            {
                ID = 2,
                Category = "Beef"
            });

            builder.HasData(new DishCategory
            {
                ID = 3,
                Category = "Poultry"
            });

            builder.HasData(new DishCategory
            {
                ID = 4,
                Category = "Vegetable"
            });

            builder.HasData(new DishCategory
            {
                ID = 5,
                Category = "Starch"
            });

            builder.HasData(new DishCategory
            {
                ID = 6,
                Category = "Seafood"
            });

            builder.HasData(new DishCategory
            {
                ID = 7,
                Category = "Soup"
            });

            builder.HasData(new DishCategory
            {
                ID = 8,
                Category = "Appetizer"
            });

            builder.HasData(new DishCategory
            {
                ID = 9,
                Category = "Salad"
            });

            builder.HasData(new DishCategory
            {
                ID = 10,
                Category = "Dessert"
            });

            builder.HasData(new DishCategory
            {
                ID = 11,
                Category = "Beverage"
            });

            builder.HasData(new DishCategory
            {
                ID = 12,
                Category = "PastaNoodles"
            });
        }
    }
}
