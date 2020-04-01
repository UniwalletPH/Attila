using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class InventoriesDeliveryVM
    {
        public int ID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public int SupplierDetailsID { get; set; }

        public SupplierDetails SupplierDetails { get; set; }

        public string Remarks { get; set; }
    }
}
