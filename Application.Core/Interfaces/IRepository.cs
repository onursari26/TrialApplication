using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);

        T GetById(object id);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null);

        T Find(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null);

        Task<T> AddAsync(T entity);

        T Add(T entity);

        Task<T> UpdateAsync(T entity);

        T Update(T entity);

        Task DeleteAsync(T entity);

        void Delete(T entity);

        Task<T> DeleteAsync(object id);

        T Delete(object id);

        void DeleteRange(IEnumerable<T> entities);

        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);

        int Count(Expression<Func<T, bool>> filter = null);

        Task<IEnumerable<T>> PagingAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, object>>[] includes = null,
            int? page = null,
            int? pageSize = null);

        IEnumerable<T> Paging(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Expression<Func<T, object>>[] includes = null,
           int? page = null,
           int? pageSize = null);

        IQueryable<T> QueryFilter(Expression<Func<T, bool>> predicate);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);

        bool IsExist(Expression<Func<T, bool>> predicate);

        Task AddRangeAsync(IEnumerable<T> entities);

        void AddRange(IEnumerable<T> entities);
    }
}
