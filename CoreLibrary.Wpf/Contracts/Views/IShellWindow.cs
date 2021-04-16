namespace CoreLibrary.Wpf.Contracts.Views
{
    using System.Windows.Controls;

    public interface IShellWindow
    {
        void CloseWindow();

        Frame GetNavigationFrame();

        void ShowWindow();
    }
}