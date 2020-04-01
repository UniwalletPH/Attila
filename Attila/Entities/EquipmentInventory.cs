using Attila.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{

    public class EquipmentInventory : BaseAuditedEntity
    {
        [ForeignKey("InventoryManager")]
        public int InventoryManagerID { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentID { get; set; }

        [ForeignKey("Delivery")]
        public int DeliveryID { get; set; }


        public int Quantity { get; set; }
        public DateTime EncodingDate { get; set; }
        public decimal ItemPrice { get; set; }
        public string Remarks { get; set; }   

        public User InventoryManager { get; set; }
        public Equipment Equipment { get; set; }
        public Delivery Delivery { get; set; }
    }
}
