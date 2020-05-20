using Attila.Domain.Entities;
using System;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class EquipmentsInventoryVM
    {
        public int EquipmentDetailsID { get; set; }
        public int EventDetailsID { get; set; }
        public int DeliveryDetailsID { get; set; }
        public int CheckOutEquipmentID { get; set; }

        public int ID { get; set; }
        public int Quantity { get; set; }
        public DateTime EncodingDate { get; set; }
        public decimal ItemPrice { get; set; }
        public string Remarks { get; set; }
        public int UserID { get; set; }

        public Equipment EquipmentDetailsVM { get; set; }
        public Event EventDetailsVM { get; set; }
    }
}
