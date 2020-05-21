using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attila
{
    public enum ServingType : byte
    {
        None = 0,
        [Display(Name = "Manage Buffet")]
        ManageBuffet = 1,

        [Display(Name = "Self-Service Buffet")]
        SelfServiceBuffet = 2
    }
}
