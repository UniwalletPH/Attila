using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Inventory_Manager.Shared.Commands
{
    public class SuppliersDetailsVM
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string ContactPersonName { get; set; }
    }
    
}
