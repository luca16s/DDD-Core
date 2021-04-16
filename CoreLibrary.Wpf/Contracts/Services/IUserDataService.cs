namespace CoreLibrary.Wpf.Contracts.Services
{
    using CoreLibrary.Wpf.ViewModel;

    using System;

    public interface IUserDataService
    {
        event EventHandler<BaseUserViewModel> UserDataUpdated;

        BaseUserViewModel GetUser();

        void Initialize();
    }
}