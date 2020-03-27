using Attila.Application.Interfaces;
using Attila.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AttilaDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionString: configuration.GetConnectionString("AttilaDBConStr"),
                    sqlServerOptionsAction: opt => opt.MigrationsAssembly("Attila.DbMigration")
                    );
            });

            services.AddScoped<IAttilaDbContext>(provider => provider.GetService<AttilaDbContext>());
            services.AddScoped<DbContext>(provider => provider.GetService<AttilaDbContext>());

            return services;
        }
    }
}
