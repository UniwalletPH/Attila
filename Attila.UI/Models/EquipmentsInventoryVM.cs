using Attila.Application.Inventory_Manager.Equipment.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EquipmentsInventoryVM
    {
        public EquipmentInventoryVM EquipmentInventoryVM { get; set; }

        public List<SelectListItem> EquipmentDetailsList { get; set; }

        public List<SelectListItem> EquipmentDeliveryList { get; set; }
    }
}
