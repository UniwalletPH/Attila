using Attila.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Attila.Application.Inventory_Manager.Equipments.Queries
{
    public class EquipmentsRestockRequestVM
    {
        public int ID { get; set; }
        public DateTime DateTimeRequest { get; set; }
        public Status Status { get; set; }
        public int UserID { get; set; }
        


        public User User { get; set; }
        public Equipment EquipmentDetails { get; set; }


        public List<EquipmentsRequestCollectionVM> EquipmentRequestCollection { get; set; }
    }
}
