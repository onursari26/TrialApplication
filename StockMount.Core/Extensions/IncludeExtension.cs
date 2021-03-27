using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Core.Extensions
{
    public static class IncludeExtension
    {
        public static IQueryable<TEntity> Includes<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes == null)
                return query;

            return includes.Aggregate(query, (query, path) => query.Include(path));
        }
    }
}
