using Attila.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class FoodRestockRequest : BaseAuditedEntity
    {

        [ForeignKey("InventoryManager")]
        public int InventoryManagerID { get; set; }

        public int Quantity { get; set; }
        public Status Status { get; set; }
        public DateTime DateTimeRequest { get; set; }

        public User InventoryManager { get; set; }
    }
}
