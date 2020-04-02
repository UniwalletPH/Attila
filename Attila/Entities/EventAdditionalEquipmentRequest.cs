using Attila.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class EventAdditionalEquipmentRequest : BaseAuditedEntity
    {

        [ForeignKey("Equipment")]
        public int EquipmentID { get; set; }
        [ForeignKey("Event")]
        public int EventID { get; set; }

        public Status Status { get; set; }
        public int Quantity { get; set; }

        public Equipment Equipment { get; set; }
        public Event Event { get; set; }
    }
}
 