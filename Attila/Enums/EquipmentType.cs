using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila
{
    public enum EquipmentType : byte
    {
        None = 0,
        Consumable = 1,

        [Display(Name = "Non-Consumable")]
        NonConsumable = 2,
        Others = 3
    }
}
