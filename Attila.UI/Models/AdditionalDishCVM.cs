using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AdditionalDishCVM
    {
        public AdditionalDishVM AdditionalDish { get; set; }
        public List<SelectListItem> DishList { get; set; }
        public List<SelectListItem> EventList { get; set; }
        public int SelectedDish { get; set; }
        public int SelectedEvent { get; set; }
    }
}
