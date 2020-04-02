using Attila.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attila.Domain.Entities
{
    public class PaymentStatus : BaseAuditedEntity
    {
        [ForeignKey("Event")]
        public int EventID { get; set; }

        public decimal Amount { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string ReferenceNumber { get; set; }
        public string Remarks { get; set; }


        public Event Event { get; set; }

    }
}
