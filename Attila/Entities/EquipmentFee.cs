using Attila.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EquipmentFee
    {
        public int ID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public decimal Price { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }
    }
}
