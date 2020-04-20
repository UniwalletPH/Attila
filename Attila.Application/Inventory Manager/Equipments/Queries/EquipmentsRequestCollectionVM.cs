using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class EquipmentsRequestCollectionVM
    {
        public int EquipmentID { get; set; }

        public int EquipmentRestockRequestID { get; set; }

        public int Quantity { get; set; }

        public Equipment Equipment { get; set; }

        public EquipmentRestockRequest EquipmentRestockRequest { get; set; }
    }
}
