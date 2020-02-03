using Atilla.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atilla.Domain.Entities
{
    [Table("tbl_EquipmentRestockRequest")]
    public class EquipmentRestockRequest
    {
        public int ID { get; set; }
        
        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int EquipmentDetailsID { get; set; }
        
        public Status Status { get; set; }

        public int UserID { get; set; }

    }
}
