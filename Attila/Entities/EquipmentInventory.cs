using Attila.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{

    public class EquipmentInventory : BaseAuditedEntity
    {
        
        public int InventoryManagerID { get; set; }

        public int Quantity { get; set; }

        public int EquipmentDetailsID { get; set; }

        public int DeliveryID { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }   

        public User InventoryManager { get; set; }

        public Equipment EquipmentDetails { get; set; }

        public Delivery Delivery { get; set; }

       
    }
}
