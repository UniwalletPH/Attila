using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    public class EventAdditionalEquipmentRequest
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }

        public Status Status { get; set; }

        public int Quantity { get; set; }

    }
}
