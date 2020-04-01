using System;
using System.Collections.Generic;
using System.Text;

namespace Attila
{
    public enum  Status : byte
    {
        None = 0,
        Processing = 1,
        CheckingRequirements = 2,
        RequirementsComplete = 3,
        ForApproval = 4,
        Approved = 5,
        Declined = 6
    }
}
