using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class MenuVM
    {
        public int ID { get; set; }
        [Required]
        public int MenuCategoryID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public MenuCategory MenuCategory { get; set; }
    }
}
