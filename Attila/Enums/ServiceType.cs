using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila.Domain.Enums
{
    public enum ServiceType : byte
    {
        None = 0,

        [Display(Name = "Food Trays")]
        FoodTrays = 1,
        Catering = 2,

        [Display(Name = "Packed Meals")]
        PackedMeals = 3,
        Merchandise = 4
    }
}
