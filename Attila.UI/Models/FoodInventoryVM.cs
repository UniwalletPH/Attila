using Attila.Application.Inventory_Manager.Food.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodInventoryVM
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

        public IEnumerable<FoodsInventoryVM> FoodsInventoryVMs { get; set; }

        public List<SelectListItem> FoodDetailsList { get; set; }

        public List<SelectListItem> FoodDeliveryList { get; set; } 

        public List<SelectListItem> UserList { get; set; }
    }
}
