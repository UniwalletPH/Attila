using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Equipment.Queries
{
    public class EquipmentRestockVM
    {
        public int ID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }
    }
}
