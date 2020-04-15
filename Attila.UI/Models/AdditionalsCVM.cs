using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AdditionalsCVM
    {
      
        public int EventID { get; set; }


        public List<SelectListItem> EquipmentList { get; set; }

        public List<SelectListItem> DishList { get; set; }


        public AdditionalDishVM AdditionalDishRequest { get; set; }

        public AdditionalEquipmentRequestListVM AdditionalEquipmentRequest { get; set; }

        public AdditionalDurationRequestListVM AdditionalDurationRequest { get; set; }


        public List<AdditionalEquipmentRequestListVM> EquipmentRequested { get; set; }

        public List<AdditionalDishVM> DishRequested { get; set; }

    }
}
