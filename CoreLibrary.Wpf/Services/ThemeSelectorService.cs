namespace CoreLibrary.Wpf.Services
{
    using ControlzEx.Theming;

    using CoreLibrary.Wpf.Contracts;
    using CoreLibrary.Wpf.Enums;

    using MahApps.Metro.Theming;

    using System;
    using System.Windows;

    public class ThemeSelectorService : IThemeSelectorService
    {
        private const string HcDarkTheme = "pack://application:,,,/Styles/Themes/HC.Dark.Blue.xaml";
        private const string HcLightTheme = "pack://application:,,,/Styles/Themes/HC.Light.Blue.xaml";

        public ThemeSelectorService()
        {
        }

        public EAppTheme GetCurrentTheme()
        {
            if (Application.Current.Properties.Contains("Theme"))
            {
                string themeName = Application.Current.Properties["Theme"].ToString();
                _ = Enum.TryParse(themeName, out EAppTheme theme);
                return theme;
            }

            return EAppTheme.Default;
        }

        public void InitializeTheme()
        {
            _ = ThemeManager.Current.AddLibraryTheme(new LibraryTheme(new Uri(HcDarkTheme), MahAppsLibraryThemeProvider.DefaultInstance));
            _ = ThemeManager.Current.AddLibraryTheme(new LibraryTheme(new Uri(HcLightTheme), MahAppsLibraryThemeProvider.DefaultInstance));

            EAppTheme theme = GetCurrentTheme();
            SetTheme(theme);
        }

        public void SetTheme(EAppTheme theme)
        {
            if (theme == EAppTheme.Default)
            {
                ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncAll;
                ThemeManager.Current.SyncTheme();
            }
            else
            {
                ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithHighContrast;
                ThemeManager.Current.SyncTheme();
                _ = ThemeManager.Current.ChangeTheme(Application.Current, $"{theme}.Blue", SystemParameters.HighContrast);
            }

            Application.Current.Properties["Theme"] = theme.ToString();
        }
    }
}