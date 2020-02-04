using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    [Table("tbl_FoodRestockRequest")]
    public class FoodRestockRequest
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int FoodsDetailsID { get; set; }

        public FoodDetails FoodDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }
    }
}
