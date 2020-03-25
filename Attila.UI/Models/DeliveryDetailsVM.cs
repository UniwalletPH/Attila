using Attila.Application.Inventory_Manager.Shared.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class DeliveryDetailsVM
    {
        public int ID { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public byte[] ReceiptImage { get; set; }

        [Required]
        public decimal DeliveryPrice { get; set; }

        [Required]
        public string Remarks { get; set; }

        public IEnumerable<InventoriesDeliveryVM> InventoryDeliveryVM { get; set; }

    }
}
