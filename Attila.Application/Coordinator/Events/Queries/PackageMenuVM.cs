using Attila.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Coordinator.Events.Queries
{
    public class PackageMenuVM
    {
        public int ID { get; set; }

        public int PackageDetailsID { get; set; }

        public int MenuID { get; set; }

        public Dish? Menu { get; set; }

        public PackageMenuDetails? PackageMenuDetails { get; set; }
    }
}
