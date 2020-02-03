using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventEquipmentRequest
    {
        public int ID { get; set; }

        public int EventDetailsID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public int Quantity { get; set; }

    }
}
