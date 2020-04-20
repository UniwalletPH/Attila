﻿using Attila.Application.Inventory_Manager.Foods.Queries;
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

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateTimeRequest { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int FoodDetailsID { get; set; }


        public User User { get; set; }
        public Food FoodDetails { get; set; }


        public List<SelectListItem> FoodDetailsList { get; set; }
        public List<SelectListItem> UserList { get; set; }
        public List<FoodsRequestCollectionVM> FoodRequestCollectionCVM { get; set; }
    }
}
