﻿using Attila.Application;
using Attila.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Attila.Presentation.InventoryManager
{
    public static class ServiceRegistration
    {
        static IServiceCollection _services;

        public static ServiceProvider ServiceProvider
        {
            get
            {
                if (_services == null) _services = new ServiceCollection();

                var _builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true);

                var _config = _builder.Build();

                _services.AddInfrastructure(_config);
                _services.AddApplication();

                var _serviceProvider = _services.BuildServiceProvider();

                return _serviceProvider;
            }
        }
    }
}
