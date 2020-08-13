using System.Net.Http;
using System.Threading.Tasks;
using PublicData.WebClient.Models;
using PublicData.WebClient.Interfaces;
using Microsoft.AspNetCore.Components;

namespace PublicData.WebClient.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AccountResult> RegisterUserAsync(RegisterModel request)
        {
            var response = await _httpClient.PostJsonAsync<AccountResult>("api/auth/register", request);
            return response;
        }

        public async Task<AccountResult> LoginUserAsync(LoginModel request)
        {
            var response = await _httpClient.PostJsonAsync<AccountResult>("api/auth/login", request);
            return response;
        }

        //public async Task ChangePassword(ChangePasswordModel changePasswordModel)
        //{
        //    var token = await _localStorage.GetItemAsync<string>("authToken");

        //    if (token != null)
        //    {
        //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        //        await _httpClient.PostJsonAsync("/api/account/changepassword", changePasswordModel);
        //    }
        //}
    }
}
