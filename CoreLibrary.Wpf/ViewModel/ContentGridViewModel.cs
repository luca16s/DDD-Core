namespace CoreLibrary.Wpf.ViewModel
{
    using CoreLibrary.Wpf.Commands;
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Contracts.ViewModels;

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class ContentGridViewModel<T> where T : BaseViewModel, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService<T> _sampleDataService;
        private ICommand _navigateToDetailCommand;

        public ContentGridViewModel(IDataService<T> sampleDataService, INavigationService navigationService)
        {
            _sampleDataService = sampleDataService;
            _navigationService = navigationService;
        }

        public ICommand NavigateToDetailCommand => _navigateToDetailCommand ??= new RelayCommandGeneric<T>(NavigateToDetail);

        public ObservableCollection<T> Source { get; } = new ObservableCollection<T>();

        public void OnNavigatedFrom()
        {
        }

        public async void OnNavigatedTo(object _)
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            IEnumerable<T> data = await _sampleDataService.GetContentGridDataAsync();
            foreach (T item in data)
            {
                Source.Add(item);
            }
        }

        private void NavigateToDetail(T item)
        {
            _ = _navigationService.NavigateTo(typeof(ContentGridDetailViewModel<T>).FullName, item.Id);
        }
    }
}