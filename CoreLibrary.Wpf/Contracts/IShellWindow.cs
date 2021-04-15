namespace CoreLibrary.Wpf.Contracts
{
    using System.Windows.Controls;

    public interface IShellWindow
    {
        void CloseWindow();

        Frame GetNavigationFrame();

        void ShowWindow();
    }
}