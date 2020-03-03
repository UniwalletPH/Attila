using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    public class EventEquipments
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public int EventDetailsID { get; set; }

    }
}
