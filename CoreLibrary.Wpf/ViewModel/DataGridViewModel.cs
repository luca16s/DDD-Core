namespace CoreLibrary.Wpf.ViewModel
{
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Contracts.ViewModels;

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class DataGridViewModel<T>
        where T : BaseViewModel, INavigationAware
    {
        private readonly IDataService<T> _dataService;

        public DataGridViewModel(IDataService<T> sampleDataService)
        {
            _dataService = sampleDataService;
        }

        public ObservableCollection<T> Source { get; } = new ObservableCollection<T>();

        public void OnNavigatedFrom()
        {
        }

        public async void OnNavigatedTo(object parameter)
        {
            if (parameter is null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            Source.Clear();

            IEnumerable<T> data = await _dataService.GetGridDataAsync();

            foreach (T item in data)
            {
                Source.Add(item);
            }
        }
    }
}