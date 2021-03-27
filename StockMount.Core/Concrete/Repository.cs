using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Application.Core.Extensions;
using Application.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Core.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = _context.Set<TEntity>();

                return _dbSet;
            }
        }

        public IQueryable<TEntity> Query()
        {
            return Entities.AsQueryable();
        }

        public IQueryable<TEntity> QueryFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await Entities.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] includes = null)
        {
            return await Entities.AsQueryable().Includes(includes).FirstOrDefaultAsync(predicate);
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] includes = null)
        {
            return await Entities.Where(predicate).Includes(includes).ToListAsync();
        }

        private IQueryable<TEntity> Includes(IQueryable<TEntity> query, Expression<Func<TEntity, object>>[] includes = null)
        {
            if (includes == null)
                return query;

            return includes.Aggregate(query, (query, path) => query.Include(path));
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await Entities.AddAsync(entity)).Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                return null;

            foreach (var property in _context.Entry(entity).Properties)
            {
                if (property.OriginalValue != null && !property.OriginalValue.Equals(property.CurrentValue))
                    property.IsModified = true;
            }

            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            EntityEntry entityEntry = _context.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                Entities.Attach(entity);
                Entities.Remove(entity);
            }
        }

        public async Task<TEntity> DeleteAsync(object id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return null;

            EntityEntry entityEntry = _context.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                Entities.Attach(entity);
                Entities.Remove(entity);
            }

            return entity;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return await Entities.CountAsync(filter);

            return await Entities.CountAsync();
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>>[] includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = Entities.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (includes != null)
                query = query.Includes(includes);

            if (page != null && pageSize != null)
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return query.ToList();
        }

        public bool IsExist(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Any(predicate);
        }
    }
}
