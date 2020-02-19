﻿using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EventEquipmentRequestVM
    {
        public int ID { get; set; }

        public int EventDetailsID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }

        public int Quantity { get; set; }

        public Status Status { get; set; }
    }
}
