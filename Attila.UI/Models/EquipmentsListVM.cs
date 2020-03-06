using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class EquipmentsListVM
    {
        public EquipmentInventoryVM EquipmentInventoryVM { get; set; }

        public List<SelectListItem> EquipmentDetailsList { get; set; }

        public List<SelectListItem> EquipmentDeliveryList { get; set; }
    }
}
