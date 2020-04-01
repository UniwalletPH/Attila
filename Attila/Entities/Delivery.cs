using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class Delivery : BaseAuditedEntity
    {  

        public int SupplierID { get; set; }

        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<EquipmentInventory> EquipmentInventories { get; set; }

        public ICollection<FoodInventory> FoodInventories { get; set; }



    }
}