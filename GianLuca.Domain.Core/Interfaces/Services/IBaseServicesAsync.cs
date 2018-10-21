using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeadFishStudio.Domain.Core.Entity;

namespace DeadFishStudio.Domain.Core.Interfaces.Services
{
    public interface IBaseServicesAsync<T> where T : BaseEntity
    {
        Task<T> AddItemAsync(T item);
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetAllItemsAsync();
        T UpdateItem(Guid id, T item);
        void DeleteItem(T item);
    }
}
