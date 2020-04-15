using App.Models;
using App.Repository.Contracts;
using App.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Services.Implementations
{
    /// <summary>
    /// Middleware of Repository and Controller.
    /// </summary>
    public class HeaderService : IHeaderService
    {
        private readonly IHeaderRepository _headerRepository;

        public HeaderService(IHeaderRepository HeaderRepository)
        {
            _headerRepository = HeaderRepository;
        }

        public async Task<IEnumerable<Header>> FindAsync()
        {
            return await _headerRepository.FindAsync(x => x.DeletedById == null);
        }

        public async Task<Header> GetAsync(int id)
        {
            // implement if that record not found
            return await _headerRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Header>> GetAllAsync()
        {
            return await _headerRepository.GetAllAsync();
        }

        public SelectList GetDropDown(string dataValueField, string dataTextField)
        {
            return _headerRepository.GetDropDown(dataValueField, dataTextField);
        }

        public async Task PostAsync(Header header, ClaimsPrincipal user)
        {
            header.CreatedAt = DateTime.Now;
            header.CreatedById = user.FindFirstValue(ClaimTypes.NameIdentifier);

            await _headerRepository.PostAsync(header);
        }

        public async Task UpdateAsync(int id, Header header, ClaimsPrincipal user)
        {
            var propToIgnore = new List<string> { "Id", "CreatedAt", "CreatedById", "DeletedById", "DeletedAt" };

            header.UpdatedAt = DateTime.Now;
            header.UpdatedById = user.FindFirstValue(ClaimTypes.NameIdentifier);

            await _headerRepository.UpdateAsync(id, header, propToIgnore);
        }

        public async Task DeleteAsync(int id, ClaimsPrincipal user)
        {
            var propToIgnore = new List<string> { "Id", "Title", "CreatedAt", "CreatedById", "UpdatedById", "UpdatedAt" };
            var header = await _headerRepository.GetAsync(id);

            header.DeletedById = user.FindFirstValue(ClaimTypes.NameIdentifier);
            header.DeletedAt = DateTime.Now;

            // soft delete record
            await _headerRepository.UpdateAsync(id, header, propToIgnore);
        }

        public async Task HardDeleteAsync(int id)
        {
            await _headerRepository.DeleteAsync(id);
        }
    }
}
