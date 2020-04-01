using Attila.Domain.Entities;
using System;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class FoodsRestockRequestVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int FoodDetailsID { get; set; }

        public Domain.Entities.Food FoodDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
