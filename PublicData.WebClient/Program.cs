using System;
using Blazored.Toast;
using System.Net.Http;
using Blazored.LocalStorage;
using PublicData.WebClient.Core;
using System.Threading.Tasks;
using PublicData.WebClient.Services;
using PublicData.WebClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PublicData.WebClient.Repository;
using Blazored.SessionStorage;

namespace PublicData.WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44333/") });
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://peoplemanagement-api.azurewebsites.net/") });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredSessionStorage(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
            });
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredToast();
            //builder.Services.AddAutoMapper(typeof(AssetRequestAllocationProfile));
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Inject repositories - TODO: move to somewhere - use reflection
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDetailRepository, DetailRepository>();
            builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
            builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
            builder.Services.AddScoped<IHeaderRepository, HeaderRepository>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IPersonContactRepository, PersonContactRepository>();
            builder.Services.AddScoped<IPersonAddressRepository, PersonAddressRepository>();
            builder.Services.AddScoped<IPersonPrivateInfoRepository, PersonPrivateInfoRepository>();

            builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
            builder.Services.AddScoped<IStateRepository, StateRepository>();
            builder.Services.AddScoped<ITalukaRepository, TalukaRepository>();
            builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
            
            builder.Services.AddScoped<ICommonService, CommonService>();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
