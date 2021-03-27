using System;
using System.Threading.Tasks;
using System.Transactions;


namespace Application.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangesAsync(TransactionScopeOption required = TransactionScopeOption.Required, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
    }
}
