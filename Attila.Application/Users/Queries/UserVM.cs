using Attila.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Users.Queries
{
    public class UserVM
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public AccessRole Role { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
