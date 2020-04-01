using Attila.Application.Inventory_Manager.Equipment.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class EquipmentDetailsCVM
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

        [Required]
        public string SearchedKeyword { get; set; }

        public IEnumerable<EquipmentsDetailsVM> EquipmentDetailsVMs { get; set; }

        public List<SelectListItem> EquipmentDetailsList { get; set; }
    }
}
