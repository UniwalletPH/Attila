using Attila.Application.Coordinator.Event.Queries;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class PaymentVM
    {
        public IEnumerable<Attila.Application.Admin.Event.Queries.EventVM> Events { get; set; }
  
    }
}
