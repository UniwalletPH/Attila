using Attila.Application.Coordinator.Events.Queries;
using Attila.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Attila.UI.Models
{
    public class AddEventMenuCVM
    {

        public int EventID { get; set; }

         public EventDetailsVM Event { get; set; }

        public List<PackageMenuVM> MenuList { get; set; }

        public List<SelectListItem> Menu { get; set; }



        public List<int> SelectedMenu { get; set; }  
        
       public IEnumerable<IGrouping<DishCategory,PackageMenuVM>> Groupings { get; set; }
 
         
    }
}
