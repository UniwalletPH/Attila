using Attila.Application;
using Attila.Application.Interfaces;
using Attila.Infrastructure;
using Attila.UI.Common;
using Attila.UI.Middlewares;
using Attila.UI.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace Attila.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddHttpContextAccessor();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ISignInManager, SignInManager>();
            services.AddScoped<ICurrentUser, AppUser>();

            services.AddKendo();


            services.AddControllersWithViews()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    opt.SerializerSettings.Formatting = Formatting.Indented;
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Login";
                    options.AccessDeniedPath = "/Error/403";

                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", authBuilder =>
                {
                    authBuilder.RequireRole("Admin");
                });

                options.AddPolicy("Coordinator", authBuilder =>
                {
                    authBuilder.RequireRole("Coordinator");
                });

                options.AddPolicy("InventoryManager", authBuilder =>
                {
                    authBuilder.RequireRole("InventoryManager");
                });
            });

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseExceptionHandler("/Error/500");
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseBrowserLink();

            app.UseRouting();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
