using NonProfitERP.Application;
using NonProfitERP.Common.Behaviours;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Security.Authorization;
using NonProfitERP.Common.Security.Identity;
using NonProfitERP.DAL.Configurations;
using NonProfitERP.Main.Configurations;
using NonProfitERP.Main.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace NonProfitERP.Main
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Add Application
            services.AddApplication();

            // Setting DBContexts
            services.AddDatabaseSetup(Configuration.GetConnectionString("DefaultConnection"));

            // ASP.NET Identity Settings & JWT
            services.AddIdentitySetup(Configuration);

            // Add Behaviour Setup
            services.AddBehaviourSetup();

            // WebAPI Config
            services.AddControllers(options =>
                    options.Filters.Add(new ApiExceptionFilter()));
                //.AddNewtonsoftJson(options =>
                //{
                //    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //    //options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                //});

            // Authorization
            var policies = new Dictionary<string, ClaimRequirement>
            {
                { "CanWriteEmployeeData", new ClaimRequirement("Employees", "Write") },
                { "CanRemoveEmployeeData", new ClaimRequirement("Employees", "Remove") }
            };

            services.AddAuthSetup(Configuration.GetConnectionString("DefaultConnection"), policies);

            // Swagger Config
            services.AddSwaggerSetup();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // .NET Native DI Abstraction
            services.AddApiSetup();

            services.AddHealthChecks()
                // Add a health check for a SQL Server database
                .AddCheck(
                    "PublicDataDb-check",
                    new SqlConnectionHealthCheckService(Configuration.GetConnectionString("DefaultConnection")),
                    HealthStatus.Unhealthy,
                    new string[] { "NonProfitERP" });

            services.ConfigureSwaggerGen(option =>
                option.CustomSchemaIds(x => x.FullName)
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseSwaggerSetup();

            loggerFactory.AddFile("Logs/log-{Date}.txt");
        }
    }
}
