using Attila.Domain.Entities;
using System;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class EquipmentsRestockRequestVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int EquipmentDetailsID { get; set; }

        public Domain.Entities.Equipment EquipmentDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
