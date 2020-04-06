using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EquipmentRequestCollection : BaseAuditedEntity
    {
        [ForeignKey("Equipment")]
        public int EquipmentID { get; set; }
        [ForeignKey("EquipmentRestockRequest ")]
        public int EquipmentRestockRequestID { get; set; }

        public Equipment Equipment { get; set; }
        public EquipmentRestockRequest EquipmentRestockRequest { get; set; }
    }
}
