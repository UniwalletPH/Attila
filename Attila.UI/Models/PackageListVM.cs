using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class PackageListVM
    {
        public IEnumerable<EventPackageVM> PackageList {get;set;}
    }
}
