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

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateTimeRequest { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int EquipmentDetailsID { get; set; }


        public User User { get; set; }
        public Equipment EquipmentDetails { get; set; }


        public List<SelectListItem> EquipmentDetailsList { get; set; }
        public List<SelectListItem> UserList { get; set; }
        public List<EquipmentsRequestCollectionVM> EquipmentRequestCollectionCVM { get; set; }

    }
}
