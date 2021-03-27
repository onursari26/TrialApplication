using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();

        Task<ICollection<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes = null);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> DeleteAsync(object id);

        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> Filter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, object>>[] includes = null,
            int? page = null,
            int? pageSize = null);

        IQueryable<T> QueryFilter(Expression<Func<T, bool>> predicate);

        bool IsExist(Expression<Func<T, bool>> predicate);

    }
}
