using Attila.Domain.Entities;
using Attila.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
