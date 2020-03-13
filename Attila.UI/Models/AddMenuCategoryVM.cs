using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddMenuCategoryVM
    {
        public MenuCategoryVM MenuCategory { get; set; }
        public List<SelectListItem> PackageList { get; set; }
        public int Selected { get; set; }
    }
}
