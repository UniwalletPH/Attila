using Attila.Application.Admin.Foods.Queries;
using Attila.Application.Admin.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class InventoryViewVM
    {
        public List<FoodRequestVM> PendingFoodRestockRequest { get; set; }

        public List<EquipmentRequestVM> PendingEquipmentRestockRequest { get; set; }

    }
}
