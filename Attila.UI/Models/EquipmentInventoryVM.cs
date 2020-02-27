using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EquipmentInventoryVM
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
        public int EquipmentDeliveryID { get; set; }

        public List<SelectListItem> EquipmentDetailsList { get; set; }

        public List<SelectListItem> EquipmentDeliveryList { get; set; }
    }
}
