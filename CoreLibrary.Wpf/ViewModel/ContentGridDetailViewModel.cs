namespace CoreLibrary.Wpf.ViewModel
{
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Contracts.ViewModels;

    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ContentGridDetailViewModel<T>
        where T : BaseViewModel, INavigationAware
    {
        private readonly IDataService<T> _dataService;
        private readonly T _itemSelected;

        public ContentGridDetailViewModel(IDataService<T> sampleDataService)
        {
            _dataService = sampleDataService;
        }

        public T Item
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

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is string Id)
            {
                IEnumerable<T> data = await _dataService.GetContentGridDataAsync();
                Item = data.First(i => i.Id == Id);
            }
        }
    }
}