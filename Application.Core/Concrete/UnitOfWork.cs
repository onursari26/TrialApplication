using Microsoft.EntityFrameworkCore;
using Application.Core.Interfaces;
using Application.Data.Entities.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Application.Utility.StaticMethods;

namespace Application.Core.Concrete
{
    public class UnitOfWork<T> : IUnitOfWork, IDisposable where T : DbContext
    {
        private readonly T _dbContext;

        public UnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }

        private bool disposed = false;
        protected virtual void Disposed(bool disposing)
        {
            if (!disposed && disposing)
            {
                _dbContext.Dispose();
            }

            disposed = true;
        }
        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync(TransactionScopeOption required = TransactionScopeOption.Required,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            using (TransactionScope transactionScope = new(required, new TransactionOptions { IsolationLevel = isolationLevel }, TransactionScopeAsyncFlowOption.Enabled))
            {
                var entities = _dbContext.ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((Entity)entity.Entity).CreatedDate = DateTime.Now;
                        ((Entity)entity.Entity).CreatedBy = CurrentUser.GetCurrentUserName();
                    }

                    ((Entity)entity.Entity).ModifiedDate = DateTime.Now;
                    ((Entity)entity.Entity).ModifiedBy = CurrentUser.GetCurrentUserName();
                }

                var saveChangeResponse = await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                transactionScope.Complete();

                return saveChangeResponse;
            }
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_dbContext);
        }
    }
}
