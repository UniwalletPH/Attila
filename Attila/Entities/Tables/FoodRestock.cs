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
        public int Code { get; set; }
        public string Name { get; set; }
        public string RecieptImage { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal DeliveryPrice { get; set; }
        public string Remarks { get; set; }



    }
}
