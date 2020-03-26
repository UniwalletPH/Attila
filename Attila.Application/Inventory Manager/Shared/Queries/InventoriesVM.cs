using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Domain.Entities;
using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class InventoriesVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }
    }
}
