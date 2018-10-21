using System;
using System.Threading.Tasks;

namespace DeadFishStudio.Domain.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        Task CommitTransactionAsync();
    }
}
