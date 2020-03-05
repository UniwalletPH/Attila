using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodRestockRequestVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }


        public DateTime DateTimeRequest { get; set; }

        public int FoodDetailsID { get; set; }

        public FoodDetails FoodDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }
    }
}
