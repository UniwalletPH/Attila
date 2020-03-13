using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddMenuVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<SelectListItem> CategoryList { get; set; }

        public int Selected { get; set; }
    }
}
