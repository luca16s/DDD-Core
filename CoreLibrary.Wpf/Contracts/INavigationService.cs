namespace CoreLibrary.Wpf.Contracts
{
    using System;
    using System.Windows.Controls;

    public interface INavigationService
    {
        event EventHandler<string> Navigated;

        bool CanGoBack { get; }

        void CleanNavigation();

        void GoBack();

        void Initialize(Frame shellFrame);

        bool NavigateTo(string pageKey, object parameter = null, bool clearNavigation = false);

        void UnsubscribeNavigation();
    }
}