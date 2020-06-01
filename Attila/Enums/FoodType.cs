using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila
{
    public enum FoodType : byte
    {
        None = 0,
        Perishable = 1,

        [Display(Name = "Non-Perishable")]
        NonPerishable = 2,
        Others = 3
    }
}
