using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Application.Inventory_Manager.Food.Queries;
using System.Collections.Generic;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class InventoryDetailsVM
    {
        public IEnumerable<EquipmentsDetailsVM> EquipmentsDetailsVM { get; set; } = new List<EquipmentsDetailsVM>();

        public IEnumerable<FoodsDetailsVM> FoodsDetailsVM { get; set; } = new List<FoodsDetailsVM>();

        public IEnumerable<EquipmentsInventoryVM> EquipmentsInventoryVM { get; set; } = new List<EquipmentsInventoryVM>();

        public IEnumerable<FoodsInventoryVM> FoodsInventoryVM { get; set; } = new List<FoodsInventoryVM>();
    }
}
