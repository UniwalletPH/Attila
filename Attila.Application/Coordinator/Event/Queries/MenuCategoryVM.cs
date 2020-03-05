using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila.Application.Coordinator.Event.Queries
{
    public class MenuCategoryVM
    {
        public int ID { get; set; }
        [Required]
        public int PackageDetailsID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public PackageMenuDetails PackageDetails { get; set; }
    }
}
