namespace CoreLibrary.Wpf.Contracts
{
    using CoreLibrary.Wpf.Enums;

    public interface IThemeSelectorService
    {
        EAppTheme GetCurrentTheme();

        void InitializeTheme();

        void SetTheme(EAppTheme theme);
    }
}