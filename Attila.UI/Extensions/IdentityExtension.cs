using Attila.Application.Identity.Queries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Attila.UI.Extensions
{
    public static class IdentityExtension
    {
        public static AttilaUser GetUserData(this IIdentity identity)
        {
            ClaimsIdentity _claimsIdentity = identity as ClaimsIdentity;
            Claim _claim = _claimsIdentity?.FindFirst(ClaimTypes.UserData);

            var _userData = _claim?.Value;

            if (string.IsNullOrWhiteSpace(_userData))
            {
                return null;
            }

            var _retVal = JsonConvert.DeserializeObject<AttilaUser>(_userData);

            return _retVal;
        }
    }
}
