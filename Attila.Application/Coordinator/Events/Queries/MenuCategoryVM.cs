using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class MenuCategoryVM
    {
        public int ID { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
