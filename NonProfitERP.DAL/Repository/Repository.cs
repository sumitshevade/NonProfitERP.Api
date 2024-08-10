using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NonProfitERP.Common.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace NonProfitERP.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly PublicDataContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(PublicDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();
            return query.FirstOrDefault();
        }

        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).SingleOrDefault();
            return query.SingleOrDefault();
        }

        public virtual IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            int index = 0,
            int size = 20,
            bool disableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query);
            return query;
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
