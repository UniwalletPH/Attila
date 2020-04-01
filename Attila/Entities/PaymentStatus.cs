using Attila.Domain.Entities.Base;
using System;

namespace Attila.Domain.Entities
{
    public class PaymentStatus : BaseAuditedEntity
    {
        public int EventDetailsID { get; set; }

        public Event EventDetails { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfPayment { get; set; }

        public string ReferenceNumber { get; set; }

        public string Remarks { get; set; }

    }
}
