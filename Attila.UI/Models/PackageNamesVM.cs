using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class PackageNamesVM
    {
        public string Selected { get; set; }
        public List<SelectListItem> PackageList { get; set; }
    }
}
