using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities.Base
{
    public class BaseAuditedEntity : BaseEntity
    {
        public DateTime CreatedOn { get; set; }
    }
}
