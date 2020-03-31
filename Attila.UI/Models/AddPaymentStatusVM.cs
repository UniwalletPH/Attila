using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddPaymentStatusVM
    {
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
