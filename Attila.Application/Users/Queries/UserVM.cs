using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila.Application.Users.Queries
{
    public class UserVM
    {
        public int ID { get; set; }
        public Guid UID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string ContactNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public AccessRole Role { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
