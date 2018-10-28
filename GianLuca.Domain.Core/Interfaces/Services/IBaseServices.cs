using System;
using System.Collections.Generic;
using GianLuca.Domain.Core.Entity;

namespace GianLuca.Domain.Core.Interfaces.Services
{
    public interface IBaseServices<T> where T : BaseEntity
    {
        T AddItem(T item);
        T GetItem(Guid id);
        IEnumerable<T> GetAllItems();
        T UpdateItem(Guid id, T item);
        void DeleteItem(T item);
    }
}
