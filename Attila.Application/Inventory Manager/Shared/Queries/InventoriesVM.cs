using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class InventoriesVM
    {
        public List<FoodVM> FoodListVM { get; set; }

        public List<EquipmentVM> EquipmentListVM { get; set; }

        public List<InventoriesDeliveryVM> InventoryDeliveryVM { get; set; }

    }
}
