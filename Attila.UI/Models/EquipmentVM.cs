using Attila.Application.Inventory_Manager.Equipment.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EquipmentVM
    {
        public List<EquipmentDetailsVM> EquipmentsDetailsVM { get; set; }

        public List<EquipmentInventoryVM> EquipmentsInventoryVM { get; set; }

        public List<EquipmentRestockVM> EquipmentsRestockVM { get; set; }

        public List<EquipmentRestockRequestVM> EquipmentsRestockRequestVM { get; set; }
    }
}
