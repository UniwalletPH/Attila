using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class FoodVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }

        public int UserID { get; set; }

        public Food FoodDetails { get; set; }
    }
}
