using Attila.Application.Inventory_Manager.Foods.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class FoodInventoryCVM
    {
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public DateTime EncodingDate { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public string Remarks { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int FoodDetailsID { get; set; }

        [Required]
        public int DeliveryDetailsID { get; set; }

        public IEnumerable<FoodInventoryVM> FoodsInventoryVMs { get; set; }

        public List<SelectListItem> FoodDetailsList { get; set; }

        public List<SelectListItem> FoodStockDetailsList { get; set; }

        public List<SelectListItem> FoodDeliveryList { get; set; } 

        public List<SelectListItem> UserList { get; set; }
    }
}
