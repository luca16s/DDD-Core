using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GianLuca.Domain.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        Task CommitTransactionAsync();
    }
}
