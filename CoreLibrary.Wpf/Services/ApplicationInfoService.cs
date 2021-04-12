namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Wpf.Contracts;

    using OSVersionHelper;

    using System;
    using System.Diagnostics;
    using System.Reflection;

    public class ApplicationInfoService : IApplicationInfoService
    {
        public ApplicationInfoService()
        {
        }

        public Version GetVersion()
        {
            if (WindowsVersionHelper.HasPackageIdentity)
            {
                return new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }

            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string version = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
            return new Version(version);
        }
    }
}