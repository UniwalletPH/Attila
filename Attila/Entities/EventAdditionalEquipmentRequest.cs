using Attila.Domain.Entities.Base;

namespace Attila.Domain.Entities
{
    public class EventAdditionalEquipmentRequest  : BaseAuditedEntity
    {
    
        public int EquipmentDetailsID { get; set; }

        public Equipment EquipmentDetails { get; set; }

        public int EventDetailsID { get; set; }

        public Event EventDetails { get; set; }

        public Status Status { get; set; }

        public int Quantity { get; set; }

    }
}
 