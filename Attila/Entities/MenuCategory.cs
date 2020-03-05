using Attila.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities
{
    public class MenuCategory
    {
        public int ID { get; set; }

        public int PackegeDetailsID { get; set; }

        public string Category { get; set; }

        public PackageDetails PackageDetails { get; set; }

       
    }
}
