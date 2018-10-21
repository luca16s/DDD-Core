using System;
using System.Collections.Generic;
using DeadFishStudio.Domain.Core.Entity;

namespace DeadFishStudio.Domain.Core.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T AddItem(T item);
        T GetItem(Guid id);
        IEnumerable<T> GetAllItems();
        T UpdateItem(Guid id, T item);
        void DeleteItem(T item);
    }
}
