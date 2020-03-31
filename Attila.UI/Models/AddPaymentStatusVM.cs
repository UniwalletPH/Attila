using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddPaymentStatusVM
    {
        public PaymentStatusVM Payment { get; set; }
        public List<SelectListItem> EventList { get; set; }
        public int SelectedEvent { get; set; }
    }
}
