using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EquipmentTracking : BaseAuditedEntity
    {
        public int EventID { get; set; }
        public int EventAdditionalEquipmentRequestID { get; set; }
        public int EquipmentID { get; set; }
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
