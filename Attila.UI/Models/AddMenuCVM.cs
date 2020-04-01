using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddMenuCVM
    {
        public IEnumerable<MenuVM> MenuList { get; set; }
         
        public MenuVM Menu { get; set; }

        public List<SelectListItem> CategoryList { get; set; }

        public int Selected { get; set; }
    }
}
