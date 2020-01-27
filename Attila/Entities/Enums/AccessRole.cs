using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities.Enums
{
    public enum AccessRole : byte
    {
        None = 0,
        Admin = 1, 
        Coordinator = 2,
        Chef = 3, 
        InventoryManager = 4
    }
}
