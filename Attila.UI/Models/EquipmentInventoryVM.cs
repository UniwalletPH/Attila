using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EquipmentInventoryVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public int EquipmentDetailsID { get; set; }

        public int EquipmentDeliveryID { get; set; }
    }
}
