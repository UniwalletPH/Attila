﻿using Attila.Application.Inventory_Manager.Shared.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class SupplierDetailsCVM
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string ContactPersonName { get; set; }

        public IEnumerable<SuppliersDetailsVM> SupplierDetailsVMs { get; set; }
    }
}
