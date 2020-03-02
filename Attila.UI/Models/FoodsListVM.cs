using Attila.Application.Inventory_Manager.Food.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodsListVM
    {
        public FoodInventoryVM FoodInventoryVM { get; set; }

        public List<SelectListItem> FoodDetailsList { get; set; }

        public List<SelectListItem> FoodDeliveryList { get; set; }
    }
}
