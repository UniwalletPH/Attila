using Attila.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class EquipmentRestockRequest : BaseAuditedEntity
    {

        [ForeignKey("InventoryManager")]
        public int InventoryManagerID { get; set; }

        public DateTime DateTimeRequest { get; set; }
        public Status Status { get; set; }
        public string Remarks { get; set; }

        public User InventoryManager { get; set; }
    }
}
