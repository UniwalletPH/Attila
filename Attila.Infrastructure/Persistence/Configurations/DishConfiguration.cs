using Attila.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure.Persistence.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {

            //Pork-------------------------------------------

            builder.HasData(new Dish
            {
                ID = 1,
                Name = " Porchetta",
                Description = "",
                DishCategoryID = 1,                
            });

            builder.HasData(new Dish
            {
                ID = 2,
                Name = "Vietnamese Glazed Pork",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 3,
                Name = "Pork Cassoulet",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 4,
                Name = "Beer Braised Pork",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 5,
                Name = "Apple Roast Pork Belly ",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 6,
                Name = "3 Hour Roasted Belly",
                Description = "",
                DishCategoryID = 1
            });


            builder.HasData(new Dish
            {
                ID = 7,
                Name = "Pork Binagoongan",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 8,
                Name = "Soy Anise Pork Chop",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 9,
                Name = "Pork Barbecue",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 10,
                Name = "Lechon Kawali ",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 11,
                Name = "Sinigang na Lechon Kawali",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 12,
                Name = "Sisig",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 13,
                Name = "Pork Dinakdakan",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 14,
                Name = "Pork Ala Cubana",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 15,
                Name = "Pork Humba",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 16,
                Name = "Pork Hamonado",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 17,
                Name = "Pork Ribs in Black Bean Sauce",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 18,
                Name = "Barbecue Ribs",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 19,
                Name = "House Smoked Liempo",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 20,
                Name = "Oriental Roast Pork",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 21,
                Name = "Balsamic Pork Tenderloin",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 22,
                Name = "Sinigang na Lechon Kawali",
                Description = "",
                DishCategoryID = 1
            });

            builder.HasData(new Dish
            {
                ID = 23,
                Name = "Twice Cooked Pork in Tamarind Sauce",
                Description = "",
                DishCategoryID = 1
            });

            //Beef-------------------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 24,
                Name = "Beef Pares",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 25,
                Name = " Bistek Tagalog",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 26,
                Name = "Beef Kare Kare",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 27,
                Name = "Beef Curry",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 28,
                Name = "Italian Beef Stew",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 29,
                Name = "Beef Korma",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 30,
                Name = "South American Stir-Fried",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 31,
                Name = "Beef Rosemary Roast Beef",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 32,
                Name = "Beef Bourguignon",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 33,
                Name = "Cuban Roast Beef",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 34,
                Name = "Beef Salisbury",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 35,
                Name = "Galbi Jjim",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 36,
                Name = "Beef Rendang",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 37,
                Name = "Beef Stroganoff",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 38,
                Name = "Beef & Broccoli",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 39,
                Name = "Mongolian Beef",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 40,
                Name = "Beef in Aligue",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 41,
                Name = "Beef Kaldereta",
                Description = "",
                DishCategoryID = 2
            });

            builder.HasData(new Dish
            {
                ID = 42,
                Name = "Beef Pochero",
                Description = "",
                DishCategoryID = 2
            });

            //Poultry -----------------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 43,
                Name = "Boneless Chicken BBQ",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 44,
                Name = "Chicken Inasal",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 45,
                Name = "Chicken Pastel",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 46,
                Name = "Chicken Tandoori",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 47,
                Name = "Tex-Mex Grilled Chicken",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 48,
                Name = "Chicken Kebab",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 49,
                Name = "Chicken Cacciatore",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 50,
                Name = "Chicken Galantine",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 51,
                Name = "Lemon Rosemary Chicken",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 52,
                Name = "Chicken Satay",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 53,
                Name = "Chicken Yakitori",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 54,
                Name = "Chicken Sambal",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 55,
                Name = "Chicken Pesto",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 56,
                Name = "Orange Chicken",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 57,
                Name = "Buttermilk Fried Chicken",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 58,
                Name = "Lechon Manok",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 59,
                Name = "Garlic Fried Chicken",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 60,
                Name = "Chicken Florentine",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 61,
                Name = "Chicken Souvlaki",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 62,
                Name = "Chicken Teriyaki",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 63,
                Name = "Chicken Cordon Bleu",
                Description = "",
                DishCategoryID = 3
            });

            builder.HasData(new Dish
            {
                ID = 64,
                Name = "Chicken, Mushroom & Tofu",
                Description = "",
                DishCategoryID = 3
            });

            //Vegetables------------------------------------------------------------


            builder.HasData(new Dish
            {
                ID = 65,
                Name = "Honey Ginger & Tofu",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 66,
                Name = "Eggplant Cups",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 67,
                Name = "Beans & Mushroom",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 68,
                Name = "Chopseuy",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 69,
                Name = "Pakbet",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 70,
                Name = "Gising Gising",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 71,
                Name = "Lentil Curry",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 72,
                Name = "Corn & Cabbage",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 73,
                Name = "Vegetable Casserole",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 74,
                Name = "Cajun Roasted Potato",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 75,
                Name = "Vegetable Parmesan",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 76,
                Name = "Stir Fried Mushroom & Tomyao",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 77,
                Name = "Vegetable Kebab",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 78,
                Name = "Sriracha Tofu",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 79,
                Name = "Tofu Spring Roll",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 80,
                Name = "Mushroom & Tofu",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 81,
                Name = "Buttered Vegetable",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 82,
                Name = "Vegetable Chimichurri",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 83,
                Name = "Patatas Bravas",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 84,
                Name = "Apple Kimchi",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 85,
                Name = "Mushroom & Water Chestnut",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 86,
                Name = "Vegetable Kare Kare",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 87,
                Name = "Tofu Binagoongan",
                Description = "",
                DishCategoryID = 4
            });

            builder.HasData(new Dish
            {
                ID = 88,
                Name = "Vegetable Pesto",
                Description = "",
                DishCategoryID = 4
            });

            //Starch ------------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 89,
                Name = "Steamed Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 90,
                Name = "Pandan Steamed Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 91,
                Name = "Garlic Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 92,
                Name = "Mexican Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 93,
                Name = "Java Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 94,
                Name = "Chinese Fried Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 95,
                Name = "Tinapa Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 96,
                Name = "Bagoong Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 97,
                Name = "Aligue Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 98,
                Name = "Vegetable Fried Rice",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 99,
                Name = "Mashed Potato",
                Description = "",
                DishCategoryID = 5
            });

            builder.HasData(new Dish
            {
                ID = 100,
                Name = "Potato Fries",
                Description = "",
                DishCategoryID = 5
            });

            //Seafood -----------------------------------------------

            builder.HasData(new Dish
            {
                ID = 101,
                Name = "Fish Laksa",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 102,
                Name = "Fish Fingers",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 103,
                Name = "Clams De Manille",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 104,
                Name = "Mussels Halabos",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 105,
                Name = "Sweet & Sour Fish",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 106,
                Name = "Seafood Gumbo",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 107,
                Name = "Seafood Sambal",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 108,
                Name = "Sinaing na Tulingan",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 109,
                Name = "Vegetable Stuffed Squid",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 110,
                Name = "Mussels in White Wine",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 111,
                Name = "Thai Fish Cakes",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 112,
                Name = "Seafood Casserole",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 113,
                Name = "Tinolang Tahong",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 114,
                Name = "Fish Tausi",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 115,
                Name = "Fish Kebab",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 116,
                Name = "Fish Souvlaki",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 117,
                Name = "Fish Cacciatore",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 118,
                Name = "Fish in Aligue",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 119,
                Name = "Seafood Halabos",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 120,
                Name = "Steamed Fish in Sweet Soy",
                Description = "",
                DishCategoryID = 6
            });

            builder.HasData(new Dish
            {
                ID = 121,
                Name = "Clam Bake",
                Description = "",
                DishCategoryID = 6
            });

            //Soup------------------------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 122,
                Name = "Chicken Sotanghon Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 123,
                Name = "Minestrone",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 124,
                Name = "Spinach & Tofu",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 125,
                Name = "Chicken & Corn Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 126,
                Name = "Miso Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 127,
                Name = "Molo Soup Tom Yum",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 128,
                Name = "Chicken Noodle Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 129,
                Name = "Chicken Chowder",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 130,
                Name = "Tomato Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 131,
                Name = "Chicken & Macaroni",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 132,
                Name = "Arroz Caldo",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 133,
                Name = "Pumpkin Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 134,
                Name = "Seafood Chowder",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 135,
                Name = "Bacon & Lentil Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 136,
                Name = "Mussels & Tomato Soup",
                Description = "",
                DishCategoryID = 7
            });

            builder.HasData(new Dish
            {
                ID = 137,
                Name = "Mushroom Soup",
                Description = "",
                DishCategoryID = 7
            });

        
            //Appetizer---------------------------------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 138,
                Name = "Dinakdakan Tart",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 139,
                Name = "Sausage Bruschetta",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 140,
                Name = "Spinach Quiche",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 141,
                Name = "Thai Spring Roll",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 142,
                Name = "Cha Gio",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 143,
                Name = "Vegetable Samosa",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 144,
                Name = "Bacon Croquettes",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 145,
                Name = "Laing Wrap",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 146,
                Name = "Sausage & Cheese",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 147,
                Name = "Chicken Empanadita",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 148,
                Name = "Beef Empanadita",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 149,
                Name = "Spiced Nuts",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 150,
                Name = "Parmesan Grissini",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 151,
                Name = "Smoked Cheese Sticks",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 152,
                Name = "Spanakopita",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 153,
                Name = "Bacon & Mushroom Rolls",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 154,
                Name = "Liver & Banana Skewer",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 155,
                Name = "Bacon & Cheese Rolls",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 156,
                Name = "Salmon & Cheese Puffs",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 157,
                Name = "Fried Bacon",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 158,
                Name = "Camaron Rebosado",
                Description = "",
                DishCategoryID = 8
            });

            builder.HasData(new Dish
            {
                ID = 159,
                Name = "Smoked Cheese & Tuna Quesadilla",
                Description = "",
                DishCategoryID = 8
            });

            //Salad-------------------------------------------------------------



            builder.HasData(new Dish
            {
                ID = 160,
                Name = "Gochujang Chicken Salad",
                Description = "",
                DishCategoryID = 9
            });

            builder.HasData(new Dish
            {
                ID = 161,
                Name = "Caesar Salad",
                Description = "",
                DishCategoryID = 9
            });

            builder.HasData(new Dish
            {
                ID = 162,
                Name = "Caesar Salad",
                Description = "",
                DishCategoryID = 9
            });

            builder.HasData(new Dish
            {
                ID = 163,
                Name = "Tapa Salad",
                Description = "",
                DishCategoryID = 9
            });

            builder.HasData(new Dish
            {
                ID = 164,
                Name = "Raspberry Salad",
                Description = "",
                DishCategoryID = 9
            });

            builder.HasData(new Dish
            {
                ID = 165,
                Name = "Greek Salad",
                Description = "",
                DishCategoryID = 9
            });

            //Dessert-------------------------------------------------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 166,
                Name = "Coconut Macaroon",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 167,
                Name = "Maja Blanca",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 168,
                Name = "Dulce De Leche",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 169,
                Name = "Calamansi Buttercake",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 170,
                Name = "Coffee Jelly",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 171,
                Name = "Mango Sago",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 172,
                Name = "Almond Tofu",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 173,
                Name = "Mandarin Orange Tart",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 174,
                Name = "Tart Chocolat",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 175,
                Name = "Signature Chocolate Cake",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 176,
                Name = "New Orleans Doughnut (Beignet)",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 177,
                Name = "Green Tea Tiramisu",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 178,
                Name = "Chocolate Tiramisu",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 179,
                Name = " Mango Float",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 180,
                Name = "Strawberries & Cream Puff",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 181,
                Name = "Coffee Cream Puff",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 182,
                Name = "Crème Brulee",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 183,
                Name = "Pannacotta",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 184,
                Name = "Mango Pannacotta",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 185,
                Name = "Tres Leches",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 186,
                Name = "Fruit Salad",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 187,
                Name = "Bomboloni",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 188,
                Name = "Chocolate Mousse",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 189,
                Name = "Tofu Mousse",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 190,
                Name = "Raspberry Taho",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 191,
                Name = "Smores Cheesecake",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 192,
                Name = "Strawberry Cheesecake",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 193,
                Name = "Blueberry Cheesecake",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 194,
                Name = "Tocino Del Cielo",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 195,
                Name = "Chocolate Cream Puffs",
                Description = "",
                DishCategoryID = 10
            });

            builder.HasData(new Dish
            {
                ID = 196,
                Name = "Black Sesame Cream Puffs",
                Description = "",
                DishCategoryID = 10
            });

            //Beverage--------------------------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 197,
                Name = "House Blend Iced Tea",
                Description = "",
                DishCategoryID = 11
            });

            builder.HasData(new Dish
            {
                ID = 198,
                Name = "Cucumber Lemon",
                Description = "",
                DishCategoryID = 11
            });

            builder.HasData(new Dish
            {
                ID = 199,
                Name = "Orange Juice",
                Description = "",
                DishCategoryID = 11
            });

            builder.HasData(new Dish
            {
                ID = 200,
                Name = " Pineapple Juice",
                Description = "",
                DishCategoryID = 11
            });

            //NodlePasta -----------------------------------------------------

            builder.HasData(new Dish
            {
                ID = 201,
                Name = "Pancit Bihon",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 202,
                Name = "Pancit Canton",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 203,
                Name = "Pancit Sotanghon",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 204,
                Name = "Chicken & Chorizo",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 205,
                Name = "Carbonara",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 206,
                Name = "Pomodoro",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 207,
                Name = "Bolognese",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 208,
                Name = "Spaghetti",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 209,
                Name = "Kung Pao Chicken",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 210,
                Name = "Chicken Pesto",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 211,
                Name = "Pad Thai",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 212,
                Name = "Japchae",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 213,
                Name = "Tinapa Pasta",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 214,
                Name = " Vegetable Bolognese",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 215,
                Name = "Pancit Habhab",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 216,
                Name = "Crab Fat Pasta",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 217,
                Name = "Chicken Alfredo",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 218,
                Name = "Seafood Marinara",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 219,
                Name = "Olive and Anchovy Pasta",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 220,
                Name = "Cha Misua",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 221,
                Name = "Mushroom & Truffle Pasta",
                Description = "",
                DishCategoryID = 12
            });

            builder.HasData(new Dish
            {
                ID = 222,
                Name = "Cheesy Taco Pasta",
                Description = "",
                DishCategoryID = 12
            });

        }
    }
}
