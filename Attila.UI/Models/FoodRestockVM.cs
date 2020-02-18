using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodRestockVM
    {
        public int ID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }

    }
}
