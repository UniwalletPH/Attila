using Attila.Application.Coordinator.Events.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attila.UI.Models
{
    public class EventPaymentCVM
    {
        public int ID { get; set; }

        [Required]
        public int EventDetailsID { get; set; }

        public EventDetailsVM? EventDetails { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? DateOfPayment { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? Remarks { get; set; }

        public IEnumerable<PaymentStatusVM>? PaymentStatus {get;set;}
    }
}
