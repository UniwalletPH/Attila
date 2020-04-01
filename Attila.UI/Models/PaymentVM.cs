using Attila.Application.Admin.Events.Queries;
using System.Collections.Generic;

namespace Attila.UI.Models
{
    public class PaymentVM
    {
        public IEnumerable<EventVM> Events { get; set; }
  
    }
}
