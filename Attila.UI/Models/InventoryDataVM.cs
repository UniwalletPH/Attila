using Attila.Application.Inventory_Manager.Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class InventoryDataVM
    {
        public List<FoodVM> FoodListVM { get; set; }

        public List<EquipmentVM> EquipmentListVM { get; set; }
    } 
}
