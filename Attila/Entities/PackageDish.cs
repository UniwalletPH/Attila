using Attila.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class PackageDish : BaseAuditedEntity
    {
        public int PackageMenuDetailsID {get; set;}

        public int DishID { get; set; }

        public Dish Dish { get; set; }

        public PackageMenuDetails PackageMenuDetails { get; set; }
    }
}
