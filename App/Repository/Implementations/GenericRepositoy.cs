using App.Models;
using App.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repository.Implementations
{
    public class GenericRepositoy<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _tEntity;

        public GenericRepositoy(DbContext context)
        {
            _context = context;
            _tEntity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _tEntity.Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _tEntity.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _tEntity.ToListAsync();
        }

        public SelectList GetDropDown(string dataValueField, string dataTextField)
        {
            return new SelectList(_tEntity, dataValueField, dataTextField);
        }

        public async Task<EntityState> PostAsync(T entity)
        {
            var result = _tEntity.Add(entity).State;
            await Save();
            return await Task.FromResult(result);
        }

        public async Task<EntityState> UpdateAsync(int id, T entity, List<string> propToIgnore)
        {
            //var record = await GetAsync(id);
            if (entity != null)
            {
                //_tEntity.Attach(entity);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;

                foreach (var property in propToIgnore)
                {
                    entry.Property(property).IsModified = false;
                }

                await Save();
                return await Task.FromResult(entry.State);
            }

            return EntityState.Detached;
        }

        public async Task<EntityState> DeleteAsync(int id)
        {
            var record = await GetAsync(id);
            if (record != null)
            {
                _tEntity.Attach(record);
                var result = _tEntity.Remove(record).State;
                await Save();
                return await Task.FromResult(result);
            }

            return EntityState.Detached;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
