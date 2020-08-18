using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using PublicData.WebClient.Interfaces;

namespace PublicData.WebClient.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly HttpClient _httpClient;

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }

        public async virtual Task<int> AddAsync(TEntity obj, string url)
        {
            return await _httpClient.PostJsonAsync<int>(url, obj);
        }

        public async virtual Task<TEntity> GetByIdAsync(string url)
        {
            return await _httpClient.GetJsonAsync<TEntity>(url);
        }

        public async virtual Task<IList<TEntity>> GetListAsync(string url)
        {
            return await _httpClient.GetJsonAsync<IList<TEntity>>(url);
        }

        public async virtual Task<bool> UpdateAsync(TEntity obj, string url)
        {
            return await _httpClient.PutJsonAsync<bool>(url, obj);
        }

        public async virtual Task<bool> RemoveAsync(string url)
        {
            return await _httpClient.SendJsonAsync<bool>(HttpMethod.Delete, url, null);
        }

        public async virtual Task<IList<TEntity>> SearchAsync(TEntity obj, string url)
        {
            return await _httpClient.SendJsonAsync<IList<TEntity>>(HttpMethod.Post, url, obj);
        }
    }
}
