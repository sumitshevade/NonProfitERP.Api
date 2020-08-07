using PublicData.WebClient.Interfaces;
using PublicData.WebClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace PublicData.WebClient.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public PeopleService(HttpClient HttpClient, ILocalStorageService localStorage)
        {
            _httpClient = HttpClient;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<People>> Get()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return await _httpClient.GetJsonAsync<People[]>("/api/people");
            }

            return null;
        }

        public async Task<People> GetById(int id)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return await _httpClient.GetJsonAsync<People>($"/api/people/{id}");
            }

            return null;
        }

        public async Task<int> Add(People people)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return await _httpClient.PostJsonAsync<int>("/api/people", people);
            }

            return 0;
        }

        public async Task Update(People people)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                await _httpClient.PutJsonAsync("/api/people", people);
            }
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return await _httpClient.DeleteAsync($"/api/people/{id}");
            }

            return null;
        }
    }
}
