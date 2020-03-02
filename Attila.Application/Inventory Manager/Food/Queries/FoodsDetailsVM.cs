using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Food.Queries
{
    public class FoodsDetailsVM
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Specification { get; set; }

        public string Description { get; set; }

        public UnitType Unit { get; set; }

        public FoodType FoodType { get; set; }
    }
}
