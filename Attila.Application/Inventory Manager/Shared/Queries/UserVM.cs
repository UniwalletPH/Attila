using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Shared.Queries
{
    public class UserVM
    {
        public Guid UID { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public AccessRole Role { get; set; }
    }
}
