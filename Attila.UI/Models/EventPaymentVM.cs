using Attila.Application.Coordinator.Events.Queries;
using Attila.Domain.Entities;
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

        public EventDetailsVM? EventDetails { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? DateOfPayment { get; set; }

        public string? ReferenceNumber { get; set; }

        public string? Remarks { get; set; }


        public IEnumerable<PaymentStatusVM>? PaymentStatus {get;set;}
    }
}
