using Attila.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class FoodsRestockRequestVM
    {
        public int ID { get; set; }
        public DateTime DateTimeRequest { get; set; }
        public Status Status { get; set; }
        public int UserID { get; set; }
        public int Quantity { get; set; }
        public decimal EstimatedPrice { get; set; }
        public decimal TotalEstimatedPrice { get; set; }


        public User User { get; set; }
        public Food FoodDetails { get; set; }

        //public List<FoodsRequestCollectionVM> FoodRequestCollection { get; set; }
    }
}
