using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class Supplier : BaseAuditedEntity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string ContactPersonName { get; set; }


        public ICollection<Delivery> Deliveries { get; private set; } = new HashSet<Delivery>(); 
    }
}
