using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class PackageEquipments : BaseAuditedEntity
    {
        public int EquipmentDetailsID { get; set; }

        public int PackageMenuDetailsID { get; set; }

        public Equipment EquipmentDetails { get; set; }

        public PackageMenuDetails PackageMenuDetails { get; set; }
    }
}
