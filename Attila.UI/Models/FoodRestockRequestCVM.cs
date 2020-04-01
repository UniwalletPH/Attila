using Attila.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class FoodRestockRequestCVM
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public DateTime DateTimeRequest { get; set; }

        public int FoodDetailsID { get; set; }

        public Food FoodDetails { get; set; }

        public Status Status { get; set; }

        public int UserID { get; set; }

        public List<SelectListItem> FoodDetailsList { get; set; }
        public List<SelectListItem> UserList { get; set; }
    }
}
