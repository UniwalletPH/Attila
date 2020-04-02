using System;
using System.ComponentModel.DataAnnotations;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class PaymentStatusVM
    {
        public int ID { get; set; }
        [Required]
        public int EventDetailsID { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime DateOfPayment { get; set; }
        [Required]
        public string ReferenceNumber { get; set; }
        [Required]
        public string Remarks { get; set; }
    }
}
