namespace CoreLibrary.Wpf.Contracts
{
    using System;
    using System.Windows.Controls;

    public interface IPageService
    {
        Page GetPage(string key);

        Type GetPageType(string key);
    }
}