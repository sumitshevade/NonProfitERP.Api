using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using NonProfitERP.Application;
using NonProfitERP.Common.Behaviours;
using NonProfitERP.Common.Exceptions;
using NonProfitERP.Common.Security.Authorization;
using NonProfitERP.Common.Security.Identity;
using NonProfitERP.DAL.Configurations;
using NonProfitERP.Main.Configurations;
using NonProfitERP.Main.Services;
using System.Collections.Generic;

namespace NonProfitERP.Main
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Application
            builder.Services.AddApplication();

            // Setting DBContexts
            builder.Services.AddDatabaseSetup(builder.Configuration.GetConnectionString("DefaultConnection"));

            // ASP.NET Identity Settings & JWT
            builder.Services.AddIdentitySetup(builder.Configuration);

            // Add Behaviour Setup
            builder.Services.AddBehaviourSetup();

            // WebAPI Config
            builder.Services.AddControllers(options =>
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

            builder.Services.AddAuthSetup(builder.Configuration.GetConnectionString("DefaultConnection"), policies);

            // Swagger Config
            builder.Services.AddSwaggerSetup();

            // Adding MediatR for Domain Events and Notifications
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

            // ASP.NET HttpContext dependency
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // .NET Native DI Abstraction
            builder.Services.AddApiSetup();

            builder.Services.AddHealthChecks()
                // Add a health check for a SQL Server database
                .AddCheck(
                    "PublicDataDb-check",
                    new SqlConnectionHealthCheckService(builder.Configuration.GetConnectionString("DefaultConnection")),
                    HealthStatus.Unhealthy,
                    ["NonProfitERP"]);

            builder.Services.ConfigureSwaggerGen(option =>
                option.CustomSchemaIds(x => x.FullName)
            );

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
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
            app.MapControllers();

            app.MapHealthChecks("/health");

            app.UseSwaggerSetup();

            //loggerFactory.AddFile("Logs/log-{Date}.txt");

            app.Run();
        }
    }
}
