using Attila.Application.Admin.Equipments.Queries;
using Attila.Application.Inventory_Manager.Equipments.Queries;
using Attila.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class EquipmentRestockRequestCVM
    {
        public int ID { get; set; }
         
        public int Quantity { get; set; }
         
        public DateTime DateTimeRequest { get; set; }
         
        public Status Status { get; set; } 
        public int UserID { get; set; }
         
        public int EquipmentDetailsID { get; set; }


        public User User { get; set; }
        public Equipment EquipmentDetails { get; set; }


        public List<SelectListItem> EquipmentDetailsList { get; set; }
        public List<SelectListItem> UserList { get; set; }
        public EquipmentRequestVM EquipmentRequest { get; set; }
        public List<EquipmentCollectionVM> EquipmentCollection { get; set; }
        public List<EquipmentsRequestCollectionVM> EquipmentRequestCollectionCVM { get; set; }

    }
}
