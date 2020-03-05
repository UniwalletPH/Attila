using System;

namespace Attila.Domain.Entities
{

    public class EquipmentInventory
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int Quantity { get; set; }

        public int EquipmentDetailsID { get; set; }

        public int EquipmentRestockID { get; set; }

        public DateTime EncodingDate { get; set; }

        public decimal ItemPrice { get; set; }

        public string Remarks { get; set; }   

        public User User { get; set; }

        public EquipmentDetails EquipmentDetails { get; set; }

        public DeliveryDetails EquipmentRestock { get; set; }

       
    }
}
