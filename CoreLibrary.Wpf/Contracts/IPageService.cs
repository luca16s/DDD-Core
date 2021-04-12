namespace CoreLibrary.Wpf.Contracts
{
    using System;
    using System.Windows.Controls;

    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}