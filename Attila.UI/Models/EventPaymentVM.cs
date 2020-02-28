using Attila.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EventPaymentVM
    {
        public int ID { get; set; }
        [Required]
        public int EventDetailsID { get; set; }
        [Required]
        public EventDetails EventDetails { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateOfPayment { get; set; }
        [Required]
        public string ReferenceNumber { get; set; }

        public string Remarks { get; set; }
    }
}
