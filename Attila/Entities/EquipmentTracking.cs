using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EquipmentTracking : BaseAuditedEntity
    {
        [ForeignKey("Event")]
        public int EventID { get; set; }

        [ForeignKey("EventAdditionalEquipmentRequest")]
        public int EventAdditionalEquipmentRequestID { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public int Quantity { get; set; }
        public DateTime TrackingDate { get; set; }
        public EquipmentAction TrackingAction { get; set; }
        public string Remarks { get; set; }

        public Event Event { get; set; }
        public EventAdditionalEquipmentRequest EventAdditionalEquipmentRequest { get; set; }
        public Equipment Equipment { get; set; }
        public User User { get; set; }
    }
}
