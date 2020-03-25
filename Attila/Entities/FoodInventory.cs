using System;

namespace Attila.Domain.Entities
{
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

        public int FoodDeliveryID { get; set; }

        public FoodDetails FoodDetails { get; set; }

        public DeliveryDetails FoodRestock { get; set; }

        public User User { get; set; }
    }
}
