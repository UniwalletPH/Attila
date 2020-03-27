﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddPackageMenuVM
    {
        public int SelectedPackage { get; set; }
        public int SelectedMenu { get; set; }
        public List<SelectListItem> PackageList { get; set; }
        public List<SelectListItem> MenuList { get; set; }
    }
}
