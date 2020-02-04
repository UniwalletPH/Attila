using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atilla.Domain.Entities.Tables
{
    [Table("tbl_PackageAdditionalEquipmentRequest")]
    public class PackageAdditionalEquipmentRequest
    {
        public int ID { get; set; }

        public int EquipmentsDetailsID { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }

        public decimal Rate { get; set; }

        public int EventDetailsID { get; set; }

        public int Quantity { get; set; }

    }
}
