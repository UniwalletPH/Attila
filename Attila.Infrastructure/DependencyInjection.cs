using Atilla.Application.Interfaces;
using Atilla.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atilla.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AttilaDbContext>();

            services.AddScoped<IAttilaDbContext>(provider => provider.GetService<AttilaDbContext>());

            return services;
        }
    }
}
