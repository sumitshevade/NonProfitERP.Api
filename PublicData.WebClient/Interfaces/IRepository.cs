using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PublicData.WebClient.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void SetToken(string token);
        Task<int> AddAsync(TEntity obj, string url);
        Task<TEntity> GetByIdAsync(string url);
        Task<IList<TEntity>> GetListAsync(string url);
        Task<bool> UpdateAsync(TEntity obj, string url);
        Task<bool> RemoveAsync(string url);
    }
}
