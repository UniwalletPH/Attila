using Attila.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class EventAdditionalEquipmentRequest : BaseAuditedEntity
    {

        [ForeignKey("Event")]
        public int EventID { get; set; }

        public Status Status { get; set; }
        public int Quantity { get; set; }

        public Event Event { get; set; }
    }
}
 