using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventFee : BaseAuditedEntity
    {
        [ForeignKey("Event")]
        public int EventID { get; set; }

        public string Description { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerQuantity { get; set; }

        public decimal TotalPrice { get; set; }

        public Event Event { get; set; }
    }
}
