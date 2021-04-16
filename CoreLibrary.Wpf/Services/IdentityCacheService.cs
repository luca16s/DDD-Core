namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Wpf.Contracts.Services;

    using System;
    using System.IO;
    using System.Reflection;
    using System.Security.Cryptography;

    public class IdentityCacheService : IIdentityCacheService
    {
        public const string MsalCacheFileName = ".msalcache.bin3";
        public static readonly string MsalCacheFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\{Assembly.GetExecutingAssembly().GetName().Name}";
        private readonly object _fileLock = new();

        public byte[] ReadMsalToken()
        {
            lock (_fileLock)
            {
                string filePath = Path.Combine(MsalCacheFilePath, MsalCacheFileName);
                if (File.Exists(filePath))
                {
                    byte[] encryptedData = File.ReadAllBytes(filePath);
                    return ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                }

                return default;
            }
        }

        public void SaveMsalToken(byte[] token)
        {
            lock (_fileLock)
            {
                if (!Directory.Exists(MsalCacheFilePath))
                {
                    _ = Directory.CreateDirectory(MsalCacheFilePath);
                }

                byte[] encryptedData = ProtectedData.Protect(token, null, DataProtectionScope.CurrentUser);
                string filePath = Path.Combine(MsalCacheFilePath, MsalCacheFileName);
                File.WriteAllBytes(filePath, encryptedData);
            }
        }
    }
}