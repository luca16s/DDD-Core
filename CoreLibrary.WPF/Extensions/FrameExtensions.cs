namespace CoreLibrary.Wpf.Extensions
{
    using System.Windows;
    using System.Windows.Controls;

    public static class FrameExtensions
    {
        public static void CleanNavigation(this Frame frame)
        {
            while (frame.CanGoBack)
            {
                _ = frame.RemoveBackEntry();
            }
        }

        public static object GetDataContext(this Frame frame)
        {
            return frame.Content is FrameworkElement element
                ? element.DataContext
                : null;
        }
    }
}