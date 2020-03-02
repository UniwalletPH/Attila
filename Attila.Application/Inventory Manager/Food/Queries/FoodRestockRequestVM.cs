using Attila.Domain.Entities.Tables;
using Attila.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Food.Queries
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

        public User User { get; set; }
    }
}
