using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Admin.Foods.Queries;
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

        public List<Application.Inventory_Manager.Shared.Queries.EquipmentVM> EquipmentListVM { get; set; }

        public List<InventoriesDeliveryVM> InventoryDeliveryVM { get; set; }

        public List<EquipmentRequestVM> EquipmentRequestList { get; set; }

        public List<FoodRequestVM> FoodRequestList { get; set; }

        public List<FoodRequestVM> ForApprovalFoodRequestList { get; set; }

        public List<EquipmentRequestVM> ForApprovalEquipmentRequestList { get; set; }
    } 
}
