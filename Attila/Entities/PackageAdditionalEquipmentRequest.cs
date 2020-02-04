﻿using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_PackageAdditionalEquipmentRequest")]
    public class PackageAdditionalEquipmentRequest
    {
        public int ID { get; set; }

        public int EventEquipmentsID { get; set; }

        public decimal Rate { get; set; }
        

        public Status Status { get; set; }

        public int EventDetailsID { get; set; }

    }
}
