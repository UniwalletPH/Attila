using Attila.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Attila.UI.Common
{
    public class AppUser : ICurrentUser
    {
        public IEnumerable<AccessRole> Roles { get; private set; }
        public int ID { get; private set; }


        public AppUser(IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor.HttpContext == null)
            {
                return;
            }

            var _currentUser = contextAccessor.HttpContext.User;

            if (_currentUser == null)
            {
                return;
            }

            ClaimsIdentity _claimsIdentity = _currentUser.Identity as ClaimsIdentity;

            string _id = _claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            if (int.TryParse(_id, out int id))
                ID = id;

            Roles = _claimsIdentity?.FindAll(ClaimTypes.Role)?
                .Select(a => (AccessRole)Enum.Parse(typeof(AccessRole), a.Value));            
        }

        public bool IsInRole(AccessRole role)
        {
            return Roles.Contains(role);
        }
    }
}
