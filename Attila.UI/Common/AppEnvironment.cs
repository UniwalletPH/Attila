using Attila.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attila.UI.Common
{
    public class AppEnvironment : IAppEnvironment
    {
        private readonly IWebHostEnvironment env;

        public AppEnvironment(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public bool IsDevelopment()
        {
            return env.IsDevelopment();
        }

        public bool IsProduction()
        {
            return env.IsProduction();
        }

        public bool IsStaging()
        {
            return env.IsStaging();
        }
    }
}
