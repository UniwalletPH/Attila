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
        public int? FoodRestockRequestID { get; set; }
        public int? EquipmentRestockRequestID { get; set; }


        public DateTime DeliveryDate { get; set; }

        public byte[] ReceiptImage { get; set; }

        public decimal DeliveryPrice { get; set; }

        public string Remarks { get; set; }


        public Supplier Supplier { get; set; }

        public ICollection<Food> Food { get; private set; } = new HashSet<Food>();

        public ICollection<FoodInventory> FoodInventories { get; private set; } = new HashSet<FoodInventory>();

        public ICollection<Equipment> Equipment { get; private set; } = new HashSet<Equipment>();

        public ICollection<EquipmentInventory> EquipmentInventories { get; private set; } = new HashSet<EquipmentInventory>();


    }
}