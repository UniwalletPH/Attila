using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class Notifications : BaseAuditedEntity
    {
        public int TargetUserID { get; set; }

        public string Description { get; set; }

        public User TargetUser { get; set; }
    }
}
    