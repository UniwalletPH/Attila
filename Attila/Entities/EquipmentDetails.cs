﻿using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;

namespace Attila.Domain.Entities
{
    public class EquipmentDetails
    {
        public int ID { get; set; }

        public string Code { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal RentalFee { get; set; }

        public UnitType UnitType { get; set; }

        public EquipmentType EquipmentType { get; set; }
    }
}
