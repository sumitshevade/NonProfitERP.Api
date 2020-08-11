using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PublicData.DAL.Interfaces;
using PublicData.DAL.Repository;
using PublicData.Common.Interfaces;
using System.Reflection;
using System.Linq;

namespace PublicData.DAL.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, string connectionString)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<PublicDataContext>(options => options.UseSqlServer(connectionString)); // .UseLazyLoadingProxies()
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PublicDataContext>();
            //Dynamically DI repositories 
            var types = Assembly.GetExecutingAssembly().GetExportedTypes().Where(t => t.GetInterfaces().Any(i=> i.Name == "IRepository`1") && !t.IsInterface); 

            foreach (var type in types)
            {
                var intfc = type.GetInterfaces().Where(x => x.Name.Contains(type.Name)).FirstOrDefault();
                if(intfc.Name != "IRepository`1")
                    services.AddScoped(intfc,type);
            }

        }
    }
}