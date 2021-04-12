namespace CoreLibrary.Wpf.Contracts
{
    using CoreLibrary.Wpf.Enums;

    public interface IThemeSelectorService
    {
        void InitializeTheme();

        void SetTheme(EAppTheme theme);

        EAppTheme GetCurrentTheme();
    }
}