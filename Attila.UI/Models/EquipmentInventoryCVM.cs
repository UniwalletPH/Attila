using Attila.Application.Coordinator.Events.Queries;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class EquipmentInventoryCVM
    {
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime EncodingDate { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public string Remarks { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int EquipmentDetailsID { get; set; }

        [Required]
        public int EventDetailsID { get; set; }

        [Required]
        public int DeliveryDetailsID { get; set; }

        public int CheckOutEquipmentID { get; set; }

        public IEnumerable<EquipmentsInventoryVM> EquipmentsInventoryVMs { get; set; }

        public EventDetailsVM EventDetailsVM { get; set; }

        public List<EquipmentTrackingVM> EquipmentTrackingVMs { get; set; }

        public List<SelectListItem> EquipmentDetailsList { get; set; }

        public List<SelectListItem> EquipmentStockDetailsList { get; set; }

        public List<SelectListItem> EquipmentDeliveryList { get; set; }

        public List<SelectListItem> UserList { get; set; }

        public List<SelectListItem> ProcessingEventsList { get; set; }
    }
}
