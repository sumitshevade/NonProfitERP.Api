using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IHeaderService
    {
        /// <summary>
        /// Returns record by id.
        /// </summary>
        Task<Header> GetAsync(int Id);

        /// <summary>
        /// Returns all records with deleted.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Header>> GetAllAsync();

        /// <summary>
        /// Returns the record by finding by predicate.
        /// </summary>
        Task<IEnumerable<Header>> FindAsync();

        /// <summary>
        /// Returns dropdown (select) list.
        /// </summary>
        SelectList GetDropDown(string dataValueField, string dataTextField);

        /// <summary>
        /// Create new record.
        /// </summary>
        Task PostAsync(Header header, ClaimsPrincipal user);

        /// <summary>
        /// Update the records.
        /// </summary>
        Task UpdateAsync(int Id, Header header, ClaimsPrincipal user);

        /// <summary>
        /// Soft delete the record.
        /// </summary>
        Task DeleteAsync(int Id, ClaimsPrincipal user);

        /// <summary>
        /// Delete the record.
        /// </summary>
        Task HardDeleteAsync(int Id);
    }
}
