using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class PackageMenus
    {
        public int ID { get; set; }

        public int PackageMenuDetailsID {get; set;}

        public int MenuID { get; set; }

        public Menu Menu { get; set; }

        public PackageMenuDetails PackageMenuDetails { get; set; }
    }
}
