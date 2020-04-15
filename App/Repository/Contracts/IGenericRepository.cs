using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repository.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Returns record by id.
        /// </summary>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Returns all records with deleted.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Returns the record by finding by predicate.
        /// </summary>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Returns dropdown (select) list.
        /// </summary>
        SelectList GetDropDown(string dataValueField, string dataTextField);

        /// <summary>
        /// Creates the record.
        /// </summary>
        Task<EntityState> PostAsync(T entity);

        /// <summary>
        /// Updates the record.
        /// </summary>
        Task<EntityState> UpdateAsync(int id, T entity, List<string> propToIgnore);

        /// <summary>
        /// Deletes the record.
        /// </summary>
        Task<EntityState> DeleteAsync(int id);

        Task Save();
    }
}
