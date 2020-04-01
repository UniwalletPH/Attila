using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Identity.Queries
{
    public class AttilaUser
    {
        public int ID { get; set; }

        public Guid UID { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public AccessRole Role { get; set; }
    }
}
