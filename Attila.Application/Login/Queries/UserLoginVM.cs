using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Login.Queries
{
    public class UserLoginVM
    {
        public string Username { get; set; }

        public byte[] Salt { get; set; }

        public byte[] Password { get; set; }
    }
}
