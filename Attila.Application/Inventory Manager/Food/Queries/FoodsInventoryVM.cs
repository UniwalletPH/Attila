using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Food.Queries
{
    public class FoodsInventoryVM
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
    }
}
