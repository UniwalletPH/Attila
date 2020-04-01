using Attila.Domain.Entities.Base;
using System;

namespace Attila.Domain.Entities
{
    public class FoodRestockRequest : BaseAuditedEntity
    {
        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int FoodDetailsID { get; set; }

        public Food FoodDetails { get; set; }

        public Status Status { get; set; }

        public int InventoryManagerID { get; set; }

        public User InventoryManager { get; set; }
    }
}
