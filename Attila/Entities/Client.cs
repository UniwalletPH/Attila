using Attila.Domain.Entities.Base;
using System.Collections.Generic;

namespace Attila.Domain.Entities
{
    public class Client : BaseAuditedEntity
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public ICollection<Event> Events { get; private set; } = new HashSet<Event>();
    }
}
