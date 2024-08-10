using Microsoft.Extensions.DependencyInjection;
using NonProfitERP.Common.Interfaces;
using NonProfitERP.Main.Services;
using System;

namespace NonProfitERP.Main.Configurations
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