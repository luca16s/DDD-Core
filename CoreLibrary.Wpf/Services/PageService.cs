namespace CoreLibrary.Wpf.Services
{
    using CoreLibrary.Wpf.Contracts.Services;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;

    public class PageService : IPageService
    {
        private readonly Dictionary<string, Type> _pages = new();
        private readonly IServiceProvider _serviceProvider;

        public PageService(IServiceProvider serviceProvider,
            IEnumerable<Tuple<string, Type>> tuplesPageList)
        {
            _serviceProvider = serviceProvider;

            foreach ((string viewModelFullName, Type pageType) in tuplesPageList)
            {
                Configure(viewModelFullName, pageType);
            }
        }

        public Page GetPage(string key)
        {
            Type pageType = GetPageType(key);
            return _serviceProvider.GetService(pageType) as Page;
        }

        public Type GetPageType(string key)
        {
            Type pageType;
            lock (_pages)
            {
                if (!_pages.TryGetValue(key, out pageType))
                {
                    throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
                }
            }

            return pageType;
        }

        private void Configure(string viewModelFullName, Type pageType)
        {
            lock (_pages)
            {
                if (_pages.ContainsKey(viewModelFullName))
                {
                    throw new ArgumentException($"The key {viewModelFullName} is already configured in PageService");
                }

                if (_pages.Any(p => p.Value == pageType))
                {
                    throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == pageType).Key}");
                }

                _pages.Add(viewModelFullName, pageType);
            }
        }
    }
}