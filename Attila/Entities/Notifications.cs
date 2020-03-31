using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class Notifications
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string Description { get; set; }

        public User User { get; set; }
    }
}
    