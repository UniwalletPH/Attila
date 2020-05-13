using Attila.Application.Coordinator.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class ServiceChargeCVM
    {
        public EventDetailsVM Event { get; set; }

        public List<AdditionalEventFeeVM> EventFees { get; set; }
    }
}
