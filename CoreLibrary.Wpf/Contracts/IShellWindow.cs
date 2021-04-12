namespace CoreLibrary.Wpf.Contracts
{
    using System.Windows.Controls;

    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        void ShowWindow();

        void CloseWindow();
    }
}