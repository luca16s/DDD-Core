namespace CoreLibrary.Wpf.Extensions
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public static class WindowExtensions
    {
        public static object GetDataContext(this Window window)
        {
            return window.Content is Frame frame
                ? frame.GetDataContext()
                : null;
        }

        public static bool IsWindowOpen(this Window window)
        {
            string name = window.Name;

            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<Window>()
                                            .Any()
               : Application.Current.Windows.OfType<Window>()
                                            .Any(w => string.Equals(w?.Name,
                                                                    name,
                                                                    StringComparison.OrdinalIgnoreCase));
        }
    }
}