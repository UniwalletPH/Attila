using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class FoodRestockVM
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

    }
}
