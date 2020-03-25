using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Application.Inventory_Manager.Food.Queries;
using System.Collections.Generic;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class InventoryDetailsVM
    {
        public List<EquipmentsDetailsVM> EquipmentsDetailsVM { get; set; }

        public List<FoodsDetailsVM> FoodsDetailsVM { get; set; }

        public List<EquipmentsInventoryVM> EquipmentsInventoryVM { get; set; }

        public List<FoodsInventoryVM> FoodsInventoryVM { get; set; }
    }
}
