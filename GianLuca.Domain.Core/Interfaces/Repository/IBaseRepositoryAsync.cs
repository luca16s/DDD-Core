using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GianLuca.Domain.Core.Entity;

namespace GianLuca.Domain.Core.Interfaces.Repository
{
    public interface IBaseRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> AddItemAsync(T item);
        Task<T> GetItemAsync(Guid id);
        Task<IEnumerable<T>> GetAllItemsAsync();
        T UpdateItem(Guid id, T item);
        void DeleteItem(T item);
    }
}
