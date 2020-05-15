using Attila.Domain.Entities;
using System;

namespace Attila.Application.Admin.Equipments.Queries
{
    public class EquipmentRequestVM
    {
        public int ID { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public Status Status { get; set; }

        public string Remarks { get; set; }

        public User InventoryManager { get; set; }
    }
}
