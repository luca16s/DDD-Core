namespace CoreLibrary.Wpf.Contracts
{
    using CoreLibrary.Wpf.ViewModel;

    using System;

    public interface IUserDataService
    {
        event EventHandler<BaseUserViewModel> UserDataUpdated;

        void Initialize();

        BaseUserViewModel GetUser();
    }
}