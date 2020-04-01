using Attila.Domain.Enums;
using System;

namespace Attila.Domain.Entities
{
    public class EquipmentRestockRequest
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int EquipmentDetailsID { get; set; }

        public Equipment EquipmentDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
