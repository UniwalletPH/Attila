using Attila.Application.Admin.Events.Queries;
using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Attila.Application.Admin.Foods.Queries;
using Attila.Application.Admin.Equipments.Queries;

using Attila.Application.Inventory_Manager.Shared.Queries;
namespace Attila.UI.Models
{
    public class ReportCVM
    {
        public  List<EventVM> Events { get; set; }

        public List<FoodRequestVM> FoodRequest { get;  set; }

        public IEnumerable<EquipmentRequestVM> EquipmentRequest { get; set; }

        public IEnumerable<InventoriesDeliveryVM> Delivery { get; set; }
    }
}
