using Blazored.LocalStorage;
using PublicData.WebClient.Core;
using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PublicData.WebClient.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<AccountResult> Register(RegisterModel registerModel)
        {
            var result = await _httpClient.PostJsonAsync<AccountResult>("api/account/register", registerModel);
            return result;
        }

        public async Task<AccountResult> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostJsonAsync<AccountResult>("api/account/login", loginModel);

            if (!response.Successful)
            {
                return response;
            }

            await _localStorage.SetItemAsync("authToken", response.Token);
            await _localStorage.SetItemAsync("userId", response.UserId);
            await _localStorage.SetItemAsync("roles", response.Roles);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(response);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

            return response;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                await _httpClient.PostJsonAsync("/api/account/changepassword", changePasswordModel);
            }
        }
    }
}
