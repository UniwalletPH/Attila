using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventEquipmentRequestCollection : BaseAuditedEntity
    {
        [ForeignKey("Equipment")]
        public int EquipmentID { get; set; }

        [ForeignKey("EventAdditionalEquipmentRequest")]
        public int EventAdditionalEquipmentRequestID { get; set; }

        public int Quantity { get; set; }

        public Equipment Equipment { get; set; }
        public EventAdditionalEquipmentRequest EventAdditionalEquipmentRequest { get; set; }
    }
}
