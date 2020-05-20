using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Interfaces
{
    public interface ICurrentUser
    {
        int ID { get; }

        IEnumerable<AccessRole> Roles { get; }
        bool IsInRole(AccessRole role);
    }
}