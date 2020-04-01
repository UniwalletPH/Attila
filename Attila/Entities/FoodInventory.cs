using Attila.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class FoodInventory : BaseAuditedEntity
    {
        [ForeignKey("InventoryManager")]
        public int InventoryManagerID { get; set; }
        [ForeignKey("Food")]
        public int FoodID { get; set; }
        [ForeignKey("Delivery")]
        public int DeliveryID { get; set; }


        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime EncodingDate { get; set; }
        public decimal ItemPrice { get; set; }
        public string Remarks { get; set; }
        
        

        public Food Food { get; set; }
        public Delivery Delivery { get; set; }
        public User InventoryManager { get; set; }
    }
}
