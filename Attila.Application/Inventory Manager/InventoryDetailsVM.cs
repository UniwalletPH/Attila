using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Application.Inventory_Manager.Food.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager
{
    public class InventoryDetailsVM
    {
        public List<EquipmentsDetailsVM> EquipmentsDetailsVM { get; set; }

        public List<FoodsDetailsVM> FoodsDetailsVM { get; set; }
    }
}
