﻿using Attila.Domain.Entities.Enums;
using Attila.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class EquipmentDetailsVM
    {
        public int ID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string RentalFee { get; set; }

        [Required]
        public UnitType UnitType { get; set; }

        [Required]
        public EquipmentType EquipmentType { get; set; }

        public List<SelectListItem> EquipmentDetailsList { get; set; }

    }
}
