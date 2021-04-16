namespace CoreLibrary.Wpf.ViewModel
{
    using CoreLibrary.Enums;
    using CoreLibrary.Wpf.Commands;
    using CoreLibrary.Wpf.Contracts.Services;
    using CoreLibrary.Wpf.Helper;
    using CoreLibrary.Wpf.Properties;

    using MahApps.Metro.Controls;

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class ShellViewModel : BaseViewModel
    {
        private readonly IIdentityService _identityService;
        private readonly ObservableCollection<HamburgerMenuItem> _menuItens = new();
        private readonly INavigationService _navigationService;
        private readonly IUserDataService _userDataService;
        private RelayCommand _goBackCommand;
        private bool _isAuthorized;
        private bool _isBusy;
        private bool _isLoggedIn;
        private ICommand _loadedCommand;
        private ICommand _menuItemInvokedCommand;
        private ICommand _optionsMenuItemInvokedCommand;
        private HamburgerMenuItem _selectedMenuItem;
        private HamburgerMenuItem _selectedOptionsMenuItem;
        private ICommand _unloadedCommand;

        public ShellViewModel(INavigationService navigationService,
            IIdentityService identityService,
            IUserDataService userDataService)
        {
            _navigationService = navigationService;
            _identityService = identityService;
            _userDataService = userDataService;
            _identityService.LoggedIn += OnLoggedIn;
            _identityService.LoggedOut += OnLoggedOut;
            _userDataService.UserDataUpdated += OnUserDataUpdated;
        }

        public RelayCommand GoBackCommand => _goBackCommand ??= new RelayCommand(OnGoBack, CanGoBack);

        public bool IsAuthorized
        {
            get => _isAuthorized;
            set => Set(ref _isAuthorized, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => Set(ref _isLoggedIn, value);
        }

        public Func<HamburgerMenuItem, bool> IsPageRestricted { get; } =
            (menuItem) => Attribute.IsDefined(menuItem.TargetPageType, typeof(Restricted));

        public ICommand LoadedCommand => _loadedCommand ??= new RelayCommand(OnLoaded);

        public ICommand MenuItemInvokedCommand => _menuItemInvokedCommand ??= new RelayCommand(OnMenuItemInvoked);

        public ObservableCollection<HamburgerMenuItem> OptionMenuItems { get; } = new ObservableCollection<HamburgerMenuItem>()
        {
            new HamburgerMenuGlyphItem()
            {
                Label = Resources.ShellSettingsPage,
                Glyph = "\uE713",
                TargetPageType = typeof(SettingsViewModel)
            }
        };

        public ICommand OptionsMenuItemInvokedCommand => _optionsMenuItemInvokedCommand ??= new RelayCommand(OnOptionsMenuItemInvoked);

        public HamburgerMenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => Set(ref _selectedMenuItem, value);
        }

        public HamburgerMenuItem SelectedOptionsMenuItem
        {
            get => _selectedOptionsMenuItem;
            set => Set(ref _selectedOptionsMenuItem, value);
        }

        public ICommand UnloadedCommand => _unloadedCommand ??= new RelayCommand(OnUnloaded);

        public ObservableCollection<HamburgerMenuItem> GetHamburgerMenuItems(IEnumerable<Tuple<string, Type>> menuItens)
        {
            foreach (Tuple<string, Type> menuItem in menuItens)
            {
                _menuItens.Add(new HamburgerMenuGlyphItem()
                {
                    Label = Resources.ShellMainPage,
                    Glyph = menuItem.Item1,
                    TargetPageType = menuItem.Item2
                });
            }

            return _menuItens;
        }

        private bool CanGoBack()
        {
            return _navigationService.CanGoBack;
        }

        private void NavigateTo(Type targetViewModel)
        {
            if (targetViewModel != null)
            {
                _ = _navigationService.NavigateTo(targetViewModel.FullName);
            }
        }

        private void OnGoBack()
        {
            _navigationService.GoBack();
        }

        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
            IsLoggedIn = _identityService.IsLoggedIn();
            IsAuthorized = IsLoggedIn && _identityService.IsAuthorized();
            var userMenuItem = new HamburgerMenuImageItem()
            {
                Command = new RelayCommand(OnUserItemSelected, () => !IsBusy)
            };
            if (IsAuthorized)
            {
                BaseUserViewModel user = _userDataService.GetUser();
                userMenuItem.Thumbnail = user.Photo;
                userMenuItem.Label = user.Name;
            }
            else
            {
                userMenuItem.Thumbnail = ImageHelper.ImageFromAssetsFile("DefaultIcon.png");
                userMenuItem.Label = Resources.Shell_LogIn;
            }

            OptionMenuItems.Insert(0, userMenuItem);
        }

        private void OnLoggedIn(object sender, EventArgs e)
        {
            IsLoggedIn = true;
            IsAuthorized = IsLoggedIn && _identityService.IsAuthorized();
            IsBusy = false;
        }

        private void OnLoggedOut(object sender, EventArgs e)
        {
            IsLoggedIn = false;
            IsAuthorized = false;
            RemoveUserInformation();
            _navigationService.CleanNavigation();
        }

        private void OnMenuItemInvoked()
        {
            NavigateTo(SelectedMenuItem.TargetPageType);
        }

        private void OnNavigated(object sender, string viewModelName)
        {
            HamburgerMenuItem item = _menuItens
                .OfType<HamburgerMenuItem>()
                .FirstOrDefault(i => viewModelName == i.TargetPageType?.FullName);

            if (item != null)
            {
                SelectedMenuItem = item;
            }
            else
            {
                SelectedOptionsMenuItem = OptionMenuItems
                        .OfType<HamburgerMenuItem>()
                        .FirstOrDefault(i => viewModelName == i.TargetPageType?.FullName);
            }

            GoBackCommand.OnCanExecuteChanged();
        }

        private void OnOptionsMenuItemInvoked()
        {
            NavigateTo(SelectedOptionsMenuItem.TargetPageType);
        }

        private void OnUnloaded()
        {
            _navigationService.Navigated -= OnNavigated;
            _userDataService.UserDataUpdated -= OnUserDataUpdated;
        }

        private void OnUserDataUpdated(object sender, BaseUserViewModel user)
        {
            HamburgerMenuImageItem userMenuItem = OptionMenuItems.OfType<HamburgerMenuImageItem>().FirstOrDefault();
            if (userMenuItem != null)
            {
                userMenuItem.Label = user.Name;
                userMenuItem.Thumbnail = user.Photo;
            }
        }

        private async void OnUserItemSelected()
        {
            if (!IsLoggedIn)
            {
                IsBusy = true;
                ELoginResultType loginResult = await _identityService.LoginAsync();
                if (loginResult != ELoginResultType.Success)
                {
                    await AuthenticationHelper.ShowLoginErrorAsync(loginResult);
                    IsBusy = false;
                }
            }

            NavigateTo(typeof(SettingsViewModel));
        }

        private void RemoveUserInformation()
        {
            HamburgerMenuImageItem userMenuItem = OptionMenuItems.OfType<HamburgerMenuImageItem>().FirstOrDefault();
            if (userMenuItem != null)
            {
                userMenuItem.Thumbnail = ImageHelper.ImageFromAssetsFile("DefaultIcon.png");
                userMenuItem.Label = Resources.Shell_LogIn;
            }
        }
    }
}