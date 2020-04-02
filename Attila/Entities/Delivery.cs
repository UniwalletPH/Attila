using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class Delivery : BaseAuditedEntity
    {  

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }


        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }


        public Supplier Supplier { get; set; }

        public ICollection<EquipmentInventory> EquipmentInventories { get; private set; } = new HashSet<EquipmentInventory>();

        public ICollection<FoodInventory> FoodInventories { get; private set; } = new HashSet<FoodInventory>();



    }
}