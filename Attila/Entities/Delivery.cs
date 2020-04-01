using System;

namespace Attila.Domain.Entities
{
    public class Delivery
    {
        public int ID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }

        public int SupplierDetailsID { get; set; }

        public Supplier SupplierDetails { get; set; }
    }
}