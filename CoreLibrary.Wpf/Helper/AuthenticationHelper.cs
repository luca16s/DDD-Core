namespace CoreLibrary.Wpf.Helper
{
    using CoreLibrary.Enums;
    using CoreLibrary.Wpf.Properties;

    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;

    using System.Threading.Tasks;
    using System.Windows;

    internal static class AuthenticationHelper
    {
        internal static async Task ShowLoginErrorAsync(ELoginResultType loginResult)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            switch (loginResult)
            {
                case ELoginResultType.NoNetworkAvailable:
                    _ = await metroWindow.ShowMessageAsync(Resources.DialogNoNetworkAvailableContent, Resources.DialogAuthenticationTitle);
                    break;

                case ELoginResultType.UnknownError:
                    _ = await metroWindow.ShowMessageAsync(Resources.DialogAuthenticationTitle, Resources.DialogStatusUnknownErrorContent);
                    break;

                case ELoginResultType.Success:
                    break;

                case ELoginResultType.Unauthorized:
                    break;

                case ELoginResultType.CancelledByUser:
                    break;

                default:
                    break;
            }
        }
    }
}