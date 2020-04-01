using Attila.Domain.Entities.Base;
using System;

namespace Attila.Domain.Entities
{
    public class EquipmentRestockRequest : BaseAuditedEntity
    {
    
        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int EquipmentDetailsID { get; set; }

        public Equipment EquipmentDetails { get; set; }

        public Status Status { get; set; }

        public int InventoryManagerID { get; set; }

        public User InventoryManager { get; set; }
    }
}
