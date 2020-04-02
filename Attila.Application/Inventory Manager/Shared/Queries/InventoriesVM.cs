using System.Collections.Generic;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class InventoriesVM
    {
        public List<FoodVM> FoodListVM { get; set; }

        public List<EquipmentVM> EquipmentListVM { get; set; }

        public List<InventoriesDeliveryVM> InventoryDeliveryVM { get; set; }

        public List<SuppliersDetailsVM> SupplierListVM { get; set; }

    }
}
