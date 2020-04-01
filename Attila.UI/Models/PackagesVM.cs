using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class PackagesVM
    {

        public IEnumerable<EventPackageVM>? EventPackages { get; set; }

        public IEnumerable<PackageMenuVM>? PackageMenu { get; set; }
        public List<SelectListItem>? MenuList { get; set; }
        public List<SelectListItem>? PackageList { get; set; }
    }
}
