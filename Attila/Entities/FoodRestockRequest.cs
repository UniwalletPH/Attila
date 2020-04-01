using Attila.Domain.Enums;
using System;

namespace Attila.Domain.Entities
{
    public class FoodRestockRequest
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
