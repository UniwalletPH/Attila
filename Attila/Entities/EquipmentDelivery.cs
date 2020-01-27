using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{

    [Table("tbl_EquipmentDelivery")]
    public class EquipmentDelivery
    {
        public int ID { get; set; }
        public DateTime DeliveryDate { get; set; } 
        public byte[] ReceiptImage { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string Remarks { get; set; }
    }
}
