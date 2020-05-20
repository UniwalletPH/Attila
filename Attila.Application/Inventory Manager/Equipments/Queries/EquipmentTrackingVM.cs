using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class EquipmentTrackingVM
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int EquipmentID { get; set; }
        public int InventoryManagerID { get; set; }

        public int Quantity { get; set; }
        public DateTime TrackingDate { get; set; }
        public EquipmentAction TrackingAction { get; set; }
        public string Remarks { get; set; }

        public Event Event { get; set; }
        public Equipment Equipment { get; set; }
        public User InventoryManager { get; set; }
    }
}
