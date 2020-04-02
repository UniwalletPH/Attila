using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventPackage : BaseAuditedEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal RatePerHead { get; set; }


        public ICollection<Event> Events { get; private set; } = new HashSet<Event>();
        public ICollection<EventPackageEquipment> EventPackageEquipments { get; private set; } = new HashSet<EventPackageEquipment>();
        public ICollection<EventPackageDish> EventPackageDishes { get; private set; } = new HashSet<EventPackageDish>();

    }
}
