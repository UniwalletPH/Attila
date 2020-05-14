using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class Notifications : BaseAuditedEntity
    {
        [ForeignKey("TargetUser")]
        public int TargetUserID { get; set; }
        public string Description { get; set; }
        public string Messages { get; set; }
        public User TargetUser { get; set; }
    }
}
    