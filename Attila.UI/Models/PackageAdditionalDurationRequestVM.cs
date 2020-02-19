using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class PackageAdditionalDurationRequestVM
    {
        public int ID { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Rate { get; set; }

        public int EventDetailsID { get; set; }
    }
}
