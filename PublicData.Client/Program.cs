using System;
using Blazored.Toast;
using System.Net.Http;
using Blazored.LocalStorage;
using PublicData.Client.Core;
using System.Threading.Tasks;
using PublicData.Client.Services;
using PublicData.Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace PublicData.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44304/") });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast();
            builder.Services.AddAuthorizationCore();
            //builder.Services.AddAutoMapper(typeof(AssetRequestAllocationProfile));
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPeopleService, PeopleService>();

            await builder.Build().RunAsync();
        }
    }
}
