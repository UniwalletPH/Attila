using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class PackageAdditionalEquipmentRequestVM
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public Equipment EquipmentDetails { get; set; }

        public decimal Rate { get; set; }

        public int EventDetailsID { get; set; }

        public Status Status { get; set; }

        public int Quantity { get; set; }
    }
}
