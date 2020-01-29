using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atilla.Domain.Entities.Tables
{
    [Table("tbl_FoodInventory")]
    public class FoodInventory
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public int FoodDetailsID { get; set; }

        public int FoodRestockID { get; set; }

    }
}
