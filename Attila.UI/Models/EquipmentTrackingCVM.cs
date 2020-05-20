using Attila.Application.Inventory_Manager.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EquipmentTrackingCVM
    {
        public List<EquipmentTrackingVM> CheckInEquipmentTracking { get; set; }
        public List<EquipmentTrackingVM> CheckOutEquipmentTracking { get; set; }
    }
}
