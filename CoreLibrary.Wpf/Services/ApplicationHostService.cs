namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Contracts.Views;
    using CoreLibrary.Wpf.Models;
    using CoreLibrary.Wpf.ViewModel;

    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    public class ApplicationHostService : IHostedService
    {
        private readonly AppConfig _appConfig;
        private readonly IIdentityService _identityService;
        private readonly INavigationService _navigationService;
        private readonly IPersistAndRestoreService _persistAndRestoreService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IThemeSelectorService _themeSelectorService;
        private readonly IUserDataService _userDataService;
        private IShellWindow _shellWindow;

        public ApplicationHostService(IServiceProvider serviceProvider,
            INavigationService navigationService,
            IThemeSelectorService themeSelectorService,
            IPersistAndRestoreService persistAndRestoreService,
            IIdentityService identityService,
            IUserDataService userDataService,
            IOptions<AppConfig> config)
        {
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
            _themeSelectorService = themeSelectorService;
            _persistAndRestoreService = persistAndRestoreService;
            _identityService = identityService;
            _userDataService = userDataService;
            _appConfig = config.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await InitializeAsync();

            _identityService.InitializeWithAadAndPersonalMsAccounts(_appConfig.SelectedSecret.AppKey, "http://localhost");
            _ = await _identityService.AcquireTokenSilentAsync();

            await HandleActivationAsync();

            await StartupAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _persistAndRestoreService.PersistData();
            await Task.CompletedTask;
        }

        private static async Task StartupAsync()
        {
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync()
        {
            if (!Application.Current.Windows.OfType<IShellWindow>().Any())
            {
                // Default activation that navigates to the apps default page
                _shellWindow = _serviceProvider.GetService(typeof(IShellWindow)) as IShellWindow;
                _navigationService.Initialize(_shellWindow.GetNavigationFrame());
                _shellWindow.ShowWindow();
                _ = _navigationService.NavigateTo(typeof(BaseViewModel).FullName);
                await Task.CompletedTask;
            }
        }

        private async Task InitializeAsync()
        {
            _persistAndRestoreService.RestoreData();
            _themeSelectorService.InitializeTheme();
            await Task.CompletedTask;
            _userDataService.Initialize();
        }
    }
}