using Attila.Domain.Entities;
using Attila.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class EquipmentRestockRequestVM
    {
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateTimeRequest { get; set; }

        [Required]
        public int EquipmentDetailsID { get; set; }

        [Required]
        public EquipmentDetails EquipmentDetails { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public User User { get; set; }

        public List<SelectListItem> EquipmentDetailsList { get; set; }

        public List<SelectListItem> UserList { get; set; }

    }
}
