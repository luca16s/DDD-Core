namespace CoreLibrary.Wpf.ViewModel
{
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Contracts.ViewModels;

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;

    public class MasterDetailViewModel<T>
        where T : BaseViewModel, INavigationAware
    {
        private readonly IDataService<T> _dataService;
        private readonly T _itemSelected;

        public MasterDetailViewModel(IDataService<T> sampleDataService)
        {
            _dataService = sampleDataService;
        }

        public ObservableCollection<T> Items { get; private set; } = new ObservableCollection<T>();

        public T Selected
        {
            get => _itemSelected;
            set
            {
                MethodInfo method = typeof(BaseViewModel).GetMethod(nameof(BaseViewModel.Set));
                MethodInfo generic = method.MakeGenericMethod(typeof(BaseViewModel));
                _ = generic.Invoke(this, null);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        public async void OnNavigatedTo(object _)
        {
            Items.Clear();

            IEnumerable<T> data = await _dataService.GetMasterDetailDataAsync();

            foreach (T item in data)
            {
                Items.Add(item);
            }

            Selected = Items.First();
        }
    }
}