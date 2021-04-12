namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Wpf.Contracts;

    using System.Diagnostics;

    public class SystemService : ISystemService
    {
        public SystemService()
        {
        }

        public static void OpenInWebBrowser(string url)
        {
            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            _ = Process.Start(psi);
        }
    }
}