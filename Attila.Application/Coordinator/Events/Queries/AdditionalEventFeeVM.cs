using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class AdditionalEventFeeVM
    {
        public int EventID { get; set; }

        public string Description { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerQuantity { get; set; }
    }
}
