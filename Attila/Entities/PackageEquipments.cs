using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class PackageEquipments
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public int PackageMenuDetailsID { get; set; }

        public Equipment EquipmentDetails { get; set; }

        public PackageMenuDetails PackageMenuDetails { get; set; }
    }
}
