using System.Collections.Generic;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class FoodDetailsVM
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Specification { get; set; }

        public string Description { get; set; }

        public UnitType Unit { get; set; }

        public FoodType FoodType { get; set; }

        public string SearchedKeyword { get; set; }

        public IEnumerable<FoodDetailsVM> FoodsDetailsVMs { get; set; }
    }
}
