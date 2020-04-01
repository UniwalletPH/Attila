using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class PackagesCVM
    {

        public IEnumerable<EventPackageVM>? EventPackages { get; set; }

        public IEnumerable<PackageMenuVM>? PackageMenu { get; set; }

        public List<SelectListItem>? MenuList { get; set; }

        public List<SelectListItem>? PackageList { get; set; }
    }
}
