using Attila.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text; 

namespace Attila.Domain.Entities.Tables
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Position{ get; set; }

        public string ContactNumber { get; set; }

        public string Email{ get; set; }

        public AccessRole Role { get; set; }

    }
}
