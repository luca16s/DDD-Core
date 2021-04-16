namespace CoreLibrary.Wpf.ViewModel
{
    using CoreLibrary.Enums;
    using CoreLibrary.Wpf.Commands;
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Contracts.ViewModels;
    using CoreLibrary.Wpf.Enums;
    using CoreLibrary.Wpf.Helper;
    using CoreLibrary.Wpf.Models;

    using Microsoft.Extensions.Options;

    using System;
    using System.Windows.Input;

    public class SettingsViewModel : BaseViewModel, INavigationAware
    {
        private readonly AppConfig _appConfig;
        private readonly IApplicationInfoService _applicationInfoService;
        private readonly IIdentityService _identityService;
        private readonly ISystemService _systemService;
        private readonly IThemeSelectorService _themeSelectorService;
        private readonly IUserDataService _userDataService;
        private bool _isBusy;
        private bool _isLoggedIn;
        private RelayCommand _logInCommand;
        private RelayCommand _logOutCommand;
        private ICommand _privacyStatementCommand;
        private ICommand _setThemeCommand;
        private EAppTheme _theme;
        private BaseUserViewModel _user;
        private string _versionDescription;

        public SettingsViewModel(IOptions<AppConfig> appConfig,
            IThemeSelectorService themeSelectorService,
            ISystemService systemService,
            IApplicationInfoService applicationInfoService,
            IUserDataService userDataService,
            IIdentityService identityService)
        {
            _appConfig = appConfig.Value;
            _themeSelectorService = themeSelectorService;
            _systemService = systemService;
            _applicationInfoService = applicationInfoService;
            _userDataService = userDataService;
            _identityService = identityService;
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                Set(ref _isBusy, value);
                LogInCommand.OnCanExecuteChanged();
                LogOutCommand.OnCanExecuteChanged();
            }
        }

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => Set(ref _isLoggedIn, value);
        }

        public RelayCommand LogInCommand => _logInCommand ??= new RelayCommand(OnLogIn, () => !IsBusy);

        public RelayCommand LogOutCommand => _logOutCommand ??= new RelayCommand(OnLogOut, () => !IsBusy);

        public ICommand PrivacyStatementCommand => _privacyStatementCommand ??= new RelayCommand(OnPrivacyStatement);

        public ICommand SetThemeCommand => _setThemeCommand ??= new RelayCommandGeneric<string>(OnSetTheme);

        public EAppTheme Theme
        {
            get => _theme;
            set => Set(ref _theme, value);
        }

        public BaseUserViewModel User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public string VersionDescription
        {
            get => _versionDescription;
            set => Set(ref _versionDescription, value);
        }

        public void OnNavigatedFrom()
        {
            UnregisterEvents();
        }

        public void OnNavigatedTo(object parameter)
        {
            VersionDescription = $"NavigationPaneProject - {_applicationInfoService.GetVersion()}";
            Theme = _themeSelectorService.GetCurrentTheme();
            _identityService.LoggedIn += OnLoggedIn;
            _identityService.LoggedOut += OnLoggedOut;
            IsLoggedIn = _identityService.IsLoggedIn();
            _userDataService.UserDataUpdated += OnUserDataUpdated;
            User = _userDataService.GetUser();
        }

        private void OnLoggedIn(object sender, EventArgs e)
        {
            IsLoggedIn = true;
            IsBusy = false;
        }

        private void OnLoggedOut(object sender, EventArgs e)
        {
            User = null;
            IsLoggedIn = false;
            IsBusy = false;
        }

        private async void OnLogIn()
        {
            IsBusy = true;
            ELoginResultType loginResult = await _identityService.LoginAsync();
            if (loginResult != ELoginResultType.Success)
            {
                await AuthenticationHelper.ShowLoginErrorAsync(loginResult);
                IsBusy = false;
            }
        }

        private async void OnLogOut()
        {
            await _identityService.LogoutAsync();
        }

        private void OnPrivacyStatement()
        {
            _systemService.OpenInWebBrowser(_appConfig.PrivacyStatement);
        }

        private void OnSetTheme(string themeName)
        {
            var theme = (EAppTheme)Enum.Parse(typeof(EAppTheme), themeName);
            _themeSelectorService.SetTheme(theme);
        }

        private void OnUserDataUpdated(object sender, BaseUserViewModel userData)
        {
            User = userData;
        }

        private void UnregisterEvents()
        {
            _identityService.LoggedIn -= OnLoggedIn;
            _identityService.LoggedOut -= OnLoggedOut;
            _userDataService.UserDataUpdated -= OnUserDataUpdated;
        }
    }
}