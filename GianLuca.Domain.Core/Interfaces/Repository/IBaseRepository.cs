using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GianLuca.Domain.Core.Entity;

namespace GianLuca.Domain.Core.Interfaces.Repository
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
