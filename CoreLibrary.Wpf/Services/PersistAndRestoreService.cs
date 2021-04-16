namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Interfaces.Services;
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Models;

    using Microsoft.Extensions.Options;

    using System;
    using System.Collections;
    using System.IO;
    using System.Windows;

    public class PersistAndRestoreService : IPersistAndRestoreService
    {
        private readonly AppConfig _appConfig;
        private readonly IFileService _fileService;
        private readonly string _localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public PersistAndRestoreService(IFileService fileService, IOptions<AppConfig> appConfig)
        {
            _fileService = fileService;
            _appConfig = appConfig.Value;
        }

        public void PersistData()
        {
            if (Application.Current.Properties != null)
            {
                string folderPath = Path.Combine(_localAppData, _appConfig.ConfigurationsFolder);
                string fileName = _appConfig.AppPropertiesFileName;
                _fileService.Save(folderPath, fileName, Application.Current.Properties);
            }
        }

        public void RestoreData()
        {
            string folderPath = Path.Combine(_localAppData, _appConfig.ConfigurationsFolder);
            string fileName = _appConfig.AppPropertiesFileName;
            IDictionary properties = _fileService.Read<IDictionary>(folderPath, fileName);
            if (properties != null)
            {
                foreach (DictionaryEntry property in properties)
                {
                    Application.Current.Properties.Add(property.Key, property.Value);
                }
            }
        }
    }
}