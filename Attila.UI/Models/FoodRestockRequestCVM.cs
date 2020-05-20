using Attila.Application.Admin.Foods.Queries;
using Attila.Application.Inventory_Manager.Foods.Queries;
using Attila.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class FoodRestockRequestCVM
    {
        public int ID { get; set; }

        public Food FoodDetails { get; set; }

        public int Quantity { get; set; }

        public decimal EstimatedPrice { get; set; }

        public decimal TotalEstimatedPrice { get; set; }

        public FoodRequestVM FoodRequest { get; set; }

        public List<FoodCollectionVM> FoodCollection { get; set; }

        public List<SelectListItem> FoodDetailsList { get; set; }

        public List<SelectListItem> UserList { get; set; }

        public List<FoodsRequestCollectionVM> FoodRequestCollectionCVM { get; set; }
    }
}
