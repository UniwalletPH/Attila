using Attila.Domain.Entities;
using Attila.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class EquipmentsDetailsVM
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal RentalFee { get; set; }

        public UnitType UnitType { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public string SearchedKeyword { get; set; }

        public IEnumerable<EquipmentsDetailsVM> EquipmentDetailsVMs { get; set; }

    }
}
