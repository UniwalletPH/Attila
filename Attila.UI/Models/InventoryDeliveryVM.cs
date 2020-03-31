using Attila.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class InventoryDeliveryVM
    {
        public int ID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public int SupplierDetailsID { get; set; }

        public SupplierDetails SupplierDetails { get; set; }

        public string Remarks { get; set; }

        public List<SelectListItem> SupplierDetailsList { get; set; }

    }
}
