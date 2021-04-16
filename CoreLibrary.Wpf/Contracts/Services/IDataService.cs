namespace CoreLibrary.Wpf.Contracts.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetContentGridDataAsync();

        Task<IEnumerable<T>> GetGridDataAsync();

        Task<IEnumerable<T>> GetMasterDetailDataAsync();
    }
}