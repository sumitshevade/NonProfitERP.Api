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
using PublicData.WebClient.Components;
using PublicData.WebClient.Repository;

namespace PublicData.WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44333/") });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredToast();
            //builder.Services.AddAutoMapper(typeof(AssetRequestAllocationProfile));
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IDetailRepository, DetailRepository>();
            builder.Services.AddScoped<IHeaderRepository, HeaderRepository>();
            builder.Services.AddScoped<IDivisionRepository, DivisionRepository>();
            builder.Services.AddScoped<ICommonService, CommonService>();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
