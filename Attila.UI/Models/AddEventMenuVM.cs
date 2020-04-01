using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddEventMenuVM
    {
        public EventMenuVM EventMenu { get; set; }
        public List<SelectListItem> MenuList { get; set; }
        public List<SelectListItem> EventList { get; set; }
        public int SelectedMenu { get; set; }
        public int SelectedEvent { get; set; }
    }
}
