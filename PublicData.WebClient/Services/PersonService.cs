using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using PublicData.WebClient.Shared.Entities;

namespace PublicData.WebClient.Services
{
    public class PersonService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public PersonService(HttpClient HttpClient, ILocalStorageService localStorage)
        {
            _httpClient = HttpClient;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<Person>> Get()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return await _httpClient.GetJsonAsync<Person[]>("/api/people");
            }

            return null;
        }

        public async Task<Person> GetById(int id)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return await _httpClient.GetJsonAsync<Person>($"/api/people/{id}");
            }

            return null;
        }

        public async Task<int> Add(Person people)
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (token != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                return await _httpClient.PostJsonAsync<int>("/api/people", people);
            }

            return 0;
        }

        public async Task Update(Person people)
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
