using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventPackageEquipment : BaseAuditedEntity
    {
        [ForeignKey("Equipment")]
        public int EquipmentID { get; set; }

        [ForeignKey("EventPackage")]
        public int EventPackageID { get; set; }


        public Equipment Equipment { get; set; }
        public EventPackage EventPackage { get; set; }
    }
}
