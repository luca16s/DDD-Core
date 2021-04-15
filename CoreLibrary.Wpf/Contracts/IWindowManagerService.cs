namespace CoreLibrary.Wpf.Contracts
{
    using System.Windows;

    public interface IWindowManagerService
    {
        Window MainWindow { get; }

        Window GetWindow(string pageKey);

        bool? OpenInDialog(string pageKey, object parameter = null);

        void OpenInNewWindow(string pageKey, object parameter = null);
    }
}