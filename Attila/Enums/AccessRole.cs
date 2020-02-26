using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Domain.Entities.Enums
{
    public enum AccessRole : byte
    {
        None = 1,
        Admin = 2, 
        Coordinator = 3,
        Chef = 4, 
        InventoryManager = 5
    }
}
