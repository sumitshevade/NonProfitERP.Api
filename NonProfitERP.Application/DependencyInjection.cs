using System.Reflection;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace NonProfitERP.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
