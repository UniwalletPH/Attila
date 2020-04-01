using Attila.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class InventoryDeliveryCVM
    {
        public int ID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public int SupplierDetailsID { get; set; }

        public Supplier SupplierDetails { get; set; }

        public string Remarks { get; set; }

        public List<SelectListItem> SupplierDetailsList { get; set; }

    }
}
