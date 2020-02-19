using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class EventPackageVM
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public int NumberOfGuest { get; set; }

        public decimal Rate { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
