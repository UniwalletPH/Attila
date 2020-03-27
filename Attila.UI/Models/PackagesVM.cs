using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class PackagesVM
    {

        public IEnumerable<Attila.Application.Coordinator.Event.Queries.EventPackageVM>? EventPackages { get; set; }

        public IEnumerable<Attila.Application.Coordinator.Event.Queries.PackageMenuVM>? PackageMenu { get; set; }
        public List<SelectListItem>? MenuList { get; set; }
        public List<SelectListItem>? PackageList { get; set; }
    }
}
