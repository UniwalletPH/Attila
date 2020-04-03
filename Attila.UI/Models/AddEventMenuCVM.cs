using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class AddEventMenuCVM
    {

        public int EventID { get; set; }
         public EventDetailsVM Event { get; set; }

        public List<PackageMenuVM> MenuList { get; set; }

        public List<SelectListItem> Menu { get; set; }

        public int SelectedMenu { get; set; }        
 
         
    }
}
