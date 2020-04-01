using Attila.Application.Inventory_Manager.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class InventoryDataCVM
    {
        public List<FoodVM> FoodListVM { get; set; }

        public List<EquipmentVM> EquipmentListVM { get; set; }

        public List<InventoriesDeliveryVM> InventoryDeliveryVM { get; set; }
    } 
}
