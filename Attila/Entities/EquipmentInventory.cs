using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{

    [Table("tbl_EquipmentInventory")]
    public class EquipmentInventory
    {
        public int ID { get; set; }
        public DateTime EncodingDate { get; set; }
        public long EncodedBy { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public string Remarks { get; set; }
    }
}
