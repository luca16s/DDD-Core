namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Wpf.Contracts;
    using CoreLibrary.Wpf.Extensions;

    using System;
    using System.Windows.Controls;
    using System.Windows.Navigation;

    public class NavigationService : INavigationService
    {
        private readonly IPageService _pageService;
        private Frame _frame;
        private object _lastParameterUsed;

        public NavigationService(IPageService pageService)
        {
            _pageService = pageService;
        }

        public event EventHandler<string> Navigated;

        public bool CanGoBack => _frame.CanGoBack;

        public void CleanNavigation()
        {
            _frame.CleanNavigation();
        }

        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                object vmBeforeNavigation = _frame.GetDataContext();
                _frame.GoBack();
                if (vmBeforeNavigation is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedFrom();
                }
            }
        }

        public void Initialize(Frame shellFrame)
        {
            if (_frame == null)
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
            }
        }

        public bool NavigateTo(string pageKey, object parameter = null, bool clearNavigation = false)
        {
            Type pageType = _pageService.GetPageType(pageKey);

            if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParameterUsed)))
            {
                _frame.Tag = clearNavigation;
                Page page = _pageService.GetPage(pageKey);
                bool navigated = _frame.Navigate(page, parameter);
                if (navigated)
                {
                    _lastParameterUsed = parameter;
                    object dataContext = _frame.GetDataContext();
                    if (dataContext is INavigationAware navigationAware)
                    {
                        navigationAware.OnNavigatedFrom();
                    }
                }

                return navigated;
            }

            return false;
        }

        public void UnsubscribeNavigation()
        {
            _frame.Navigated -= OnNavigated;
            _frame = null;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (sender is Frame frame)
            {
                bool clearNavigation = (bool)frame.Tag;
                if (clearNavigation)
                {
                    frame.CleanNavigation();
                }

                object dataContext = frame.GetDataContext();
                if (dataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(e.ExtraData);
                }

                Navigated?.Invoke(sender, dataContext.GetType().FullName);
            }
        }
    }
}