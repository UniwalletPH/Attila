using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Attila.UI
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsInRole(this ClaimsPrincipal principal, AccessRole role)
        {
            return principal.IsInRole(role.ToString());
        }
    }
}
