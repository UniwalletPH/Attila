using Attila.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    [Table("tbl_EquipmentRestockRequest")]
    public class EquipmentRestockRequest
    {
        public int ID { get; set; }
        
        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int EquipmentDetailsID { get; set; }
        
        public int UserID { get; set; }

    }
}
