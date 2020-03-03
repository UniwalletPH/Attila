using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{

    public class EquipmentRestock
    {
        public int ID { get; set; }

        public DateTime DeliveryDate { get; set; } 

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }
    }
}
