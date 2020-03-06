using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class AddEventVM
    {

        public EventDetailsVM Event { get; set; }

        public List<SelectListItem> PackageList { get; set; }

        public List<SelectListItem> ClientList { get; set; }

        public int Selected { get; set; }

        public int SelectedClient { get; set; }
    }
}
