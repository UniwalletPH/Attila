using Attila.Application.Inventory_Manager.Food.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodVM
    {
        public List<FoodDetailsVM> FoodsDetailsVM { get; set; }

        public List<FoodInventoryVM> FoodsInventoryVM { get; set; }

        public List<FoodRestockVM> FoodsRestockVM { get; set; }

        public List<FoodRestockRequestVM> FoodsRestockRequestVM { get; set; }
    }
}
