using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class FoodsRequestCollectionVM
    {
        public int FoodID { get; set; }

        public int FoodRestockRequestID { get; set; }

        public int Quantity { get; set; }

        public Food Food { get; set; }

        public FoodRestockRequest FoodRestockRequest { get; set; }

    }
}
