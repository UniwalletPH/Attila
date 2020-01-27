using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities.Tables
{
    [Table("tbl_FoodRestock")]
    public class FoodRestock
    {
        public int ID { get; set; }  
        public byte[] RecieptImage { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string Remarks { get; set; }

    }
}
