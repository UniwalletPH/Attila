using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Models
{
    public class UserCVM
    {
        public Guid UID { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public AccessRole Role { get; set; }
    }
}
