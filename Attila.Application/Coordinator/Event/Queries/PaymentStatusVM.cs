using Attila.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Event.Queries
{
    public class PaymentStatusVM
    {
        public int ID { get; set; }

        public int EventDetailsID { get; set; }

        public EventDetails EventDetails { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfPayment { get; set; }

        public string ReferenceNumber { get; set; }

        public string Remarks { get; set; }
    }
}
