using Attila.Application.Coordinator.Events.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class AddMenuCategoryVM
    {
       [Required]
       public string Category { get; set; }

    }
}
