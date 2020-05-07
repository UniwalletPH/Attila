using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Interfaces
{
    public interface IAppEnvironment
    {
        bool IsDevelopment();
        bool IsStaging();
        bool IsProduction();
    }
}
