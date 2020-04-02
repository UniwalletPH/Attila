using Attila.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class EventEquipment : BaseAuditedEntity
    {

        [ForeignKey("Event")]
        public int EventID { get; set; }
        [ForeignKey("Equipment")]
        public int EquipmentID { get; set; }
        

        public Equipment Equipment{ get; set; }
        public Event Event { get; set; }
    }
}
