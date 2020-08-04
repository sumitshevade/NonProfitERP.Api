using System;
using PublicData.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PublicData.Api.Services;

namespace PublicData.Api.Configurations
{
    public static class ApiSetup
    {
        public static void AddApiSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}