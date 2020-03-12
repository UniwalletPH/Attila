using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class InventoryDetailVM
    {
        public List<EquipmentDetailsVM> EquipmentDetailsVMs { get; set; }

        public List<FoodDetailsVM> FoodDetailsVMs { get; set; }
    }
}
