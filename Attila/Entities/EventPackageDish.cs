using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Attila.Domain.Entities
{
    public class EventPackageDish : BaseAuditedEntity
    {
        [ForeignKey("EventPackage")]
        public int EventPackageID {get; set;}
        
        [ForeignKey("Dish")]
        public int DishID { get; set; }
        
        public Dish Dish { get; set; }
        public EventPackage EventPackage { get; set; }
    }
}
