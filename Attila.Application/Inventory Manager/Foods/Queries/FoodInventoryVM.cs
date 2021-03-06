﻿using Attila.Domain.Entities;
using System;

namespace Attila.Application.Inventory_Manager.Foods.Queries
{
    public class FoodInventoryVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public int FoodDetailsID { get; set; }

        public int DeliveryDetailsID { get; set; }

        public Food FoodDetailsVM { get; set; }
    }
}
