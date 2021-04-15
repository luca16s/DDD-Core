namespace CoreLibrary.Wpf.Contracts
{
    public interface INavigationAware
    {
        void OnNavigatedFrom();

        void OnNavigatedTo(object parameter);
    }
}