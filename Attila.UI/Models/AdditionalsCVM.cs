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
      
        public List<SelectListItem> EquipmentList { get; set; }

        public List<AdditionalDishVM> AdditionalDishRequest { get; set; }

        public List<AdditionalEquipmentRequestListVM> AdditionalEquipmentRequest { get; set; }

        public AdditionalDurationRequestListVM AdditionalDurationRequest { get; set; }
    }
}
