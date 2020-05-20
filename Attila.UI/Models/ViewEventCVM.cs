using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class ViewEventCVM
    {

        public EventDetailsVM EventDetails { get; set; }  

        public int Selected { get; set; }

        public int SelectedClient { get; set; }

        public SelectList Package { get; set; }

        public SelectList Client { get; set; }

        public decimal TotalCharge { get; set; }

        public decimal TotalPayment { get; set; }
    }

     
}
