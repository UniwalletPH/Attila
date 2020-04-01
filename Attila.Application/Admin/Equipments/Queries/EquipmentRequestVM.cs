using Attila.Domain.Entities;
using System;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class EquipmentRequestVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public Status Status { get; set; }

        public Domain.Entities.Equipment EquipmentDetails { get; set; }

        public User User { get; set; }
    }
}
