namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Interfaces.Services;
    using CoreLibrary.Models;
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Helper;
    using CoreLibrary.Wpf.Models;
    using CoreLibrary.Wpf.ViewModel;

    using Microsoft.Extensions.Options;

    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class UserDataService : IUserDataService
    {
        private readonly AppConfig _appConfig;
        private readonly IFileService _fileService;
        private readonly IIdentityService _identityService;
        private readonly string _localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly IMicrosoftGraphService _microsoftGraphService;
        private BaseUserViewModel _user;

        public UserDataService(IFileService fileService,
            IIdentityService identityService,
            IMicrosoftGraphService microsoftGraphService,
            IOptions<AppConfig> appConfig)
        {
            _fileService = fileService;
            _identityService = identityService;
            _microsoftGraphService = microsoftGraphService;
            _appConfig = appConfig.Value;
        }

        public event EventHandler<BaseUserViewModel> UserDataUpdated;

        public BaseUserViewModel GetUser()
        {
            if (_user == null)
            {
                _user = GetUserFromCache();
                if (_user == null)
                {
                    _user = GetDefaultUserData();
                }
            }

            return _user;
        }

        public void Initialize()
        {
            _identityService.LoggedIn += OnLoggedIn;
            _identityService.LoggedOut += OnLoggedOut;
        }

        private static BaseUserViewModel GetUserViewModelFromData(UserModel userData)
        {
            if (userData == null)
            {
                return null;
            }

            System.Windows.Media.Imaging.BitmapImage userPhoto = string.IsNullOrEmpty(userData.Photo)
                ? ImageHelper.ImageFromAssetsFile("DefaultIcon.png")
                : ImageHelper.ImageFromString(userData.Photo);

            return new BaseUserViewModel()
            {
                Name = userData.DisplayName,
                UserPrincipalName = userData.UserPrincipalName,
                Photo = userPhoto
            };
        }

        private BaseUserViewModel GetDefaultUserData()
        {
            return new BaseUserViewModel()
            {
                Name = _identityService.GetAccountUserName(),
                Photo = ImageHelper.ImageFromAssetsFile("DefaultIcon.png")
            };
        }

        private BaseUserViewModel GetUserFromCache()
        {
            string folderPath = Path.Combine(_localAppData, _appConfig.ConfigurationsFolder);
            string fileName = _appConfig.UserFileName;
            UserModel cacheData = _fileService.Read<UserModel>(folderPath, fileName);
            return GetUserViewModelFromData(cacheData);
        }

        private async Task<BaseUserViewModel> GetUserFromGraphApiAsync()
        {
            string accessToken = await _identityService.GetAccessTokenForGraphAsync();
            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }

            UserModel userData = await _microsoftGraphService.GetUserInfoAsync(accessToken);
            if (userData != null)
            {
                userData.Photo = await _microsoftGraphService.GetUserPhoto(accessToken);
                string folderPath = Path.Combine(_localAppData, _appConfig.ConfigurationsFolder);
                string fileName = _appConfig.UserFileName;
                _fileService.Save(folderPath, fileName, userData);
            }

            return GetUserViewModelFromData(userData);
        }

        private async void OnLoggedIn(object sender, EventArgs e)
        {
            _user = await GetUserFromGraphApiAsync();
            UserDataUpdated?.Invoke(this, _user);
        }

        private void OnLoggedOut(object sender, EventArgs e)
        {
            _user = null;
            string folderPath = Path.Combine(_localAppData, _appConfig.ConfigurationsFolder);
            string fileName = _appConfig.UserFileName;
            _fileService.Save<UserModel>(folderPath, fileName, null);
        }
    }
}